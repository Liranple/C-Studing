using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Homework0121.Maps;
using Homework0121.Players;
using Homework0121.Properties;
using static System.Console;
using static Homework0121.CommonAction;
using static Homework0121.CommonUtility;
using static Homework0121.ServerPrinter;

namespace Homework0121
{
    class GameStory
    {
        public bool reset = true; // 기본 반복 여부
        public string select = null; // 선택지
        public string ment = null; // 문구

        public bool item_map = false; // 지도 습득 여부
        public bool board = false; // 게시판 확인 여부

        public Town town = new Town(); // 필드 타운 생성
        public Forest forest = new Forest(); // 필드 포레스트 생성
        public Temple temple = new Temple(); // 필드 템플 생성
        public Cave cave = new Cave(); // 필드 케이브 생성

        public Player player;// 플레이어 생성

        public void FullStoryLine()
        {
            SetWindowSize(130, 50);

            CharacterCreate();
            JoinMessage();

            StoryLine1();
            StoryLine2();
            StoryLine3();
            StoryLine4();
            StoryLine5();

            Epilogue();
        }
        public void CharacterCreate()
        {
            string playerName = null;

            Warrior warrior = new Warrior();
            Thief thief = new Thief();

            WriteLine(" ────────────────────────────────────────────────────────────────");
            ColorLine();
            ColorLine("<g>              『 드림캐쳐에 오신것을 환영합니다 』             </g>");
            WriteLine();
            ColorLine("<g>                   『 캐릭터를 생성합니다 』                   </g>");
            WriteLine();
            WriteLine(" ────────────────────────────────────────────────────────────────");
            WriteLine();
            while (reset == true)
            {
                Color(Resources.message1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                playerName = ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                WriteLine();
                ment = $"「 캐릭터의 이름을 <y>[ { playerName } ]</y> (으)로 하시겠습니까? 」\n\n"
                      + "「    1. 네    /    2. 아니오    」: ";
                select = Choice(ment, "1", "2");
                switch (select)
                {
                    case "1":
                        reset = false;
                        break;
                    case "2":
                        WriteLine();
                        break;
                }
            }
            reset = true;
            WriteLine();
            WriteLine(" ────────────────────────────────────────────────────────────────");
            WriteLine();

            while (reset == true)
            {
                // 직업 선택 구간
                ment = "                    <g>『 직업을 선택합니다 』</g>                    \n\n"
                    + $" <c>◎</c> 1. <y>{ warrior.job }</y> -- [ 긍지높은 하얀늑대 부족의 마지막 생존자입니다. ]\n"
                    + $" <c>◎</c> 2. <y>{ thief.job }</y> -- [ 리스턴 도적 길드의 엘리트 단원이였습니다. ]\n\n"
                     + "「 캐릭터의 직업을 선택해주세요 」: ";
                select = Choice(ment, "1", "2");
                switch (select)
                {
                    case "1":
                        player = warrior;
                        break;
                    case "2":
                        player = thief;
                        break;
                }
                player.name = playerName;
                PStat(player);

                // 직업 확정 구간
                ment = $"「 직업<y>《 { player.job } 》</y>(으)로 결정하시겠습니까? 」\n\n"
                      + "「    1. 네    /    2. 아니오    」: ";
                select = Choice(ment, "1", "2");
                switch (select)
                {
                    case "1":
                        Clear();
                        WriteLine(" ────────────────────────────────────────────────────────────────");
                        WriteLine();
                        WriteLine("「 캐릭터가 정상적으로 생성되었습니다. 」");
                        WriteLine();
                        ColorLine($"「 <y>{ player.name }</y> 님의 직업은<y>《 { player.job } 》</y>입니다. 」");
                        WriteLine();
                        WriteLine(" ────────────────────────────────────────────────────────────────");

                        reset = false;
                        break;
                    case "2":
                        WriteLine();
                        WriteLine(" ────────────────────────────────────────────────────────────────");
                        WriteLine();
                        break;
                }
            }
            reset = true;

            Thread.Sleep(2000);

            // 캐릭터 생성 분기점 ************************************************
        }
        public void JoinMessage()
        {
            WriteLine();
            WriteLine(" ────────────────────────────────────────────────────────────────");
            WriteLine();
            ColorLine("<g>                  『 게임에 접속되었습니다 』                  </g>");
            ColorLine("<g>               『 즐거운 시간 되시길 바랍니다 』               </g>");
            WriteLine();
            WriteLine(" ────────────────────────────────────────────────────────────────");
            WriteLine();
            WriteLine();
            ColorLine("<c>   ■            본 게임은 자동으로 진행되지만            ■   </c>");
            ColorLine("<c>   ■   일부 구간은 엔터를 입력하여 진행할 수 있습니다.   ■   </c>");
            WriteLine();
            WriteLine();
            Thread.Sleep(2000);

            // 접속 문구 출력 분기점 ************************************************
        }
        public void StoryLine1()
        {
            SleepLine("<r>「 알바나 전쟁 」</r>", true);
            Sleep("「 아이단 국왕이 다스리는 솔리움 왕국, 그리고 폴드린 국왕이 다스리는 하벨 왕국간의 영토 전쟁이 발발했다. 」", true);
            Sleep("「 전쟁이 길어짐에 따라 양측에서는 물자나 용병 보급을 피할 수 없었고, 주변의 마을들을 약탈하여 부족한 물자를 채웠다. 」", true);
            Sleep("「 두 왕국 사이에 위치한 알바나 산맥에는 몇 만년간 쌓였던 눈 대신에 <r>붉은 핏물</r>이 물들었고 」", true);
            SleepLine("「 검게 드리워진 하늘에는 수 년간 빛 한 점 들지 않았다. 」", true);
            Thread.Sleep(2000);
            SleepLine("「 그리고 기나긴 전쟁이 끝난 현재. 」", true);
            Thread.Sleep(2000);
            switch (player.job)
            {
                case "전사":
                    Sleep("「 당신은 하얀 눈으로 덮힌 묘비의 앞에 서있습니다. 」",true);
                    Sleep("「 잠시 숨을 고른 당신은 손에 쥐어진 파란 꽃을 묘비 앞에 내려놓고 주변을 둘러봅니다. 」", true);
                    Sleep("「 넓게 펼쳐진 하얀 배경에는 같은 모양의 묘비들이 나란히 놓여져 있습니다. 」", true);
                    Sleep("「 당신은 묘비에 가볍게 목례를 하고는 등을 돌려 알바나 산맥에서 내려옵니다. 」", true);
                    break;
                case "도적":
                    Sleep("「 당신은 정신없이 달리던 중, 더 이상 뒤따라오는 사람이 없음을 알아챕니다. 」", true);
                    Sleep("「 잠시 숨을 고른 당신은 주머니를 열어 안을 확인합니다. 」", true);
                    Sleep("「 주머니 안에는 작은 양피지 하나가 들어있었고, 당신은 안도하며 주변을 둘러봅니다. 」", true);
                    Sleep("「 시야가 확보되지 않은 빽빽한 숲에서 당신은 특유의 직감만을 믿고 발걸음을 조용히 옮깁니다. 」", true);
                    break;
            }
            Thread.Sleep(2000);
            player.zone = town.name;
            EnterZone(player);
            WriteLine();
            SleepLine("「 당신이 입구를 지나가려 하자 경비병이 막아섭니다. 」");
            ColorLine("<y>【 경비병 】</y>");
            SleepLine("\" 멈춰라. 이곳은 영주님의 명에 따라 외부인은 들일 수 없다. 돌아가라. \"",true);
            ment = " <c>◎</c> 1. 경비병을 향해 무기를 꺼내든다.\n"
                 + " <c>◎</c> 2. 어떻게 하면 들어갈 수 있는지 물어본다.\n\n"
                 + "「 어떻게 하시겠습니까? 」: ";
            select = Choice(ment, "1", "2");
            switch (select)
            {
                case "1":
                    WriteLine();
                    SleepLine("「 당신이 무기를 꺼내 경비병에게 겨누자 경비병이 놀라며 뒤로 물러섭니다. 」");
                    ColorLine("<y>【 경비병 】</y>");
                    Sleep("\" 이봐, 진정해. 그렇게까지 할 필요는 없다고. \"",true);
                    SleepLine("\" 정 들어가고 싶다면 방법이 아주 없는건 아니야. \"",true);
                    break;
                case "2":
                    WriteLine();
                    SleepLine("「 당신은 경비병에게 타운에 들어가는 방법을 묻습니다. 」");
                    ColorLine("<y>【 경비병 】</y>");
                    SleepLine("\" 꼭 들어가고 싶은건가? 그렇다면 한 가지 방법을 알려주도록 하지. \"",true);
                    break;
            }
            Sleep("\" 요새 근처 숲에서 웨어울프가 종종 출몰한다고 하더군. \"",true);
            SleepLine("\" 자네가 그것을 처리한다면 안으로 들여보내주겠네. \"",true);
            while (reset == true)
            {
                ment = "「<y>【 경비병 】</y>의 퀘스트를 수락하시겠습니까? 」\n\n"
                     + "「    1. 네    /    2. 아니오    」: ";
                select = Choice(ment, "1", "2");
                switch (select)
                {
                    case "1":
                        WriteLine();
                        Sleep("<c>「《 웰턴 타운으로 》퀘스트를 받았습니다. 」</c>");
                        player.questNumber = 1;
                        Quest(player);
                        reset = false;
                        ReadKey();
                        break;
                    case "2":
                        WriteLine();
                        ColorLine("<r>「 반드시 퀘스트를 받아야 합니다. 」</r>");
                        WriteLine();
                        break;
                }
            }
            reset = true;
            ColorLine("<y>【 경비병 】</y>");
            SleepLine("\" 그럼 웨어울프를 처치하고 다시 돌아오게. \"",true);
            Sleep("「 당신은 웨어울프를 처치하기 위해 숲으로 이동합니다. 」");
            player.zone = forest.name;
            EnterZone(player);
            WriteLine();
            Action(player);

            // 퀘스트 1 완료 분기점 ************************************************
        }
        public void StoryLine2()
        {
            ColorLine("<y>【 경비병 】</y>");
            Sleep("\" 웨어울프를 처치하고 돌아온 모양이군. 타운에 들어갈 명분은 생긴 셈이지. \"",true);
            SleepLine("\" 타운에 들어가는것을 허락하겠네. \"",true);
            player.experiencePoint += 300;
            WriteLine(" ────────────────────────────────────────────────────────────────");
            ColorLine("<c>                 「 퀘스트를 완료했습니다 」                  </c>");
            WriteLine();
            ColorLine("          「 <g>[ 300 ]</g> 만큼의 경험치를 얻었습니다. 」     ");
            WriteLine(" ────────────────────────────────────────────────────────────────");
            ReadLine();
            player.Player_LevelUp();
            SleepLine("「 당신은 경비병의 안내에 따라 웰턴 타운 안으로 들어갑니다. 」");
            SleepLine("「 타운 안으로 들어서자 많은 사람들이 북적대는 모습이 보입니다. 」");
            ColorLine("<y>【 ??? 】</y>");
            SleepLine("\" 실례합니다. 혹시 여행자이신가요? \"",true);
            SleepLine("「 잠시 주변을 둘러보던 당신에게 길드 복장을 입은 여성이 말을 건네옵니다. 」");

            ment = " <c>◎</c> 1. 여인의 말을 무시하고 지나간다.\n"
                 + " <c>◎</c> 2. 여인을 바라보며 신분을 밝힌다.\n\n"
                 + "「 어떻게 하시겠습니까? 」: ";
            select = Choice(ment, "1", "2");
            switch (select)
            {
                case "1":
                    WriteLine();
                    SleepLine("「 당신은 말을 건네온 여인을 무시한 채 다시 타운 안을 둘러봅니다. 」");
                    break;
                case "2":
                    WriteLine();
                    SleepLine("「 당신은 여인에게 현재 여행을 하는 중이라 말하며 신분을 밝힙니다. 」");
                    ColorLine("<y>【 아이라 】</y>");
                    SleepLine("\" 안녕하세요 여행자님. 저는 이곳 웰턴의 길드 안내원인 아이라 라고 합니다. \"",true);
                    SleepLine("「 자신을 아이라라 밝힌 여인은 주머니에서 지도를 꺼내 당신에게 건네줍니다. 」");
                    ColorLine("<y>【 아이라 】</y>");
                    Sleep("\" 웰턴 타운의 정보가 적힌 지도예요. 워낙 크다보니 길을 잃는 여행자분들이 계시더라고요. \"",true);
                    SleepLine("\" 타운의 동쪽으로 오시면 다양한 길드가 모여있는 건물이 있으니 꼭 한 번 찾아와주세요. \"",true);
                    Sleep("「 여인은 당신에게 고개를 꾸벅이고는 입구로 들어오는 다른 사람들에게로 돌아갔습니다. 」");
                    SleepLine("「 당신은 지도를 주머니에 넣고는 다시 타운 안을 둘러봅니다. 」");
                    item_map = true;
                    break;
            }
            SleepLine("「 주변에는 무기를 파는 대장장이와 많은 사람이 모여있는 게시판이 보입니다. 」");
            while (reset == true)
            {
                ment = " <c>◎</c> 1. 타운 입구의 게시판으로 간다.\n"
                     + " <c>◎</c> 2. 대장장이의 대장간으로 다가간다.\n\n"
                     + "「 어디로 이동 하시겠습니까? 」: ";
                select = Choice(ment, "1", "2");
                switch (select)
                {
                    case "1":
                        WriteLine();
                        SleepLine("「 당신은 타운 입구에 설치된 게시판으로 다가갑니다. 」");
                        SleepLine("「 게시판에는 용병을 모집하는 글이 적혀있습니다. 」");
                        ColorLine(" ────────────────────────────────────────────────────────────────");
                        ColorLine("                      『 정예 용병 모집 』                      ");
                        WriteLine();
                        WriteLine("  최근 서쪽의 숲 주변에서 원인불명의 실종사건이 발생하고 있다.  ");
                        WriteLine("       이에 우리 루그두눔 기사단에서는 숲 주변을 수색하고       ");
                        WriteLine("           실종된 사람들을 구하기 위해 용병을 모집한다.         ");
                        WriteLine();
                        WriteLine(" 큰 공헌을 한 용병에게는 루그두눔 기사단에 입단할 영광을 주겠다.");
                        WriteLine();
                        WriteLine("      의사가 있는 용병들은 루그두눔 기사단으로 오길 바란다.     ");
                        ColorLine(" ────────────────────────────────────────────────────────────────");
                        ReadLine();
                        SleepLine("「 당신은 게시판에 쓰여진 글에 흥미를 느끼고는 다시 돌아섭니다. 」");
                        board = true;
                        break;
                    case "2":
                        WriteLine();
                        SleepLine("「 당신은 무기를 팔고있는 대장장이의 대장간으로 이동합니다. 」");
                        ColorLine("<y>【 대장장이 】</y>");
                        SleepLine("\" 이봐! 웰턴 타운에서 가장 좋은 무기를 사고 싶으면 여기로 오라고! \"",true);
                        SleepLine("「 대장장이는 호탕한 목소리를 내며 당신을 대장간으로 안내합니다. 」");
                        Sleep("「 대장간 안에는 거대한 무기부터 화려한 무기까지 다양하게 나열되어 있었습니다. 」");
                        SleepLine("「 당신은 무기들을 둘러보던 중 무기를 살만한 돈이 없다는 것을 깨닫고는 이내 등을 돌립니다. 」");
                        ColorLine("<y>【 대장장이 】</y>");
                        SleepLine("\" 어이 형씨. 보아하니 여행자 같은데 내 부탁 하나 들어주지 않겠나? \"",true);
                        SleepLine("「 대장간을 나가려는 당신은 뒤에서 들려오는 무기 상인의 목소리에 다시 등을 돌려 대장장이를 바라봅니다. 」"); ;
                        ColorLine("<y>【 대장장이 】</y>");
                        Sleep("\" 최근 남쪽의 사원에서 특별한 광물을 발견했는데 고블린들 때문에 도저히 갈 수가 없더군. \"",true);
                        SleepLine("\" 아마 그 놈들이 광물을 독점하려는 모양이야. \"",true);
                        Sleep("\" 그래서 말인데..그 놈들을 잡아서 광물을 몇 개만 가져다 주었으면 하네. \"",true);
                        SleepLine("\" 보수는 그 광물로 형씨에게 특별한 무기를 만들어 주도록 하지. 어떤가? \"",true);
                        while (reset == true)
                        {
                            ment = "「<y>【 대장장이 】</y>의 퀘스트를 수락하시겠습니까? 」\n\n"
                                 + "「    1. 네    /    2. 아니오    」: ";
                            select = Choice(ment, "1", "2");
                            switch (select)
                            {
                                case "1":
                                    WriteLine();
                                    Sleep("<c>「《 오색 빛의 광물 》퀘스트를 받았습니다. 」</c>");
                                    player.questNumber = 2;
                                    player.questStack = 0;
                                    Quest(player);
                                    reset = false;
                                    ReadKey();
                                    break;
                                case "2":
                                    WriteLine();
                                    ColorLine("<r>「 반드시 퀘스트를 받아야 합니다. 」</r>");
                                    WriteLine();
                                    break;
                            }
                        }
                        break;
                }
            }
            reset = true;
            ColorLine("<y>【 대장장이 】</y>");
            SleepLine("\" 좋아! 그럼 형씨만 믿고 기다리고 있겠네! \"",true);
            SleepLine("「 당신은 대장장이의 호탕한 웃음소리와 함께 대장간을 나옵니다. 」");
            Sleep("「 대장간을 나와 타운 밖으로 향하던 중 당신은 뒤쪽에서 갑자기 옷자락이 당겨지는 것을 느낍니다. 」");
            SleepLine("「 뒤를 돌아보니 한 꼬마아이가 꽃을 든 채로 당신을 물끄러미 바라봅니다. 」");
            ColorLine("<y>【 꼬마아이 】</y>");
            SleepLine("\" 피나요! 여기, 여기 피나요! \"",true);
            Sleep("「 꼬마아이는 손가락으로 당신의 옆구리를 가리킵니다. 」");
            SleepLine("「 손가락이 가리킨 옆구리를 보니 꽤나 상처가 벌어져 있었습니다. 」");
            ColorLine("<y>【 꼬마아이 】</y>");
            SleepLine("\" 저어기 대성당 있어요. 가면 신부님이 치료해줘요. \"",true);
            Sleep("「 꼬마아이는 당신의 옆구리에 있던 손가락을 반대편 방향으로 옮겼습니다. 」");
            SleepLine("「 저 멀리 건물틈에서 높게 솟아오른 한 건물이 눈에 들어옵니다. 」");
            ColorLine("<y>【 꼬마아이 】</y>");
            SleepLine("\" 이쪽이예요. 같이 가요! \"",true);
            Sleep("「 꼬마아이는 당신의 옷자락을 다시 잡고는 등을 돌렸습니다. 」");
            SleepLine("「 당신은 꼬마아이를 따라 대성당 앞으로 이동합니다. 」");
            ColorLine("<y>【 ??? 】</y>");
            SleepLine("\" 어머, 마를렌. 이분은 누구시니? \"",true);
            SleepLine("「 대성당 앞에 다다르자 성직자 복장을 한 여인이 꼬마아이에게 싱긋 웃으며 말을 꺼냅니다. 」");
            ColorLine("<y>【 마를렌 】</y>");
            SleepLine("\" 신부님! 여기. 피나요! 치료해야해요. \"",true);
            SleepLine("「 마를렌은 당신의 옆구리를 다시 한 번 가리킵니다. 」");
            ColorLine("<y>【 ??? 】</y>");
            SleepLine("\" 안으로 들어오세요. 이쪽이예요. \"",true);
            Sleep("「 당신의 상처를 본 신부는 대성당 안으로 당신을 안내합니다. 」");
            Sleep("「 대성당 안은 창문으로 들어오는 빛 때문인진 몰라도 성스러운 분위기가 감돌았습니다. 」");
            SleepLine("「 당신은 신부를 따라 대성당 한 쪽에 자리한 방에 들어갑니다. 」");
            ColorLine("<y>【 클레아 】</y>");
            Sleep("\" 저는 클레아라고 해요. 이 성당에서 일하고 있죠. \"",true);
            SleepLine("\" 이 타운에서는 처음뵈는것 같은데, 혹시 여행자이신가요? \"",true);
            SleepLine("「 클레아는 당신을 치료하며 자연스럽게 말을 건넸습니다. 」");
            ment = " <c>◎</c> 1. 침묵을 지킨다.\n"
                 + " <c>◎</c> 2. 클레아에게 신분을 밝힌다.\n\n"
                 + "「 어떻게 하시겠습니까? 」: ";
            select = Choice(ment, "1", "2");
            WriteLine();
            switch (select)
            {
                case "1":
                    SleepLine("「 당신은 클레아의 말을 무시합니다. 」");
                    ColorLine("<y>【 클레아 】</y>");
                    SleepLine("\" 말하기 곤란하시다면 말씀 안해주셔도 괜찮아요. \"",true);
                    SleepLine("「 클레아는 당신을 바라보며 싱긋 웃습니다. 」");
                    break;
                case "2":
                    SleepLine("「 당신은 클레아에게 현재 여행중인 여행자라고 말합니다. 」");
                    ColorLine("<y>【 클레아 】</y>");
                    SleepLine("\" 요새 경비가 삼엄해져서 여행자분들은 타운에 들어오기 힘드셨을텐데 고생많으셨어요. \"",true);
                    SleepLine("「 클레아는 미안하다는 표정을 지으며 조심스럽게 말합니다. 」");
                    break;
            }
            ColorLine("<y>【 클레아 】</y>");
            SleepLine("\" 지, 치료는 끝났어요. 혹시나 또 다치시거나 하시면 주저말고 저를 찾아와주세요. \"",true);
            SleepLine("「 클레아는 능숙한 솜씨로 당신의 상처를 치료했습니다. 」");
            player.healthPoint = player.maxHealthPoint;
            player.manaPoint = player.maxManaPoint;
            SleepLine("<c>「 체력과 마나가 모두 회복되었습니다. 」</c>");
            Sleep("「 당신은 클레아에게 인사를 건넨 후 타운 밖으로 발걸음을 옮깁니다. 」");
            player.zone = temple.name;
            EnterZone(player);
            WriteLine();
            Action(player);

            // 퀘스트 2 완료 분기점 ************************************************
        }
        public void StoryLine3()
        {
            SleepLine("「 당신이 대장간 문을 열고 들어가자 대장장이가 환한 미소를 띄며 당신을 바라봅니다. 」");
            ColorLine("<y>【 대장장이 】</y>");
            SleepLine("\" 돌아왔군 형씨! 빨리 그 광물을 만지고 싶어서 손이 근질근질 하다고! 하하하! \"",true);
            SleepLine("「 당신은 대장장이에게 <m>[ 특별한 광물 ]</m> 을 건네주었습니다. 」");
            player.experiencePoint += 400;
            WriteLine(" ────────────────────────────────────────────────────────────────");
            ColorLine("<c>                 「 퀘스트를 완료했습니다 」                  </c>");
            WriteLine();
            ColorLine("          「 <g>[ 400 ]</g> 만큼의 경험치를 얻었습니다. 」     ");
            WriteLine(" ────────────────────────────────────────────────────────────────");
            ReadLine();
            player.Player_LevelUp();
            ColorLine("<y>【 대장장이 】</y>");
            SleepLine("\" 오오오.. 이 감촉..! 이 단단함..! 정말 굉장하구만...! \"",true);
            SleepLine("「 대장장이는 광물을 이리저리 살펴보며 연신 감탄사를 내뱉습니다. 」");
            ColorLine("<y>【 대장장이 】</y>");
            Sleep("\" 그렇지! 형씨에게 무기를 만들어주기로 했었지. \"",true);
            SleepLine("\" 형씨한테 어울리는 최고의 무기를 만들어 놓을테니 내일 다시 찾아와주게! \"",true);
            SleepLine("「 대장장이는 기쁜 표정을 짓고는 벌겋게 타오르는 작업실 안으로 들어갔습니다. 」");
            Sleep("「 당신은 더 이상 대장간에 머무를 이유가 없자 밖으로 발걸음을 옮깁니다. 」");
            SleepLine("「 꽤나 시간이 흘렀는지 날은 어둑해져가고 타운은 하나 둘 불빛들을 수놓습니다. 」");
            Sleep("「 당신은 멀리에 여관처럼 보이는 건물을 발견하고는 가까이 다가갑니다. 」");
            SleepLine("「 건물 안으로는 많은 사람들이 술을 마시며 이야기를 나누고 있는 모습이 보였습니다. 」");
            ColorLine("<y>【 여관 주인 】</y>");
            SleepLine("\" 어서오세요. 식사를 하시러 오셨나요? 아니면 묵으러 오셨나요? \"",true);
            SleepLine("「 사람들을 바라보던 당신에게 인상 좋아보이는 남성이 다가왔습니다. 」");
            ment = " <c>◎</c> 1. 식사를 한다.\n"
                 + " <c>◎</c> 2. 숙박을 한다.\n"
                 + " <c>◎</c> 3. 무기를 꺼내 주인을 위협한다.\n\n"
                 + "「 어떻게 하시겠습니까? 」: ";
            select = Choice(ment, "1", "2", "3");
            WriteLine();
            switch (select)
            {
                case "1":
                    SleepLine("「 당신은 식사를 해야겠다는 대답과 동시에 배가 굶주림을 느낍니다. 」");
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 이쪽으로 앉으세요. 식사는 어떻게 하시겠습니까? \"",true);
                    Sleep("「 여관 주인은 메뉴가 적혀있는 종이를 건네어 줍니다. 」");
                    SleepLine("「 당신은 적당한 메뉴를 고른 후, 잠시 기다리자 여관 주인이 먹음직스러운 음식을 들고 옵니다. 」");
                    SleepLine("「 당신은 만족스러운 식사를 마친 후, 숙박을 하기 위해 여관 주인에게 다가갑니다. 」");
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 식사는 괜찮으셨는지요. 식사값과 하루 숙박으로 총 60 베르 입니다. \"",true);
                    break;
                case "2":
                    SleepLine("「 지금 당장 쉬어야 한다는 생각이 당신을 덮쳐옵니다. 」");
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 많이 피로해보이시는 군요, 하루 숙박에 40 베르 입니다. \"",true);
                    break;
                case "3":
                    SleepLine("「 당신은 허리춤에서 무기를 꺼내 여관 주인을 위협합니다. 」");
                    SleepLine("「 순간, 주변이 조용해지며 수 많은 사람들의 시선이 당신에게로 향합니다. 」");
                    ColorLine("<y>【 술을 마시고 있는 남성 】</y>");
                    SleepLine("\" 이봐, 주인장. 아무것도 모르는 꼬맹이인것 같은데 한 번만 봐주라고. \"",true);
                    SleepLine("「 남성의 말이 끝나자 건물 안의 사람들이 모두 폭소를 터트립니다. 」");
                    Sleep("「 당신은 남성과 여관 주인의 얼굴을 번갈아 바라봅니다. 」");
                    SleepLine("「 여관 주인의 얼굴에는 당황한 기색이 전혀 느껴지지 않아 보입니다. 」");
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 이 타운에 들어온지 얼마 되지 않으신 것 같군요. 일단 무기를 집어넣으시지요. \"",true);
                    SleepLine("「 여관 주인은 부드러운 말투로 당신의 무기를 살짝 치웁니다. 」");
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 많이 피곤해보이시는데 조용히 묵다 가시는건 어떠신가요? \"",true);
                    Sleep("「 웃는 여관 주인의 모습에서 묘하게 거부할 수 없는 분위기가 풍겨옵니다. 」");
                    SleepLine("「 당신은 무기를 집어넣고는 얌전히 여관 주인을 따라갑니다. 」");
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 숙박은 하루에 40 베르입니다. \"",true);
                    break;
            }
            Sleep("「 당신은 베르라는 단어를 듣고는 정신이 번쩍 들었습니다. 」");
            SleepLine("「 당신은 주머니에 손을 넣어보았으나 허공에 손을 휘저을 뿐이였습니다. 」");
            ColorLine("<y>【 여관 주인 】</y>");
            SleepLine("\" 하하하. 돈이 없으신가요? \"",true);
            SleepLine("「 당신을 물끄러미 바라보던 여관 주인은 미묘한 표정을 짓습니다. 」");
            ColorLine("<y>【 여관 주인 】</y>");
            SleepLine("\" 이쪽으로 오시지요. \"",true);
            Sleep("「 여관 주인은 그렇게 말하고는 발걸음을 옮겼고 당신은 그 뒤를 따라갑니다. 」");
            SleepLine("「 2층의 어느 방 문 앞에 선 여관 주인은 문을 열고 당신을 안으로 들입니다. 」");
            ColorLine("<y>【 여관 주인 】</y>");
            SleepLine("\" 시간이 늦었으니 먼저 주무시지요. 돈은 나중에 받도록 하겠습니다. \"",true);
            SleepLine("「 방문이 닫히고 여관 주인의 발소리가 멀어집니다. 」");
            Sleep("「 당신은 무언가 기분이 이상했지만 그것이 무엇때문인지 생각할 기력이 없었습니다. 」");
            SleepLine("「 살짝 풀려버린 긴장의 틈에서 당신은 아무도 모르게 잠이 들었습니다. 」");
            Thread.Sleep(3000);
            player.healthPoint = player.maxHealthPoint;
            player.manaPoint = player.maxManaPoint;
            SleepLine("<c>「 체력과 마나가 모두 회복되었습니다. 」</c>");
            Thread.Sleep(3000);
            Sleep("「 햇빛이 창문을 통해 당신의 얼굴을 비춥니다. 」");
            SleepLine("「 얼굴을 찡그리며 잠에서 깬 당신은 주변을 둘러봅니다. 」");
            SleepLine("「 방 안에는 오래되었지만 관리가 잘 되어 있는 물건들이 놓여져 있었습니다. 」");
            Sleep("「 당신의 시선은 옆에 놓여져 있던 하나의 종이에서 멈추었습니다. 」");
            SleepLine("「 당신은 종이를 집어들고는 내용을 확인합니다. 」");
            ColorLine(" ────────────────────────────────────────────────────────────────");
            WriteLine();
            ColorLine("     일어나면 3시까지 동쪽에 있는 길드 건물로 오세요            ");
            WriteLine();
            WriteLine("     혹시라도 도망갈 생각을 하고 있다면 그만두는게 좋을겁니다   ");
            WriteLine();
            WriteLine();
            WriteLine();
            WriteLine("                                             여관 주인          ");
            WriteLine();
            ColorLine(" ────────────────────────────────────────────────────────────────");
            WriteLine();
            SleepLine("「 깔끔한 글씨로 써져있는 글은 당신에게 말을 하는 것이 분명했습니다. 」");
            SleepLine("「 당신은 종이를 주머니에 넣고는 여관 밖을 나갑니다. 」");
            SleepLine("「 타운 안은 여전히 많은 사람들이 교류하고 있습니다. 」");
            ment = " <c>◎</c> 1. 대장간으로 이동한다.\n"
                 + " <c>◎</c> 2. 길드 건물로 이동한다.\n\n"
                 + "「 어디로 이동 하시겠습니까? 」: ";
            bool weapon = false;
            while (reset == true)
            {
                select = Choice(ment, "1", "2");
                WriteLine();
                switch (select)
                {
                    case "1":
                        switch (weapon)
                        {
                            case true:
                                SleepLine("「 당신은 아직 대장간에 갈 필요를 느끼지 못합니다. 」");
                                break;
                            case false:
                                SleepLine("「 당신은 무기를 받기 위해 대장간으로 이동합니다. 」");
                                SleepLine("「 대장간의 문을 열고 들어가자 대장장이는 잔뜩 흥분한 얼굴로 당신을 맞이합니다. 」");
                                ColorLine("<y>【 대장장이 】</y>");
                                SleepLine("\" 형씨! 이거 정말 굉장하다고! 내 인생 걸작이라고 봐도 좋을걸세! \"",true);
                                SleepLine("「 대장장이의 손에는 한 눈에 봐도 비싸보이는 무기가 들려있었습니다. 」");
                                ColorLine("<y>【 대장장이 】</y>");
                                SleepLine("\" 자! 어서 가져가라고! \"",true);
                                SleepLine("「 당신은 대장장이에게 무기를 건네 받았습니다. 」");
                                switch (player.job)
                                {
                                    case "전사":
                                        SleepLine("<c> [ 오리엔탈 대검 ]</c> 을 얻었습니다.");
                                        player.strength += 15;
                                        player.maxStrikingPower += 30;
                                        player.minStrikingPower += 20;
                                        break;
                                    case "도적":
                                        SleepLine("<c> [ 오리엔탈 단검 ]</c> 을 얻었습니다.");
                                        player.dexterity += 25;
                                        player.maxStrikingPower += 15;
                                        player.minStrikingPower += 15;
                                        break;
                                }
                                weapon = true;
                                SleepLine("<c>「 무기 장착으로 스테이터스가 상승하였습니다. 」</c>");
                                ColorLine("<y>【 대장장이 】</y>");
                                SleepLine("\" 다른게 필요하면 찾아오게. 형씨라면 조금 싸게 주도록 하지! \"",true);
                                SleepLine("「 당신은 대장장이의 호의를 받으며 대장간 밖으로 나섭니다. 」");
                                break;
                        }
                        break;
                    case "2":
                        switch (weapon)
                        {
                            case true:
                                SleepLine("「 당신은 종이에 적힌 길드 건물로 이동하려 했으나 타운은 너무나도 복잡했습니다. 」");
                                switch (item_map)
                                {
                                    case true:
                                        Sleep("「 당신은 길드 안내원에게 받은 지도를 꺼내 확인합니다. 」");
                                        break;
                                    case false:
                                        SleepLine("「 당신은 어쩔 수 없이 주변 사람들에게 길을 묻기로 했습니다. 」");
                                        Sleep("「 길을 묻고, 헤메는 과정을 반복하며 당신은 힘겹게 발걸음을 옮깁니다. 」");
                                        break;
                                }
                                reset = false;
                                break;
                            case false:
                                SleepLine("「 당신은 아직 길드 건물로 가기에는 너무 이른시간임을 깨닫습니다. 」");
                                break;
                        }
                        break;
                }
            }
            reset = true;
            SleepLine("「 길드 건물로 이동하던 당신은 다시금 타운이 얼마나 크고 복잡한 공간인지 체감합니다. 」");
            SleepLine("「 당신은 길드로 추정되는 건물 앞에 도착하자 익숙한 얼굴을 찾아볼 수 있었습니다. 」");
            switch (item_map)
            {
                case true:
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 시간 맞춰 오셨군요. 좋습니다. \"",true);
                    SleepLine("「 여관 주인은 만족한듯한 얼굴로 당신을 바라봅니다. 」");
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 여기 서서 말하기는 좀 그러니 안으로 들어가서 얘기하도록 할까요. \"",true);
                    break;
                case false:
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 꽤나 늦으셨군요. 시간은 넉넉했을텐데요.. \"",true);
                    SleepLine("「 당신은 타운이 넓고 복잡하여 길을 찾기 어려웠다고 변명합니다. 」");
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 이상하네요. 안내원이 분명 지도를 나누어주고 있었을텐데요. \"",true);
                    SleepLine("「 순간 당신은 타운 입구에서 마주쳤던 한 여인을 떠올립니다. 여관 주인에게 안좋은 인상을 준 듯 합니다. 」");
                    ColorLine("<y>【 여관 주인 】</y>");
                    SleepLine("\" 어찌됐든 알겠습니다. 우선 안으로 들어가서 얘기하도록 할까요. \"",true);
                    break;
            }
            SleepLine("「 여관 주인은 길드 건물 안으로 당신을 안내합니다. 」");
            SleepLine("「 건물 안에는 다양한 길드들이 사용하고 있는 방들이 있었고 당신은 그 중 아우룸이라는 길드의 방으로 들어갑니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 정식으로 소개하도록 하지요. 제 이름은 라크다난입니다. 여기 아우룸 길드에 소속되어있죠.. \"",true);
            SleepLine("「 라크다난은 자신을 소개하고는 당신을 바라보며 눈을 번뜩입니다. 」");
            switch (player.job)
            {
                case "전사":
                    ColorLine("<y>【 라크다난 】</y>");
                    SleepLine("\" 하얀늑대의 부족원이라. 저도 처음 뵙는군요. \"",true);
                    break;
                case "도적":
                    ColorLine("<y>【 라크다난 】</y>");
                    SleepLine("\" 최근에 로크길드의 기밀문서가 도난당했다지요? \"",true);
                    break;
            }
            SleepLine("「 당신은 라크다난의 말이 끝나기 무섭게 뒤로 물러서며 무기를 꺼냅니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 그렇게 경계하지 않아도 됩니다. 그저 저는 당신에게 의뢰할 것이 있어서 부른거니까요. \"",true);
            SleepLine("「 당신은 경계를 풀지 않은 채로 라크다난을 노려봅니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 좋습니다. 바로 본론으로 들어가지요. 혹시 마을 입구에 있는 게시판을 본 적 있습니까?  \"",true);
            switch (board)
            {
                case true:
                    SleepLine("「 당신은 타운 입구에서 보았던 용병 모집을 떠올리며 고개를 끄덕입니다. 」");
                    ColorLine("<y>【 라크다난 】</y>");
                    Sleep("\" 그럼 얘기가 빠르겠군요. 기사단이 조사하려고 하는 서쪽의 숲 안쪽에는 깊게 파인 동굴이 있어요. \"",true);
                    break;
                case false:
                    SleepLine("「 당신은 희미하게 게시판이 있었다는 사실만을 기억하고 고개를 젓습니다. 」");
                    ColorLine("<y>【 라크다난 】</y>");
                    Sleep("\" 현재 루그두눔 기사단이 용병을 모집해 모종의 실종사건을 조사하려 하고있어요. \"",true);
                    Sleep("\" 서쪽의 숲에서 더 안쪽으로 들어가면 깊게 파인 동굴이 있습니다. \"",true);
                    break;
            }
            SleepLine("\" 저는 최근 실종사건의 원인이 그 동굴에 있다고 생각해요. \"",true);
            SleepLine("\" 제 의뢰는 루그두눔 기사단보다 먼저 그 동굴을 탐사해오는 것입니다. \"",true);
            Sleep("\" 물론 보수는 어젯 밤 외상비를 내고도 충분히 남을 정도로 드리도록 하지요. \"",true);
            SleepLine("\" 싫으시다면 외상비는 따로 갚으셔야겠지요. \"",true);
            SleepLine("「 당신은 라크다난의 말이 반 협박을 하는 것으로 들립니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 어떻게 하시겠어요? \"",true);
            while (reset == true)
            {
                ment = "「<y>【 라크다난 】</y>의 퀘스트를 수락하시겠습니까? 」\n\n"
                     + "「    1. 네    /    2. 아니오    」: ";
                select = Choice(ment, "1", "2");
                switch (select)
                {
                    case "1":
                        WriteLine();
                        Sleep("<c>「《 삼켜버리는 어둠 》퀘스트를 받았습니다. 」</c>");
                        player.questNumber = 3;
                        player.questStack = 0;
                        Quest(player);
                        reset = false;
                        ReadKey();
                        break;
                    case "2":
                        WriteLine();
                        ColorLine("<r>「 반드시 퀘스트를 받아야 합니다. 」</r>");
                        WriteLine();
                        break;
                }
            }
            reset = true;
            ColorLine("<y>【 라크다난 】</y>");
            Sleep("\" 루그두눔 기사단이 슬슬 움직이고 있는 것 같아요. 최대한 빨리 움직여주셔야 합니다. \"",true);
            SleepLine("\" 아, 그리고 이게 도움이 될 것 같군요. \"",true);
            Sleep("「 라크다난은 허리춤에서 작은 전등을 하나 떼어 건네줍니다. 」");
            SleepLine("「 당신은 전등을 허리춤에 차고는 등을 돌려 발걸음을 옮깁니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 아. 그리고 당연하겠지만 오늘 여기에서 한 얘기들은 발설하시면 안됩니다. \"",true);
            SleepLine("「 당신은 문고리를 잡은채로 고개를 끄덕이고는 길드 건물 밖으로 나갑니다. 」");
            SleepLine("「 길드 건물 앞으로는 몇몇의 사람들이 얘기를 나누고 있습니다. 」");
            Sleep("「 당신은 조금 귀찮은 일을 맡아버린 것 같다는 생각을 하며 서쪽의 숲으로 향합니다. 」");
            player.zone = forest.name;
            EnterZone(player);
            WriteLine();
            Action(player);

            // 퀘스트 3~4 완료 분기점 ************************************************
        }
        public void StoryLine4()
        {
            SleepLine($"「 당신이 아우룸 길드의 문을 열고 들어가자 라크다난이 당신을 빤히 바라봅니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 성과가 있었나요? \"",true);
            SleepLine($"「 당신은 스켈레톤의 뼛조각을 보여주며 동굴 안에서 있었던 일을 말해줍니다. 」");
            player.experiencePoint += 400;
            WriteLine(" ────────────────────────────────────────────────────────────────");
            ColorLine("<c>                 「 퀘스트를 완료했습니다 」                  </c>");
            WriteLine();
            ColorLine("          「 <g>[ 400 ]</g> 만큼의 경험치를 얻었습니다. 」     ");
            WriteLine(" ────────────────────────────────────────────────────────────────");
            ReadLine();
            player.Player_LevelUp();
            SleepLine($"「 라크다난은 뼛조각을 이리저리 살펴보더니 이내 표정이 구겨집니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 이게 그 안에 있던 스켈레톤의 뼛조각이라 이거죠? \"",true);
            SleepLine($"「 미묘하게 무거워진 분위기에 당신은 긴장하며 고개를 끄덕입니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            Sleep("\" 알겠습니다. 일단 무사히 돌아온 것 만으로도 당신의 능력이 어느정도인진 알겠군요. \"",true);
            SleepLine("\" 한 가지만 더 의뢰하겠습니다. \"",true);
            SleepLine($"「 라크다난은 주머니에서 돈 뭉치를 당신의 손에 올리며 말을 꺼냈습니다. 」");
            SleepLine($"「 당신은 돈 뭉치를 쥔 채로 라크다난을 바라봅니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            Sleep("\" 스켈레톤들은 무리를 짓고 한 명의 왕이 그 무리를 이끄는 습성이 있습니다. \"",true);
            Sleep("\" 필히 이 스켈레톤들 뒤에는 왕이 있을 것이라는 말이지요. \"",true);
            SleepLine("\" 최근의 실종사건들이 이 스켈레톤들과 연관이 있다면 그건 스켈레톤 킹의 지시임이 분명합니다. \"",true);
            SleepLine($"「 라크다난은 작은 상자를 당신에게 건네줍니다. 」");
            Sleep($"「 상자 주변에는 알 수 없는 오오라가 감싸고 있었습니다. 열어보니 안은 텅 비어있습니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            Sleep("\" 스켈레톤 킹을 처치하고 녀석의 마법석을 담아와 주세요. \"",true);
            SleepLine("\" 강제는 아니지만, 이번 의뢰를 해내주신다면 당신에게 꼭 필요한 도움을 드릴 수 있을겁니다. \"",true);
            SleepLine($"「 라크다난의 표정은 웃고있었지만 어딘가 날카로운 느낌이 들었습니다. 」");
            while (reset == true)
            {
                ment = "「<y>【 라크다난 】</y>의 퀘스트를 수락하시겠습니까? 」\n\n"
                     + "「    1. 네    /    2. 아니오    」: ";
                select = Choice(ment, "1", "2");
                switch (select)
                {
                    case "1":
                        WriteLine();
                        Sleep("<c>「《 비명을 지르는 마법석 》퀘스트를 받았습니다. 」</c>");
                        player.questNumber = 5;
                        player.questStack = 0;
                        Quest(player);
                        reset = false;
                        ReadKey();
                        break;
                    case "2":
                        WriteLine();
                        ColorLine("<r>「 반드시 퀘스트를 받아야 합니다. 」</r>");
                        WriteLine();
                        break;
                }
            }
            reset = true;
            ColorLine("<y>【 라크다난 】</y>");
            Sleep("\" 꼭 명심하세요. 반드시 마법석을 담아올 것. 그리고 살아돌아올 것. \"",true);
            SleepLine("\" 당신한테 반드시 손해볼 거래가 아니라는것 정도는 말해주도록 하죠. \"",true);
            SleepLine($"「 라크다난의 말투는 사뭇 진지했습니다. 」");
            SleepLine($"「 당신은 작은 상자와 돈 뭉치를 주머니에 넣고는 등을 돌려 길드 밖으로 나갑니다. 」");
            SleepLine($"「 하늘을 바라보니 비가 올 것 같습니다. 」");
            player.zone = forest.name;
            EnterZone(player);
            WriteLine();
            Action(player);

            // 퀘스트 5 완료 분기점 ************************************************
        }
        public void StoryLine5()
        {
            SleepLine($"「 당신은 길드 건물 앞에서 갑옷을 입은 사내와 대화를 하고 있는 라크다난을 발견했습니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 글쎄요, 저는 잘 모르겠군요. 그저 일개 길드원이 뭘 알겠습니까. \"",true);
            Sleep($"「 라크다난은 생긋 웃으며 사람 좋은 얼굴을 하며 사내를 바라보고 있었습니다. 」");
            SleepLine($"「 이내 갑옷을 입은 사내는 바닥에 침을 뱉고는 인상을 찌푸리며 자리를 떠났습니다. 」");
            Sleep($"「 작게 한숨을 쉰 라크다난은 금새 당신을 발견하고는 은밀하게 눈짓을 보냅니다. 」");
            Sleep($"「 당신은 무슨 의미인지 알 것 같았습니다. 」");
            SleepLine($"「 당신은 라크다난과의 간격을 유지하며 아우룸 길드로 따라 들어갑니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 어땠나요? 문제가 생기진 않았겠죠? \"",true);
            SleepLine($"「 당신은 주머니에서 작은 상자를 꺼내 라크다난에게 건네줍니다. 」");
            player.experiencePoint += 600;
            WriteLine(" ────────────────────────────────────────────────────────────────");
            ColorLine("<c>                 「 퀘스트를 완료했습니다 」                  </c>");
            WriteLine();
            ColorLine("          「 <g>[ 600 ]</g> 만큼의 경험치를 얻었습니다. 」     ");
            WriteLine(" ────────────────────────────────────────────────────────────────");
            ReadLine();
            player.Player_LevelUp();
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 고생하셨습니다. 큰 도움이 되었군요. \"",true);
            SleepLine($"「 마법석을 확인한 라크다난은 미소를 지으며 당신을 바라봅니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            Sleep("\" 자 그럼. 약속대로... \"",true);
            SleepLine($"「 라크다난은 말끝을 흐리며 사뭇 진지한 표정을 짓습니다. 」");
            switch (player.job)
            {
                case "전사":
                    ColorLine("<y>【 라크다난 】</y>");
                    Sleep("\" 저는 다른 하얀늑대의 위치를 알고 있습니다. \"",true);
                    SleepLine("\" 그리고 당신에게 충분히 알려줄 의향이 있고요. \"",true);
                    SleepLine($"「 당신은 생각치도 못한 의외에 정보에 정신이 번쩍 들었습니다. 」");
                    break;
                case "도적":
                    ColorLine("<y>【 라크다난 】</y>");
                    Sleep("\" 지금 이 타운에도 로크길드원들이 비밀리에 들어와 있습니다.  \"",true);
                    SleepLine("\" 그리고 저는 그 사람들을 혼동시킬 수도, 당신에게 안전한 곳이 어디인지 알려주는 것도 가능하죠.  \"",true);
                    SleepLine($"「 어느정도 예상은 했었지만 마땅히 숨을 곳이 없었던 당신은 라크다난의 말에 귀를 기울입니다. 」");
                    break;
            }
            ColorLine("<y>【 라크다난 】</y>");
            Sleep("\" 동쪽의 라도가 해안 근처에 아카이아라는 마을이 있습니다. \"",true);
            Sleep("\" 닦여진 길로 간다면 4일은 족히 걸리는 거리지만 웰턴 타운에서 바로 동쪽으로 나간다면 하루로 충분하죠. \"",true);
            SleepLine("\" 아쉽게도 타운의 동쪽은 바로 절벽이라 출입구가 없습니다...만... \"",true);
            SleepLine($"「 라크다난의 얼굴에 장난기 가득한 미소가 번집니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            Sleep("\" 타운 동쪽으로 가시면 노파 혼자 살고있는 집이 있습니다. \"",true);
            SleepLine("\" 이미 얘기는 해놓았으니 그쪽으로 가시면 잘 도와주실겁니다. \"",true);
            SleepLine($"「 라며 말을 하던 라크다난은 당신에게 하얀 꽃 한 송이를 건네줍니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            SleepLine("\" 노파를 만나면 대신 좀 전해주세요. \"",true);
            SleepLine($"「 당신은 고개를 끄덕이며 하얀 꽃을 손에 들고 일어납니다. 」");
            ColorLine("<y>【 라크다난 】</y>");
            Sleep("\" 연이 된다면 다시 또 뵙도록 하죠. \"",true);
            SleepLine($"「 당신은 라크다난과 가볍게 인사를 한 후 길드 밖을 나서 타운의 동쪽으로 향합니다. 」");
            Sleep($"「 점점 인적이 드물어 질 때 쯤, 당신은 한 노파가 집 밖에서 꾸벅 꾸벅 졸고있는 모습을 발견합니다. 」");
            SleepLine($"「 당신이 노파를 부르며 다가가자 노파는 멍한 표정으로 당신을 바라보았습니다. 」");
            ColorLine("<y>【 노파 】</y>");
            SleepLine("\" 네놈이냐. 꼬맹이가 말한 녀석이? \"",true);
            SleepLine($"「 노파는 가느다란 눈으로 당신의 위 아래를 훑어봅니다. 」");
            SleepLine($"「 당신은 고개를 끄덕이며 라크다난의 전언과 함께 하얀 꽃을 노파에게 건넵니다. 」");
            ColorLine("<y>【 노파 】</y>");
            SleepLine("\" 흥! 빨리 죽으라고 보채는구만. \"",true);
            SleepLine($"「 노파는 툴툴거리는 말투였지만 표정에는 미소를 감출 수 없었습니다. 」");
            ColorLine("<y>【 노파 】</y>");
            SleepLine("\" 이쪽으로 오거라. \"",true);
            SleepLine($"「 당신은 노파를 따라 집 안으로 들어갑니다. 」");
            Sleep($"「 노파의 집은 일반적인 가정집보다 작고 소박해 보입니다. 」");
            Sleep($"「 노파는 아무 말 없이 벽난로 근처를 더듬더니 철컥 하는 소리와 함께 벽난로의 불이 꺼집니다. 」");
            ColorLine("<y>【 노파 】</y>");
            SleepLine("\" 여기로 들어가면 된다. 빛나는 구슬을 꼭 잡거라. 꽤나 신이 날게다 클클클... \"",true);
            SleepLine($"「 노파는 벽난로의 구멍을 가리키면서 소리내 웃으며 말합니다. 」");
            SleepLine($"「 당신은 조금 의심스러웠지만 당장에 다른 선택지가 없었기에 벽난로로 기어들어갑니다. 」");
            Sleep($"「 어느정도 기어들어가자 희미하게 빛나는 구슬이 공중에 둥둥 떠다니고 있었습니다. 」");
            Sleep($"「 당신은 엎드린 상태로 빛나는 구슬을 양손으로 붙잡았습니다. 」");
            SleepLine($"「 구슬은 잠시 작게 공명을 하더니 빠른 속도로 날아가기 시작합니다. 」");
            Sleep($"「 꽤나 빠른 속도에 구슬을 놓치는건 아닐까 하는 생각이 들 때 쯤 통로 밖으로 빛이 보입니다. 」");
            SleepLine($"「 구슬이 천천히 멈추고 당신의 눈 앞에는 익숙하지만 조금 다른 숲이 보입니다. 」");
            Sleep($"「 구슬은 당신이 바닥에 발을 딛고 나서야 사라졌습니다. 」");
            SleepLine($"「 마법. 당신은 지금은 모두 사라져 버린 마법일리가 없을거라며 고개를 젓습니다. 」");
            SleepLine($"「 그것 보다 당신에겐 더 중요한 것이 있었기에 당신은 서둘러 동쪽의 아카이아 마을로 향합니다. 」");
            Thread.Sleep(3000);
        }
        public void Epilogue()
        {
            Clear();
            SleepLine("<c>「 우르둠 길드 」</c>", true);
            ColorLine("<y>【 라크다난 】</y>");
            Sleep("\" 예. 방금 출발했습니다. \"", true);
            Thread.Sleep(1000);
            Sleep("\" 다른 방법이 없을겁니다. 반드시 아카이아로 갈겁니다. \"", true);
            SleepLine("\" 예. 알겠습니다. 잘 처리하겠습니다. \"", true);
            Sleep(" . ");
            Sleep(" . ");
            SleepLine(" . ");
            SleepLine("\" 그럼 슬슬 이쪽도 움직여볼까. \"", true);
            ColorLine();
            ColorLine();
            Thread.Sleep(2000);
            ColorLine("<c>                  『 에피소드 2에서 계속... 』                 </c>");

        }
    }
}
