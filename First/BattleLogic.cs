using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace First
{
    class BattleLogic
    {
        /// <summary>
        /// Метод получения рандомных координат
        /// </summary>
        /// <param name="Count">Перебор мобов</param>
        /// <returns></returns>
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

        /// <summary>
        /// Метод, располагающий игрока на карте
        /// </summary>
        /// <param name="Player">Тип персонажа</param>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        public static void PlayerPositioning(IPerson Player, int x, int y)
        {
            Player.Position.x = x;
            Player.Position.y = y;
            Program.Map[Player.Position.x, Player.Position.y] = "P";
        }

        /// <summary>
        /// Метод создания карты
        /// </summary>
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

        /// <summary>
        /// Метод, генерирующий мобов
        /// </summary>
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
                //Program.Mobs[i].ClosePoints = new PointsAround(Program.Mobs[i].Position);
            }
        }

        /// <summary>
        /// Метод отображения карты
        /// </summary>
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

        /// <summary>
        /// Метод, вызывающий действия мобов
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="Player"></param>
        /// <param name="Mobs"></param>
        public static void MobAction(int Num, IPerson Player, List<Mob> Mobs)
        {
            foreach (Mob SelectesMob in Mobs)
            {
                #region Атака моба(если игрок рядом в любом случае)
                bool tempCheck = false;
                if (!tempCheck)
                {
                    SelectesMob.Attack(Player);
                    tempCheck = true;
                }
                #endregion
                else
                {
                    Random ActionRnd = new Random();
                    Num = ActionRnd.Next(2);
                    #region Ходьба моба(недописанная)
                    if (Num == 0)
                    {
                        
                        //int temp;
                        //Random Rndm = new Random();
                        //temp = Rndm.Next(3);
                        //if (temp == 0)
                        //{
                        //    SelectesMob.MobsMove("W");
                        //}
                        //else if (temp == 1)
                        //{
                        //    SelectesMob.MobsMove("E");
                        //}
                        //else if (temp == 2)
                        //{
                        //    SelectesMob.MobsMove("N");
                        //}
                        //else if (temp == 3)
                        //{
                        //    SelectesMob.MobsMove("S");
                        //}
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
                            //    if (SelectesMob.SightDirection != "N")
                            //    {
                            //        SelectesMob.Rotate("N");
                            //    }
                            //    else
                            //    {
                            //        SelectesMob.Rotate("S");
                            //    }
                            //}
                            //else if (temp == 1)
                            //{
                            //    if (SelectesMob.SightDirection != "S")
                            //    {
                            //        SelectesMob.Rotate("S");
                            //    }
                            //    else
                            //    {
                            //        SelectesMob.Rotate("N");
                            //    }
                            //}
                            //else if (temp == 2)
                            //{
                            //    if (SelectesMob.SightDirection != "W")
                            //    {
                            //        SelectesMob.Rotate("W");
                            //    }
                            //    else
                            //    {
                            //        SelectesMob.Rotate("E");
                            //    }
                            //}
                            //else if (temp == 3)
                            //{
                            //    if (SelectesMob.SightDirection != "E")
                            //    {
                            //        SelectesMob.Rotate("E");
                            //    }
                            //    else
                            //    {
                            //        SelectesMob.Rotate("W");
                            //    }
                            //}
                        }
                    #endregion
                        #region Поиск моба
                        else if (Num == 2)
                        {
                            SelectesMob.Search(Player);
                        }
                        #endregion
                        else { }

                    }
                }
            }
        }
    }
}