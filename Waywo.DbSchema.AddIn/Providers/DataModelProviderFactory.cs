using Microsoft.Dynamics.ApplicationPlatform.Environment;
using Microsoft.Dynamics.AX.Metadata.Providers;
using Microsoft.Dynamics.AX.Metadata.Storage;
using Microsoft.Dynamics.AX.Metadata.Storage.Runtime;
using Microsoft.Dynamics.Framework.Tools.Core;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace Waywo.DbSchema.Providers
{
    public static class DataModelProviderFactory
    {
        public static IDataModelProvider Create()
        {
            IDesignMetaModelService metaModelService = AxServiceProvider.GetService<IDesignMetaModelService>();
            IMetadataProvider provider = metaModelService.CachedProvider.MetadataProvider;

            return new D365FODataModelProvider(provider);
        }
    }
}
