﻿namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal pricePerPerson = 3.50m;

        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, pricePerPerson)
        {

        }
    }
}
