using System;
using System.Collections.Generic;

namespace RoomManagement.Models;

public partial class FoodDetail
{
    public int Id { get; set; }

    public int? MemberId { get; set; }

    public int? AmountToGive { get; set; }

    public int? AmountRecived { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }
}
