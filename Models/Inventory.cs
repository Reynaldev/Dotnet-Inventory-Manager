using System;
using System.Collections.Generic;

namespace Dotnet_Inventory_Manager.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public string? ItemName { get; set; }

    public DateTime? DatePurchased { get; set; }

    public string? Quality { get; set; }
}
