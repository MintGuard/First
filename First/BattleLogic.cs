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

        //Метод получения рандомного числа
        public static int ActionRandomizer(int maxNumber)
       {
            Random Rnd = new Random();
            return Rnd.Next(maxNumber);
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
        public static void MobAction(int ActionRnd, IPerson Player, List<Mob> Mobs)
        {
            foreach (Mob SelectesMob in Mobs)
            {
                #region Атака моба(если игрок рядом в любом случае)
                //Написана хуйня
                bool tempCheck = false;
                if (!tempCheck)
                {
                    SelectesMob.Attack(Player);
                    tempCheck = true;
                }
                #endregion
                else
                {
                    ActionRnd = ActionRandomizer(2);
                    #region Ходьба моба
                    if (ActionRnd == 0)
                    {
                        SelectesMob.Move();
                    }
                    #endregion
                    #region Поворот моба
                    else if (ActionRnd == 1)
                    {   
                        SelectesMob.Rotate();
                    }
                    #endregion
                        #region Поиск моба
                    else
                    {
                        SelectesMob.Search();
                    }
                        #endregion 
                    }
                }
            }
        }
    }
