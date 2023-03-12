using System;
using System.Collections.Generic;

namespace RoomManagement.Dto;

public partial class FoodDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int? MemberId { get; set; }

    public int? AmountToGive { get; set; }

    public int? AmountRecived { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }
}
