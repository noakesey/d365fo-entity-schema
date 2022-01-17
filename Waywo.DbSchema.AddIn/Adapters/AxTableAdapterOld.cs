using Microsoft.Dynamics.Ax.Xpp;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.AX.Metadata.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string clusteredIndexField = GetClusteredIndexField(axTable);

            Table table = new Table();
            table.Name = axTable.Name;
            table.Description = LabelHelper.GetLabel(axTable.DeveloperDocumentation);

            CreateFields(table, axTable, simplifyTypes);
            PopulateFields(table, axTable, primaryKeyFields, relationFields, clusteredIndexField, simplifyTypes);

            foreach (var tableExtension in this.provider.TableExtensions.GetPrimaryKeys())
            {
                string extendedTable = tableExtension.Split('.')[0];
                if (extendedTable == axTable.Name)
                {
                    AxTableExtension axTableExtension = this.provider.TableExtensions.Read(tableExtension);

                    List<string> extendedRelationFields = GetFieldsFromRelations(axTableExtension);

                    PopulateFields(table, axTableExtension, primaryKeyFields, extendedRelationFields, clusteredIndexField, simplifyTypes);
                }
            }

            return table;
        }

        private static void CreateFields(Table table, AxTable axTable, bool simplifyTypes)
        {
            table.Fields = new List<Field>();
            table.Fields.Add(new Field
            {
                Name = "RecId",
                DataType = simplifyTypes ? "Long" : "RecId",
                KeyType = (axTable.PrimaryIndex == "SurrogateKey" ? KeyType.Primary : KeyType.Surrogate),
                IndexType = (axTable.ClusteredIndex == "SurrogateKey" ? IndexType.Clustered : IndexType.NonClustered)
            });
        }

        private void PopulateFields(Table table, IAxTableElement axTable, List<string> primaryKeyFields, 
            List<string> relationFields, string clusteredIndexField, bool simplifyTypes)
        {
            foreach (var field in axTable.Fields)
            {
                Field newField = new Field();

                newField.Name = field.Name;

                if (simplifyTypes)
                {
                    newField.DataType = this.tableFieldAdapter.Adapt(field);
                }
                else
                {
                    newField.DataType = field.ExtendedDataType;
                }

                if (primaryKeyFields.Contains(field.Name))
                {
                    newField.KeyType = KeyType.Primary;
                }
                else if (relationFields.Contains(field.Name))
                {
                    newField.KeyType = KeyType.Referential;
                }
                else
                {
                    newField.KeyType = KeyType.None;
                }

                newField.IndexType = IndexType.None;

                table.Fields.Add(newField);
            }
        }

        private string GetClusteredIndexField(AxTable axTable)
        {
            string clusteredIndexfield = string.Empty; 

            foreach (var index in axTable.Indexes)
            {
                if (index.Name == axTable.ClusteredIndex)
                {
                    foreach (var field in index.Fields)
                    {
                        clusteredIndexfield = field.Name;
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
