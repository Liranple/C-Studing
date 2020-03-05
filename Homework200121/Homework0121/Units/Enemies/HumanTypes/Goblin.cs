using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Players;
using static Homework0121.CommonUtility;
using static System.Console;

namespace Homework0121.Enemies.HumanTypes
{
    class Goblin : HumanType
    {
        public Goblin()
        {
            name = "약삭빠른 고블린";
            type = "인간형";

            comment = $" <y>[ { name } ]</y> 은 날카로운 눈으로 당신을 바라보며 칼을 꺼냅니다. ";

            level = 2;
            experiencePoint = 150;

            maxHealthPoint = 500;
            healthPoint = 500;
            manaPoint = 200;

            maxStrikingPower = 90;
            minStrikingPower = 85;
            defensivePower = 10;

            strength = 10;
            dexterity = 25;
            intelligence = 10;
            luck = 20;

            skillName1 = "포인트 어택";
            skillUseMana1 = 40;
            skillInfo1 = "상대방의 약점을 노려 재빠르게 공격합니다.";

            skillName2 = "포이즌";
            skillUseMana2 = 60;
            skillInfo2 = "치명적인 독으로 상대방 현재 체력의 10% 만큼의 데미지를 줍니다.";

            zone = "고대 사원";
        }
        public void Skill_PA(Player player)
        {
            int pa_damage = (maxStrikingPower * 2) + dexterity;

            player.healthPoint -= pa_damage;
            manaPoint -= skillUseMana1;

            ColorLine($" <y>[ { name } ]</y> (은)는 당신에게 <b>[ { skillName1 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" 당신은 <r>[ { pa_damage } ]</r> 만큼의 피해를 입었습니다.");
        }
        public void Skill_Po(Player player)
        {
            int po_damage = (int)Math.Round(player.healthPoint * 0.1);

            player.healthPoint -= po_damage;
            manaPoint -= skillUseMana2;

            ColorLine($" <y>[ { name } ]</y> (은)는 당신에게 <b>[ { skillName2 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" 당신은 <r>[ { po_damage } ]</r> 만큼의 피해를 입었습니다.");
        }
    }
}
