using System;

namespace Epam.Task3.UserProgram
{
    public class User
    {
        private string surname;
        private string name;
        private string middleName;
        private DateTime birthday;

        public string Surname
        {
            get => this.surname;

            set
            {
                StringCheck(value);

                this.surname = value;
            }
        }

        public string Name
        {
            get => this.name;

            set
            {
                StringCheck(value);

                this.name = value;
            }
        }

        public string MiddleName
        {
            get => this.middleName;

            set
            {
                MiddleNameCheck(value);

                this.middleName = value;
            }
        }

        public DateTime Birthday
        {
            get => this.birthday;

            set
            {
                DateCheck(value);

                this.birthday = value;
            }
        }

        public int Age
        {
            get
            {
                int age = AgeCalculation(this.Birthday);

                return age;
            }
        }

        protected static bool DateCheck(DateTime dt)
        {
            DateTime today = DateTime.Now;

            if (dt.Year > today.Year)
            {
                throw new ArgumentException("Invalid date. The year of must be at least same as this year or less.");
            }

            if (dt.Year == today.Year && dt.Month > today.Month)
            {
                throw new ArgumentException("Invalid date. The month must be at least same as this month or less.");
            }

            if (dt.Year == today.Year &&
                dt.Month == today.Month &&
                dt.Day > today.Day)
            {
                throw new ArgumentException("Invalid date. The day must be at least same as this day or less.");
            }

            return true;
        }

        protected static bool StringCheck(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("This field is required.");
            }

            if (value.Length == 1)
            {
                if (!char.IsLetter(value[0]))
                {
                    throw new ArgumentException("Value mustn't consist of only white spaces.");
                }
            }

            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetter(value[i]) && !char.IsWhiteSpace(value[i]))
                {
                    throw new ArgumentException("Invalid characters. Value must contain only letters and white spaces.");
                }
            }

            int whiteSpaceCount = 0;

            for (int i = 1; i < value.Length; i++)
            {
                if (char.IsWhiteSpace(value[i]) && 
                    char.IsWhiteSpace(value[i - 1]))
                {
                    whiteSpaceCount++;
                }

                if (whiteSpaceCount > 0)
                {
                    throw new ArgumentException("Value mustn't consist of only white spaces.");
                }
            }

            return true;
        }

        protected static int AgeCalculation(DateTime dt)
        {
            DateTime today = DateTime.Now;

            int a = (((today.Year * 100) + today.Month) * 100) + today.Day;
            int b = (((dt.Year * 100) + dt.Month) * 100) + dt.Day;

            int age = (a - b) / 10000;

            return age;
        }

        protected static bool MiddleNameCheck(string value)
        {
            if (value.Length == 1)
            {
                if (!char.IsLetter(value[0]))
                {
                    throw new ArgumentException("Value mustn't consist of only white spaces.");
                }
            }

            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetter(value[i]) && !char.IsWhiteSpace(value[i]))
                {
                    throw new ArgumentException("Invalid characters. Value must contain only letters and white spaces.");
                }
            }

            int whiteSpaceCount = 0;

            for (int i = 1; i < value.Length; i++)
            {
                if (char.IsWhiteSpace(value[i]) &&
                    char.IsWhiteSpace(value[i - 1]))
                {
                    whiteSpaceCount++;
                }

                if (whiteSpaceCount > 0)
                {
                    throw new ArgumentException("Value mustn't consist of only white spaces.");
                }
            }

            return true;
        }
    }
}