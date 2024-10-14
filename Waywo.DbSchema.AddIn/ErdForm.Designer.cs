namespace Waywo.DbSchema.AddIn
{
    partial class ErdForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErdForm));
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.extensionFieldsCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreSelfReferencesCheckBox = new System.Windows.Forms.CheckBox();
            this.convertEDTCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreStagingCheckBox = new System.Windows.Forms.CheckBox();
            this.standardFieldsCheckBox = new System.Windows.Forms.CheckBox();
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.getDBMLButton = new System.Windows.Forms.Button();
            this.tableTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addAllRelatedButton = new System.Windows.Forms.Button();
            this.addOutwardRelatedButton = new System.Windows.Forms.Button();
            this.addInwardRelatedButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.addAllFromModelButton = new System.Windows.Forms.Button();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.getWIKIButton = new System.Windows.Forms.Button();
            this.optionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsGroupBox.Controls.Add(this.extensionFieldsCheckBox);
            this.optionsGroupBox.Controls.Add(this.ignoreSelfReferencesCheckBox);
            this.optionsGroupBox.Controls.Add(this.convertEDTCheckBox);
            this.optionsGroupBox.Controls.Add(this.ignoreStagingCheckBox);
            this.optionsGroupBox.Controls.Add(this.standardFieldsCheckBox);
            this.optionsGroupBox.Location = new System.Drawing.Point(296, 290);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(174, 136);
            this.optionsGroupBox.TabIndex = 0;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options";
            // 
            // extensionFieldsCheckBox
            // 
            this.extensionFieldsCheckBox.AutoSize = true;
            this.extensionFieldsCheckBox.Location = new System.Drawing.Point(6, 41);
            this.extensionFieldsCheckBox.Name = "extensionFieldsCheckBox";
            this.extensionFieldsCheckBox.Size = new System.Drawing.Size(136, 17);
            this.extensionFieldsCheckBox.TabIndex = 1;
            this.extensionFieldsCheckBox.Text = "Include extension fields";
            this.extensionFieldsCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreSelfReferencesCheckBox
            // 
            this.ignoreSelfReferencesCheckBox.AutoSize = true;
            this.ignoreSelfReferencesCheckBox.Checked = true;
            this.ignoreSelfReferencesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreSelfReferencesCheckBox.Location = new System.Drawing.Point(6, 63);
            this.ignoreSelfReferencesCheckBox.Name = "ignoreSelfReferencesCheckBox";
            this.ignoreSelfReferencesCheckBox.Size = new System.Drawing.Size(128, 17);
            this.ignoreSelfReferencesCheckBox.TabIndex = 0;
            this.ignoreSelfReferencesCheckBox.Text = "Ignore self references";
            this.ignoreSelfReferencesCheckBox.UseVisualStyleBackColor = true;
            // 
            // convertEDTCheckBox
            // 
            this.convertEDTCheckBox.AutoSize = true;
            this.convertEDTCheckBox.Checked = true;
            this.convertEDTCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.convertEDTCheckBox.Location = new System.Drawing.Point(6, 107);
            this.convertEDTCheckBox.Name = "convertEDTCheckBox";
            this.convertEDTCheckBox.Size = new System.Drawing.Size(93, 17);
            this.convertEDTCheckBox.TabIndex = 0;
            this.convertEDTCheckBox.Text = "Convert EDTs";
            this.convertEDTCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreStagingCheckBox
            // 
            this.ignoreStagingCheckBox.AutoSize = true;
            this.ignoreStagingCheckBox.Checked = true;
            this.ignoreStagingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreStagingCheckBox.Location = new System.Drawing.Point(6, 85);
            this.ignoreStagingCheckBox.Name = "ignoreStagingCheckBox";
            this.ignoreStagingCheckBox.Size = new System.Drawing.Size(165, 17);
            this.ignoreStagingCheckBox.TabIndex = 0;
            this.ignoreStagingCheckBox.Text = "Ignore staging and tmp tables";
            this.ignoreStagingCheckBox.UseVisualStyleBackColor = true;
            // 
            // standardFieldsCheckBox
            // 
            this.standardFieldsCheckBox.AutoSize = true;
            this.standardFieldsCheckBox.Location = new System.Drawing.Point(6, 19);
            this.standardFieldsCheckBox.Name = "standardFieldsCheckBox";
            this.standardFieldsCheckBox.Size = new System.Drawing.Size(129, 17);
            this.standardFieldsCheckBox.TabIndex = 0;
            this.standardFieldsCheckBox.Text = "Include non-key fields";
            this.standardFieldsCheckBox.UseVisualStyleBackColor = true;
            // 
            // tablesListBox
            // 
            this.tablesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablesListBox.FormattingEnabled = true;
            this.tablesListBox.Location = new System.Drawing.Point(10, 12);
            this.tablesListBox.Name = "tablesListBox";
            this.tablesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.tablesListBox.Size = new System.Drawing.Size(270, 407);
            this.tablesListBox.TabIndex = 1;
            this.tablesListBox.SelectedIndexChanged += new System.EventHandler(this.tablesListBox_SelectedIndexChanged);
            // 
            // getDBMLButton
            // 
            this.getDBMLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.getDBMLButton.Location = new System.Drawing.Point(390, 432);
            this.getDBMLButton.Name = "getDBMLButton";
            this.getDBMLButton.Size = new System.Drawing.Size(81, 23);
            this.getDBMLButton.TabIndex = 2;
            this.getDBMLButton.Text = "DBML";
            this.getDBMLButton.UseVisualStyleBackColor = true;
            this.getDBMLButton.Click += new System.EventHandler(this.getDBMLButton_Click);
            // 
            // tableTextBox
            // 
            this.tableTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableTextBox.Location = new System.Drawing.Point(296, 12);
            this.tableTextBox.Name = "tableTextBox";
            this.tableTextBox.Size = new System.Drawing.Size(175, 20);
            this.tableTextBox.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(296, 38);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(81, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "<< Add";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(390, 38);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(81, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove >>";
            this.removeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addAllRelatedButton
            // 
            this.addAllRelatedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAllRelatedButton.Location = new System.Drawing.Point(156, 432);
            this.addAllRelatedButton.Name = "addAllRelatedButton";
            this.addAllRelatedButton.Size = new System.Drawing.Size(124, 23);
            this.addAllRelatedButton.TabIndex = 2;
            this.addAllRelatedButton.Text = "Add all relations";
            this.addAllRelatedButton.UseVisualStyleBackColor = true;
            this.addAllRelatedButton.Click += new System.EventHandler(this.addAllRelatedButton_Click);
            // 
            // addOutwardRelatedButton
            // 
            this.addOutwardRelatedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addOutwardRelatedButton.Location = new System.Drawing.Point(296, 67);
            this.addOutwardRelatedButton.Name = "addOutwardRelatedButton";
            this.addOutwardRelatedButton.Size = new System.Drawing.Size(175, 23);
            this.addOutwardRelatedButton.TabIndex = 2;
            this.addOutwardRelatedButton.Text = "<<< Add outward relations";
            this.addOutwardRelatedButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addOutwardRelatedButton.UseVisualStyleBackColor = true;
            this.addOutwardRelatedButton.Click += new System.EventHandler(this.addOutwardRelatedButton_Click);
            // 
            // addInwardRelatedButton
            // 
            this.addInwardRelatedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addInwardRelatedButton.Location = new System.Drawing.Point(296, 96);
            this.addInwardRelatedButton.Name = "addInwardRelatedButton";
            this.addInwardRelatedButton.Size = new System.Drawing.Size(175, 23);
            this.addInwardRelatedButton.TabIndex = 2;
            this.addInwardRelatedButton.Text = "<<< Add inward relations";
            this.addInwardRelatedButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addInwardRelatedButton.UseVisualStyleBackColor = true;
            this.addInwardRelatedButton.Click += new System.EventHandler(this.addInwardRelatedButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.Location = new System.Drawing.Point(12, 432);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(73, 23);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // addAllFromModelButton
            // 
            this.addAllFromModelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addAllFromModelButton.Location = new System.Drawing.Point(296, 201);
            this.addAllFromModelButton.Name = "addAllFromModelButton";
            this.addAllFromModelButton.Size = new System.Drawing.Size(105, 23);
            this.addAllFromModelButton.TabIndex = 2;
            this.addAllFromModelButton.Text = "<< Add from model";
            this.addAllFromModelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addAllFromModelButton.UseVisualStyleBackColor = true;
            this.addAllFromModelButton.Click += new System.EventHandler(this.addAllFromModelButton_Click);
            // 
            // modelComboBox
            // 
            this.modelComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(296, 174);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(175, 21);
            this.modelComboBox.TabIndex = 4;
            // 
            // getWIKIButton
            // 
            this.getWIKIButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.getWIKIButton.Location = new System.Drawing.Point(296, 432);
            this.getWIKIButton.Name = "getWIKIButton";
            this.getWIKIButton.Size = new System.Drawing.Size(81, 23);
            this.getWIKIButton.TabIndex = 2;
            this.getWIKIButton.Text = "WIKI";
            this.getWIKIButton.UseVisualStyleBackColor = true;
            this.getWIKIButton.Click += new System.EventHandler(this.getWIKIButton_Click);
            // 
            // ErdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 474);
            this.Controls.Add(this.modelComboBox);
            this.Controls.Add(this.tableTextBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addInwardRelatedButton);
            this.Controls.Add(this.addOutwardRelatedButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addAllRelatedButton);
            this.Controls.Add(this.addAllFromModelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.getWIKIButton);
            this.Controls.Add(this.getDBMLButton);
            this.Controls.Add(this.tablesListBox);
            this.Controls.Add(this.optionsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErdForm";
            this.Text = "Generate entity relation schema";
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.ListBox tablesListBox;
        private System.Windows.Forms.CheckBox standardFieldsCheckBox;
        private System.Windows.Forms.Button getDBMLButton;
        private System.Windows.Forms.CheckBox ignoreStagingCheckBox;
        private System.Windows.Forms.TextBox tableTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addAllRelatedButton;
        private System.Windows.Forms.CheckBox ignoreSelfReferencesCheckBox;
        private System.Windows.Forms.Button addOutwardRelatedButton;
        private System.Windows.Forms.Button addInwardRelatedButton;
        private System.Windows.Forms.CheckBox convertEDTCheckBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox extensionFieldsCheckBox;
        private System.Windows.Forms.Button addAllFromModelButton;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.Button getWIKIButton;
    }
}