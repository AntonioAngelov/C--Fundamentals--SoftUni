namespace _13.OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            // storage
            SortedDictionary<string, Dictionary<string, int>> companyOrders = new SortedDictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                // order input
                string[] order = Console.ReadLine().Split(new char[] { '|', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                FillDictionary(order, companyOrders);
            }

            // print
            Print(companyOrders);
        }

        private static void Print(SortedDictionary<string, Dictionary<string, int>> companyOrders)
        {
            // this list prepares the results for final formating
            List<string> result = new List<string>();

            foreach (var pair1 in companyOrders)
            {
                Console.Write("{0}: ", pair1.Key);

                result.AddRange(pair1.Value.Select(pair2 => String.Format("{0}-{1}", pair2.Key, pair2.Value)));
                Console.WriteLine(string.Join(", ", result));
                result.Clear();
            }
        }

        private static void FillDictionary(string[] order, SortedDictionary<string, Dictionary<string, int>> companyOrders)
        {
            string company = order[0];
            string product = order[2];
            int amount = int.Parse(order[1]);

            // storing the order details into the dictionary 
            if (!companyOrders.ContainsKey(company))
            {
                Dictionary<string, int> products = new Dictionary<string, int>();
                products.Add(product, 0);

                companyOrders.Add(company, products);
            }
            else if (!companyOrders[company].ContainsKey(product))
            {
                companyOrders[company].Add(product, 0);
            }
            companyOrders[company][product] += amount;
        }
    }
}
