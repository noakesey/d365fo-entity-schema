using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waywo.DbSchema.Providers;

namespace Waywo.DbSchema.AddIn.Controllers
{
    public interface IErdController
    {
        IDataModelProvider DataModelProvider { get; set; }
        ISchemaProvider DBMLSchemaProvider { get; set; }
        ISchemaProvider WIKISchemaProvider { get; set; }

        void GetDBML();
        void GetWIKI();

        void UseActiveDocument();

    }
}
