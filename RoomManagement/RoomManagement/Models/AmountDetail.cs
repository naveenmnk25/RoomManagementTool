using System;
using System.Collections.Generic;

namespace RoomManagement.Models;

public partial class AmountDetail
{
    public int Id { get; set; }

    public int? RoomRentAmount { get; set; }

    public int? FootAmountAmount { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }
}
