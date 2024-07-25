using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waywo.DbSchema.Model;

namespace Waywo.DbSchema.Providers
{
    public class DBMLSchemaProvider : ISchemaProvider
    {
        protected readonly IDataModelProvider provider;

        public DBMLSchemaProvider(IDataModelProvider provider)
        {
            this.provider = provider;
        }

        public bool StandardFields { get; set; }
        public bool ExtensionFields { get; set; }

        public string GetSchema()
        {
            provider.GenerateDataModel();

            StringBuilder dbml = new StringBuilder();
            dbml.AppendLine("// Use a tool like https://dbdiagram.io/ to render this DBML");
            dbml.AppendLine("// https://waywo.co.uk/2021/12/20/entity-relationship-diagrams/");

            dbml.AppendLine();

            foreach (var table in provider.DataModel.Tables)
            {
                bool tableShouldBeShown = false;

                foreach (var field in table.Fields.OrderBy(f => f.KeyType).ThenBy(f => f.Name))
                {
                    if (!tableShouldBeShown)
                    {
                        dbml.Append(string.Format("Table {0} ", table.Name));
                        dbml.AppendLine("{");

                        tableShouldBeShown = true;
                    }

                    //Always include key fields
                    if ((field.KeyType == KeyType.Primary 
                        || field.KeyType == KeyType.Surrogate
                        || provider.DataModel.Relations.Exists(r => (r.FromTableName == table.Name || r.ToTableName == table.Name) &&
                                                                    (r.FromTableField == field.Name || r.ToTableField == field.Name)))
                        ||
                        (field.IsExtension && this.ExtensionFields) 
                        || 
                        (!field.IsExtension && this.StandardFields)
                    )
                    {
                        dbml.AppendLine(string.Format("  {0} {1} {2}",
                            field.Name, field.DataType, field.KeyType == KeyType.Primary || field.KeyType == KeyType.Surrogate ? "[pk]" : string.Empty));
                    }
                }

                if (tableShouldBeShown)
                {
                    dbml.AppendLine();
                    dbml.AppendLine("  Note: '''");
                    dbml.AppendLine();
                    dbml.AppendLine(string.Format("  {0}", table.Description));
                    dbml.AppendLine();

                    if (table.Fields.Exists(f => f.IsClusteredIndex == true))
                    {
                        dbml.Append("  Clustered    :");
                        foreach (var clusteredField in table.Fields.Where(f => f.IsClusteredIndex == true))
                        {
                            dbml.Append(string.Format(" {0}", clusteredField.Name));
                        }
                        dbml.AppendLine();
                    }

                    foreach (var property in table.Properties)
                    {
                        dbml.AppendLine(string.Format("  {0} : {1}", property.Key.PadRight(12), property.Value));
                    }
                    dbml.AppendLine("  '''");
                    dbml.AppendLine("}");
                    dbml.AppendLine();

                    foreach (var relation in provider.DataModel.Relations.Where(r => r.FromTableName == table.Name))
                    {
                        string line = string.Format("Ref: {0}.{1} {2} {3}.{4}",
                                            relation.FromTableName, relation.FromTableField,
                                            relation.isMany ? ">" : "-",
                                            relation.ToTableName, relation.ToTableField);

                        dbml.AppendLine(line);
                    }

                    dbml.AppendLine();
                }
            }

            return dbml.ToString();
        }
    }
}
