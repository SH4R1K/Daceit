using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DaceItFront.Models;

public partial class Player : IdentityUser
{
    public int IdPlayer { get; set; }

    public int SteamId { get; set; }

    public string NamePlayer { get; set; } = null!;

    public int PlayerMmr { get; set; }
}
