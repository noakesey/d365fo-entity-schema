using Microsoft.Dynamics.ApplicationPlatform.Environment;
using Microsoft.Dynamics.AX.Metadata.Providers;
using Microsoft.Dynamics.AX.Metadata.Storage;
using Microsoft.Dynamics.AX.Metadata.Storage.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waywo.DbSchema.Providers
{
    public static class DataModelProviderFactory
    {
        public static IDataModelProvider Create()
        {
            var environment = EnvironmentFactory.GetApplicationEnvironment();
            var packageDir = environment.Aos.PackageDirectory;
            var runtimeProviderConfiguration = new RuntimeProviderConfiguration(packageDir);
            var metadataProviderFactory = new MetadataProviderFactory();

            IMetadataProvider provider = metadataProviderFactory.CreateRuntimeProvider(runtimeProviderConfiguration);

            return new D365FODataModelProvider(provider);
        }
    }
}
