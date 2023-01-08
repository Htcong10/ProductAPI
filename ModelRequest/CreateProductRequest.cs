namespace ProductAPI.ModelRequest
{
    public class CreateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Desc { get; set; }
        public string imageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
