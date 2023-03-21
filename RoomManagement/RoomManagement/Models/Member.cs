using System;
using System.Collections.Generic;

namespace RoomManagement.Models;

public partial class Member
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Company { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public bool? IsVecate { get; set; }

    public bool? IsFood { get; set; }

    public DateTime? JoinDate { get; set; }

    public DateTime? VecateDate { get; set; }
}
