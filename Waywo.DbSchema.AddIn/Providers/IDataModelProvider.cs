using System.Collections.Generic;
using Waywo.DbSchema.Model;

namespace Waywo.DbSchema.Providers
{
    public interface IDataModelProvider
    {
        IDataModelProvider AddTable(string text);
        IDataModelProvider AddRelatedTables();
        IDataModelProvider AddInwardTables(string tableName);
        IDataModelProvider AddOutwardTables(string tableName);
        IDataModelProvider AddTablesFromModel(string modelName);
        
        string Model { get; set; }
        bool SimplifyTypes { get; set; }
        bool IgnoreStaging { get; set; }
        bool IgnoreSelfReferences { get; set; }

        DataModel DataModel { get; set; }
        List<string> Tables { get; set; }

        List<string> GetModels();

        IDataModelProvider GenerateDataModel();
    }
}