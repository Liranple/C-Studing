using System;
using System.Collections.Generic;
using System.Text;
using static Homework0121.CommonUtility;

namespace Homework0121.Units
{
    class Unit
    {
        public bool controler;
        public string name;
        public string type;

        public int maxHealthPoint;
        public int healthPoint;
        public int maxManaPoint;
        public int manaPoint;
        public int level;
        public int experiencePoint;
        public int levelUpPoint;

        public int maxStrikingPower;
        public int minStrikingPower;

        public int defensivePower;

        public int strength;
        public int dexterity;
        public int intelligence;
        public int luck;

        public int poisonCount;
        public int burnCount;
        public int curseCount;

        public string skillName1;
        public int skillUseMana1;
        public string skillInfo1;

        public string skillName2;
        public int skillUseMana2;
        public string skillInfo2;

        public string zone;

        public void Condition_Damame()
        {
            if (0 < poisonCount)
            {
                int poisonDamage = (int)Math.Round(maxHealthPoint * 0.04);
                healthPoint -= poisonDamage;
                poisonCount--;
                switch (controler)
                {
                    case true:
                        ColorLine($"당신은 독으로 인해 <r>[ { poisonDamage } ]</r> 의 데미지를 입었습니다.");
                        break;
                    case false:
                        ColorLine($" <y>[ {name} ]</y> (은)는 독으로 인해 <r>[ { poisonDamage } ]</r> 의 데미지를 입었습니다. </c>");
                        break;
                }
                switch (poisonCount)
                {
                    case 0:
                        switch (controler)
                        {
                            case true:
                                ColorLine($"당신의 <c>[ 상태이상 : 독 ]</c> 이(가) 해제되었습니다.");
                                break;
                            case false:
                                ColorLine($" <y>[ {name} ]</y> 의 <c>[ 상태이상 : 독 ]</c> 이(가) 해제되었습니다.");
                                break;
                        }
                        break;
                }
            }
            if (0 < burnCount)
            {
                int burnDamage = (int)Math.Round(maxHealthPoint * 0.025);
                healthPoint -= burnDamage;
                burnCount--;
                switch (controler)
                {
                    case true:
                        ColorLine($"당신은 화상으로 인해 <r>[ { burnDamage } ]</r> 의 데미지를 입었습니다.");
                        break;
                    case false:
                        ColorLine($" <y>[ {name} ]</y> (은)는 화상으로 인해 <r>[ { burnDamage } ]</r> 의 데미지를 입었습니다.");
                        break;
                }
                switch (poisonCount)
                {
                    case 0:
                        switch (controler)
                        {
                            case true:
                                ColorLine($"당신의 <c>[ 상태이상 : 화상 ]</c> 이(가) 해제되었습니다.");
                                break;
                            case false:
                                ColorLine($" <y>[ {name} ]</y> 의 <c>[ 상태이상 : 화상 ]</c> 이(가) 해제되었습니다.");
                                break;
                        }
                        break;
                }
            }
            if (0 < curseCount)
            {
                curseCount--;
                switch (curseCount)
                {
                    case 0:
                        switch (controler)
                        {
                            case true:
                                Color($"당신의 <c>[ 상태이상 : 저주 ]</c> 이(가) 해제되어 능력치가 정상이 되었습니다..</c>");
                                break;
                            case false:
                                ColorLine($" <y>[ {name} ]</y> 의 <c>[ 상태이상 : 저주 ]</c> 이(가) 해제되어 능력치가 정상이 되었습니다.");
                                break;
                        }
                        maxStrikingPower += 30;
                        minStrikingPower += 30;
                        defensivePower += 15;
                        break;
                }
            }
        }
    }

}
