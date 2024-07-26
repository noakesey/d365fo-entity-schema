using EnvDTE;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Waywo.DbSchema.Providers;

namespace Waywo.DbSchema.AddIn.Controllers
{
    public class ErdController : IErdController
    {
        protected readonly DTE devenv;
        protected TextDocument textDocument;

        public IDataModelProvider DataModelProvider { get; set; }
        public ISchemaProvider DBMLSchemaProvider { get; set; }
        public ISchemaProvider WIKISchemaProvider { get; set; }

        public ErdController(
            IDataModelProvider dataModelProvider, 
            ISchemaProvider dbmlSchemaProvider,
            ISchemaProvider wikiSchemaProvider,
            DTE dte)
        {
            this.DataModelProvider = dataModelProvider;
            this.DBMLSchemaProvider = dbmlSchemaProvider;
            this.WIKISchemaProvider = wikiSchemaProvider;
            this.devenv = dte;
        }

        public void UseActiveDocument()
        {
            if ((this.devenv.ActiveDocument != null) && (this.devenv.ActiveDocument.Name.EndsWith(".dbml")))
            {
                try
                {
                    this.textDocument = (TextDocument)(devenv.ActiveDocument.Object("TextDocument"));
                    EditPoint editPoint = textDocument.StartPoint.CreateEditPoint();
                    string text = editPoint.GetText(textDocument.EndPoint);

                    Regex regex = new Regex(@"Table ([\S]*) {");
                    Match match = regex.Match(text);

                    while (match.Success)
                    {
                        Group group = match.Groups[1];
                        this.DataModelProvider.AddTable(group.Value);

                        match = match.NextMatch();
                    }
                }
                catch
                {
                    //Something went wrong with the format
                }
            }
        }

        public void GetDBML()
        {
            if (this.DataModelProvider.Tables.Count > 0 && devenv != null)
            {
                string dbml = DBMLSchemaProvider.GetSchema();

                if (this.textDocument == null)
                {
                    var window = this.devenv.ItemOperations.NewFile(Name: string.Format(@"{0} ER Diagram.dbml", this.DataModelProvider.Tables[0]));
                    this.textDocument = (TextDocument)this.devenv.ActiveDocument.Object("TextDocument");
                }

                EditPoint editPoint = this.textDocument.CreateEditPoint(this.textDocument.StartPoint);
                editPoint.Delete(this.textDocument.EndPoint);
                editPoint.Insert(dbml);
            }
        }

        public void GetWIKI()
        {
            if (this.DataModelProvider.Tables.Count > 0 && devenv != null)
            {
                string dbml = WIKISchemaProvider.GetSchema();

                if (this.textDocument == null)
                {
                    var window = this.devenv.ItemOperations.NewFile(Name: string.Format(@"{0} WIKI.md", this.DataModelProvider.Tables[0]));
                    this.textDocument = (TextDocument)this.devenv.ActiveDocument.Object("TextDocument");
                }

                EditPoint editPoint = this.textDocument.CreateEditPoint(this.textDocument.StartPoint);
                editPoint.Delete(this.textDocument.EndPoint);
                editPoint.Insert(dbml);
            }
        }
    }
}
