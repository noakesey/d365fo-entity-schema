//using Microsoft.Dynamics.Ax.Xpp;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.AX.Metadata.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waywo.DbSchema.AddIn.Adapters;
using Waywo.DbSchema.Model;

namespace Waywo.DbSchema.Providers
{
    public class D365FODataModelProvider : IDataModelProvider
    {
        protected IMetadataProvider provider;

        public DataModel DataModel { get; set; }
        public List<String> Tables { get; set; }

        public bool SimplifyTypes { get; set; }
        public bool IgnoreStaging { get; set; }
        public bool IgnoreSelfReferences { get; set; }
        public string Model { get; set; }

        public D365FODataModelProvider(IMetadataProvider provider)
        {
            this.provider = provider;

            this.DataModel = new DataModel();

            this.Tables = new List<string>();
        }

        public IDataModelProvider GenerateDataModel()
        {
            DataModel = new DataModel();

            var tableAdapter = new AxTableAdapter(provider);

            foreach (var tableName in Tables)
            {
                if (!tableName.Contains("Staging") || !this.IgnoreStaging)
                {
                    AxTable axTable = this.provider.Tables.Read(tableName);
                    if (axTable != null && 
                       (axTable.TableType == TableType.Regular || !this.IgnoreStaging))
                    {
                        var table = tableAdapter.Adapt(axTable, this.SimplifyTypes);
                        this.DataModel.Tables.Add(table);
                    }
                }
            }

            this.DataModel.Relations = this.GetRelationsBetweenTables();

            return this;
        }

        public IDataModelProvider AddTable(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                AxTable metaData = this.provider.Tables.Read(tableName);

                if (metaData != null)
                {
                    this.Tables.Add(metaData.Name);
                    this.Tables.Sort();
                }
            }

            return this;
        }

        public IDataModelProvider AddInwardTables(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                List<string> newTables = new List<string>();
                newTables.AddRange(this.Tables);

                //[1] Handle tables
                foreach (string key in this.provider.Tables.GetPrimaryKeys())
                {
                    AxTable axTable = this.provider.Tables.Read(key);

                    foreach (var relation in axTable.Relations)
                    {
                        if (relation.RelatedTable == tableName)
                        {
                            if (!newTables.Contains(axTable.Name))
                            {
                                //Could be a view
                                AxTable metaData = this.provider.Tables.Read(axTable.Name);
                                if (metaData != null)
                                {
                                    newTables.Add(axTable.Name);
                                }
                            }
                        }
                    }
                }

                //[2] Handle table extensions
                foreach (string key in this.provider.TableExtensions.GetPrimaryKeys())
                {
                    AxTableExtension axTableExtension = this.provider.TableExtensions.Read(key);
                    string extendedTable = axTableExtension.Name.Split('.')[0];

                    foreach (var relation in axTableExtension.Relations)
                    {
                        if (relation.RelatedTable == tableName)
                        {
                            if (!newTables.Contains(extendedTable))
                            {
                                //Could be a view
                                AxTable axTable = this.provider.Tables.Read(relation.RelatedTable);
                                if (axTable != null)
                                {
                                    newTables.Add(extendedTable);
                                }
                            }
                        }
                    }
                }

                this.Tables = newTables;
                this.Tables.Sort();
            }
            return this;
        }

        public IDataModelProvider AddOutwardTables(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                List<string> newTables = new List<string>();
                newTables.AddRange(this.Tables);

                //[1] Handle tables
                AxTable axTable = this.provider.Tables.Read(tableName);
                foreach (var relation in axTable.Relations)
                {
                    if (!newTables.Contains(relation.RelatedTable))
                    {
                        //Could be a view
                        AxTable metaData = this.provider.Tables.Read(relation.RelatedTable);
                        if (metaData != null)
                        {
                            newTables.Add(relation.RelatedTable);
                        }
                    }
                }

                //[2] Handle table extensions
                foreach (var tableExtension in this.provider.TableExtensions.GetPrimaryKeys())
                {
                    string extendedTable = tableExtension.Split('.')[0];
                    if (extendedTable == tableName)
                    {
                        AxTableExtension axTableExtension = this.provider.TableExtensions.Read(tableExtension);
                        foreach (var relation in axTableExtension.Relations)
                        {
                            if (!newTables.Contains(relation.RelatedTable))
                            {
                                //Could be a view
                                AxTable metaData = this.provider.Tables.Read(relation.RelatedTable);
                                if (metaData != null)
                                {
                                    newTables.Add(relation.RelatedTable);
                                }
                            }
                        }
                    }
                }

                this.Tables = newTables;
                this.Tables.Sort();
            }

            return this;
        }

        public IDataModelProvider AddRelatedTables()
        {
            if (this.Tables.Count > 0)
            {
                List<string> newTables = new List<string>();
                newTables.AddRange(this.Tables);

                //[1] Handle tables
                foreach (string tableName in this.provider.Tables.GetPrimaryKeys())
                {
                    AxTable axTable = this.provider.Tables.Read(tableName);

                    foreach (var relation in axTable.Relations)
                    {
                        if (this.Tables.Contains(relation.RelatedTable) || this.Tables.Contains(tableName))
                        {
                            AxTable relatedMetaData = this.provider.Tables.Read(relation.RelatedTable);

                            //Could be a view
                            if (relatedMetaData != null)
                            {
                                if (!newTables.Contains(tableName))
                                {
                                    newTables.Add(tableName);
                                }

                                if (!newTables.Contains(relation.RelatedTable))
                                {
                                    newTables.Add(relation.RelatedTable);
                                }
                            }
                        }
                    }
                }

                //[2] Handle table extensions
                foreach (var tableExtension in this.provider.TableExtensions.GetPrimaryKeys())
                {
                    AxTableExtension axTableExtension = this.provider.TableExtensions.Read(tableExtension);

                    string extendedTable = tableExtension.Split('.')[0];

                    foreach (var relation in axTableExtension.Relations)
                    {
                        if (this.Tables.Contains(relation.RelatedTable) || this.Tables.Contains(extendedTable))
                        {
                            AxTable relatedMetaData = this.provider.Tables.Read(relation.RelatedTable);

                            //Could be a view
                            if (relatedMetaData != null)
                            {
                                if (!newTables.Contains(extendedTable))
                                {
                                    newTables.Add(extendedTable);
                                }

                                if (!newTables.Contains(relation.RelatedTable))
                                {
                                    newTables.Add(relation.RelatedTable);
                                }
                            }
                        }
                    }
                }

                this.Tables = newTables;
                this.Tables.Sort();
            }

            return this;
        }

        public IDataModelProvider AddTablesFromModel(string modelName)
        {
            List<string> newTables = new List<string>();
            newTables.AddRange(this.Tables);

            if (!string.IsNullOrEmpty(modelName))
            {
                foreach (var tableName in this.provider.Tables.ListObjectsForModel(modelName))
                {
                    AxTable metaData = this.provider.Tables.Read(tableName);

                    if (metaData != null && !newTables.Contains(metaData.Name))
                    {
                        newTables.Add(metaData.Name);
                    }
                }

                foreach (var tableName in this.provider.TableExtensions.ListObjectsForModel(modelName))
                {
                    if (tableName.Contains('.'))
                    { 
                        string standardTableName = tableName.Split('.')[0];

                        AxTable metaData = this.provider.Tables.Read(standardTableName);

                        if (metaData != null && !newTables.Contains(metaData.Name))
                        {
                            newTables.Add(metaData.Name);
                        }
                    }
                }


                this.Tables = newTables;
                this.Tables.Sort();
            }

            return this;
        }


        protected List<Relation> GetRelationsBetweenTables()
        {
            var constraintAdapter = new AxTableRelationConstraintFieldAdapter(provider);

            List<Relation> relations = new List<Relation>();

            //[1] Handle tables
            foreach (var sourceTable in this.DataModel.Tables)
            {
                AxTable axTable = this.provider.Tables.Read(sourceTable.Name);

                foreach (var relation in axTable.Relations)
                {
                    foreach (var constraint in relation.Constraints)
                    {
                        if (constraint is AxTableRelationConstraintField)
                        {
                            var fromTable = this.DataModel.Tables.FirstOrDefault(t => t.Name.ToUpper() == axTable.Name.ToUpper());
                            var toTable = this.DataModel.Tables.FirstOrDefault(t => t.Name.ToUpper() == relation.RelatedTable.ToUpper());
                            if (toTable != null)
                            {
                                var newRelation = constraintAdapter.Adapt(fromTable, toTable, relation.Cardinality, (AxTableRelationConstraintField)constraint);

                                if (ShouldAddRelation(fromTable, toTable, relations, newRelation))
                                {
                                    relations.Add(newRelation);
                                }
                            }
                        }
                    }
                }
            }

            //[2] Handle table extensions
            foreach (string key in this.provider.TableExtensions.GetPrimaryKeys())
            {
                AxTableExtension axTableExtension = this.provider.TableExtensions.Read(key);
                string extendedTable = axTableExtension.Name.Split('.')[0];

                var fromTable = this.DataModel.Tables.FirstOrDefault(t => t.Name.ToUpper() == extendedTable.ToUpper());

                if (fromTable != null)
                {
                    foreach (var relation in axTableExtension.Relations)
                    {
                        foreach (var constraint in relation.Constraints)
                        {
                            if (constraint is AxTableRelationConstraintField)
                            {
                                var toTable = this.DataModel.Tables.FirstOrDefault(t => t.Name.ToUpper() == relation.RelatedTable.ToUpper());

                                if (toTable != null)
                                {
                                    var newRelation = constraintAdapter.Adapt(fromTable, toTable, relation.Cardinality, (AxTableRelationConstraintField)constraint);

                                    if (ShouldAddRelation(fromTable, toTable, relations, newRelation))
                                    {
                                        relations.Add(newRelation);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return relations;
        }

        private bool ShouldAddRelation(Table fromTable, Table toTable, List<Relation> relations, Relation tableRelation)
        {
            bool shouldAdd = false;

            var existingForwardRelation = relations.FirstOrDefault(r =>
                r.FromTableName == tableRelation.FromTableName &&
                r.FromTableField == tableRelation.FromTableField &&
                r.ToTableName == tableRelation.ToTableName &&
                r.ToTableField == tableRelation.ToTableField
            );

            var existingReverseRelation = relations.FirstOrDefault(r =>
                r.FromTableName == tableRelation.ToTableName &&
                r.FromTableField == tableRelation.ToTableField &&
                r.ToTableName == tableRelation.FromTableName &&
                r.ToTableField == tableRelation.FromTableField
            );

            var existingTargetField = fromTable.Fields.FirstOrDefault(f => f.Name == tableRelation.FromTableField);

            var existingSourceField = toTable.Fields.FirstOrDefault(f => f.Name == tableRelation.ToTableField);

            if (existingForwardRelation == null && existingReverseRelation == null &&
                existingTargetField != null && existingSourceField != null &&
                (tableRelation.FromTableName != tableRelation.ToTableName ||
                    tableRelation.FromTableField != tableRelation.ToTableField)
                )
            {
                if (tableRelation.FromTableName != tableRelation.ToTableName || !this.IgnoreSelfReferences)
                {
                    shouldAdd = true;
                }
            }

            return shouldAdd;
        }

        public List<string> GetModels()
        {
            var manifest = this.provider.ModelManifest;

            var models = manifest.ListModels();

            return models.OrderBy(x => x).ToList();

        }
    }
}
