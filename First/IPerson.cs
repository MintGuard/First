﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using First;

public interface IPerson
{
    /// <summary>
    /// Поля, которые есть у всех персонажей
    /// </summary>
    string PersonType { get ; set; }
    string Name { get; set; }
    string SightDirection { get; set; }
    Position Position { get; set; }
    Direction Directions { get; set; }
    int Power { get; set; }
    int Health { get; set; }

    /// <summary>
    /// Методы, которые выполняют все персонажи
    /// </summary>
    /// <param name="Target"></param>
    List<IPointAround> ReturnPoints(Position currentPoint);
    void Attack(IPerson Target);  
    void Move();
    void Search();
    void Rotate();
    void PlayerAction(List<Mob> Mobs);
    event Player.Acted OnSomeAction ;
}

