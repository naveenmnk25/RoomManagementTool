using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomManagement.Models;


[NotMapped]
[Keyless]
public partial class GetRent
{
    public string Name { get; set; }
    public int? AmountToGive { get; set; }
}
