using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MyString
{
    public class MyString : IEquatable<MyString>, IComparable<MyString>, IComparable
    {
        private char[] chars;

        public static readonly string Empty = "";

        public int Length { get; private set; }

        private MyString()
        {
            this.chars = new char[0];

            this.Length = 0;
        }

        private MyString(int length)
        {
            this.chars = new char[length];

            this.Length = length;
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

            string result = o1.ToString();

            myString = new MyString(result);

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

            string result = o1.ToString() + o2.ToString();

            myString = new MyString(result);

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

            string result = o1.ToString() + o2.ToString() + o3.ToString();

            myString = new MyString(result);

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

        public static MyString Concat(MyString ms1, MyString ms2, MyString ms3)
        {
            MyString myString;

            if (ms1 == null && ms2 == null && ms3 == null)
            {
                return myString = new MyString();
            }

            if (ms1 == null && ms2 == null)
            {
                return myString = ms3;
            }

            if (ms1 == null && ms3 == null)
            {
                return myString = ms2;
            }

            if (ms2 == null && ms3 == null)
            {
                return myString = ms1;
            }

            if (ms1 == null)
            {
                myString = MyString.Concat(ms2, ms3);
            }

            if (ms2 == null)
            {
                myString = MyString.Concat(ms1, ms3);
            }

            if (ms3 == null)
            {
                myString = MyString.Concat(ms1, ms2);
            }

            string result = ms1.ToString() + ms2.ToString() + ms3.ToString();

            myString = new MyString(result);

            return myString;
        }

        public static MyString Concat(params MyString[] args)
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

        public bool Contains(MyString value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value is null.");
            }

            bool check = false;

            for (int i = 0; i <= this.Length - value.Length; i++)
            {
                if (this[i] == value[0])
                {
                    int index = i;
                    int j;

                    for (j = 0; j < value.Length; j++)
                    {
                        if (this[index] != value[j])
                        {
                            break;
                        }

                        index++;
                    }

                    if (j == value.Length)
                    {
                        check = true;
                        break;
                    }
                }
            }

            return check;
        }

        public static MyString Copy(MyString value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value is null.");
            }

            string result = value.ToString();

            return new MyString(result);
        }

        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            if (destination == null)
            {
                throw new ArgumentNullException("Destination array is null.");
            }

            if (sourceIndex < 0 ||
                destinationIndex < 0 ||
                count < 0 ||
                sourceIndex > this.Length - 1 ||
                destinationIndex > destination.Length - 1 ||
                count + sourceIndex > this.Length ||
                count + destinationIndex > destination.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            for (int i = 0; i < count; i++)
            {
                destination[destinationIndex + i] = this[sourceIndex + i];
            }
        }

        public bool EndsWith(MyString value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value is null.");
            }

            for (int i = this.Length - 1, j = value.Length - 1; j >= 0 ; i--, j--)
            {
                if (this[i] != value[j])
                {
                    return false;
                }
            }

            return true;
        }

        public int IndexOf(char ch)
        {
            return this.IndexOf(ch, 0);
        }

        public int IndexOf(char ch, int startIndex)
        {
            return this.IndexOf(ch, startIndex, this.Length - startIndex);
        }

        public int IndexOf(char ch, int startIndex, int count)
        {
            if (startIndex < 0 ||
                count < 0 ||
                startIndex >= this.Length ||
                startIndex + count > this.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            for (int i = startIndex; i < count; i++)
            {
                if (this[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(MyString value)
        {
            return this.IndexOf(value, 0);
        }

        public int IndexOf(MyString value, int startIndex)
        {
            return this.IndexOf(value, startIndex, this.Length - startIndex);
        }

        public int IndexOf(MyString value, int startIndex, int count)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value is null.");
            }

            if (startIndex < 0 ||
                count < 0 ||
                startIndex >= this.Length ||
                startIndex + count > this.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            bool check = false;

            int i;

            for (i = startIndex; i <= count - value.Length; i++)
            {
                if (this[i] == value[0])
                {
                    int index = i;
                    int j;

                    for (j = 0; j < value.Length; j++)
                    {
                        if (this[index] != value[j])
                        {
                            break;
                        }

                        index++;
                    }

                    if (j == value.Length)
                    {
                        check = true;
                        break;
                    }
                }
            }

            if (check)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }

        public int IndexOfAny(char[] anyOf)
        {
            return this.IndexOfAny(anyOf, 0);
        }

        public int IndexOfAny(char[] anyOf, int startIndex)
        {
            return this.IndexOfAny(anyOf, startIndex, this.Length - startIndex);
        }

        public int IndexOfAny(char[] anyOf, int startIndex, int count)
        {
            if (anyOf == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (startIndex < 0 ||
                count < 0 ||
                startIndex >= this.Length ||
                startIndex + count > this.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            int i;

            for (i = startIndex; i < count + startIndex; i++)
            {
                for (int j = 0; j < anyOf.Length; j++)
                {
                    if (this[i] == anyOf[j])
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        
        public MyString Insert(int startIndex, MyString value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value is null.");
            }

            if (startIndex < 0 || startIndex > this.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            MyString myString = new MyString(this.Length + value.Length);

            int i = 0;
            int j = 0;
            int k = 0;
            
            while (i < myString.Length)
            {
                if (i == startIndex)
                {
                    while (j < value.Length)
                    {
                        myString.chars[i] = value[j];
                        i++;
                        j++;
                    }
                }

                if (i != startIndex)
                {
                    while (k < this.Length)
                    {
                        myString.chars[i] = this[k];
                        i++;
                        k++;

                        if (i == startIndex)
                        {
                            break;
                        }
                    }
                }
            }

            return myString;
        }

        public int LastIndexOf(char ch)
        {
            return this.LastIndexOf(ch, this.Length - 1);
        }

        public int LastIndexOf(char ch, int startIndex)
        {
            return this.LastIndexOf(ch, startIndex, this.Length - startIndex);
        }

        public int LastIndexOf(char ch, int startIndex, int count)
        {
            if (startIndex < 0 ||
                count < 0 ||
                startIndex >= this.Length ||
                startIndex - count + 1 < 0)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            for (int i = startIndex; i >= 0; i--)
            {
                if (this[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        public int LastIndexOf(MyString value)
        {
            return this.LastIndexOf(value, this.Length - 1);
        }

        public int LastIndexOf(MyString value, int startIndex)
        {
            return this.LastIndexOf(value, startIndex, this.Length - startIndex);
        }

        public int LastIndexOf(MyString value, int startIndex, int count)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value is null.");
            }

            if (startIndex < 0 ||
                count < 0 ||
                startIndex >= this.Length ||
                startIndex - count + 1 < 0)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            bool check = false;

            int i;

            for (i = startIndex; i >= 0; i--)
            {
                if (this[i] == value[0])
                {
                    int index = i;
                    int j;

                    for (j = 0; j < value.Length; j++)
                    {
                        if (this[index] != value[j])
                        {
                            break;
                        }

                        index++;
                    }

                    if (j == value.Length)
                    {
                        check = true;
                        break;
                    }
                }
            }

            if (check)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }

        public int LastIndexOfAny(char[] anyOf)
        {
            return this.LastIndexOfAny(anyOf, this.Length - 1);
        }

        public int LastIndexOfAny(char[] anyOf, int startIndex)
        {
            return this.LastIndexOfAny(anyOf, startIndex, this.Length - startIndex);
        }

        public int LastIndexOfAny(char[] anyOf, int startIndex, int count)
        {
            if (anyOf == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (startIndex < 0 ||
                count < 0 ||
                startIndex >= this.Length ||
                startIndex - count + 1 < 0)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            int i;

            for (i = startIndex; i >= 0; i--)
            {
                for (int j = 0; j < anyOf.Length; j++)
                {
                    if (this[i] == anyOf[j])
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public char[] ToCharArray()
        {
            return this.chars;
        }

        public static implicit operator string(MyString value)
        {
            return value.ToString();
        }

        public static implicit operator StringBuilder(MyString value)
        {
            StringBuilder sb = new StringBuilder(value.ToString());

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

            for (int i = 0; i < this.Length; i++)
            {
                sb.Append(this[i]);
            }

            return result = sb.ToString();
        }

        public override bool Equals(object value)
        {
            string temp = value as string;

            if (temp == null)
            {
                throw new ArgumentNullException("Value is null or not supported type.");
            }

            return this.Equals(temp);
        }

        public bool Equals(MyString value)
        {
            if (object.ReferenceEquals(value, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, value))
            {
                return true;
            }

            if (this.GetType() != value.GetType())
            {
                return false;
            }

            if (this.Length != value.Length)
            {
                return false;
            }

            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != value[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int num = 5381;
            int num2 = num;
            for (int i = 0; i < this.Length; i += 2)
            {
                num = (((num << 5) + num) ^ this[i]);
                if (i + 1 == this.Length)
                {
                    break;
                }
                num2 = (((num2 << 5) + num2) ^ this[i + 1]);
            }
            return num + num2 * 1566083941;
        }

        public static bool operator ==(MyString lhs, MyString rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                if (object.ReferenceEquals(rhs, null))
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(MyString lhs, MyString rhs)
        {
            return !(lhs == rhs);
        }

        public int CompareTo(object value)
        {
            string temp = value as string;

            if (temp == null)
            {
                throw new ArgumentNullException("Value is null or not supported type.");
            }

            return this.CompareTo(temp);
        }

        public int CompareTo(MyString value)
        {
            int min = this.Length < value.Length ? this.Length : value.Length;

            for (int i = 0; i < min; i++)
            {
                if (char.ToUpper(this[i]) < char.ToUpper(value[i]))
                {
                    return -1;
                }

                if (char.ToUpper(this[i]) > char.ToUpper(value[i]))
                {
                    return 1;
                }
            }

            if (this.Length < value.Length)
            {
                return -1;
            }

            if (this.Length > value.Length)
            {
                return 1;
            }

            if (char.IsLower(this[0]) && char.IsLower(value[0]))
            {
                return 0;
            }

            if (char.IsLower(this[0]))
            {
                return -1;
            }

            if (char.IsLower(value[0]))
            {
                return 1;
            }

            return 0;
        }
    }
}
