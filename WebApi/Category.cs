namespace WebApi
{
    public class Category
    {
        public string CategoryName { get; set; }
        public string Aciklama { get; set; }

        public override string ToString()
        {
            return this.CategoryName;
        }
    }
}
