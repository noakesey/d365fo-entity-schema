using Microsoft.Dynamics.AX.Metadata.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waywo.DbSchema.Model;

namespace Waywo.DbSchema.AddIn.Adapters
{
    public class AxTableRelationConstraintFieldAdapter
    {
        protected readonly IMetadataProvider provider;

        public AxTableRelationConstraintFieldAdapter(IMetadataProvider provider)
        {
            this.provider = provider;
        }

        public Relation Adapt(Table fromTable, Table toTable, Microsoft.Dynamics.AX.Metadata.Core.MetaModel.Cardinality cardinality,
            Microsoft.Dynamics.AX.Metadata.MetaModel.AxTableRelationConstraintField constraint)
        {
            var tableRelation = new Relation();

            if (cardinality == Microsoft.Dynamics.AX.Metadata.Core.MetaModel.Cardinality.OneMore ||
                cardinality == Microsoft.Dynamics.AX.Metadata.Core.MetaModel.Cardinality.ZeroMore)
            {
                tableRelation.isMany = true;
            }

            tableRelation.FromTableName = fromTable.Name;

            var fromTableConstrainedField = constraint.Field;
            // Handle e.g. ProjTable.sortingId[1] > ProjSorting.sortingId
            if (fromTableConstrainedField.Contains("["))
            {
                fromTableConstrainedField = fromTableConstrainedField.Split('[')[0];
            }
            var fromField = fromTable.Fields.FirstOrDefault(f => f.Name.ToUpper() == fromTableConstrainedField.ToUpper());
            tableRelation.FromTableField = fromField != null ? fromField.Name : fromTableConstrainedField;
            tableRelation.ToTableName = toTable.Name;

            var toTableConstrainedField = constraint.RelatedField;
            var toField = toTable.Fields.FirstOrDefault(f => f.Name.ToUpper() == toTableConstrainedField.ToUpper());
            tableRelation.ToTableField = toField != null ? toField.Name : toTableConstrainedField;

            return tableRelation;
        }
    }
}
