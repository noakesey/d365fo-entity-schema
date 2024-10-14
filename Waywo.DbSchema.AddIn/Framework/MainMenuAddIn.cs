using EnvDTE;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using Waywo.DbSchema.AddIn.Controllers;
using Waywo.DbSchema.Providers;

namespace Waywo.DbSchema.AddIn
{
    [Export(typeof(IMainMenu))]
    public class MainMenuAddIn : MainMenuBase
    {
        private const string addinName = "Waywo.DbDiagram.AddIn";

        /// <summary>
        /// Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption
        {
            get
            {
                return AddinResources.MainMenuAddInCaption;
            }
        }

        /// <summary>
        /// Unique name of the add-in
        /// </summary>
        public override string Name
        {
            get
            {
                return MainMenuAddIn.addinName;
            }
        }

        /// <summary>
        /// Called when user clicks on the add-in menu
        /// </summary>
        /// <param name="e">The context of the VS tools and metadata</param>
        public override void OnClick(AddinEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var dataModelProvider = DataModelProviderFactory.Create();
                var dbmlSchemaProvider = new DBMLSchemaProvider(dataModelProvider);
                var wikiSchemaProvider = new WIKISchemaProvider(dataModelProvider);

                DTE dte = CoreUtility.ServiceProvider.GetService(typeof(DTE)) as DTE;

                IErdController controller = new ErdController(dataModelProvider, dbmlSchemaProvider, wikiSchemaProvider, dte);
                controller.UseActiveDocument();

                ErdForm form = new ErdForm(controller);

                Cursor.Current = Cursors.Default;

                form.ShowDialog();
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
    }
}