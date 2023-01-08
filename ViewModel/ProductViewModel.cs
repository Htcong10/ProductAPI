namespace ProductAPI.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string imageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public bool CategoryStatus { get; set; }

    }
}
