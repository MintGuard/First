using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using First;

public class Person : IPerson
{
    public string PersonType { get; set; }
    public string Name { get; set; }
    public string SightDirection { get; set; }
    public Position Position { get; set; }
    public Direction Directions { get; set; }
    public int Power { get; set; }
    public int Health { get; set; }
    public Dictionary<ConsoleKey, IPointAround> dir;


    public Person()
    {

    }


    //Метод, возвращающий соседние точки
    public List<IPointAround> ReturnPoints(Position currentPoint)
    {
        Direction dir = new Direction(this.Position);
        List<IPointAround> Points = new List<IPointAround>();
        Points.Add(dir.Up);
        Points.Add(dir.Down);
        Points.Add(dir.Left);
        Points.Add(dir.Right);

        return Points;
    }


    public delegate void Acted(object sender, PlayerEventArgs e);
    public event Player.Acted OnSomeAction;
    #region Методы персонажей

    public virtual void PlayerAction(List<Mob> Mobs)
    {

    }

    public void Attack(IPerson target)
    {
            target.Health -= this.Power;
           
    }

    public virtual void Move()
    {

    }

    public virtual void Move(ConsoleKey Key)
    {

    }

    public virtual void Search()
    {
            
    }

    public virtual void Rotate()
    {

    }
    public virtual void Rotate(ConsoleKey Key)
    {

    }
    #endregion
}
