namespace WebApi
{
    public class Product
    {
        public int id { get; set; }
        public int supplierId { get; set; }
        public int categoryId { get; set; }
        public string quantityPerUnit { get; set; }
        public double unitPrice { get; set; }
        public double unitsInStock { get; set; }
        public int unitsOnOrder { get; set; }
        public int reorderLevel { get; set; }
        public bool discontinued { get; set; }
        public string name { get; set; }
        public Supplier supplier { get; set; }
        public Category category { get; set; }

        public override string ToString()
        {
            return this.name;
        }

    }
}
