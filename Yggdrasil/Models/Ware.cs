namespace Yggdrasil.Models
{
    public enum WareType {Dairy, Canned, Fresh, Dry, Drink, All} //"All" should never be used, it is purely for sorting purposes
    public class Ware
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public WareType Type { get; set; }
        public bool IsVegan { get; set; }
        public bool IsOrganic { get; set; }
        public string ImageName { get; set; }
        
        public int AmountSold { get; set; }
        
    }
}
