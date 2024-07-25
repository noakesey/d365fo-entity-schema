using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Waywo.DbSchema.AddIn.Controllers;

namespace Waywo.DbSchema.AddIn
{
    public partial class ErdForm : Form
    {
        protected readonly IErdController controller;

        public ErdForm(IErdController controller)
        {
            InitializeComponent();

            this.controller = controller;

            tablesListBox.DataSource = this.controller.DataModelProvider.Tables;
        }

        private void getDBMLButton_Click(object sender, EventArgs e)
        {
            controller.DBMLSchemaProvider.StandardFields = standardFieldsCheckBox.Checked;
            controller.DBMLSchemaProvider.ExtensionFields = extensionFieldsCheckBox.Checked;

            controller.DataModelProvider.SimplifyTypes = convertEDTCheckBox.Checked;
            controller.DataModelProvider.IgnoreStaging = ignoreStagingCheckBox.Checked;
            controller.DataModelProvider.IgnoreSelfReferences = ignoreSelfReferencesCheckBox.Checked;

            this.Close();

            controller.GetDBML();
        }

        private void addAllRelatedButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            controller.DataModelProvider.AddRelatedTables();

            tablesListBox.DataSource = null;
            tablesListBox.DataSource = this.controller.DataModelProvider.Tables;

            Cursor.Current = Cursors.Default;
        }

        private void addOutwardRelatedButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            controller.DataModelProvider.AddOutwardTables((string)tablesListBox.SelectedItem);

            tablesListBox.DataSource = null;
            tablesListBox.DataSource = this.controller.DataModelProvider.Tables;

            Cursor.Current = Cursors.Default;
        }

        private void addInwardRelatedButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            controller.DataModelProvider.AddInwardTables((string)tablesListBox.SelectedItem);

            tablesListBox.DataSource = null;
            tablesListBox.DataSource = this.controller.DataModelProvider.Tables;

            Cursor.Current = Cursors.Default;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var existing = this.controller.DataModelProvider.Tables.FirstOrDefault(t => t.ToUpper() == tableTextBox.Text.ToUpper());
            if (existing == null)
            {
                this.controller.DataModelProvider.AddTable(tableTextBox.Text);

                tablesListBox.DataSource = null;
                tablesListBox.DataSource = this.controller.DataModelProvider.Tables;

                if (this.controller.DataModelProvider.Tables.Count > 0)
                {
                    tablesListBox.SelectedIndex = 0;
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (var item in tablesListBox.SelectedItems)
            {
                var existing = this.controller.DataModelProvider.Tables.FirstOrDefault(t => t.ToUpper() == ((string)item).ToUpper());
                if (existing != null)
                {
                    this.controller.DataModelProvider.Tables.Remove(existing);
                }
            }

            tablesListBox.DataSource = null;
            tablesListBox.DataSource = this.controller.DataModelProvider.Tables;
        }

        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableTextBox.Text = (string)tablesListBox.SelectedItem;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.controller.DataModelProvider.Tables.Clear();
            tablesListBox.DataSource = null;
            tablesListBox.DataSource = this.controller.DataModelProvider.Tables;
        }
    }
}
