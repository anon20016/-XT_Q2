using System;

namespace Task2_4
{
    public class MyString
    {
        private char[] mystring;
        private int length;

        public MyString(char[] mystring)
        {
            Mystring = mystring;
            Length = mystring.Length;
        }

        public MyString(string arr)
        {
            mystring = arr.ToCharArray();
            Length = mystring.Length;
        }

        public char[] Mystring { get => mystring; private set { mystring = value; } }
        public int Length { get => length; set { length = value; } }

        public char this[int idx]
        {
            get
            {
                if (idx > this.Length || idx < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.Mystring[idx];
            }
            set
            {
                if (idx > this.Length || idx < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                this.Mystring[idx] = value;
            }
        }

        public static MyString operator +(MyString str1, MyString str2)
        {
            char[] str3 = new char[str1.Length + str2.Length];
            str1.Mystring.CopyTo(str3, 0);
            str2.Mystring.CopyTo(str3, str1.Length);
            return new MyString(str3);
        }

        public static bool operator <(MyString str1, MyString str2)
        {
            for (int i = 0; i < Math.Min(str1.Length, str2.Length); i++)
            {
                if (str1.Mystring[i] < str2.Mystring[i])
                {
                    return true;
                }
                else if (str1.Mystring[i] > str2.Mystring[i])
                {
                    return false;
                }
            }
            return str1.Length < str2.Length;
        }

        public static bool operator >(MyString str1, MyString str2)
        {
            for (int i = 0; i < Math.Min(str1.Length, str2.Length); i++)
            {
                if (str1.Mystring[i] > str2.Mystring[i])
                {
                    return true;
                }
                else if (str1.Mystring[i] < str2.Mystring[i])
                {
                    return false;
                }
            }

            return str1.Length > str2.Length;
        }

        public static bool operator ==(MyString str1, MyString str2)
        {
            if (str1.Mystring.Length != str2.Mystring.Length)
            {
                return false;
            }

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1.Mystring[i] != str2.Mystring[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(MyString str1, MyString str2)
        {
            return !(str1 == str2);
        }

        public static explicit operator string(MyString str) => new string(str.Mystring);

        public static implicit operator MyString(string str) => new MyString(str);

        public static explicit operator char[] (MyString str) => str.Mystring;

        public static implicit operator MyString(char[] mystring) => new MyString(mystring);

        public int IndexOf(char ch)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this.Mystring[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

       
        public override string ToString()
        {
            return new string(Mystring);
        }

        public override bool Equals(object obj)
        {
            try
            {
                MyString myString = obj as MyString;
                return this.Mystring == myString.Mystring;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
            }
        }
    }
}
