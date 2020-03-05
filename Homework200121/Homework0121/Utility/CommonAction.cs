using System;
using System.Collections.Generic;
using System.Text;
using Homework0121.Players;
using Homework0121.Enemies;
using Homework0121.Enemies.AnimalTypes;
using Homework0121.Enemies.HumanTypes;
using static System.Console;
using static Homework0121.CommonUtility;
using static Homework0121.ServerPrinter;


namespace Homework0121
{
    class CommonAction
    {
        public static void MoveAction(Player player) // 지역 이동 행동 패턴
        {
            string select;
            string move;
            switch (player.zone)
            {
                case "웰턴 타운":
                    move = "<c>                    「 이동 가능한 장소 」                     </c>\n"
                         + " <c>◎</c> 1, 울창한 숲  [ 길게 뻗은 나무들이 가득한 숲입니다. ]\n"
                         + " <c>◎</c> 2, 고대 사원  [ 사람의 발길이 끊긴지 정말 오래되었습니다. ]\n"
                         + " <c>◎</c> 3. 다른 행동 하기\n\n"
                         + "「 무엇을 하시겠습니까? 」: ";
                    select = Choice(move, "1", "2", "3");
                    switch (select)
                    {
                        case "1":
                            player.zone = "울창한 숲";
                            EnterZone(player);
                            break;
                        case "2":
                            player.zone = "고대 사원";
                            EnterZone(player);
                            break;
                        case "3":
                            break;
                    }
                    break;
                case "울창한 숲":
                    move = "<c>                    「 이동 가능한 장소 」                     </c>\n"
                         + " <c>◎</c> 1, 웰턴 타운  [ 주민들의 생활 수준과 치안이 높은 도시 입니다. ]\n"
                         + " <c>◎</c> 2, 깊은 동굴  [ 끝이 보이지 않은 어둠속에서 음산한 기운이 느껴집니다. ]\n"
                         + " <c>◎</c> 3. 다른 행동 하기\n\n"
                         + "「 무엇을 하시겠습니까? 」: ";
                    select = Choice(move, "1", "2", "3");
                    switch (select)
                    {
                        case "1":
                            player.zone = "웰턴 타운";
                            EnterZone(player);
                            break;
                        case "2":
                            player.zone = "깊은 동굴";
                            EnterZone(player);
                            break;
                        case "3":
                            break;
                    }
                    break;
                case "고대 사원":
                    move = "<c>                    「 이동 가능한 장소 」                     </c>\n"
                         + " <c>◎</c> 1, 웰턴 타운  [ 주민들의 생활 수준과 치안이 높은 도시 입니다. ]\n"
                         + " <c>◎</c> 2. 다른 행동 하기\n\n"
                         + "「 무엇을 하시겠습니까? 」: ";
                    select = Choice(move, "1", "2");
                    switch (select)
                    {
                        case "1":
                            player.zone = "웰턴 타운";
                            EnterZone(player);
                            break;
                        case "2":
                            break;
                    }
                    break;
                case "깊은 동굴":
                    move = "<c>                    「 이동 가능한 장소 」                     </c>\n"
                         + " <c>◎</c> 1, 울창한 숲  [ 길게 뻗은 나무들이 가득한 숲입니다. ]\n"
                         + " <c>◎</c> 2. 다른 행동 하기\n\n"
                         + "「 무엇을 하시겠습니까? 」: ";
                    select = Choice(move, "1", "2");
                    switch (select)
                    {
                        case "1":
                            player.zone = "울창한 숲";
                            EnterZone(player);
                            break;
                        case "2":
                            break;
                    }
                    break;
            }
            WriteLine();
        }
        public static void Action(Player player) // 플레이어 기본 행동 패턴
        {
            bool reaction = true;
            string select;
            while (reaction == true)
            {
                string action = $"          「 당신은 현재 <g>[ { player.zone } ]</g> 에 있습니다 」          \n\n"
                               + "<c>                   「 사용 가능한 명령어 」                    </c>\n"
                               + " <c>◎</c> 1, 스테이터스  :  스테이터스 창을 확인합니다.\n"
                               + " <c>◎</c> 2, 퀘스트      :  현재 퀘스트 정보를 확인합니다.\n"
                               + " <c>◎</c> 3. 조사하기    :  현재 장소를 조사합니다. <G>(적과 조우할 수 있습니다)</G>\n"
                               + " <c>◎</c> 4. 이동하기    :  다른 장소로 이동합니다.\n\n"
                               + "「 어떤 행동을 하시겠습니까? 」: ";
                select = Choice(action, "1", "2", "3", "4");
                switch (select)
                {
                    case "1":
                        PStat(player);
                        break;
                    case "2":
                        Quest(player);
                        break;
                    case "3":
                        WriteLine();
                        SleepLine($"「 당신은 <g>[ { player.zone } ]</g> 에서 주변을 조사합니다. 」", false, 500);
                        switch (player.zone)
                        {
                            case "웰턴 타운":
                                Town_Action(player, ref reaction);
                                break;
                            default:
                                Zombie zombie = new Zombie(); // 인간형 좀비 생성
                                Goblin goblin = new Goblin(); // 인간형 고블린 생성

                                Werewolf werewolf = new Werewolf(); // 야수형 웨어울프 생성
                                Bear bear = new Bear(); // 야수형 베어 생성

                                List<Enemy> enemyList = new List<Enemy>(); // Enemy 타입의 클래스 리스트
                                List<Enemy> enemies = new List<Enemy>();

                                enemyList.Add(zombie);
                                enemyList.Add(goblin);
                                enemyList.Add(werewolf);
                                enemyList.Add(bear);

                                if (player.zone == "깊은 동굴")
                                {
                                    if (player.questNumber == 3)
                                    {
                                        Sleep("「 동굴 안은 바람소리인지 모를 음산한 소리가 계속해서 들려옵니다. 」");
                                        SleepLine("「 당신은 안으로 깊숙히 들어갈 수록 분위기가 점점 어두워지는것을 느낍니다. 」");
                                        Sleep("「 뼈다귀가 밟에 밟히는 빈도가 잦아질 때 쯤 안쪽에서 이질적인 소리가 들려옵니다. 」");
                                        ColorLine("<y>【 ??? 】</y>");
                                        SleepLine("\" 인간... 죽어라... \"",true);
                                        SleepLine("「 어둠 속에서 달그락거리는 소리와 함께 기분 나쁜 목소리가 들려왔습니다. 」");
                                        SleepLine("「 당신은 곧바로 무기를 꺼내들고는 전투를 준비합니다. 」");
                                        SleepLine("<c>「 퀘스트가 새로 갱신되었습니다. 」</c>");
                                        player.questNumber = 4;
                                        player.questStack = 0;
                                        Quest(player);
                                        ReadKey();
                                    }
                                    if (player.questNumber >= 4)
                                    {
                                        if (player.questStack == 1 && player.questNumber == 5)
                                        {

                                        }
                                        else
                                        {
                                            Skeleton skeleton = new Skeleton(); // 인간형 스켈레톤 생성
                                            enemyList.Add(skeleton);
                                        }
                                    }
                                    if (player.questStack == 0  && player.questNumber == 5)
                                    {
                                        SkeletonKing skeletonKing = new SkeletonKing(); // 인간형 스켈레톤 킹 
                                        enemyList.Add(skeletonKing);
                                    }
                                }

                                if (player.questStack == 1 && player.questNumber == 5 && player.zone == "깊은 동굴")
                                {
                                    SleepLine($"「 스켈레톤 킹이 사라짐과 동시에 스켈레톤들도 자취를 감추었습니다. 」", false, 500);
                                }
                                else
                                {
                                    Random rand1 = new Random();
                                    int i_rand1 = rand1.Next(2);
                                    switch (i_rand1)
                                    {
                                        case 0:
                                            bool ableBattle = false;
                                            for (int i = 0; i < enemyList.Count; i++)
                                            {
                                                if (player.zone == enemyList[i].zone)
                                                {
                                                    enemies.Add(enemyList[i]);
                                                }
                                            }
                                            Random rand2 = new Random();
                                            int i_rand2 = rand2.Next(enemies.Count);
                                            if (enemies.Count == 0)
                                            {
                                                ableBattle = true;
                                                SleepLine($"「 당신은 주변을 둘러보았지만 아무것도 찾을 수 없었습니다. 」", false, 500);
                                            }
                                            else if (player.level >= enemies[i_rand2].level)
                                            {
                                                ableBattle = true;
                                                if (player.questStack == 0 && enemies[i_rand2].name == "지배자 스켈레톤 킹")
                                                {
                                                    Sleep($"「 얼음보다 차가운 공기가 당신의 몸을 꿰뚫습니다. 」", true);
                                                    SleepLine($"「 분명 기분 탓은 아니였습니다. 」", true);
                                                    SleepLine($"「 당신의 체온이 서서히 떨어지는 것을 느낄 때 쯤. 」", true);
                                                    SleepLine($"「 거대한 몸집의 해골이 파란 빛을 내뿜으며 모습을 드러냅니다. 」", true);
                                                    ColorLine("<y>【 스켈레톤 킹 】</y>");
                                                    SleepLine("\" 네놈.. 들의......들을.. 모두 죽이.. 겠다...! \"", true);
                                                }
                                                SleepLine($"「 당신의 앞에 <y>[ { enemies[i_rand2].name } ]</y> (이)가 나타났습니다! 」");
                                                ColorLine("<r> ────────────────────────────────────────────────────────────────</r>");
                                                ColorLine("<r>                      『 전투 개시 ! 』                      </r>");
                                                ColorLine($"{ enemies[i_rand2].comment }");
                                                Battle_Action(player, enemies[i_rand2]);
                                            }
                                            switch (ableBattle)
                                            {
                                                case true:
                                                    break;
                                                case false:
                                                    SleepLine($"「 당신은 주변에서 인기척을 느낍니다. 」", false, 500);
                                                    break;
                                            }
                                            break;
                                        case 1:
                                            SleepLine($"「 당신은 주변을 둘러보았지만 아무것도 찾을 수 없었습니다. 」", false, 500);
                                            break;
                                    }
                                }
                                break;
                        }
                        break;
                    case "4":
                        WriteLine();
                        MoveAction(player);
                        break;
                }
            }
        }
        public static void Battle_Action(Player player, Enemy enemy) // 플레이어 배틀 행동 패턴
        {
            bool reset = true;
            string select;
            while (reset == true)
            {
                string enableSkill = "<r>「 마나가 부족합니다. 」</r>";
                WriteLine();
                select = BattleChoice(player, "1", "2", "3", "4");
                WriteLine();
                Warrior warrior;
                Thief thief;
                switch (select)
                {
                    case "1":
                        player.Player_Attack_Action(enemy);
                        Enemy_Action(player, enemy);
                        break;
                    case "2":
                        string skillList = "<c>                    「 사용 가능한 스킬 」                     </c>\n"
                                        + $" <c>◎</c> 1, [ { player.skillName1 } ]  <G>/  마나 소모 : { player.skillUseMana1 }</G>\n"
                                        + $" <c>◎</c> 2, [ { player.skillName2 } ]  <G>/  마나 소모 : { player.skillUseMana2 }</G>\n"
                                        + $" <c>◎</c> 3, 돌아가기.\n\n"
                                         + "「 어떤 행동을 하시겠습니까? 」: ";
                        string skillselect = Choice(skillList, "1", "2", "3");
                        WriteLine();
                        switch (skillselect)
                        {
                            case "1":
                                if (player.manaPoint >= player.skillUseMana1)
                                {
                                    switch (player.job)
                                    {
                                        case "전사":
                                            warrior = (Warrior)player;
                                            warrior.Skill_DA(enemy);
                                            break;
                                        case "도적":
                                            thief = (Thief)player;
                                            thief.Skill_SA(enemy);
                                            break;
                                    }
                                    WriteLine();
                                    Enemy_Action(player, enemy);
                                    break;
                                }
                                else
                                {
                                    ColorLine(enableSkill);
                                }
                                break;
                            case "2":
                                if (player.manaPoint >= player.skillUseMana2)
                                {
                                    switch (player.job)
                                    {
                                        case "전사":
                                            warrior = (Warrior)player;
                                            warrior.Skill_PS(enemy);
                                            break;
                                        case "도적":
                                            thief = (Thief)player;
                                            thief.Skill_To(enemy);
                                            break;
                                    }
                                    WriteLine();
                                    Enemy_Action(player, enemy);
                                }
                                else
                                {
                                    ColorLine(enableSkill);
                                }
                                break;
                            case "3":
                                break;
                        }
                        break;
                    case "3":
                        EStat(enemy);
                        break;
                    case "4":
                        SleepLine("「 당신은 전투에서 도망쳤습니다. 」");
                        ColorLine("<r> ────────────────────────────────────────────────────────────────</r>");
                        WriteLine();
                        reset = false;
                        break;
                }
                if (enemy.healthPoint <= 0)
                {
                    WriteLine();
                    SleepLine($"「 <y>[ { enemy.name } ]</y> 은(는) 체력이 다해 쓰러졌습니다. 」");
                    ColorLine($"「 당신은 <y>[ { enemy.name } ]</y> 과(와)의 전투에서 승리했습니다! 」");
                    player.experiencePoint += enemy.experiencePoint;
                    SleepLine($"「 당신은 <c>[ { enemy.experiencePoint } ]</c> 만큼의 경험치를 얻었습니다. 」");
                    ColorLine("<r> ────────────────────────────────────────────────────────────────</r>");
                    WriteLine();
                    player.Player_LevelUp();
                    switch (player.questNumber)
                    {
                        case 1:
                            if (enemy.name == "굶주린 웨어울프")
                            {
                                player.questStack++;
                            }
                            break;
                        case 2:
                            if (enemy.name == "약삭빠른 고블린")
                            {
                                Random rand = new Random();
                                int itemDrop = rand.Next(100);
                                if (itemDrop > 29)
                                {
                                    SleepLine($"「 당신은 <y>[ { enemy.name } ]</y> 에게서 <m>[ 특별한 광물 ]</m> 을 얻었습니다. 」");
                                    player.questStack++;
                                }
                                else
                                {
                                    SleepLine($"「 당신은 <y>[ { enemy.name } ]</y> 을(를) 뒤져보았으나 아무것도 찾지 못했습니다. 」");
                                }
                            }
                            break;
                        case 4:
                            if (enemy.name == "저주하는 스켈레톤")
                            {
                                player.questStack++;
                            }
                            break;
                        case 5:
                            if (enemy.name == "지배자 스켈레톤 킹")
                            {
                                ColorLine("<y>【 스켈레톤 킹 】</y>");
                                SleepLine("\" 또 다시... 무너....지면... \"",true);
                                SleepLine($"「 당신은 <y>[ { enemy.name } ]</y> 에게서 <m>[ 파란 빛의 마법석 ]</m> 을 얻었습니다. 」");
                                player.questStack++;
                            }
                            break;
                    }
                    break;
                }
                else if (player.healthPoint <= 0)
                {
                    ColorLine($"「 당신은 체력이 다해 쓰러졌습니다. 」");
                    WriteLine();
                    SleepLine("<r> ────────────────────────────────────────────────────────────────</r>");
                    WriteLine();
                    SleepLine($"「 당신은 <y>[ { enemy.name } ]</y> 과의 전투에서 패배했습니다. 」");
                    WriteLine();
                    WriteLine();
                    ColorLine("<r>           ┃                              ┃</r>");
                    ColorLine("<r>           ┃          Game  Over          ┃</r>");
                    ColorLine("<r>           ┃                              ┃</r>");
                    WriteLine();
                    WriteLine();
                    ColorLine("<r> ────────────────────────────────────────────────────────────────</r>");
                    ReadLine();
                }
            }
        }
        public static void Enemy_Action(Player player, Enemy enemy) // 몬스터 행동 패턴
        {
            switch (enemy.type)
            {
                case "야수형":
                    enemy.Enemy_Attack_Action(player);
                    break;
                case "인간형":
                    Zombie zombie;
                    Goblin goblin;
                    SkeletonKing skeletonKing;
                    Skeleton skeleton;
                    Random rand1 = new Random();
                    int enemyAction = rand1.Next(10);
                    if (enemyAction < 3)
                    {
                        Random rand2 = new Random();
                        int enemySkill = rand2.Next(2);
                        switch (enemy.name)
                        {
                            case "썩어가는 좀비":
                                if (enemy.manaPoint >= enemy.skillUseMana1)
                                {
                                    zombie = (Zombie)enemy;
                                    zombie.Skill_SB(player);
                                }
                                else
                                {
                                    enemy.Enemy_Attack_Action(player);
                                }
                                break;
                            case "약삭빠른 고블린":
                                switch (enemySkill)
                                {
                                    case 0:
                                        if (enemy.manaPoint >= enemy.skillUseMana1)
                                        {
                                            goblin = (Goblin)enemy;
                                            goblin.Skill_PA(player);
                                        }
                                        else
                                        {
                                            enemy.Enemy_Attack_Action(player);
                                        }
                                        break;
                                    case 1:
                                        if (enemy.manaPoint >= enemy.skillUseMana2)
                                        {
                                            goblin = (Goblin)enemy;
                                            goblin.Skill_Po(player);
                                        }
                                        else if (enemy.manaPoint >= enemy.skillUseMana1)
                                        {
                                            goblin = (Goblin)enemy;
                                            goblin.Skill_PA(player);
                                        }
                                        else
                                        {
                                            enemy.Enemy_Attack_Action(player);
                                        }
                                        break;
                                }
                                break;
                            case "저주하는 스켈레톤":
                                switch (enemySkill)
                                {
                                    case 0:
                                        if (enemy.manaPoint >= enemy.skillUseMana1)
                                        {
                                            skeleton = (Skeleton)enemy;
                                            skeleton.Skill_Ba(player);
                                        }
                                        else
                                        {
                                            enemy.Enemy_Attack_Action(player);
                                        }
                                        break;
                                    case 1:
                                        if (enemy.manaPoint >= enemy.skillUseMana2)
                                        {
                                            skeleton = (Skeleton)enemy;
                                            skeleton.Skill_CV(player);
                                        }
                                        else
                                        {
                                            enemy.Enemy_Attack_Action(player);
                                        }
                                        break;
                                }
                                break;
                            case "지배자 스켈레톤 킹":
                                switch (enemySkill)
                                {
                                    case 0:
                                        if (enemy.minStrikingPower < 260)
                                        {
                                            skeletonKing = (SkeletonKing)enemy;
                                            skeletonKing.Skill_PU();
                                        }
                                        else if (enemy.manaPoint >= enemy.skillUseMana2)
                                        {
                                            skeletonKing = (SkeletonKing)enemy;
                                            skeletonKing.Skill_ST(player);
                                        }
                                        else
                                        {
                                            enemy.Enemy_Attack_Action(player);
                                        }
                                        break;
                                    case 1:
                                        if (enemy.manaPoint >= enemy.skillUseMana2)
                                        {
                                            skeletonKing = (SkeletonKing)enemy;
                                            skeletonKing.Skill_ST(player);
                                        }
                                        break;
                                }
                                break;
                        }
                    }
                    else
                    {
                        enemy.Enemy_Attack_Action(player);
                    }
                    break;
            }
            player.Condition_Damame();
            enemy.Condition_Damame();
        }
        public static void Town_Action(Player player, ref bool reaction) // 타운 내부 행동 패턴
        {
            string ment = null;
            string select = null;
            switch (player.questNumber)
            {
                case 1:
                    if (player.questStack >= 2)
                    {
                        reaction = false;
                    }
                    else
                    {
                        SleepLine($"「 웰턴 타운 입구에서 경비병이 당신을 막아섭니다. 」");
                        ColorLine("<y>【 경비병 】</y>");
                        SleepLine("\" 웨어울프를 처치하고 돌아오면 들여보내주겠네. \"",true);
                    }
                    break;
                case 2:
                    ment = " <c>◎</c> 1. 대장간의 대장장이를 만난다.\n"
                         + " <c>◎</c> 2. 대성당의 클레아를 만난다.\n"
                         + " <c>◎</c> 3. 아무것도 하지 않는다.\n\n"
                         + "「 무엇을 하시겠습니까? 」: ";
                    select = Choice(ment, "1", "2", "3");
                    WriteLine();
                    switch (select)
                    {
                        case "1":
                            if (player.questStack >= 3)
                            {
                                reaction = false;
                            }
                            else
                            {
                                SleepLine($"「 당신은 대장간의 문을 열고 들어갑니다. 」");
                                ColorLine("<y>【 대장장이 】</y>");
                                SleepLine("\" 광물은 아직인가? 가능하면 빨리 그 광물을 만져보고 싶군. \"",true);
                            }
                            break;
                        case "2":
                            SleepLine($"「 당신은 대성당의 입구에서 클레아를 만났습니다. 」");
                            ColorLine("<y>【 클레아 】</y>");
                            SleepLine("\" 안녕하세요, 치료를 받으러 오셨나요? \"",true);
                            ment = "「<y>【 클레아 】</y>에게 치료를 받으시겠습니까? 」\n\n"
                                 + "「    1. 네    /    2. 아니오    」: ";
                            select = Choice(ment, "1", "2");
                            WriteLine();
                            switch (select)
                            {
                                case "1":
                                    SleepLine("「 클레아는 능숙한 솜씨로 당신의 상처를 치료했습니다. 」");
                                    player.healthPoint = player.maxHealthPoint;
                                    player.manaPoint = player.maxManaPoint;
                                    SleepLine("<c>「 체력과 마나가 모두 회복되었습니다. 」</c>");
                                    break;
                                case "2":
                                    break;
                            }
                            ColorLine("<y>【 클레아 】</y>");
                            SleepLine("\" 부디 몸조심 하세요. 바렌지아의 가호가 함께하시길. \"",true);
                            break;
                        case "3":
                            break;
                    }
                    break;
                case 3:
                case 4:
                case 5:
                    ment = " <c>◎</c> 1. 아우룸 길드의 라크다난을 만난다.\n"
                         + " <c>◎</c> 2. 대성당의 클레아를 만난다.\n"
                         + " <c>◎</c> 3. 아무것도 하지 않는다.\n\n"
                         + "「 무엇을 하시겠습니까? 」: ";
                    select = Choice(ment, "1", "2", "3");
                    WriteLine();
                    switch (select)
                    {
                        case "1":
                            if (player.questNumber == 4)
                            {
                                if (player.questStack >= 2)
                                {
                                    reaction = false;
                                }
                            }
                            else if (player.questNumber == 5)
                            {
                                if (player.questStack >= 1)
                                {
                                    reaction = false;
                                }
                            }
                            else
                            {
                                SleepLine($"「 당신은 아우룸 길드 안으로 들어가려 했으나 문이 닫혀있었습니다. 」");
                            }
                            break;
                        case "2":
                            SleepLine($"「 당신은 대성당의 입구에서 클레아를 만났습니다. 」");
                            ColorLine("<y>【 클레아 】</y>");
                            SleepLine("\" 안녕하세요, 치료를 받으러 오셨나요? \"",true);
                            ment = "「<y>【 클레아 】</y>에게 치료를 받으시겠습니까? 」\n\n"
                                 + "「    1. 네    /    2. 아니오    」: ";
                            select = Choice(ment, "1", "2");
                            WriteLine();
                            switch (select)
                            {
                                case "1":
                                    SleepLine("「 클레아는 능숙한 솜씨로 당신의 상처를 치료했습니다. 」");
                                    player.healthPoint = player.maxHealthPoint;
                                    player.manaPoint = player.maxManaPoint;
                                    SleepLine("<c>「 체력과 마나가 모두 회복되었습니다. 」</c>");
                                    break;
                                case "2":
                                    break;
                            }
                            ColorLine("<y>【 클레아 】</y>");
                            SleepLine("\" 부디 몸조심 하세요. 바렌지아의 가호가 함께하시길. \"",true);
                            break;
                        case "3":
                            break;
                    }
                    break;
            }
        }
    }
}
