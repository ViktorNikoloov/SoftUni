using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> boxes = new List<Box>();

            while (input != "end")
            {
                string[] data = input.Split().ToArray();
                //{Serial Number} {Item Name} {Item Quantity} {itemPrice}

                Item item = new Item();
                item.Name = data[1];
                item.Price = decimal.Parse(data[3]);

                Box box = new Box();
                box.Item = new Item();
                box.SerialNumber = data[0];
                box.Item.Name = data[1];
                box.ItemQuantity = int.Parse(data[2]);
                box.Item.Price = decimal.Parse(data[3]);
                box.PriceForABox = box.ItemQuantity * box.Item.Price;

                boxes.Add(box);

                input = Console.ReadLine();
            }

            List<Box> boxesAscending = boxes.OrderBy(x => x.PriceForABox).ToList();
            boxesAscending.Reverse();

            foreach (var box in boxesAscending)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox:f2}");
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Box
    {
        //public Box()
        //{
        //    Item = new Item();
        //}

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForABox { get; set; }
        //public decimal Price { get; set; }
    }

}
