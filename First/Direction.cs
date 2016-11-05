using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Direction
{
    public Up Up;
    public Down Down;
    public Left Left;
    public Right Right;

    public Direction(Position currentPoint)
    {
        Up = new Up(currentPoint);
        Down = new Down(currentPoint);
        Left = new Left(currentPoint);
        Right = new Right(currentPoint);
    }

    public void Update (Position newPosition)
    {
        Up.Update(newPosition);
        Down.Update(newPosition);
        Left.Update(newPosition);
        Right.Update(newPosition);
    }
}

public class Up : IZoglushka
{
    public Position chototam { get; set; }
    public string Sight = "N";
    public Position Around;
    public Up(Position point)
    {
        Around = point;
        Around.y--;
    }
    public void Update(Position point)
    {
        Around = point;
        Around.y--;
    }
}
public class Down : IZoglushka
{
    public Position chototam { get; set; }
    public string Sight = "S";
    public Position Around;
    public Down(Position point)
    {
        Around = point;
        Around.y++;
    }
    public void Update(Position point)
    {
        Around = point;
        Around.y++;
    }
}
public class Left : IZoglushka
{
    public Position chototam { get; set; }
    public string Sight = "W";
    public Position Around;
    public Left(Position point)
    {
        Around = point;
        Around.x--;
    }
    public void Update(Position point)
    {
        Around = point;
        Around.x--;
    }
}
public class Right : IZoglushka
{
    public Position chototam { get; set; }
    public string Sight { get; set; }
    public Position Around { get; set; }
    public Right(Position point)
    {
        Around = point;
        Around.x++;
        Sight = "E";
    }
    public void Update(Position point)
    {
        Around = point;
        Around.x++;
    }
}

public interface IZoglushka
{
    Position chototam { get; set; }
    string Sight { get; set; }
    Position Around { get; set; }
}





