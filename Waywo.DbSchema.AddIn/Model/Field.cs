using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waywo.DbSchema.Model
{
    public class Field
    {
        public string Name { get; set; }
        public string DataType { get; set; }

        public KeyType KeyType { get; set; }
        public bool IsClusteredIndex { get; set; }
    }
}
