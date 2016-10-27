using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    interface IPerson
    {
        string PersonType { get ; set; }
        string Name { get; set; }
        string SightDirection { get; set; }
        Position Position { get; set; }
        int Power { get; set; }
        int Health { get; set; }

        void Attack(IPerson Target);
        void MovePlayer(string Direction);
        void MobsMove(string Direction);
        void Search();
        void Rotate(string SightDirection);
    }
}
