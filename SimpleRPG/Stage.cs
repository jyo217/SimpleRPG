using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    //    - **`stage`**라는 클래스를 만들어 주세요. 이 클래스는 플레이어와 몬스터, 그리고 보상 아이템들을 멤버 변수로 가지며, **`start`**라는 메서드를 통해 스테이지를 시작하게 됩니다.
    //        - 스테이지가 시작되면, 플레이어와 몬스터가 교대로 턴을 진행합니다.
    //        - 플레이어나 몬스터 중 하나가 죽으면 스테이지가 종료되고, 그 결과를 출력해줍니다.
    //        - 스테이지가 끝날 때, 플레이어가 살아있다면 보상 아이템 중 하나를 선택하여 사용할 수 있습니다.
    //    - 각 스테이지가 시작할 때 플레이어와 몬스터의 상태를 출력해주세요.
    //    - 각 턴이 진행될 때 천천히 보여지도록 **`thread.sleep`**을 사용하여 1초의 대기시간을 추가해주세요.

    internal class Stage
    {
        private static int FINAL_STAGE = 3;
        private static string BOSS_NAME = "BOSS - The Fury";
        private static int BOSS_HEALTH= 100;
        private static int BOSS_ATK = 10;
        Warrior player;
        Monster monster;

        private bool isPlayerTurn = true;

        public Stage() { }

        /// <summary>
        /// 게임 진행 전반을 담당하는 메소드
        /// </summary>
        public void Start() 
        {
            //보스 정보 생성
            Dragon dragon = new Dragon(BOSS_NAME, BOSS_HEALTH, BOSS_ATK, false);

            int monsterHealth = 40;
            string monsterName = "";
            int stage = 1;
            bool isBoss = false;

            player = new Warrior("Rtan", 100, 10, false);
            monster = new Goblin("Lv.1 Goblin", 40, 5, false);

            //게임 시작 화면 출력

            //플레이어 사망, 또는 마지막 스테이지 클리어 시 결과창 출력 후 종료
            while (true)
            {
                //둘 중 하나가 죽을 때 까지 번갈아가며 턴 진행
                while (!player.IsDead && !monster.IsDead) { Take_A_Turn(isBoss); }

                //플레이어 사망 시 종료.
                if (player.IsDead) { GameOver(ENDING.PLAYER_DEAD); break; }
                //몬스터가 사망했을 때 
                else if (monster.IsDead)
                {
                    //현재 스테이지가 최종 스테이지라면
                    if (stage == FINAL_STAGE)
                    {
                        //게임 클리어 결과창 출력 후 게임 종료.
                        GameOver(ENDING.FINAL_STAGE_CLEARED);
                        break;
                    }

                    //보상 창 출력. 보상 선택 => 보상 효과가 플레이어에게 반영되고 다음 스테이지로 넘어감
                    Reward();
                    stage++;

                    //마지막 스테이지에 돌입했다면 보스몬스터 출현
                    if (stage == FINAL_STAGE) { isBoss = true; monster = dragon; }
                    else
                    {
                        monsterHealth = (int)(monsterHealth * 2.5);
                        monsterName = "LV." + stage + " " + monster.GetType().Name;
                        monster = new Goblin(monsterName, monsterHealth, monster.Atk + 1, false);
                    }
                }
            }
        }

        /// <summary>
        /// 현재 턴을 진행하는 메소드
        /// </summary>
        public void Take_A_Turn(bool isBoss)
        {
            //공격 => 상대의 체력 감소 메소드 호출
            //턴 넘기기 => 아무 행동도 하지 않음
            //매 턴 종료 시 마다 상대방의 생존 여부 확인

            //플레이어의 턴
            if (isPlayerTurn)
            {
                bool isInputError = false ;
                while (true)
                {
                    Console.Clear();

                    if (isInputError)
                    {
                        Console.WriteLine("잘못된 입력입니다!\n");
                        isInputError = false;
                    }

                    if (isBoss) { PrintWhosStatus(); }
                    else { PrintGoblinStatus(); }
                    PrintPlayerStatus();

                    Console.WriteLine($"[{player.Name} 의 턴]\n");
                    Console.WriteLine("1. 공격한다      2. 가만히 있는다");
                    string action = Console.ReadLine();

                    // 공격
                    if (action == "1")
                    {
                        monster.TakeDamage(player.Atk);
                        isPlayerTurn = false;
                        break;
                    }
                    // 턴 넘기기
                    else if (action == "2")
                    {
                        isPlayerTurn = false;
                        break;
                    }
                    else
                    {
                        isInputError = true;
                    }
                }
                //종료 시 턴 전환
                isPlayerTurn = false;
            }
            //적의 턴
            else
            {
                //적은 무조건 공격만 한다.
                player.TakeDamage(monster.Atk);

                isPlayerTurn = true;
            }
        }

        /// <summary>
        /// 플레이어 사망 또는 마지막 스테이지 클리어에 대한 결과 창 출력
        /// </summary>
        public void GameOver(ENDING ending)
        {
            Console.Clear();
            PrintPlayerStatus();

            switch (ending)
            {
                case ENDING.PLAYER_DEAD:
                    {
                        Console.WriteLine($"[{player.Name}은 고된 여정을 견뎌내지 못했습니다...]\n\n");
                        break;
                    }
                case ENDING.FINAL_STAGE_CLEARED:
                    {
                        Console.WriteLine($"[SimpleRPG 클리어! 축하드립니다, {player.Name}!]\n\n");
                        break;
                    }
            }
        }

        /// <summary>
        /// 보상 창 출력 및 보상 적용
        /// </summary>
        public void Reward()
        {
            bool isInputError = false;
            while (true)
            {
                Console.Clear();

                if (isInputError)
                {
                    Console.WriteLine("잘못된 입력입니다!\n");
                    isInputError = false;
                }

                PrintPlayerStatus();
                Console.WriteLine($"\n[스테이지 클리어!!!]\n");
                Console.WriteLine($"\n[스테이지 클리어 보상을 선택해주세요]\n");
                Console.WriteLine("1. 회복 포션(+ 50 HP)      2. 힘 포션(+ 5 ATK)");
                string action = Console.ReadLine();

                if (action == "1")
                {
                    HealthPotion healthPotion = new HealthPotion(50);

                    healthPotion.Use(player);
                    break;
                }
                else if (action == "2")
                {
                    StrengthPotion strengthPotion = new StrengthPotion(5);

                    strengthPotion.Use(player);
                    break;
                }
                else
                {
                    isInputError = true;
                }
            }
        }

        /// <summary>
        /// 고블린의 상태를 출력한다
        /// </summary>
        public void PrintGoblinStatus()
        {
            Console.WriteLine("                  ,,,,,,,,,.  \r\n                  ,,,,,,,,,.  \r\n           -~~  ,,, ,~~ .     \r\n         .,,,-~,,,   ~~       \r\n         ,,,,,,,,,  ,,,,      \r\n       ,,,,,,,,,,,  ,,,,      \r\n      ,,,,,,,,,,,-  ,,,,      \r\n      ,,,,,,,,,,,~  ,,,,      \r\n        .,,,,,::::~,,,,,      \r\n         ,  ,,::::,,,,,,      \r\n         ,,,,-::::,,,,,,      \r\n     ,,.    :::::::,,,,       \r\n     ~~ .-~:::::::::          \r\n     ,-~~~::::::::::          \r\n     ,~~~~::::::::::          \r\n    .~~..~::::::::::          \r\n   -~~~~~   ~~~~,,,,          \r\n   ~~~~~~   ~~~~,,,,          \r\n   ~~~~~~, -~~~~,,,,          \r\n   ~~~~~~ ~~~~~~,,,,          \r\n   ~~~~~~~~~~~~ ,,,-          \r\n    -~~- ~~~:~  ,-,,.         \r\n         ~~~~   ,,,,,.        \r\n         ~~~~    ,,,,,.       \r\n         ~~~~     ,,,,,.      \r\n        ~~~~~     ,,,,,,      \r\n       ~~~~~~    ,,,,,,,      \r\n       ~~~~~~    ,,,,,,,    ");
            Console.WriteLine($"[{monster.Name}] [HP : {monster.Health}] [ATK : {monster.Atk}] \n");
        }

        /// <summary>
        /// 플레이어의 상태를 출력한다
        /// </summary>
        public void PrintPlayerStatus()
        {
            Console.WriteLine($"[{player.Name}] [HP : {player.Health}] [ATK : {player.Atk}] \n");
            Console.WriteLine("===============================================\n");
        }

        /// <summary>
        /// ??? 의 상태를 출력한다
        /// </summary>
        public void PrintWhosStatus()
        {
            Console.WriteLine("             ,                \r\n            . .,              \r\n           .........          \r\n          .............       \r\n         ............  .      \r\n        . ,...........,       \r\n       .................      \r\n    .. .   .,,,. ........     \r\n          ...     .......     \r\n         .,        ......,    \r\n    ..   ,   ,      ,... ,    \r\n    .  .,    ,.     .... .    \r\n   .,.       ,.     .... .    \r\n    ,.       ,.    .  ..      \r\n    ..      .      ......     \r\n     .  ....      .....,.     \r\n     . ..,.      ,,....,      \r\n       ..,.    ...... ..      \r\n       ....,,,,....., .       \r\n        ...,,......, .        \r\n          ..  ..,,            \r\n            .....            ");
            Console.WriteLine($"[{monster.Name}] [HP : {monster.Health}] [ATK : {monster.Atk}] \n");
        }

        /// <summary>
        /// 게임 종료 시 호출할 함수를 하나만 사용하기 위함. 이것으로 엔딩 분기를 판단한다.
        /// </summary>
        public enum ENDING
        {
            PLAYER_DEAD,
            FINAL_STAGE_CLEARED
        }
    }
}
