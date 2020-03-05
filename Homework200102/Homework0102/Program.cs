using System;

namespace Homework0102
{
    class Program
    {
        static void Main(string[] args)
        {
            int replay = 1;
            while (replay == 1)
            {
                while (replay == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("-------------- 원하는 옵션을 선택해주세요 --------------");
                    Console.WriteLine("1. 피라미드 모형");
                    Console.WriteLine("2. 역 피라이드 모형");
                    Console.WriteLine("3. 나비 넥타이 모형");
                    Console.WriteLine("4. FizzBuzz");
                    Console.WriteLine("5. 소수 출력");
                    Console.WriteLine("--------------------------------------------------------");
                    Console.Write("번호를 입력해주세요 : ");
                    int select = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    if (select == 1)
                    {
                        Console.WriteLine("-------------------- 피라미드 모형 ---------------------");
                        Console.Write("단 수를 입력하세요 : ");
                        int dan = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        for (int hang = 0; hang < dan; hang++)
                        {
                            for (int space = dan; space > hang + 1; space--)
                            {
                                Console.Write(" ");
                            }
                            for (int star = 0; star <= hang * 2; star++)
                            {
                                Console.Write("*");
                            }
                            Console.WriteLine();
                        }
                        break;
                    } // 피라미드
                    else if (select == 2)
                    {
                        Console.WriteLine("------------------- 역 피라미드 모형 -------------------");
                        Console.Write("단 수를 입력하세요 : ");
                        int dan = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        for (int hang = 0; hang < dan; hang++)
                        {
                            for (int space = 0; space < hang; space++)
                            {
                                Console.Write(" ");
                            }
                            for (int star = dan * 2; star - 1 > hang * 2; star--)
                            {
                                Console.Write("*");
                            }
                            Console.WriteLine();
                        }
                        break;
                    } // 역 피라미드
                    else if (select == 3)
                    {
                        int dan = 0;
                        while (dan % 2 == 0)
                        {
                            Console.WriteLine("------------------- 나비 넥타이 모형 -------------------");
                            Console.Write("단 수(홀수)를 입력하세요 : ");
                            dan = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            if (dan % 2 == 1)
                            {
                                for (int hang = 0; hang < dan; hang++)
                                {
                                    if (hang < dan / 2)
                                    {
                                        for (int star = 0; star <= hang; star++)
                                        {
                                            Console.Write("*");
                                        }
                                        for (int space = dan; space - 2 > hang * 2; space--)
                                        {
                                            Console.Write(" ");
                                        }
                                        for (int star = 0; star <= hang; star++)
                                        {
                                            Console.Write("*");
                                        }
                                    }
                                    else if (hang == dan / 2)
                                    {
                                        for (int star = 0; star < dan; star++)
                                        {
                                            Console.Write("*");
                                        }
                                    }
                                    else
                                    {
                                        for (int star = dan; star > hang; star--)
                                        {
                                            Console.Write("*");
                                        }
                                        for (int space = dan; space < hang * 2; space++)
                                        {
                                            Console.Write(" ");
                                        }
                                        for (int star = dan; star > hang; star--)
                                        {
                                            Console.Write("*");
                                        }
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("※ 오류 :: 홀수만 입력해주세요.");
                            }
                        }
                        break;
                    } // 나비 넥타이
                    else if (select == 4)
                    {
                        Console.WriteLine("----------------------- FizzBuzz -----------------------");
                        Console.Write("숫자를 입력하세요 : ");
                        int high = Convert.ToInt32(Console.ReadLine());
                        for (int suja = 1; suja <= high; suja++)
                        {
                            if (suja % 3 == 0 && suja % 5 == 0)
                            {
                                Console.Write("FizzBuzz ");
                            }
                            else if (suja % 3 == 0)
                            {
                                Console.Write("Fizz ");
                            }
                            else if (suja % 5 == 0)
                            {
                                Console.Write("Buzz ");
                            }
                            else
                            {
                                Console.Write(suja + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    } // FizzBuzz
                    else if (select == 5)
                    {
                        Console.WriteLine("---------------------- 소수 출력 -----------------------");
                        Console.Write("숫자를 입력하세요 : ");
                        int max = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        for (int sosu = 2; sosu < max; sosu++)
                        {
                            bool isSosu = true;
                            for (int n = 1; n < sosu; n++)
                            {
                                for (int m = 1; m < sosu; m++)
                                {
                                    if (n * m <= sosu)
                                    {
                                        if (n * m == sosu)
                                        {
                                            isSosu = false;
                                        }
                                    }
                                }
                            }
                            if (isSosu == true)
                            {
                                Console.Write(sosu + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    } // 소수 출력
                    else
                    {
                        Console.WriteLine("※ 오류 :: 올바르지 않은 번호입니다.");
                    } // 오류 문구
                }
                Console.WriteLine();
                Console.WriteLine("------------- 처음부터 다시 시작하겠습니까? ------------ ");
                Console.WriteLine("1. 처음부터 다시 시작하기");
                Console.WriteLine("2. 끝내기");
                Console.WriteLine();
                Console.Write("번호를 입력해주세요 : ");
                replay = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
