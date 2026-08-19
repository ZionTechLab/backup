namespace ZION.SFA.Domain.SCS
{
 public    class tbl_genItemMaster
    {
        public string item_ID { get; set; }
        public string itemName { get; set; }
        public string uomCode { get; set; }
        public decimal PackingSize { get; set; }   
        public decimal CostPrice_WA { get; set; }
    }
}
