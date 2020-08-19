using data_product.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace data_product
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> listprod = new List<Product>();

            Console.Write("Enter the number of products: ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"Product {i} data:");

                Console.Write("Common, used or imported? (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name_input = Console.ReadLine();

                Console.Write("Price: ");
                double price_input = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date_input = DateTime.Parse(Console.ReadLine());

                    listprod.Add(new UsedProduct(name_input, price_input, date_input));
                }

                else if (ch == 'i')
                {
                    Console.Write("Custom fee: ");
                    double fee_input = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    listprod.Add(new ImportedProduct(name_input, price_input, fee_input));
                }

                else
                {
                    listprod.Add(new Product(name_input, price_input));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");

            foreach (Product prod in listprod)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}