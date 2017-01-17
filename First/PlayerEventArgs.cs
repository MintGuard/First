using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using First;


public class PlayerEventArgs : EventArgs
{
    public IPerson Person { get; set; }
    public List<Mob> Mobs { get; set; }

    public PlayerEventArgs(IPerson sPerson, List<Mob> sMobs)
    {
        Person = sPerson;
        Mobs = sMobs;
    }
}

