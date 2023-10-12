using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nour_Shop.Models;
public partial class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; } = null!;
    public string? Name { get; set; }
    public string Status { get; set; } = null!;
    public byte[]? ImageData { get; set; }

    public string? Catogary { get; set; }
    public int? Times { get; set; }
    public string? Description { get; set; }

    public string Image { get; set; } = null!;

    public string? Brand { get; set; }

    public int Price { get; set; }

    public decimal? Discount { get; set; }

    public int? Oid { get; set; }

    public virtual Order? OidNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
