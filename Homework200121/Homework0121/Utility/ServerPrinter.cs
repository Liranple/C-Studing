using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Players;
using Homework0121.Enemies;
using static System.Console;
using static Homework0121.CommonUtility;

namespace Homework0121
{
    class ServerPrinter
    {
        public static void PStat(Player player) // 플레이어 스테이터스 정보 출력
        {
            WriteLine();
            ColorLine("<g> ────────────────────────────────────────────────────────────────</g>");
            ColorLine("<g>                        『 스테이터스 』                       </g>");
            WriteLine();
            ColorLine($" 이름 : { player.name }");
            WriteLine();
            ColorLine($" 직업 : { player.job }  /  종족 : { player.type }");
            WriteLine();
            ColorLine($" 레벨 : { player.level }");
            ColorLine($" 경험치 : { player.experiencePoint } / { player.levelUpPoint }");
            WriteLine();
            ColorLine($" 공격력 : { player.minStrikingPower } ~ { player.maxStrikingPower }");
            WriteLine();
            ColorLine($" 생명력 : { player.healthPoint } / { player.maxHealthPoint }");
            ColorLine($" 마나   : { player.manaPoint } / { player.maxManaPoint }");
            WriteLine();
            WriteLine($" 힘   : { player.strength }");
            WriteLine($" 민첩 : { player.dexterity }");
            WriteLine($" 지력 : { player.intelligence }");
            WriteLine($" 운   : { player.luck }");
            WriteLine();
            ColorLine($"《 보유 스킬 》");
            WriteLine();
            ColorLine($" [ { player.skillName1 } ]  /  마나 소모 : { player.skillUseMana1 }");
            WriteLine($"  { player.skillInfo1 }");
            WriteLine();
            ColorLine($" [ { player.skillName2 } ]  /  마나 소모 : { player.skillUseMana2 }");
            WriteLine($"  { player.skillInfo2 }");
            ColorLine("<g> ────────────────────────────────────────────────────────────────</g>");
            WriteLine();
        }
        public static void EStat(Enemy enemy) // 몬스터 스테이터스 정보 출력
        {
            ColorLine("<g> ────────────────────────────────────────────────────────────────</g>");
            ColorLine("<g>                        『 분석하기 』                         </g>");
            WriteLine();
            WriteLine($" 이름 : { enemy.name }");
            WriteLine();
            WriteLine($" 종족 : { enemy.type }");
            WriteLine();
            WriteLine($" 생명력 : { enemy.healthPoint }   /   { enemy.maxHealthPoint }");
            if (enemy.type == "인간형")
            {
                WriteLine();
                WriteLine($"《 보유 스킬 》");
                WriteLine();
                WriteLine($"[ { enemy.skillName1 } ]");
                WriteLine($"  { enemy.skillInfo1 }");
                if (enemy.name != "썩어가는 좀비")
                {
                    WriteLine();
                    WriteLine($"[ { enemy.skillName2 } ]");
                    WriteLine($"  { enemy.skillInfo2 }");
                }
            }
            ColorLine("<g> ────────────────────────────────────────────────────────────────</g>");
        }
        public static void Quest(Player player) // 퀘스트 정보 출력
        {
            WriteLine();
            ColorLine("<g> ────────────────────────────────────────────────────────────────</g>");
            switch (player.questNumber)
            {
                case 1:
                    ColorLine("<g>                       『 웰턴 타운으로 』                     </g>");
                    WriteLine();
                    WriteLine("                 웰턴 타운에 들어가기 위해서는                 ");
                    WriteLine("           근처 숲에 출몰하는 웨어울프를 잡아야한다.           ");
                    WriteLine("          2마리 정도 잡고 다시 경비병에게 돌아와보자.          ");
                    WriteLine();
                    WriteLine($"                   《 웨어울프 처치 { player.questStack } / 2 》              ");
                    break;
                case 2:
                    ColorLine("<g>                      『 오색 빛의 광물 』                     </g>");
                    WriteLine();
                    WriteLine("      타운 남쪽에 있는 사원에서 특별한 광물이 발견되었다.      ");
                    WriteLine("          대장장이는 고블린을 잡아 광물을 구해온다면           ");
                    WriteLine("            특별한 무기를 만들어 줄 것을 약속했다.             ");
                    WriteLine();
                    WriteLine($"                 《 특별한 광물 획득 { player.questStack } / 3 》                   ");
                    break;
                case 3:
                    ColorLine("<g>                     『 삼켜버리는 어둠 』                     </g>");
                    WriteLine();
                    WriteLine("       서쪽의 숲 어딘가에 빛 조차 들지 않는 동굴이 있다.       ");
                    WriteLine("            라크다난은 루그두눔 기사단 보다 먼저               ");
                    WriteLine("             깊은 동굴을 탐사해줄 것을 의뢰했다.               ");
                    WriteLine("    깊은 동굴에 들어가 탐사를 한 뒤 루크다난에게 돌아와보자.   ");
                    WriteLine();
                    WriteLine($"                  《 깊은 동굴 탐사 { player.questStack } / 1 》          ");
                    break;
                case 4:
                    ColorLine("<g>                     『 삼켜버리는 어둠 』                     </g>");
                    WriteLine();
                    WriteLine("           동굴 안쪽에는 스켈레톤이 서식하고 있었다.           ");
                    WriteLine("   스켈레톤을 처치한 후 뼈다귀를 모아 라크다난에게 보고하자.   ");
                    WriteLine();
                    WriteLine($"                  《 스켈레톤 처치 { player.questStack } / 2 》           ");
                    break;
                case 5:
                    ColorLine("<g>                   『 비명을 지르는 마법석 』                  </g>");
                    WriteLine();
                    WriteLine("       깊은 동굴 안쪽에 서식하고 있는 스켈레톤의 우두머리      ");
                    WriteLine("  스켈레톤 킹을 처치하여 마법석을 구해 라크다난에게 돌아가자.  ");
                    WriteLine();
                    WriteLine($"                 《 스켈레톤 킹 처치 { player.questStack } / 1 》           ");
                    break;
                default:
                    ColorLine("<g>             『 현재 수주한 퀘스트가 없습니다. 』              </g>");
                    break;
            }
            ColorLine("<g> ────────────────────────────────────────────────────────────────</g>");
            WriteLine();
        }
        public static void EnterZone(Player player) // 지역 이동 시 안내 문구 출력
        {
            WriteLine();
            ColorLine($"<g>                      ▣▣ { player.zone } ▣▣                      </g>");
            WriteLine();
            ColorLine($"          「 당신은 <g>[ { player.zone } ]</g> 에 도착했습니다. 」          ");
        }

    }
}
