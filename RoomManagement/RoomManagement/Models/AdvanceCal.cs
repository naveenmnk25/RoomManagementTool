using System;
using System.Collections.Generic;

namespace RoomManagement.Models;

public partial class AdvanceCal
{
    public int Id { get; set; }

    public int? MemberId { get; set; }

    public int? AmountGiven { get; set; }

    public int? AmountReFund { get; set; }

    public int? RemAmtFromAd { get; set; }

    public int? DetectedAmt { get; set; }

    public DateTime? Date { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }
}
