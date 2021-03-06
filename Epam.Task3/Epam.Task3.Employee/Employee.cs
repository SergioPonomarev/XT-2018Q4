﻿using System;
using Epam.Task3.UserProgram;

namespace Epam.Task3.Employee
{
    public class Employee : User
    {
        private DateTime startWorkDate;

        private string position;

        public string Position
        {
            get => this.position;

            set
            {
                Employee.StringCheck(value);

                this.position = value;
            }
        }

        public DateTime StartWorkDate
        {
            get => this.startWorkDate;

            set
            {
                Employee.DateCheck(value);

                this.startWorkDate = value;
            }
        }

        public string TimeEmployment
        {
            get
            {
                string te = TimeEmploymentCalculation(this.StartWorkDate);

                return te;
            }
        }

        private static string TimeEmploymentCalculation(DateTime dt)
        {
            DateTime today = DateTime.Now;

            int a = today.Year - dt.Year;
            int b = today.Month - dt.Month;

            string resutl = string.Empty;

            resutl += a == 1
                ? string.Format($"{a.ToString()} year ")
                : string.Format($"{a.ToString()} years ");

            resutl += b == 1
                ? string.Format($"{b.ToString()} month")
                : string.Format($"{b.ToString()} months");

            return resutl;
        }
    }
}
