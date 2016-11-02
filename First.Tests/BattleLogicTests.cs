using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace First.Tests
{
    [TestClass]
    public class BattleLogicTests
    {
        //[ManualParameters]
        private int mapWidth  = 10;
        private int mapLength = 10;

        //[Objects]
        private string[][] Map;

        [TestInitialize]
        public void TestInitialize()
        {
            Map = BattleLogic.CreateMap(mapWidth, mapLength);
        }

        [TestMethod]
        public void Test_RandomCoordinates_CheckingRandom()
        {
            List<int[]> Result = new List<int[]>();
            for (int i = 0; i < 10; i++) Result.Add(BattleLogic.RandomCoordinates(50));
            foreach (var Coordinate in Result)
            {
                foreach (var ComparingItem in Result)
                {
                    if (Result.IndexOf(Coordinate) != Result.IndexOf(ComparingItem)) Assert.AreNotEqual(Coordinate, ComparingItem);
                }
            }
        }

        [TestMethod]
        public void Test_CreateMap_CheckingFilling()
        {
            for (int i = 0; i < Map.Length; i++)
            {
                for (int j = 0; j < Map[i].Length; j++) Assert.AreEqual(Map[i][j], "N");
            }
            
        }

        [TestMethod]
        public void Test_PlayerPositioning()
        {

        }
    }
}
