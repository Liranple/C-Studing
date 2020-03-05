using System;

namespace Homework
{
    class Program
    {
        const int END_SCORE = 80;
        static void Main(string[] args)
        {
            Console.WriteLine("성적 확인 프로그램");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("이름을 입력해주세요");
            Console.Write("이름 : ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("점수를 입력해주세요");
            Console.Write("국어 점수 : ");
            int score1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("영어 점수 : ");
            int score2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("수학 점수 : ");
            int score3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("과학 점수 : ");
            int score4 = Convert.ToInt32(Console.ReadLine());
            Console.Write("일어 점수 : ");
            int score5 = Convert.ToInt32(Console.ReadLine());
            float total = score1 + score2 + score3 + score4 + score5;
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(name + " 님의 성적표 입니다.");
            Console.WriteLine("국어 점수 : " + score1 + " 점 // 등급 : " + (score1 >= END_SCORE ? "A" : "F"));
            Console.WriteLine("영어 점수 : " + score2 + " 점 // 등급 : " + (score2 >= END_SCORE ? "A" : "F"));
            Console.WriteLine("수학 점수 : " + score3 + " 점 // 등급 : " + (score3 >= END_SCORE ? "A" : "F"));
            Console.WriteLine("과학 점수 : " + score4 + " 점 // 등급 : " + (score4 >= END_SCORE ? "A" : "F"));
            Console.WriteLine("일어 점수 : " + score5 + " 점 // 등급 : " + (score5 >= END_SCORE ? "A" : "F"));
            Console.WriteLine();
            Console.WriteLine("총점 : " + total + " 점");
            Console.WriteLine("평균 : " + (total / 5) + " 점 // 등급 : " + ((total / 5) >= END_SCORE ? "A" : "F"));
            Console.WriteLine();
            Console.WriteLine("당신은 " + ((total / 5) >= END_SCORE ? "우등생" : "열등생") + " 입니다.");
        }
    }
}
