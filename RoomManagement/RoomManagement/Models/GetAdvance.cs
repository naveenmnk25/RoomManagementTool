using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomManagement.Models;


[NotMapped]
[Keyless]
public partial class GetAdvance
{
    public string Name { get; set; }

    public int? Memberid { get; set; }

    public int? AdvanceCalId { get; set; }
    public int? AmountGiven { get; set; }
    public int? AmountReFund { get; set; }
    public int? RemAmtFromAd { get; set; }
    public int? DetectedAmt { get; set; }
    public int? DetectedAdvAmt { get; set; }
    public int? MonthStayed { get; set; }
    public bool? IsVecate { get; set; }
    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }
}
