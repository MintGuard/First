using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    class Player : Person
    {
        #region Конструкторы 
        public Player() //Написать конструктор с заданием POwer и Health
        {
            new Player("NoName");
        }

        public Player(string name)
        {
            new Player(name, 100, 10, "N");
        }

        public Player(string name, int hp, int power, string sd)
        {
            this.PersonType = "Player";
            this.Name = name;
            this.Health = hp;
            this.Power = power;
            this.Position = new Position();
            this.SightDirection = sd;

            //ToDo Исправить, убрать инициализацию прямо в классе
            this.ClosePoints = new PointsAround(Position);   
        }
        #endregion

        public override void Search(IPerson Mob)
        {

        }
    }
}
