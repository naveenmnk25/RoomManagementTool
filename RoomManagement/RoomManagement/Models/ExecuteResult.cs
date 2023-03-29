using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomManagement.Models;

[NotMapped]
[Keyless]
public class ExecuteResult
{
    public int Result { get; set; }
}
