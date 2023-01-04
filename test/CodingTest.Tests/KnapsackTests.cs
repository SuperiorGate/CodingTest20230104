using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingTest.Tests
{
    [TestClass]
    public class KnapsackTests
    {
        [TestMethod]
        public void AddItemsTest()
        {
            // 重さ当たりの価値が高い
            // 重さ当たり価値が高い順に入れた場合は 81 となり、最適解と違う数値となるパラメータを渡す
            var items = new (int weight, int value)[]
            {            // 重さ当たりの価値
                (3, 36), // 12
                (5, 45), // 9
                (3, 27), // 9
                (4, 32), // 8
            };

            var target = new Knapsack();

            var actual = target.AddItems(items, 10);

            Assert.AreEqual(95, actual);
        }
    }
}
