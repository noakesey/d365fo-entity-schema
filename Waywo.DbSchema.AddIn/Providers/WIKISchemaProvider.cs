﻿using EnvDTE;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Analytics;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.DataEntityViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waywo.DbSchema.Model;
using static System.Windows.Forms.AxHost;

namespace Waywo.DbSchema.Providers
{
    public class WIKISchemaProvider : ISchemaProvider
    {
        protected readonly IDataModelProvider provider;

        public WIKISchemaProvider(IDataModelProvider provider)
        {
            this.provider = provider;
        }

        public bool StandardFields { get; set; }
        public bool ExtensionFields { get; set; }

        public string GetSchema()
        {
            provider.GenerateDataModel();

            StringBuilder wiki = new StringBuilder();
            wiki.AppendLine(">This markdown was generated by [waywo.co.uk](https://waywo.co.uk/2021/12/20/entity-relationship-diagrams/).  Paste it straight into an Azure DevOps WIKI page!");
            wiki.AppendLine();

            wiki.AppendLine("[[_TOC_]]");

            foreach (var table in provider.DataModel.Tables)
            {
                wiki.AppendLine($"#{table.Name}");
                wiki.AppendLine($"{table.Description}");
                wiki.AppendLine();
                wiki.AppendLine("##Properties");
                wiki.AppendLine("|**Property**|**Value**|");
                wiki.AppendLine("|--|--|");
                foreach (var property in table.Properties)
                {
                    wiki.AppendLine($"|{property.Key}|{property.Value}");
                }
                if (table.Fields.Exists(f => f.IsClusteredIndex == true))
                {
                    wiki.Append("|Clustered|");
                    foreach (var clusteredField in table.Fields.Where(f => f.IsClusteredIndex == true))
                    {
                        wiki.Append(string.Format("{0} ", clusteredField.Name));
                    }
                    wiki.AppendLine("|");
                }
                wiki.AppendLine();
                wiki.AppendLine("##Fields");
                wiki.AppendLine();
                wiki.AppendLine("|**Name**|**Type**|**Key**|");
                wiki.AppendLine("|--|--|--|");

                foreach (var field in table.Fields.OrderBy(f => f.KeyType).ThenBy(f => f.Name))
                {
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
                        wiki.AppendLine(string.Format("|{0}|{1}|{2}|",
                            field.Name, field.DataType, field.KeyType == KeyType.Primary || field.KeyType == KeyType.Surrogate ? "Yes" : string.Empty));
                    }
                }
                wiki.AppendLine();

            }

            return wiki.ToString();
        }
    }
}
