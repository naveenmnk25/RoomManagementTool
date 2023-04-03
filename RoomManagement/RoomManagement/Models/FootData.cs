using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomManagement.Models;


[NotMapped]
[Keyless]
public partial class FootData
{
    public string Name { get; set; }

    public int? Memberid { get; set; }

    public int? FoodDetailsid { get; set; }
    public int? AmountToGive { get; set; }
    public int? AmountRecived { get; set; }
    public int? RemainingTogive { get; set; }
    public int? ExceptAmt { get; set; }
    public int? SectionId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }
}
