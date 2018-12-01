using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MyString
{
    public class MyString
    {
        private char[] chars;

        public static readonly string Empty = "";

        public int Length { get; }

        private MyString()
        {
            this.chars = new char[0];

            this.Length = 0;
        }

        private MyString(string str)
        {
            this.chars = str.ToCharArray();

            this.Length = str.Length;
        }

        public MyString(char[] value)
        {
            this.chars = value;

            this.Length = value.Length;
        }

        public MyString(char[] value, int startIndex, int length)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value collection is null.");
            }

            if (((startIndex + length) > value.Length) ||
                (startIndex < 0) ||
                (length < 0))
            {
                throw new ArgumentOutOfRangeException("Index is out of range. Start index and length must be greater than or equal to zero. The sum of start index and length must be less than or equal to elements in value collection.");
            }

            this.chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                this.chars[i] = value[startIndex + i];
            }

            this.Length = length;
        }

        public MyString(char ch, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Count must be greater than or equal to zero.", nameof(count));
            }

            this.chars = new char[count];

            for (int i = 0; i < count; i++)
            {
                this.chars[i] = ch;
            }

            this.Length = count;
        }

        public char this[int index]
        {
            get
            {
                if (index >= this.Length || index < 0)
                {
                    throw new IndexOutOfRangeException("Index is out of range. ");
                }

                return chars[index];
            }
        }

        public static MyString Concat(object o1)
        {
            MyString myString;

            if (o1 == null)
            {
                return myString = new MyString();
            }

            string obj = o1.ToString();

            myString = new MyString(obj);

            return myString;
        }

        public static MyString Concat(object o1, object o2)
        {
            MyString myString;

            if (o1 == null && o2 == null)
            {
                return myString = new MyString();
            }

            if (o1 == null)
            {
                return myString = MyString.Concat(o2);
            }

            if (o2 == null)
            {
                return myString = MyString.Concat(o1);
            }

            string obj = o1.ToString() + o2.ToString();

            myString = new MyString(obj);

            return myString;
        }

        public static MyString Concat(object o1, object o2, object o3)
        {
            MyString myString;

            if (o1 == null && o2 == null && o3 == null)
            {
                return myString = new MyString();
            }

            if (o1 == null && o2 == null)
            {
                return myString = MyString.Concat(o3);
            }

            if (o1 == null && o3 == null)
            {
                return myString = MyString.Concat(o2);
            }

            if (o2 == null && o3 == null)
            {
                return myString = MyString.Concat(o1);
            }

            if (o1 == null)
            {
                return myString = MyString.Concat(o2, o3);
            }

            if (o2 == null)
            {
                return myString = MyString.Concat(o1, o3);
            }

            if (o3 == null)
            {
                return myString = MyString.Concat(o1, o2);
            }

            string obj = o1.ToString() + o2.ToString() + o3.ToString();

            myString = new MyString(obj);

            return myString;
        }

        public static MyString Concat(params object[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("Collection of elements is null.");
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < args.Length; i++)
            {
                sb.Append(args[i].ToString());
            }

            string result = sb.ToString();

            MyString myString = new MyString(result);

            return myString;
        }

        public static MyString Concat(MyString ms1, MyString ms2)
        {
            MyString myString;

            if (ms1 == null && ms2 == null)
            {
                return myString = new MyString();
            }

            if (ms1 == null)
            {
                return myString = ms2;
            }

            if (ms2 == null)
            {
                return myString = ms1;
            }

            string result = ms1.ToString() + ms2.ToString();

            myString = new MyString(result);

            return myString;
        }

        public char[] ToCharArray()
        {
            return this.chars;
        }

        public static implicit operator string(MyString ms)
        {
            return ms.ToString();
        }

        public static implicit operator StringBuilder(MyString ms)
        {
            StringBuilder sb = new StringBuilder(ms.ToString());

            return sb;
        }

        public static implicit operator MyString(string str)
        {
            MyString myString = new MyString(str);

            return myString;
        }

        public static implicit operator MyString(StringBuilder sb)
        {
            MyString myString = new MyString(sb.ToString());

            return myString;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(this.Length);

            string result;

            for (int i = 0; i < this.chars.Length; i++)
            {
                sb.Append(this.chars[i]);
            }

            return result = sb.ToString();
        }
    }
}
