using System;
using System.Collections.Generic;

namespace MyApp.Models.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int TypeId { get; set; }

    public int UnitId { get; set; }

    public virtual ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();

    public virtual Type Type { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
