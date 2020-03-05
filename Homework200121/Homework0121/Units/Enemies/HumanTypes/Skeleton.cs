using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Players;
using static Homework0121.CommonUtility;
using static System.Console;

namespace Homework0121.Enemies.HumanTypes
{
    class Skeleton : HumanType
    {
        public Skeleton()
        {
            name = "저주하는 스켈레톤";
            type = "인간형";

            comment = $" <y>[ { name } ]</y> 은 비어있는 눈으로 당신을 주시합니다. ";

            level = 3;
            experiencePoint = 250;

            maxHealthPoint = 1300;
            healthPoint = 1300;
            manaPoint = 250;

            maxStrikingPower = 150;
            minStrikingPower = 140;
            defensivePower = 25;

            strength = 25;
            dexterity = 20;
            intelligence = 10;
            luck = 15;

            skillName1 = "배쉬";
            skillUseMana1 = 40;
            skillInfo1 = "무기에 힘을 가득 실어 상대방을 공격합니다.";

            skillName2 = "저주의 목소리";
            skillUseMana2 = 70;
            skillInfo2 = "끔찍한 소리를 내어 상대방을 3턴간 약화시킵니다.";

            zone = "깊은 동굴";
        }
        public void Skill_Ba(Player player)
        {
            int ba_damage = (int)Math.Round(maxStrikingPower * 1.8) + strength + dexterity;

            player.healthPoint -= ba_damage;
            manaPoint -= skillUseMana1;

            ColorLine($" <y>[ { name } ]</y> (은)는 당신에게 <b>[ { skillName1 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" 당신은 <r>[ { ba_damage } ]</r> 만큼의 피해를 입었습니다.");
        }
        public void Skill_CV(Player player)
        {
            player.curseCount = 4;
            if (player.curseCount == 0)
            {
                player.maxStrikingPower -= 30;
                player.minStrikingPower -= 30;
                player.defensivePower -= 15;
            }
            manaPoint -= skillUseMana2;

            ColorLine($" <y>[ { name } ]</y> (은)는 당신에게 <b>[ { skillName2 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" 당신의 공격력과 방어력이 일시적으로 약해졌다.");
        }
    }
}
