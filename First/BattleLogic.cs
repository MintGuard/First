using System;
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

        public static void MobsAction(IPerson Player, List<Mob> Mobs)
        {

            int ActionId = ActionRandomizer(3);
            foreach (Mob SelectesMob in Mobs)
            {
                #region Координаты точки на которую смотри моб
                int tempX = 0;
                int tempY = 0;

                if (SelectesMob.SightDirection == "N")
                {
                    tempX = SelectesMob.Position.x;
                    tempY = SelectesMob.Position.y - 1;
                }
                if (SelectesMob.SightDirection == "S")
                {
                    tempX = SelectesMob.Position.x;
                    tempY = SelectesMob.Position.y + 1;
                }
                if (SelectesMob.SightDirection == "W")
                {
                    tempX = SelectesMob.Position.x - 1;
                    tempY = SelectesMob.Position.y;
                }
                if (SelectesMob.SightDirection == "E")
                {
                    tempX = SelectesMob.Position.x + 1;
                    tempY = SelectesMob.Position.y;
                }
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
                    else if ((ActionId == 1) && (Player.Position.x == tempX) && (Player.Position.y == tempY))
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
    }
}
