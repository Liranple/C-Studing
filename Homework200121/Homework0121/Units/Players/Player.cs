using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Enemies;
using Homework0121.Units;
using static Homework0121.Program;
using static Homework0121.CommonUtility;
using static System.Console;

namespace Homework0121.Players
{
    class Player : Unit
    {
        public string job;

        public int questNumber;
        public int questStack;

        public void Player_Attack_Action(Enemy enemy) // 공격 액션
        {
            int critical = (int)Math.Round((intelligence + luck) * 1.2);
            Random rand1 = new Random();
            int percent = rand1.Next(100);

            Random rand2 = new Random();
            int attackpower = rand2.Next(minStrikingPower, maxStrikingPower);

            if (percent <= critical)
            {
                int attack_damage = (int)Math.Round( attackpower * 1.4 ) - enemy.defensivePower;
                enemy.healthPoint -= attack_damage;

                ColorLine($" 당신의 <c>회심의 공격!!!</c> <y>[ { enemy.name } ]</y> 은(는) <r>[ { attack_damage } ]</r> 만큼의 피해를 입었습니다.");
            }
            else
            {
                int attack_damage = attackpower - enemy.defensivePower;
                enemy.healthPoint -= attack_damage;

                ColorLine($" 당신의 공격! <y>[ { enemy.name } ]</y> 은(는) <r>[ { attack_damage } ]</r> 만큼의 피해를 입었습니다.");
            }
        }
        public void Player_LevelUp() // 레벨업 액션
        {
            if (experiencePoint >= levelUpPoint)
            {
                level++;
                experiencePoint = experiencePoint - levelUpPoint;

                levelUpPoint += level * 150;

                if (job == "전사")
                {
                    maxHealthPoint += 300;
                    maxManaPoint += 80;

                    maxStrikingPower += 35;
                    minStrikingPower += 25;
                    defensivePower += 15;

                    strength += 10;
                    dexterity += 5;
                    intelligence += 5;
                }
                else if (job == "도적")
                {
                    maxHealthPoint += 200;
                    maxManaPoint += 120;

                    maxStrikingPower += 25;
                    minStrikingPower += 20;
                    defensivePower += 10;

                    strength += 5;
                    dexterity += 15;
                    intelligence += 5;
                    luck += 3;
                }

                healthPoint = maxHealthPoint;
                manaPoint = maxManaPoint;

                ColorLine($"「 당신의 레벨이<g>【 { level } 】</g>로 상승하였습니다! 」");
                ColorLine("<c>「 체력과 마나가 모두 회복됩니다. 」</c>");
                WriteLine();
            }
        }

    }
}
