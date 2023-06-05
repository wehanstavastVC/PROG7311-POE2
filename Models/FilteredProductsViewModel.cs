namespace FarmerCentral2.Models
{
    public class FilteredProductsViewModel
    {
        public string UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProductType { get; set; }
        public List<Product> Products { get; set; }
    }
}
