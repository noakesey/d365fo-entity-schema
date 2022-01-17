using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.AX.Metadata.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waywo.DbSchema.AddIn.Adapters
{
    public class AxTableFieldAdapter
    {
        protected readonly IMetadataProvider provider;

        public AxTableFieldAdapter(IMetadataProvider provider)
        {
            this.provider = provider;
        }

        public string Adapt(AxTableField field, bool simplifyTypes)
        {
            string retval = string.Empty;

            if (field is AxTableFieldEnum)
            {
                retval = ((AxTableFieldEnum)field).EnumType;
            }
            else if (field.ExtendedDataType != null)
            {
                retval = field.ExtendedDataType;
            }

            if (retval == string.Empty || simplifyTypes)
            {
                if (field is AxTableFieldEnum)
                {
                    retval = "Enum";
                }
                else if (field is AxTableFieldInt)
                {
                    retval = "Integer";
                }
                else if (field is AxTableFieldInt64)
                {
                    retval = "Long";
                }
                else if (field is AxTableFieldString)
                {
                    retval = "String";
                }
                else if (field is AxTableFieldContainer)
                {
                    retval = "String";
                }
                else if (field is AxTableFieldDate)
                {
                    retval = "Date";
                }
                else if (field is AxTableFieldTime)
                {
                    retval = "Date";
                }
                else if (field is AxTableFieldUtcDateTime)
                {
                    retval = "Date";
                }
                else if (field is AxTableFieldGuid)
                {
                    retval = "Guid";
                }
                else if (field is AxTableFieldReal)
                {
                    retval = "Real";
                }
                else if (field is AxTableFieldEnum)
                {
                    retval = "Enum";
                }
            }

            return retval; 
        }
    }
}
