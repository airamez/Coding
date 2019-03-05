using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class FruitsIntoBaskets
    {
        /// <summary>
        /// In a row of trees, the i-th tree produces fruit with type tree[i].
        /// You start at any tree of your choice, then repeatedly perform the following steps:
        ///     1 - Add one piece of fruit from this tree to your baskets.If you cannot, stop.
        ///     2 - Move to the next tree to the right of the current tree.  If there is no tree to the right, stop.
        /// Note that you do not have any choice after the initial choice of starting tree: you must perform step 1, then step 2, 
        /// then back to step 1, then step 2, and so on until you stop.
        /// You have two baskets, and each basket can carry any quantity of fruit, but you want each basket to only carry one type of fruit each.
        /// What is the total amount of fruit you can collect with this procedure?
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine(totalFruits(new int[] {1,2,1 }));
            Console.WriteLine(totalFruits(new int[] { 0, 1, 2, 2 }));
            Console.WriteLine(totalFruits(new int[] { 1, 2, 3, 2, 2 }));
            Console.WriteLine(totalFruits(new int[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 }));
            Console.WriteLine(totalFruits(new int[] { 0, 1, 1, 2 }));
            Console.WriteLine(totalFruits(new int[] { 1, 0, 1, 4, 1, 4, 1, 2, 3 }));
            Console.WriteLine(totalFruits(new int[] { 0, 0, 5, 0, 0, 1, 0, 4, 0, 4 }));
            Console.WriteLine(totalFruits(new int[] { 0, 1, 6, 6, 4, 4, 6 })); // 5
            Console.WriteLine(totalFruits(new int[] { 6, 2, 1, 1, 3, 6, 6 })); // 3
    }

        private static int totalFruits(int[] trees)
        {
            if (trees == null || trees.Length == 0) {
                return 0;
            }
            Basket basket1 = null;
            Basket basket2 = null;
            int max = 0;
            int lastFruitSequence = 1;
            foreach (int fruit in trees) {
                if (basket1 == null) {
                    basket1 = new Basket(fruit);
                } else if (fruit == basket1.Fruit) {
                    lastFruitSequence = 1;
                    if (basket2 == null) {
                        basket1.Count++;
                    } else {
                        basket1.Count++;
                        Basket aux = basket1;
                        basket1 = basket2;
                        basket2 = aux;
                    }
                } else if (basket2 == null) {
                    lastFruitSequence = 1;
                    basket2 = new Basket(fruit);
                } else if (fruit == basket2.Fruit) {
                    basket2.Count++;
                    lastFruitSequence++;
                } else {
                    basket1 = basket2;
                    basket1.Count = lastFruitSequence;
                    lastFruitSequence = 1;
                    basket2 = new Basket(fruit);
                }
                max = Math.Max(max, basket1.Count + (basket2 == null ? 0 : basket2.Count));
            }

            return max;
        }
    }

    public class Basket
    {
        public int Fruit { set; get; }
        public int Count { set; get; }
        public Basket(int fruit)
        {
            this.Fruit = fruit;
            this.Count = 1;
        }
    }
}
