using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public class MyStringImplementation
    {
        public static string BazardString(string input)
        {
            string start = "",end = "";
            for (int i = 0; i < input.Length; i++)
            {
                if(i % 2 == 0)
                {
                    start += input[i];
                } else
                {
                    end += input[i];
                }
            }
            return start+end;
        }

        public static bool IsNullEmptyOrWhiteSpace(string input)
        {
            return String.IsNullOrWhiteSpace(input); 
        }

        public static string MixString(string a, string b)
        {
            if (IsNullEmptyOrWhiteSpace(a) || IsNullEmptyOrWhiteSpace(b))
            {
                throw new ArgumentException();
            }
            string mix = "";
            int i = 0;
            while (i < a.Length || i < b.Length)
            {
                if (i < a.Length)
                {
                    mix = mix + a[i];
                }
                if (i < b.Length)
                {
                    mix = mix + b[i];
                }
                i++;
            }
            return mix;
        }

        public static string Reverse(string a)
        {
            char[] charArray = a.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static char ToCesarCodeWithLimits(char c, int offset, char min, char max)
        {
            char res;
            if (c + offset > max)
            {
                res = (char)(c + offset - (max + 1) + min);
            }
            else if (c + offset < min)
            {
                res = (char)(c + offset + max + 1 - min);
            }
            else
            {
                res = (char)(c + offset);
            }
            return res;
        }
        public static string ToCesarCode(string input, int offset)
        {

            char[] code = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 'A' && input[i] <= 'Z')
                {
                    code[i] = ToCesarCodeWithLimits(input[i], offset,'A','Z');
                }
                else if (input[i] >= 'a' && input[i] <= 'z')
                {
                    code[i] = ToCesarCodeWithLimits(input[i], offset, 'a', 'z');
                }
                else
                {
                    code[i] = input[i];
                }
            }

            return String.Concat(code);
        }

        public static string ToLowerCase(string a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                if ((a[i] >= 'A' && a[i] <= 'Z') || (a[i] >= 'À' && a[i] <= 'Ý'))
                {
                    a = a.Replace(a[i], (char)(a[i] + 32));
                }
            }
                
            return a;
        }

        public static string UnBazardString(string input)
        {
            char[] str = new char[input.Length];
            int i = 0;
            foreach(char c in input)
            {
                str[i] = c;
                i += 2;
                if (i >= input.Length)
                {
                    i = 1;
                }
            }
            return String.Concat(str);
        }

        public static bool IsAVowel(char c)
        {
            string vowels = "aeiouy";
            return vowels.Contains(c);
        }
        public static string Voyelles(string a)
        {
            string lowercase = ToLowerCase(a);
            List<char> list = new List<char>();
            foreach(char c in lowercase)
            {
                if (IsAVowel(c) && !list.Contains(c))
                {
                    list.Add(c);
                }
            }
            return String.Concat(list);
        }
    }
}
