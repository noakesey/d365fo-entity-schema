using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waywo.DbSchema.Providers
{
    public interface ISchemaProvider
    {
        bool JustKeys { get; set; }

        string GetSchema();
    }
}
