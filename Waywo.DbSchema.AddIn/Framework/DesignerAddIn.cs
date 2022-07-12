﻿using EnvDTE;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using Waywo.DbSchema.AddIn.Controllers;
using Waywo.DbSchema.Providers;

namespace Waywo.DbSchema.AddIn
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IRelation))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITable))]
    public class DesignerAddIn : DesignerMenuBase
    {
        private const string addinName = "Designer.Waywo.DbDiagram.AddIn";

        /// <summary>
        /// Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption
        {
            get
            {
                return AddinResources.DesignerAddinCaption;
            }
        }

        /// <summary>
        /// Unique name of the add-in
        /// </summary>
        public override string Name
        {
            get
            {
                return DesignerAddIn.addinName;
            }
        }
        /// <summary>
        /// Called when user clicks on the add-in menu
        /// </summary>
        /// <param name="e">The context of the VS tools and metadata</param>
        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ITable table = (ITable)e.SelectedElement;

                var dataModelProvider = DataModelProviderFactory.Create();
                var schemaProvider = new DBMLSchemaProvider(dataModelProvider);
                DTE dte = CoreUtility.ServiceProvider.GetService(typeof(DTE)) as DTE;

                IErdController controller = new ErdController(dataModelProvider, schemaProvider, dte);
                controller.DataModelProvider.AddTable(table.Name);

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