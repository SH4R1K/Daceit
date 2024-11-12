using System;
using System.Collections.Generic;

namespace DaceItFront.Models;

public partial class Match
{
    public int IdMatch { get; set; }

    public DateTime StartDate { get; set; }

    public int Duration { get; set; }
}
