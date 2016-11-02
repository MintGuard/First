using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace First
{
    /// <summary>
    /// Класс мусорка
    /// </summary>
    public class BattleLogic
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
            Program.Map[Player.Position.x][Player.Position.y] = "P";
        }

        public static string[][] CreateMap(int width, int length)
        {
            string[][] result = new string[width][];
            for (int i = 0; i < width; i++)
            {
                result[i] = new string[length];
                for (int j = 0; j < length; j++)
                {
                    result[i][j] = "N";
                }
            }
            return result;
        }

        public static void MobGenerator()
        {
            for (int i = 0; i < Program.MobCount; i++)
            {
                Program.coordinates = BattleLogic.RandomCoordinates(10);
                while (Program.Map[Program.coordinates[0]][Program.coordinates[1]] != "N")
                {
                    Program.coordinates = BattleLogic.RandomCoordinates(10);
                }
                Program.Mobs.Add(new Mob("Mob_" + i.ToString()));
                Program.Mobs[i].Position = new Position();
                Program.Mobs[i].Position.x = Program.coordinates[0];
                Program.Mobs[i].Position.y = Program.coordinates[1];
                Program.Map[Program.coordinates[0]][Program.coordinates[1]] = "M";
            }
        }

        public static void ShowMap()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" | " + Program.Map[i][j] + " | ");
                }
                Console.WriteLine("\n");
            }
        }  

        public static void MobsAction(IPerson Player, List<Mob> Mobs)
        {

            int ActionId = ActionRandomizer(3);
            foreach (Mob SelectesMob in Mobs)
            {
                #region Координаты точки на которую смотри моб
                int[] sightCoordinates = SightPoint(SelectesMob);
                #endregion

                bool condition = false;
                while (!condition)
                {
                    #region Ходьба. Условие недопилено еще
                    if ((ActionId == 0))
                    {
                        string[] DirectionsId = new string[] {"N", "S", "W", "E"};

                        SelectesMob.Move(DirectionsId[ActionRandomizer(4)]);
                        condition = true;
                    }
                    #endregion
                    #region Атака.
                    else if ((ActionId == 1) && (Player.Position.x == sightCoordinates[0]) && (Player.Position.y == sightCoordinates[1]))
                    {
                        SelectesMob.Attack(Player);
                        condition = true;
                    }
                    #endregion
                    #region Поиск. Условие недопилено еще
                    else if (ActionId == 2)
                    {
                        SelectesMob.Search();
                        condition = true;
                    }
                    #endregion
                    #region Перезапуск выбора действия
                    else
                    {
                        ActionId = ActionRandomizer(3);
                    }
                    #endregion
                }

            }
        }

        public static int ActionRandomizer(int maxNumber)
        {
            Random Rnd = new Random();
            return Rnd.Next(maxNumber);
        }

        public static int[] SightPoint(IPerson Peperson)
        {
            if (Peperson.SightDirection == "N")
            {
                int[] result = new int[] { Peperson.Position.x, Peperson.Position.y - 1 };
                return result;
            }
            else if (Peperson.SightDirection == "S")
            {
                int[] result = new int[] { Peperson.Position.x, Peperson.Position.y + 1 };
                return result;
            }
            else if (Peperson.SightDirection == "W")
            {
                int[] result = new int[] { Peperson.Position.x - 1, Peperson.Position.y };
                return result;
            }
            else //if (Peperson.SightDirection == "E")
            {
                int[] result = new int[] { Peperson.Position.x + 1, Peperson.Position.y };
                return result;
            }
        }
    }
}
