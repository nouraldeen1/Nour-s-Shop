using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nour_Shop.Models;

public partial class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 

    public string FirstName { get; set; } 

    public string LastName { get; set; }

    public string UserName { get; set; }

     public int age { get; set; } 

    public string Email { get; set; } 

    public String Password { get; set; } 

    public string Address { get; set; } 

    public int? Oid { get; set; }

    public string Sex { get; set; } = null!;
    public string Mobile { get; set; }

    public virtual Order? OidNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
