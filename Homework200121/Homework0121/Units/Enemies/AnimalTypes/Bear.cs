using System;
using System.Collections.Generic;
using System.Text;

namespace Homework0121.Enemies.AnimalTypes
{
    class Bear: AnimalType
    {
        public Bear()
        {
            name = "사나운 그리즐리 베어";
            type = "야수형";

            comment = $" <y>[ { name } ]</y> 는 날카로운 발톱을 세우며 당신에게 큰 포효를 내지릅니다. ";

            level = 2;
            experiencePoint = 150;

            maxHealthPoint = 1000;
            healthPoint = 1000;
            manaPoint = 0;

            maxStrikingPower = 150;
            minStrikingPower = 120;
            defensivePower = 20;

            strength = 25;
            dexterity = 5;
            intelligence = 10;
            luck = 0;

            zone = "울창한 숲";
        }
    }
}
