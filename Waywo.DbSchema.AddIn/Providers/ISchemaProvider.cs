namespace Waywo.DbSchema.Providers
{
    public interface ISchemaProvider
    {
        bool StandardFields { get; set; }
        bool ExtensionFields {  get; set; }

        bool MarkMandatory { get; set; }

        string GetSchema();
    }
}
