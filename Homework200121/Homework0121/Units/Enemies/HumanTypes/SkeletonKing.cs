using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Players;
using static Homework0121.CommonUtility;
using static System.Console;

namespace Homework0121.Enemies.HumanTypes
{
    class SkeletonKing : HumanType
    {
        public SkeletonKing()
        {
            name = "지배자 스켈레톤 킹";
            type = "인간형";

            comment = $" <y>[ { name } ]</y> 은 귀가 찢어질듯한 비명을 지르며 당신을 무섭게 노려봅니다. ";

            level = 4;
            experiencePoint = 500;

            maxHealthPoint = 2000;
            healthPoint = 2000;
            manaPoint = 400;

            maxStrikingPower = 250;
            minStrikingPower = 200;
            defensivePower = 40;

            strength = 40;
            dexterity = 30;
            intelligence = 15;
            luck = 15;

            skillName1 = "신체 강화";
            skillUseMana1 = 40;
            skillInfo1 = "자신의 신체를 강화시켜 능력치를 향상시킵니다.";

            skillName2 = "영혼 흡수";
            skillUseMana2 = 60;
            skillInfo2 = "상대방의 최대 체력을 10%만큼 흡수하여 자신의 생명력을 회복시킵니다.";

            zone = "깊은 동굴";
        }
        public void Skill_PU()
        {
            maxStrikingPower += 50;
            minStrikingPower += 40;
            defensivePower += 20;

            manaPoint -= skillUseMana1;

            ColorLine($" <y>[ { name } ]</y> (은)는 <b>[ { skillName1 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" <y>[ { name } ]</y> 의 공격력과 방어력이 상승했습니다.");
        }

        public void Skill_ST(Player player)
        {
            int st_damage = (int)Math.Round(player.maxHealthPoint * 0.1);

            player.healthPoint -= st_damage;
            healthPoint += st_damage;
            manaPoint -= skillUseMana2;

            ColorLine($" <y>[ { name } ]</y> (은)는 당신에게 <b>[ { skillName2 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" 당신은 <r>[ { st_damage } ]</r> 만큼의 피해를 입었습니다.");
            ColorLine($" <y>[ { name } ]</y> 의 생명력이 <g>[ { st_damage } ]</g> 만큼 회복되었습니다.");
        }
    }
}
