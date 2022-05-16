using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progterv_mintak_beadando

    // Neptun ID: B5T3ZN

    // Used design patterns:
    //                          Factory: creating Food and Drink instances -- line 37 and 54
    //                          Facade: write/read list elements to/from JSON file (test.json) and increasing, decreasing price -- line 68, 71, 85, 87, 97, 99 and 107
    //                          Decorator: print the elements to console -- line 77, 89, 90, 101, 102, 116
    //                          Iterator: processing the list (hasNext, getProduct) -- line 74, 75, 77, 80, 81

{
    class Program
    {
        static void Main(string[] args)
        {
            JSONHandler jsonHandler = new JSONHandler();
            List<Product> products = new List<Product>();
            ProductFactory factory = new ProductFactory();

            Random random = new Random();

            int pieceOfFoods = 0;
            do
            {
                Console.WriteLine("How many foods do you want to generate? (min. 5)");
                pieceOfFoods = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < pieceOfFoods; i++)
                {
                    Product product = factory.GetInstance("food");
                    product.SetName("Food " + (i + 1));
                    product.SetPrice(random.Next(1000, 25000));
                    product.SetStock(random.Next(5, 25));
                    ((Food)product).SetWeight(random.NextDouble() * (7.5 - 0.1) + 0.1);
                    ((Food)product).SetExpiration(new DateTime(random.Next(2022, 2026), random.Next(1, 12), random.Next(1, 28)));
                    products.Add(product);
                }
            } while (pieceOfFoods < 5);

            int pieceOfDrinks = 0;
            do
            {
                Console.WriteLine("\nHow many drinks do you want to generate? (min. 5)");
                pieceOfDrinks = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < pieceOfDrinks; i++)
                {
                    Product product = factory.GetInstance("drink");
                    product.SetName("Drink " + (i + 1));
                    product.SetPrice(random.Next(1000, 25000));
                    product.SetStock(random.Next(5, 25));

                    ((Drink)product).SetCapacity(random.NextDouble() * (2.0 - 0.33) + 0.33);
                    ((Drink)product).SetDrinkPackaging(random.Next(0, 1));
                    ((Drink)product).SetAlcoholVolume(random.NextDouble() * (72.0 - 0.0) + 0.0);

                    products.Add(product);
                }
            } while(pieceOfDrinks < 5);
           
            // write the elements of generated list to json (facade)           
            jsonHandler.WriteToJSON(products);

            Console.WriteLine("Read in from JSON file:\n");
            List<Product> jsonProducts = jsonHandler.ReadFromJSON("../../", "test.json");

            // using iterator and decorator to print the elements
            ProductIterator iterator = new ProductIterator(jsonProducts); 
            while (iterator.HasNext())
            {
                iterator.GetProduct().DisplayProduct();
            }

            iterator.ResetIterator();
            consume(iterator.GetProduct());

            Console.WriteLine("\nIncreasing the price of Food 1 and Drink 5 with 15%:");
            Product product1 = jsonProducts.ElementAt(0);
            product1.IncreasePrice(15);
            Product product2 = jsonProducts.ElementAt(8);
            product2.IncreasePrice(15);

            product1.DisplayProduct();
            product2.DisplayProduct();

            products[0] = product1;
            products[8] = product2;

            Console.WriteLine("\nDecreasing the price of Food 2 and Drink 4 with 7%:");
            Product product3 = jsonProducts.ElementAt(1);
            product3.DecreasePrice(7);
            Product product4 = jsonProducts.ElementAt(7);
            product4.DecreasePrice(7);

            product3.DisplayProduct();
            product4.DisplayProduct();

            products[1] = product3; 
            products[7] = product4;

            jsonHandler.WriteToJSON(products);

            Console.ReadKey();
        }

        static void consume(Product p)
        {
            Consumable consumable = new Consumable(p);
            consumable.ConsumeItem("TestFirstName TestLastName");
            consumable.DisplayProduct();
        }
    }
}
