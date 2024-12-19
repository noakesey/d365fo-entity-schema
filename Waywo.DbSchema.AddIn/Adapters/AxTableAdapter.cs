using Microsoft.Dynamics.Ax.Xpp;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.AX.Metadata.Providers;
using System.Collections.Generic;
using Waywo.DbSchema.Model;

namespace Waywo.DbSchema.AddIn.Adapters
{
    public class AxTableAdapter
    {
        protected readonly IMetadataProvider provider;
        protected readonly AxTableFieldAdapter tableFieldAdapter;

        public AxTableAdapter(IMetadataProvider provider)
        {
            this.provider = provider;
            this.tableFieldAdapter = new AxTableFieldAdapter(provider);
        }

        public Table Adapt(AxTable axTable, bool simplifyTypes)
        {
            List<string> primaryKeyFields = GetPrimaryKeyFields(axTable);
            List<string> relationFields = GetFieldsFromRelations(axTable);
            List<string> clusteredIndexFields = GetClusteredIndexFields(axTable);

            Table table = new Table();
            table.Properties = new Dictionary<string, string>();
            table.Name = axTable.Name;
            table.Description = LabelHelper.GetLabel(axTable.DeveloperDocumentation);
            table.Properties.Add("Group", axTable.TableGroup.ToString());
            table.Properties.Add("Cache", axTable.CacheLookup.ToString());

            table.Fields = new List<Field>();
            table.Fields.Add(CreateRecId(axTable, simplifyTypes));
            table.Fields.AddRange(AdaptFields(axTable, primaryKeyFields, relationFields, clusteredIndexFields, simplifyTypes));

            foreach (var tableExtension in this.provider.TableExtensions.GetPrimaryKeys())
            {
                string extendedTable = tableExtension.Split('.')[0];
                if (extendedTable == axTable.Name)
                {
                    AxTableExtension axTableExtension = this.provider.TableExtensions.Read(tableExtension);

                    List<string> extendedRelationFields = GetFieldsFromRelations(axTableExtension);

                    table.Fields.AddRange(AdaptFields(axTableExtension, primaryKeyFields, extendedRelationFields, clusteredIndexFields, simplifyTypes));
                }
            }

            return table;
        }

        private Field CreateRecId(AxTable axTable, bool simplifyTypes)
        {
            return new Field
            {
                Name = "RecId",
                DataType = simplifyTypes ? "Long" : "RecId",
                KeyType = (axTable.PrimaryIndex == "SurrogateKey" ? KeyType.Primary : KeyType.Surrogate),
                IsClusteredIndex = (axTable.ClusteredIndex == "SurrogateKey"),
                IsMandatory = true
            };
        }

        private List<Field> AdaptFields(IAxTableElement axTable, List<string> primaryKeyFields, 
            List<string> relationFields, List<string> clusteredIndexFields, bool simplifyTypes)
        {
            List<Field> fields = new List<Field>();

            foreach (var field in axTable.Fields)
            {
                Field newField = new Field();

                newField.Name = field.Name;
                newField.DataType = this.tableFieldAdapter.Adapt(field, simplifyTypes);

                if (primaryKeyFields.Contains(field.Name))
                {
                    newField.KeyType = KeyType.Primary;
                    newField.IsMandatory = true;
                }
                else if (relationFields.Contains(field.Name))
                {
                    newField.KeyType = KeyType.Referential;
                }
                else
                {
                    newField.KeyType = KeyType.None;
                }

                if (clusteredIndexFields.Contains(field.Name))
                {
                    newField.IsClusteredIndex = true;
                    newField.IsMandatory = true;
                }

                if (field.Mandatory.Equals(Microsoft.Dynamics.AX.Metadata.Core.MetaModel.NoYes.Yes))
                {
                    newField.IsMandatory = true;
                }

                newField.IsExtension = axTable.Name.Contains(".");

                fields.Add(newField);
            }

            return fields;
        }

        private List<string> GetClusteredIndexFields(AxTable axTable)
        {
            List<string> clusteredIndexfield = new List<string>();

            foreach (var index in axTable.Indexes)
            {
                if (index.Name == axTable.ClusteredIndex)
                {
                    foreach (var field in index.Fields)
                    {
                        clusteredIndexfield.Add(field.Name);
                    }
                }
            }

            return clusteredIndexfield;
        }

        private List<string> GetPrimaryKeyFields(AxTable axTable)
        {
            List<string> fields = new List<string>();

            foreach (var index in axTable.Indexes)
            {
                if (index.Name == axTable.PrimaryIndex)
                {
                    foreach (var field in index.Fields)
                    {
                        fields.Add(field.Name);
                    }
                }
            }

            return fields;
        }

        private static List<string> GetFieldsFromRelations(IAxTableElement axTable)
        {
            List<string> relatedFields = new List<string>();
            foreach (var relation in axTable.Relations)
            {
                foreach (var constraint in relation.Constraints)
                {
                    if (constraint is AxTableRelationConstraintField)
                    {
                        relatedFields.Add(((AxTableRelationConstraintField)constraint).Field);
                    }
                }
            }

            return relatedFields;
        }
    }
}
