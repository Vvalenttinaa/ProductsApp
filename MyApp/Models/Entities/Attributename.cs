using System;
using System.Collections.Generic;

namespace MyApp.Models.Entities;

public partial class Attributename
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();

    public int? UnitId { get; set; } 

    public virtual Unit? Unit { get; set; }

}
