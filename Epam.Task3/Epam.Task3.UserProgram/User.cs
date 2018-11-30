using System;

namespace Epam.Task3.User
{
    public class User
    {
        private string surname;
        private string name;
        private string patronymic;
        private DateTime birthday;

        public string Surname
        {
            get
            {
                if (this.surname == null)
                {
                    throw new ArgumentException("The surname is not defined.", nameof(this.Surname));
                }

                return this.surname;
            }

            set
            {
                StringCheck(value);

                this.surname = value;
            }
        }

        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    throw new ArgumentException("The name is not defined.", nameof(this.Name));
                }

                return this.name;
            }

            set
            {
                StringCheck(value);

                this.name = value;
            }
        }

        public string Patronymic
        {
            get
            {
                if (this.patronymic == null)
                {
                    throw new ArgumentException("The patronymic is not defined.", nameof(this.Patronymic));
                }

                return this.patronymic;
            }

            set
            {
                StringCheck(value);

                this.patronymic = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                if (this.birthday == DateTime.MinValue)
                {
                    throw new ArgumentException("The birthday is not defined.");
                }

                return this.birthday;
            }

            set
            {
                BirthdayCheck(value);

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

        private static bool BirthdayCheck(DateTime dt)
        {
            DateTime today = DateTime.Now;

            if (dt.Year > today.Year)
            {
                throw new ArgumentException("The user is not born yet. The year of birth must be at least same as this year or less.");
            }

            if (dt.Year == today.Year && dt.Month > today.Month)
            {
                throw new ArgumentException("The user is not born yet. The month of birth must be at least same as this month or less.");
            }

            if (dt.Year == today.Year &&
                dt.Month == today.Month &&
                dt.Day > today.Day)
            {
                throw new ArgumentException("The user is not born yet. The day of birth must be at least same as this day or less.");
            }

            return true;
        }

        private static int AgeCalculation(DateTime dt)
        {
            DateTime today = DateTime.Now;

            int a = (((today.Year * 100) + today.Month) * 100) + today.Day;
            int b = (((dt.Year * 100) + dt.Month) * 100) + dt.Day;

            int age = (a - b) / 10000;

            return age;
        }

        private static bool StringCheck(string value)
        {
            char[] arr = value.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!char.IsLetter(arr[i]) && !char.IsWhiteSpace(arr[i]))
                {
                    throw new ArgumentException("Invalid characters. The name, surname or patronymic must contain only letters and white spaces.");
                }
            }

            return true;
        }
    }
}