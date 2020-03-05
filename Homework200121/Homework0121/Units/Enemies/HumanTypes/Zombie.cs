using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Players;
using static Homework0121.CommonUtility;
using static System.Console;

namespace Homework0121.Enemies.HumanTypes
{
    class Zombie : HumanType
    {
        public Zombie()
        {
            name = "썩어가는 좀비";
            type = "인간형";

            comment = $" <y>[ { name } ]</y> 는 당신을 발견하자 끔찍한 신음소리를 냅니다. ";

            level = 1;
            experiencePoint = 80;

            maxHealthPoint = 600;
            healthPoint = 600;
            manaPoint = 100;

            maxStrikingPower = 75;
            minStrikingPower = 65;
            defensivePower = 10;

            strength = 20;
            dexterity = 10;
            intelligence = 10;
            luck = 0;

            skillName1 = "살점 뜯기";
            skillUseMana1 = 40;
            skillInfo1 = "상대방의 살점을 물어 뜯어 피해를 입힙니다.";

            zone = "고대 사원";
        }
        public void Skill_SB(Player player)
        {
            int sb_damage = (int)Math.Round(maxStrikingPower * 1.5) + strength -  player.defensivePower;

            player.healthPoint -= sb_damage;
            manaPoint -= skillUseMana1;

            ColorLine($" <y>[ { name } ]</y> (은)는 당신에게 <b>[ { skillName1 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" 당신은 <r>[ { sb_damage } ]</r> 만큼의 피해를 입었습니다.");
        }
    }
}