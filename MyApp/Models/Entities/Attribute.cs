using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyApp.Models.Entities;

public partial class Attribute
{
    public int Id { get; set; }

    public string? Value { get; set; }

    public int AttributeNameId { get; set; }

    public int ProductId { get; set; }

    public virtual Attributename AttributeName { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
