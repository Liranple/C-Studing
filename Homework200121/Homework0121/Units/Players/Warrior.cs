using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Enemies;
using static Homework0121.CommonUtility;
using static System.Console;

namespace Homework0121.Players
{
    class Warrior : Player
    {
        public Warrior()
        {
            controler = true;
            job = "전사";
            type = "인간형";

            level = 1;
            experiencePoint = 0;
            levelUpPoint = 450;

            maxHealthPoint = 1500;
            healthPoint = 1500;
            maxManaPoint = 200;
            manaPoint = 200;

            maxStrikingPower = 80;
            minStrikingPower = 60;
            defensivePower = 30;

            strength = 30;
            dexterity = 10;
            intelligence = 10;
            luck = 10;

            skillName1 = "연속 공격";
            skillUseMana1 = 40;
            skillInfo1 = "능숙한 솜씨로 빠르게 두 번 공격합니다.";

            skillName2 = "파워스트라이크";
            skillUseMana2 = 60;
            skillInfo2 = "무기로 강하게 내려쳐 큰 피해를 입힙니다.";
        }

        public void Skill_DA(Enemy enemy)
        {
            int da_damage = (strength / 2) + maxStrikingPower - enemy.defensivePower;

            enemy.healthPoint -= da_damage * 2;
            manaPoint -= skillUseMana1;

            ColorLine($" 당신은 <y>[ { enemy.name } ]</y> 에게 <b>[ { skillName1 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" <y>[ { enemy.name } ]</y> (은)는 <r>[ { da_damage * 2 } ]</r> 만큼의 피해를 입었습니다.");
        }

        public void Skill_PS(Enemy enemy)
        {
            int ps_damage = (maxStrikingPower * 2) + strength - enemy.defensivePower;

            enemy.healthPoint -= ps_damage;
            manaPoint -= skillUseMana2;

            ColorLine($" 당신은 <y>[ { enemy.name } ]</y> 에게 <b>[ { skillName2 } ]</b> 을(를) 시전하였습니다.");
            ColorLine($" <y>[ { enemy.name } ]</y> (은)는 <r>[ { ps_damage } ]</r> 만큼의 피해를 입었습니다.");
        }
    }
}
