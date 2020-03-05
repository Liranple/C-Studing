using System;

namespace Homework0114
{
    class Program
    {
        //static int?[] Sort(int?[] array1, int size, int select)
        //{
        //    int?[] array2 = new int?[size];
        //    int? min = array1[0];
        //    if (select == 1)
        //    {
        //        for (int i = 0; i < array2.Length; i++)
        //        {
        //            for (int j = 0; j < array1.Length; j++)
        //            {
        //                if (array1[j] != null)
        //                {
        //                    if (min > array1[j])
        //                    {
        //                        min = array1[j];
        //                    }
        //                }
        //            }
        //            array2[i] = min;
        //            for (int j = 0; j < array1.Length; j++)
        //            {
        //                if (min == array1[j])
        //                {
        //                    array1[j] = null;
        //                    break;
        //                }
        //            }
        //            for (int j = 0; j < array1.Length; j++)
        //            {
        //                if (array1[j] != null)
        //                {
        //                    min = array1[j];
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    else if (select == 2)
        //    {
        //        for (int i = 0; i < array2.Length; i++)
        //        {
        //            for (int j = 0; j < array1.Length; j++)
        //            {
        //                if (array1[j] != null)
        //                {
        //                    if (min < array1[j])
        //                    {
        //                        min = array1[j];
        //                    }
        //                }
        //            }
        //            array2[i] = min;
        //            for (int j = 0; j < array1.Length; j++)
        //            {
        //                if (min == array1[j])
        //                {
        //                    array1[j] = null;
        //                    break;
        //                }
        //            }
        //            for (int j = 0; j < array1.Length; j++)
        //            {
        //                if (array1[j] != null)
        //                {
        //                    min = array1[j];
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return array2;
        //}
        static int[] Sort2(int[] array, int i_select)
        {
            int a = 0;
            int b = 0;
            if (i_select == 1)
            {
                for (int n = 0; n < array.Length; n++)
                {
                    a = array[n];
                    b = array[n];
                    for (int i = n; i < array.Length; i++)
                    {
                        if (a > array[i])
                        {
                            a = array[i];
                        }
                    }
                    for (int j = n; j < array.Length; j++)
                    {
                        if (a == array[j])
                        {
                            array[n] = a;
                            array[j] = b;
                            break;
                        }
                    }
                }
            }
            else if (i_select == 2)
                for (int n = 0; n < array.Length; n++)
                {
                    a = array[n];
                    b = array[n];
                    for (int i = n; i < array.Length; i++)
                    {
                        if (a < array[i])
                        {
                            a = array[i];
                        }
                    }
                    for (int j = n; j < array.Length; j++)
                    {
                        if (a == array[j])
                        {
                            array[n] = a;
                            array[j] = b;
                            break;
                        }
                    }
                }
            return array;
        }
        static bool Trans(string str)
        {
            bool able = true;
            try
            {
                int n = int.Parse(str);
            }
            catch
            {
                able = false;
            }
            return able;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("※주의 : 해당프로그램은 얼리억세스 단계이므로 정확한 입력값이 아닐 경우 오류가 발생할 수 있습니다.");
            Console.WriteLine();
            bool reset = true;
            int i_select = 0;
            int i_size = 0;
            int[] array = new int[0];
            while (reset == true)
            {
                Console.WriteLine("--------------- 배열 자동 정렬 프로그램 ---------------");
                Console.WriteLine("배열 차순을 입력해주세요.");
                Console.WriteLine("1. 오름차순");
                Console.WriteLine("2. 내림차순");
                Console.WriteLine("-------------------------------------------------------");
                while (reset == true)
                {
                    Console.Write("배열 차순 : ");
                    string s_select = Console.ReadLine();
                    if (s_select == "1" || s_select == "2")
                    {
                        i_select = int.Parse(s_select);
                        break;
                    }
                    else
                        Console.WriteLine("※오류 : 정확한 값을 입력해주세요");
                }
                while (reset == true)
                {
                    Console.Write("배열의 크기 : ");
                    string s_size = Console.ReadLine();
                    if (Trans(s_size) == true)
                    {
                        i_size = int.Parse(s_size);
                        if (i_size > 0)
                        {
                            array = new int[i_size];
                            break;
                        }
                        else
                            Console.WriteLine("※오류 : 0보다 큰 값을 입력해주세요");
                    }
                    else
                        Console.WriteLine("※오류 : 정확한 값을 입력해주세요");
                }
                for (int i = 0; i < i_size; i++)
                {
                    Console.Write(i + 1 + "번째 숫자 : ");
                    string s_array = Console.ReadLine();
                    if (Trans(s_array) == true)
                    {
                        array[i] = int.Parse(s_array);
                    }
                    else
                    {
                        Console.WriteLine("※오류 : 정확한 값을 입력해주세요");
                        i--;
                    }
                }
                Console.WriteLine();
                if (i_select == 1)
                {
                    int[] sortarray = Sort2(array, 1);
                    Console.WriteLine("오름차순으로 정렬된 숫자입니다");
                    Console.Write("{ ");
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(sortarray[i]);
                        if (i + 1 < array.Length)
                        {
                            Console.Write(", ");
                        }
                    }
                }
                else if (i_select == 2)
                {
                    int[] sortarray = Sort2(array, 2);
                    Console.WriteLine("내림차순으로 정렬된 숫자입니다");
                    Console.Write("{ ");
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(sortarray[i]);
                        if (i + 1 < array.Length)
                        {
                            Console.Write(", ");
                        }
                    }
                }
                Console.WriteLine(" }");
                Console.WriteLine();
                Console.WriteLine("처음부터 다시 하시겠습니까?");
                while (reset == true)
                {
                    Console.Write("(Y / N) : ");
                    string set = Console.ReadLine();
                    if (set == "Y" || set == "y")
                    {
                        Console.WriteLine();
                        break;
                    }
                    else if (set == "N" || set == "n")
                    {
                        Console.WriteLine();
                        Console.WriteLine("수고하셨습니다.");
                        reset = false;
                    }
                    else
                        Console.WriteLine("※오류 : 정확한 값을 입력해주세요");
                }
            }
        }
    }
}

