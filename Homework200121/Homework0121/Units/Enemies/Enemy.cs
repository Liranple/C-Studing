using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Units;
using Homework0121.Players;
using static Homework0121.CommonUtility;

namespace Homework0121.Enemies
{
    class Enemy : Unit
    {
        public string comment;
        public void Enemy_Attack_Action(Player player) // 공격 액션
        {
            int critical = (int)Math.Round((intelligence + luck) * 1.2);
            Random rand1 = new Random();
            int percent = rand1.Next(100);

            Random rand2 = new Random();
            int attackpower = rand2.Next(minStrikingPower, maxStrikingPower);

            if (percent <= critical)
            {
                int attack_damage = (int)Math.Round(attackpower * 1.4) - player.defensivePower;
                player.healthPoint -= attack_damage;

                ColorLine($" <y>[ { name } ]</y> 의 <c>회심의 공격!</c> 당신은 <r>[ { attack_damage } ]</r> 만큼의 피해를 입었습니다.");
            }
            else
            {
                int attack_damage = attackpower - player.defensivePower;
                player.healthPoint -= attack_damage;

                ColorLine($" <y>[ { name } ]</y> 의 공격! 당신은 <r>[ { attack_damage } ]</r> 만큼의 피해를 입었습니다.");
            }
        }
        public Enemy Copy()
        {
            Enemy e = new Enemy();

            e.name = name;
            e.type = type;

            e.comment = comment;

            e.level = level;
            e.experiencePoint = experiencePoint;

            e.maxHealthPoint = maxHealthPoint;
            e.healthPoint = healthPoint;
            e.manaPoint = manaPoint;

            e.maxStrikingPower = maxStrikingPower;
            e.minStrikingPower = minStrikingPower;
            e.defensivePower = defensivePower;

            e.strength = strength;
            e.dexterity = dexterity;
            e.intelligence = intelligence;
            e.luck = luck;

            e.skillName1 = skillName1;
            e.skillUseMana1 = skillUseMana1;
            e.skillInfo1 = skillInfo1;

            e.skillName2 = skillName2;
            e.skillUseMana2 = skillUseMana2;
            e.skillInfo2 = skillInfo2;

            e.zone = zone;

            return e;
        }
    }
}