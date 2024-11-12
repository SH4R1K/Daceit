using System;
using System.Collections.Generic;

namespace DaceItFront.Models;

public partial class MatchHasPlayer
{
    public int PlayerIdPlayer { get; set; }

    public int MatchIdMatch { get; set; }

    public ulong IsDire { get; set; }

    public ulong IsWin { get; set; }

    public int? IdTeam { get; set; }

    public virtual Team? IdTeamNavigation { get; set; }

    public virtual Match MatchIdMatchNavigation { get; set; } = null!;

    public virtual Player PlayerIdPlayerNavigation { get; set; } = null!;
}
