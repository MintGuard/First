﻿using System;
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
    public string Sight { get; set; }
    public Position Around { get; set; }
    public int Index { get; set; }
    public ConsoleKey Input { get; set; }
    public Up(Position point)
    {
        Around = point;
        Around.y--;
        Sight = "N";
        Index = 0;
        Input = ConsoleKey.UpArrow;
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
    public string Sight { get; set; }
    public Position Around { get; set; }
    public int Index { get; set; }
    public ConsoleKey Input { get; set; }
    public Down(Position point)
    {
        Around = point;
        Around.y++;
        Sight = "S";
        Index = 1;
        Input = ConsoleKey.DownArrow;
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
    public string Sight { get; set; }
    public Position Around { get; set; }
    public int Index { get; set; }
    public ConsoleKey Input { get; set; }
    public Left(Position point)
    {
        Around = point;
        Around.x--;
        Sight = "W";
        Index = 2;
        Input = ConsoleKey.LeftArrow;
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
    public int Index { get; set; }
    public ConsoleKey Input { get; set; }
    public Right(Position point)
    {
        Around = point;
        Around.x++;
        Sight = "E";
        Index = 3;
        Input = ConsoleKey.RightArrow;
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

    int Index { get; set; }
    ConsoleKey Input { get; set; }
}





