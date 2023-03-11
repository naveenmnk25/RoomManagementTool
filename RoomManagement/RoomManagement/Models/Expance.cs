using System;
using System.Collections.Generic;

namespace RoomManagement.Models;

public partial class Expance
{
    public int Id { get; set; }

    public string? Item { get; set; }

    public int? Price { get; set; }

    public DateTime? Date { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }
}
