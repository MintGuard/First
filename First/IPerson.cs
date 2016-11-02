using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    interface IPerson
    {
        /// <summary>
        /// Поля, которые есть у всех персонажей
        /// </summary>
        string PersonType { get ; set; }
        string Name { get; set; }
        Position SightDirection { get; set; }
        Position Position { get; set; }
        PointsAround ClosePoints { get; set; }
        int Power { get; set; }
        int Health { get; set; }

        /// <summary>
        /// Методы, которые выполняют все персонажи
        /// </summary>
        /// <param name="Target"></param>
        void Attack(IPerson Target);  
        void Move(IPerson PersonToMove);
        void Search(IPerson Target);
        void Rotate();
    }
}
