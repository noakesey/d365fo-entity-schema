using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waywo.DbSchema.Model
{
    public class DataModel
    {
        public DataModel()
        {
            Tables = new List<Table>();
            Relations = new List<Relation>();
        }

        public List<Table> Tables { get; set; }
        public List<Relation> Relations { get; set; }
    }
}
