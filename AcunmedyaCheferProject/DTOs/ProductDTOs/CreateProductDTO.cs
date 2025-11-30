namespace AcunmedyaCheferProject.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }


        public int CategoryId { get; set; }
    }
}
