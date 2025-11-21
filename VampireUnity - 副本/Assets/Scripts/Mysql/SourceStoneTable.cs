namespace Mysql
{
    public class SourceStoneTable:TableBase
    {
        public SourceStoneTable()
        {
            TableType = TableType.SourceStoneTable;
        }
        public int SourceStoneType { get; set; }
        public int Count { get; set; }
        public int SourceStoneId { get; set; }
        public string SourceStoneName { get; set; }
        public string SourceStoneDesc { get; set; }
    }
}