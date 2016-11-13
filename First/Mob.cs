﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    class Mob : Person
    {
        #region Конструкторы
        public Mob()
        {
            new Mob("Noname");
        }

        public Mob(string name)
        {
            new Mob(name, 30, 9, "N");
        }

        public Mob(string name, int hp, int power, string sd)
        {
            this.PersonType = "Enemy";
            this.Name = name;
            this.Health = hp;
            this.Power = power;
            this.SightDirection = sd;
            this.Directions = new Direction(Position);

            //ToDo Исправить, убрать инициализацию прямо в классе
            //this.ClosePoints = new PointsAround(Position);
        }
        #endregion
        //ToDo Исправить косяки

        int ActionId = BattleLogic.ActionRandomizer(3);
        public override void Move() 
        {
            base.Move();
            if (Program.Map[this.ReturnPoints(this.Position).Where(x => x.Index == ActionId).FirstOrDefault().Around.x, this.ReturnPoints(this.Position).Where(x => x.Index == ActionId).FirstOrDefault().Around.y] == "N")
            {
                this.Position = this.ReturnPoints(this.Position).Where(x => x.Index == ActionId).FirstOrDefault().Around;
            }
            else 
            { 
                ActionId = BattleLogic.ActionRandomizer(3); 
            }
            }
        public override void Rotate()
        {   
            base.Rotate();
            if (this.SightDirection != this.ReturnPoints(this.Position).Where(x => x.Index == ActionId).FirstOrDefault().Sight)
            {
                this.SightDirection = this.ReturnPoints(this.Position).Where(x => x.Index == ActionId).FirstOrDefault().Sight;
            }
            else 
            {
                ActionId = BattleLogic.ActionRandomizer(3);
            }
            }
    }
}
