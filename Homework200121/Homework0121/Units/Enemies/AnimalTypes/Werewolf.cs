using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Maps;

namespace Homework0121.Enemies.AnimalTypes
{
    class Werewolf : AnimalType
    {
        public Werewolf()
        {
            name = "굶주린 웨어울프";
            type = "야수형";

            comment = $" <y>[ { name } ]</y> 는 침을 흘리며 당신을 맛있는 먹잇감으로 바라봅니다. ";

            level = 1;
            experiencePoint = 60;

            maxHealthPoint = 400;
            healthPoint = 400;
            manaPoint = 0;

            maxStrikingPower = 75;
            minStrikingPower = 60;
            defensivePower = 10;

            strength = 10;
            dexterity = 15;
            intelligence = 10;
            luck = 5;

            zone = "울창한 숲";
        }

    }
}
