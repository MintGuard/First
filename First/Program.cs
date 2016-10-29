using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace First
{
    class Program
    {
        //Карта
        public static string[,] Map = new string[10, 10];

        //Количество мобов, задается вначале игры
        public static int MobCount;

        //Внутренние переменные
        public static string TEMP;
        public static int[] coordinates;

        //Список для хранения объектов мобов
        public static List<Mob> Mobs = new List<Mob>();
        delegate void Del(int Num, IPerson Player, List<Mob> Mobs);
        delegate void Del1(int x, int y, IPerson Player, List<Mob> Mobs);
        static void Main(string[] args)
        {
            Console.WriteLine("Hi Masha. I'm your first test game which you will analyze and upgrade. Do your best!");
            Thread.Sleep(1000);
            Console.WriteLine("Write enemy count -> ");
            while (TEMP == null)
            {
                TEMP = Console.ReadLine();
            }
            //Console.WriteLine(TEMP + " " + TEMP.GetType().ToString());
            try
            {
                Thread.Sleep(1000);

                List<string> TEMPList = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                foreach (string TEMPValue in TEMPList)
                {
                    //Console.WriteLine(TEMPValue +" "+ TEMPValue.GetType().ToString());
                    if (TEMP == TEMPValue)
                    {
                        MobCount = Int32.Parse(TEMP);
                        TEMP = "Okay";
                    }
                }
                if ((TEMP != "Okay") && (TEMP != null)) throw new Exception("Ой пиздеееец. Все упало!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #region Стартовая генерация игрока, мобов и карты
            //Создание карты и заполнение ее пустыми значениями
            BattleLogic.CreateMap();

            //Создание игрока
            IPerson Player = new Player("Li", 1000, 10, "N");
            BattleLogic.PlayerPositioning(Player, x: 4, y: 4);
            Player.ClosePoints = new PointsAround(Player.Position);

            //Генерация мобов и расставление их на карте, параметры мобов по дефолту
            BattleLogic.MobGenerator();

            //Отображение карты
            BattleLogic.ShowMap();
            #endregion

            //
            while ((Player.Health > 0) && (Mobs[0] != null))
            {
                Console.WriteLine("Введите M, чтобы шагать. Введите А, чтобы атаковать. Введите S, чтобы искать. Введите R, чтобы повернуть голову. Не вводите ничего иного. Ибо эксепшны еще не прописаны.");
                string tempAction = Console.ReadLine();
                if (tempAction == "M")
                {
                    Console.WriteLine("Куда? Жмякни по стрелкам и будет тебе щастье");
                    if (Console.ReadKey().Key == ConsoleKey.UpArrow) Player.MovePlayer("N");
                    else if (Console.ReadKey().Key == ConsoleKey.DownArrow) Player.MovePlayer("S");
                    else if (Console.ReadKey().Key == ConsoleKey.LeftArrow) Player.MovePlayer("W");
                    else if (Console.ReadKey().Key == ConsoleKey.RightArrow) Player.MovePlayer("E");
                    else Console.WriteLine("Еблан! Я ж сказал только стрелки(!)");
                }
                if (tempAction == "A")
                {
                    foreach (Mob SelectesMob in Mobs)
                    {
                        if (((SelectesMob.Position.x == (Player.Position.x - 1)) && (SelectesMob.Position.y == Player.Position.y) && (SelectesMob.SightDirection == "E")) |
                    ((SelectesMob.Position.x == (Player.Position.x + 1)) && (SelectesMob.Position.y == Player.Position.y) && (SelectesMob.SightDirection == "W")) |
                    ((SelectesMob.Position.x == Player.Position.x) && (SelectesMob.Position.y == (Player.Position.y - 1)) && (SelectesMob.SightDirection == "S")) |
                    ((SelectesMob.Position.x == Player.Position.x) && (SelectesMob.Position.y == (Player.Position.y + 1)) && (SelectesMob.SightDirection == "N")))
                        {
                            Player.Attack(SelectesMob);
                        }
                    }
                    if (tempAction == "R")
                    {
                        Console.WriteLine("Куда? Жмякни по стрелкам и будет тебе щастье");
                        bool tempCheck = false;
                        while (!tempCheck)
                        {
                            if ((Console.ReadKey().Key == ConsoleKey.UpArrow) && (Player.SightDirection != "N"))
                            {
                                Player.Rotate("N");
                                tempCheck = true;
                            }
                            else if ((Console.ReadKey().Key == ConsoleKey.DownArrow) && (Player.SightDirection != "S"))
                            {
                                Player.Rotate("S");
                                tempCheck = true;
                            }
                            else if ((Console.ReadKey().Key == ConsoleKey.LeftArrow) && (Player.SightDirection != "W"))
                            {
                                Player.Rotate("W");
                                tempCheck = true;
                            }
                            else if ((Console.ReadKey().Key == ConsoleKey.RightArrow) && (Player.SightDirection != "E"))
                            {
                                Player.Rotate("E");
                                tempCheck = true;
                            }
                            else Console.WriteLine("Еблан! Я ж сказал только стрелки(!)");


                        }
                    }
                }
                else if (tempAction == "S")
                {   
                   

                }

                Console.Read();
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Del d = BattleLogic.MobAction;
                    BattleLogic.ShowMap();

                };
                //
            }
        }
    }
}
