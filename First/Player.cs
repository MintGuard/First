using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using First;

public class Player : Person
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
        this.SightDirection = sd;
        this.Position = new Position();
        this.Directions = new Direction(this.Position);

    }
    #endregion
    public delegate void Acted(object sender, PlayerEventArgs e);
    public event Acted OnSomeAction;

    public override void Move()
    {
        if (Program.Map[this.ReturnPoints(this.Position).Where(x => x.Input == Console.ReadKey().Key).FirstOrDefault().Around.x, this.ReturnPoints(this.Position).Where(x => x.Input == Console.ReadKey().Key).FirstOrDefault().Around.y] == "N")
        {
            this.Position = this.ReturnPoints(this.Position).Where(x => x.Input == Console.ReadKey().Key).FirstOrDefault().Around;
        }
        else
        {
            Console.WriteLine("Нельзя туда шагнуть");
        }
    }

    public override void Rotate()
    {
        if (this.SightDirection != this.ReturnPoints(this.Position).Where(x => x.Input == Console.ReadKey().Key).FirstOrDefault().Sight)
        {
            this.SightDirection = this.ReturnPoints(this.Position).Where(x => x.Input == Console.ReadKey().Key).FirstOrDefault().Sight;
        }
        else
        {
            Console.WriteLine("Выбери другое направление");
        }
    }

    public override void Search()
    {
            
}
    /// <summary>
    /// Метод, вызывающий действие игрока
    /// </summary>
    /// <param name="Player"></param>
    /// <param name="Mobs"></param>
    public override void PlayerAction(List<Mob> Mobs)
    {
        try
        {
            List<string> ActList = new List<string> { "M", "A", "R", "S" };
            string tempAction = Console.ReadLine();
            Console.Read();
            if (tempAction == "M")
            {
                Console.WriteLine("Нажми стрелку");
                Console.ReadKey();
                this.Move();
            }

            else if (tempAction == "A")
            {
                foreach (Mob SelectesMob in Mobs)
                {
                    this.Attack(SelectesMob);
                }
            }

            else if (tempAction == "R")
            {
                Console.WriteLine("Куда? Жмякни по стрелкам и будет тебе щастье");
                Console.ReadLine();
                this.Rotate();
            }


            else if (tempAction == "S")
            {
                this.Search();
            }

            else
            {
                foreach (string ActValue in ActList)
                {
                    if (tempAction != ActValue) throw new Exception("Нет такого действия");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       
        //Запуск события
        if (OnSomeAction != null)
        {
            OnSomeAction(this, new PlayerEventArgs(this, Mobs));
        }
    }
}

