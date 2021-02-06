﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Date_Modifier
{
    public class DateModifier
    {
        private DateTime startDate;
        private DateTime endDate;

        public DateModifier(DateTime startDate, DateTime endDate)
        {
            this.endDate = endDate;
            this.startDate = startDate;
        }

        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        public DateTime EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value; }
        }

        public void GetTimeBetweenDates()
        {
            double days = Math.Abs((this.startDate - this.endDate).TotalDays);

            Console.WriteLine(days);
        }
    }
}
