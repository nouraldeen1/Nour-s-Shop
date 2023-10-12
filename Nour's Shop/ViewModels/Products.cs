namespace Nour_Shop.ViewModels
{
	public class Products
    {
        public int? Id { get; set; } = null!;
        public string? Name { get; set; }

        public string Status { get; set; } = null!;

        public string? Catogary { get; set; }

        public string? Description { get; set; }

        public string Image { get; set; } = null!;
        public IFormFile ImageFile { get; set; }
        public byte[] ImageData { get; set; }

        public string? Brand { get; set; }

        public int Price { get; set; }

        public decimal? Discount { get; set; }
    }
}
