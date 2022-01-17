using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waywo.DbSchema.Model
{
    public class Relation
    {
        public string FromTableName { get; set; }
        public string FromTableField { get; set; }

        public string ToTableName { get; set; }
        public string ToTableField { get; set; }

        public bool isMany { get; set; }
    }
}
