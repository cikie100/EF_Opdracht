using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Objects
{
    public class Speler
    {
        int id { get; set; }
        String naam { get; set; }
        int rugnummer { get; set; }
        int waarde { get; set; } //(geschatte transferwaarde).
        Team team { get; set; }
    }
}
