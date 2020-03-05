using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Enemies;
using static Homework0121.CommonUtility;
using static System.Console;

namespace Homework0121.Players
{
    class Thief : Player
    {
        public Thief()
        {
            controler = true;
            job = "도적";
            type = "인간형";

            level = 1;
            experiencePoint = 0;
            levelUpPoint = 450;

            maxHealthPoint = 1100;
            healthPoint = 1100;
            maxManaPoint = 300;
            manaPoint = 300;

            maxStrikingPower = 60;
            minStrikingPower = 55;
            defensivePower = 20;

            strength = 10;
            dexterity = 25;
            intelligence = 15;
            luck = 20;

            skillName1 = "기습 공격";
            skillUseMana1 = 40;
            skillInfo1 = "재빠르게 공격하여 방어력을 무시한 피해를 입힙니다.";

            skillName2 = "맹독";
            skillUseMana2 = 100;
            skillInfo2 = "치명적인 독으로 상대방 최대 체력의 15% 만큼 피해를 입힙니다.";
        }

        public void Skill_SA(Enemy enemy)
        {
            int sa_damage = (dexterity * 2) + maxStrikingPower;

            enemy.healthPoint -= sa_damage;
            manaPoint -= skillUseMana1;

            ColorLine($" 당신은 <y>[ { enemy.name } ]</y> 에게 <b>[ { skillName1 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" <y>[ { enemy.name } ]</y> (은)는 <r>[ { sa_damage } ]</r> 만큼의 피해를 입었습니다.");
        }
        public void Skill_To(Enemy enemy)
        {
            int to_damage = (int)Math.Round(enemy.maxHealthPoint * 0.15);

            enemy.healthPoint -= to_damage;
            manaPoint -= skillUseMana2;

            ColorLine($" 당신은 <y>[ { enemy.name } ]</y> 에게 <b>[ { skillName2 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" <y>[ { enemy.name } ]</y> (은)는 <r>[ { to_damage } ]</r> 만큼의 피해를 입었습니다.");
        }
    }
}
