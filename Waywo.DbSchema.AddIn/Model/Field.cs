namespace Waywo.DbSchema.Model
{
    public class Field
    {
        public string Name { get; set; }
        public string DataType { get; set; }

        public KeyType KeyType { get; set; }
        public bool IsClusteredIndex { get; set; }

        public bool IsExtension { get; set; }

        public bool IsMandatory { get; set; }
    }
}
