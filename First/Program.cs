using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace First
{
    public class Program
    {
        //Карта
        public static string[][] Map;

        //Количество мобов, задается вначале игры
        public static int MobCount;

        //Внутренние переменные
        public static string TEMP;
        public static int[] coordinates;

        /// <summary>
        /// Список для хранения объектов мобов
        /// </summary>
        public static List<Mob> Mobs = new List<Mob>();

        /// <summary>
        /// Направления
        /// </summary>
        public static Dictionary<ConsoleKey, string> Directions = 
            new Dictionary<ConsoleKey, string> {
                { ConsoleKey.UpArrow, "N" },
                { ConsoleKey.DownArrow, "S" },
                { ConsoleKey.LeftArrow, "W" },
                { ConsoleKey.RightArrow, "E" }
            };


        //---------------------------ToDo - Допилить
        //public static List<List<string>> inputCommand =
        //    new List<List<string>>
        //    {
        //        new List<string> {"ATTACK", "ЕБАШЬ" },
        //        new List<string> {"MOVE",  "I LIKE TO MOVE IT MOVE IT", "Пшел" },
        //        new List<string> {"ROTATE", "Оглянись бро" }
        //    };

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

                List<string> TEMPList = new List<string> {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
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
            Map = BattleLogic.CreateMap(10,10);

            //Создание игрока
            IPerson Player = new Player("Li", 1000, 10, "N");
            BattleLogic.PlayerPositioning(Player, x : 4, y : 4);

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
                bool completeAction = false;

                while (!completeAction)
                {
                    completeAction = false;
                    #region I like to move move it
                    if (tempAction == "M")
                    {
                        bool rightEnter = false;
                        while (!rightEnter)
                        {
                            Console.WriteLine("Введите направление стрелками");
                            ConsoleKey enteredKey = Console.ReadKey().Key;
                            rightEnter = Directions.ContainsKey(enteredKey);
                            if (rightEnter)
                            {
                                Player.Move(Directions[Console.ReadKey().Key]);
                                completeAction = true;
                            }
                            else if (!rightEnter) Console.WriteLine("Еблан! Я ж сказал только стрелки(!)");
                        }
                        BattleLogic.ShowMap();
                    }
                    #endregion
                    #region Do u like it?
                    else if (tempAction == "A")
                    {
                        if (Map[BattleLogic.SightPoint(Player)[0]][BattleLogic.SightPoint(Player)[1]] == "M")
                        {
                            foreach (Mob PoorMob in Mobs)
                            {
                                if ((PoorMob.Position.x == BattleLogic.SightPoint(Player)[0]) && (PoorMob.Position.y == BattleLogic.SightPoint(Player)[1])) Player.Attack(PoorMob);
                                completeAction = true;
                            }
                        }
                        else Console.WriteLine("Еблан!"); ;
                }
                    #endregion
                    #region Somethin behind u...
                    else if (tempAction == "R")
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
                    #endregion
                    BattleLogic.MobsAction(Player, Mobs);
                }
            }
            Console.Read();
       
            //
        }
    }
}
