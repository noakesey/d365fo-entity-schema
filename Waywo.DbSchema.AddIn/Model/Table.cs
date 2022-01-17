using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waywo.DbSchema.Model
{
    public class Table
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Field> Fields { get; set; }

        public Dictionary<string, string> Properties { get; set; }
    }
}
