﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;

using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly ICollection<IBakedFood> foodOrders;
        private readonly ICollection<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;

        public Table()
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
            :this()
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => PricePerPerson * NumberOfPeople;


        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal bill = Price + drinkOrders.Select(x => x.Price).Sum() + foodOrders.Select(x => x.Price).Sum() ;

            return bill;
        }

        public void Clear()
        {
            drinkOrders.Clear();
            foodOrders.Clear();

            IsReserved = false;
            capacity = 0;
        }


        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }


    }
}
