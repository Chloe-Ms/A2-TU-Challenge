using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public class MyMathImplementation
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static bool IsGenericListInOrder(List<int> list, Func<int, int, int> isInOrder)
        {
            bool res = true;
            int i = 0;
            while (i < list.Count - 1 && res)
            {
                res = isInOrder(list[i], list[i + 1]) == 1 || isInOrder(list[i], list[i + 1]) == 0;
                i++;
            }
            return res;
        }

        public static List<int> GenericSort(List<int> toSort, Func<int, int, int> isInOrder)
        {
            while (!IsGenericListInOrder(toSort, isInOrder))
            {
                for (int i = 0; i < toSort.Count - 1; i++)
                {
                    if (isInOrder(toSort[i], toSort[i + 1]) == -1)
                    {
                        int temp = toSort[i];
                        toSort[i] = toSort[i + 1];
                        toSort[i + 1] = temp;
                    }
                }
            }
            return toSort;
        }

        public static List<int> GetAllPrimary(int a)
        {
            List<int> list = new List<int>();
            for (int i = 2;i <= a; i++)
            {
                if (IsPrimary(i))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public static bool IsDivisible(int a, int b)
        {
            return a % b == 0;
        }

        public static bool IsEven(int a)
        {
            return a % 2 == 0;
        }

        public static int IsInOrder(int a, int b)
        {
            if(a == b)
            {
                return 0;
            } else if(a > b)
            {
                return -1;
            } else
            {
                return 1;
            }
            
        }

        public static int IsInOrderDesc(int arg1, int arg2)
        {
            if (arg1 == arg2)
            {
                return 0;
            }
            else if (arg1 > arg2)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public static bool IsListInOrder(List<int> list)
        {
            bool res = true;
            int i = 0;
            while (i < list.Count - 1 && res)
            {
                res = IsInOrder(list[i], list[i+1]) == 1 || IsInOrder(list[i], list[i + 1]) == 0;
                i++;
            }
            return res;
        }

        public static bool IsMajeur(int age)
        {
            if (age < 0 ||age >= 150)
            {
                throw new ArgumentException();
            }
            return age >= 18;
        }

        public static bool IsPrimary(int a)
        {
            bool res = false;
            int i = 2;
            while (i < a && !res)
            {
                res = IsDivisible(a, i);
                i++;
            }
            return !res;
        }

        public static int Power(int a, int b)
        {
            int res = a;
            for (int i = 1;i < b; i++)
            {
                res *= a;
            }
            return res;
        }

        public static int Power2(int a)
        {
            return a * a;
        }

        public static List<int> Sort(List<int> toSort)
        {
            while (!IsListInOrder(toSort))
            {
                for (int i = 0;i < toSort.Count - 1;i++)
                {
                    if(IsInOrder(toSort[i], toSort[i + 1]) == -1)
                    {
                        int temp = toSort[i];
                        toSort[i] = toSort[i + 1];
                        toSort[i + 1] = temp;
                    }
                }
            }
            return toSort;
        }
    }
}
