namespace Entities
{
    public class Supplier
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Adres { get; set; }
        public string Phone { get; set; }
        public override string ToString()
        {
            return this.CompanyName;
        }
    }

}
