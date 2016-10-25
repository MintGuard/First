﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace First
{
    class BattleLogic
    {
        public static int[] RandomCoordinates(int Count)
        {
            int[] result = new int[2];
            Random Rnd = new Random();
            for (int i = 0; i < 2; i++)
            {
                result[i] = Rnd.Next(Count);
            }
            return result;
        }

        public static void PlayerPositioning(IPerson Player, int x, int y)
        {
            Player.Position.x = x;
            Player.Position.y = y;
            Program.Map[Player.Position.x, Player.Position.y] = "P";
        }

        public static void CreateMap()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Program.Map[i, j] = "N";
                }
            }
        }

        public static void MobGenerator()
        {
            for (int i = 0; i < Program.MobCount; i++)
            {
                Program.coordinates = BattleLogic.RandomCoordinates(10);
                while (Program.Map[Program.coordinates[0], Program.coordinates[1]] != "N")
                {
                    Program.coordinates = BattleLogic.RandomCoordinates(10);
                }
                Program.Mobs.Add(new Mob("Mob_" + i.ToString()));
                Program.Mobs[i].Position = new Position();
                Program.Mobs[i].Position.x = Program.coordinates[0];
                Program.Mobs[i].Position.y = Program.coordinates[1];
                Program.Map[Program.coordinates[0], Program.coordinates[1]] = "M";
            }
        }

        public static void ShowMap()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" | " + Program.Map[i, j] + " | ");
                }
                Console.WriteLine("\n");
            }
        }
        public static void MobAction(int Num, IPerson Player, List<Mob> Mobs)
        {   
            foreach (Mob SelectesMob in Mobs)
            {
                #region Атака моба(если игрок рядом в любом случае)
                if (((SelectesMob.Position.x == (Player.Position.x - 1)) && (SelectesMob.Position.y == Player.Position.y) && (SelectesMob.SightDirection == "E")) |
                    ((SelectesMob.Position.x == (Player.Position.x + 1)) && (SelectesMob.Position.y == Player.Position.y) && (SelectesMob.SightDirection == "W")) |
                    ((SelectesMob.Position.x == Player.Position.x) && (SelectesMob.Position.y == (Player.Position.y - 1)) && (SelectesMob.SightDirection == "S")) |
                    ((SelectesMob.Position.x == Player.Position.x) && (SelectesMob.Position.y == (Player.Position.y + 1)) && (SelectesMob.SightDirection == "N")))
                {
                    SelectesMob.Attack(Player);
                }
                #endregion
                else
                {
                    Random ActionRnd = new Random();
                    Num = ActionRnd.Next(2);
                    #region Ходьба моба(недописанная)
                    if (Num == 0)
                    {
                        int temp;
                        Random Rndm = new Random();
                        temp = Rndm.Next(3);
                        if (temp == 0)
                        {
                            SelectesMob.Move("W");
                        }
                        else if (temp == 1)
                        {
                            SelectesMob.Move("E");
                        }
                        else if (temp == 2)
                        {
                            SelectesMob.Move("N");
                        }
                        else if (temp == 3)
                        {
                            SelectesMob.Move("S");
                        }
                    }
                    #endregion
                    #region Поворот моба
                    else if (Num == 1)
                    {
                        int temp;
                        Random Rndm = new Random();
                        temp = Rndm.Next(3);
                        if (temp == 0)
                        {
                            if (SelectesMob.SightDirection != "N")
                            {
                                SelectesMob.Rotate("N");
                            }
                            else
                            {
                                SelectesMob.Rotate("S");
                            }
                        }
                        else if (temp == 1)
                        {
                            if (SelectesMob.SightDirection != "S")
                            {
                                SelectesMob.Rotate("S");
                            }
                            else
                            {
                                SelectesMob.Rotate("N");
                            }
                        }
                        else if (temp == 2)
                        {
                            if (SelectesMob.SightDirection != "W")
                            {
                                SelectesMob.Rotate("W");
                            }
                            else
                            {
                                SelectesMob.Rotate("E");
                            }
                        }
                        else if (temp == 3)
                        {
                            if (SelectesMob.SightDirection != "E")
                            {
                                SelectesMob.Rotate("E");
                            }
                            else
                            {
                                SelectesMob.Rotate("W");
                            }
                        }
                    }
                    #endregion
                    #region Поиск моба(недописанный)
                    else if (Num == 2)
                    {
                        SelectesMob.Search();
                    }
                    #endregion
                    else { }

                }
            }
        }
    }
}