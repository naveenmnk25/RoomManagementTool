using System;
using System.Collections.Generic;

namespace RoomManagement.Models;

public partial class Login
{

    public string Email { get; set; }

    public string? PassWord { get; set; }
    public string? Role { get; set; }

    public bool KeepLoggedIn { get; set; }

}
