using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Direction
{
    public PointAround Up;
    public PointAround Down;
    public PointAround Left;
    public PointAround Right;

    public Direction(Position point)
    {
        Up = new PointAround(point, "N", 0, ConsoleKey.UpArrow);
        Down = new PointAround(point, "S", 1, ConsoleKey.DownArrow);
        Left = new PointAround(point, "W", 2, ConsoleKey.LeftArrow);
        Right = new PointAround(point, "E", 3, ConsoleKey.RightArrow);
    }

    public void Update (Position newPosition)
    {
        Up.Update(newPosition);
        Down.Update(newPosition);
        Left.Update(newPosition);
        Right.Update(newPosition);
    }
}

public class PointAround : IPointAround
{
    public string Sight { get; set; }
    public Position Around { get; set; }
    public int Index { get; set; }
    public ConsoleKey Input { get; set; }

    public PointAround(Position point, string sight, int index, ConsoleKey input)
    {
        Around = new Position();
        Around = point;
        Sight = sight;
        Index = index;
        Input = input;
        RecalculatePosition(sight);
    }

    public void Update(Position point)
    {
        Around = point;
        RecalculatePosition(Sight);
    }

    private void RecalculatePosition(string sight)
    {
        switch (sight)
        {
            case "N":
                Around.y--;
                break;
            case "S":
                Around.y++;
                break;
            case "W":
                Around.x--;
                break;
            case "E":
                Around.x++;
                break;
            default:
                throw new Exception("No sight direction");
        }
    }
}

public interface IPointAround
{
    string Sight { get; set; }
    Position Around { get; set; }
    int Index { get; set; }
    ConsoleKey Input { get; set; }
}





