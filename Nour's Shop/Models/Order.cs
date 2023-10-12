using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nour_Shop.Models;

public partial class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }

    public int? Number { get; set; }

    public int? Times { get; set; }

    public string Status { get; set; } = null!;

    public int Payment { get; set; }

    public int? RemainingTime { get; set; }

    public int? Uid { get; set; }

    public int? Pid { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public virtual Product? PidNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual User? UidNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
