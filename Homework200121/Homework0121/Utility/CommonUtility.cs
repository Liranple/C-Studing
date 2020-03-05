using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Homework0121.Players;
using static System.Console;


namespace Homework0121
{
    class CommonUtility
    {
        public static void SleepLine(string str, bool bo = false, int time = 1000) // 문자열 지연 출력 및 빈 문단 추가
        {
            ColorLine(str, bo);
            Thread.Sleep(time);
            WriteLine();
        }
        public static void Sleep(string str, bool bo = false, int time = 1000) // 문자열 지연 출력 및 문단 변경 
        {
            ColorLine(str, bo);
            Thread.Sleep(time);
        }
        public static void ColorLine(string str = null, bool bo = false) // 문자열 색상 변경 및 문단 변경
        {
            if (str == null)
            {
                WriteLine();
                return;
            }
            char[] text = str.ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                bool plus = true;
                switch (text[i])
                {
                    case '<':
                        switch (text[++i])
                        {
                            case 'y':
                                ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 'b':
                                ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 'g':
                                ForegroundColor = ConsoleColor.Green;
                                break;
                            case 'r':
                                ForegroundColor = ConsoleColor.Red;
                                break;
                            case 'G':
                                ForegroundColor = ConsoleColor.Gray;
                                break;
                            case 'c':
                                ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case 'm':
                                ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case '/':
                                ForegroundColor = ConsoleColor.White;
                                i += 1;
                                break;
                            default:
                                plus = false;
                                break;
                        }
                        if (plus)
                        {
                            i += 2;
                        }
                        break;
                }
                switch (bo)
                {
                    case true:
                        if (i < text.Length)
                        {
                            Write(str.Substring(i, 1));
                            Thread.Sleep(50);
                        }
                        break;
                    case false:
                        if (i < text.Length)
                        {
                            Write(str.Substring(i, 1));
                        }
                        break;
                }
            }
            WriteLine();
        }
        public static void Color(string str, bool bo = false) // 문자열 색상 변경
        {
            if (str == null)
            {
                WriteLine();
                return;
            }
            char[] text = str.ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                bool plus = true;
                switch (text[i])
                {
                    case '<':
                        switch (text[++i])
                        {
                            case 'y':
                                ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 'b':
                                ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 'g':
                                ForegroundColor = ConsoleColor.Green;
                                break;
                            case 'r':
                                ForegroundColor = ConsoleColor.Red;
                                break;
                            case 'G':
                                ForegroundColor = ConsoleColor.Gray;
                                break;
                            case 'c':
                                ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case 'm':
                                ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case '/':
                                ForegroundColor = ConsoleColor.White;
                                i += 1;
                                break;
                            default:
                                plus = false;
                                break;
                        }
                        if (plus)
                        {
                            i += 2;
                        }
                        break;
                }
                switch (bo)
                {
                    case true:
                        if (i < text.Length)
                        {
                            Write(str.Substring(i, 1));
                            Thread.Sleep(50);
                        }
                        break;
                    case false:
                        if (i < text.Length)
                        {
                            Write(str.Substring(i, 1));
                        }
                        break;
                }
            }
        }
        public static bool Sortation(string str) // 숫자 문자 구분
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
        public static string Choice(string ment, params string[] strs) // 예외 처리 및 구문 반복
        {
            string warning = "■ ※ 오류 : 올바른 번호를 입력해주세요 ■";
            while (true)
            {
                Color(ment);
                string str = ReadLine();
                for (int i = 0; i < strs.Length; i++)
                {
                    if (str == strs[i])
                    {
                        return str;
                    }
                }
                WriteLine();
                ColorLine($"<r>{ warning }</r>");
                WriteLine();
            }
        }
        public static string BattleChoice(Player player, params string[] strs) // 배틀 예외 처리 및 구문 반복
        {
            string warning = "■ ※ 오류 : 올바른 번호를 입력해주세요 ■";
            while (true)
            {
                string ment = $" 플레이어 생명력  :   { player.healthPoint }   /   { player.maxHealthPoint } \n"
                            + $" 플레이어 마나    :   { player.manaPoint }    /   { player.maxManaPoint } \n\n"
                             + "<c>                   「 사용 가능한 명령어 」                    </c>\n"
                             + " <c>◎</c> 1, 공격하기  :  무기를 휘둘러 기본적인 공격을 합니다.\n"
                             + " <c>◎</c> 2, 스킬사용  :  스킬을 사용하여 강력한 공격을 합니다.\n"
                             + " <c>◎</c> 3. 분석하기  :  적의 상태를 분석합니다.\n"
                             + " <c>◎</c> 4. 도망치기  :  전투를 포기하고 도망갑니다.\n\n"
                             + "「 어떤 행동을 하시겠습니까? 」: ";
                Color(ment);
                string str = ReadLine();
                for (int i = 0; i < strs.Length; i++)
                {
                    if (str == strs[i])
                    {
                        return str;
                    }
                }
                WriteLine();
                ColorLine($"<r>{ warning }</r>");
                WriteLine();
            }
        }
    }
}
