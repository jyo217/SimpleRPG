# SimpleRPG
C# 콘솔로 구현한 간단한 텍스트 RPG

- 전체적인 흐름

스테이지 시작 시, 플레이어와 몬스터가 턴을 주고받게 됨. 매 턴마다 공격을 주고받으며, 각각 공격을 받을 때 마다 TakeDamage 를 호출한다.</br>
현재 스테이지가 끝날 때 까지 서로의 정보가 턴 진행 상황에 따라 갱신되어 출력된다. 한 쪽이 죽으면 그 결과를 출력하고 스테이지를 마친다.</br> 
플레이어가 죽었다면 그대로 게임 종료, 몬스터가 죽었다면 회복 포션과 공격력 강화 포션 둘 중 하나를 선택하여 보상을 받고</br> 다음 스테이지를 시작한다.


- 사실상 모든 기능의 중심이 되는 Stage 클래스

Start() : 후술하는 모든 메소드들을 다루며 게임 진행 전반을 담당한다. 

Take_A_Turn(bool) : 입력값에 따라 플레이어 또는 몬스터의 턴을 진행 

GameOver(enum) : 입력된 열거형 값에 따른 게임 종료 화면 출력

Reward() : 스테이지 클리어 보상 목록 출력 및 선택된 클리어 보상 적용

PrintGoblinStatus(), PrintPlayerStatus(), PrintWhosStatus() : 순서대로 일반 몬스터, 플레이어, ??? 의 상태를 출력.</br> UI 를 좀 더 깔끔하게 보이도록, 코드 가시성을 높이기 위해 나누었음

 
    //    - **`stage`**라는 클래스를 만들어 주세요. 이 클래스는 플레이어와 몬스터, 그리고 보상 아이템들을 멤버 변수로 가지며, **`start`**라는 메서드를 통해 스테이지를 시작하게 됩니다.
    //        - 스테이지가 시작되면, 플레이어와 몬스터가 교대로 턴을 진행합니다.
    //        - 플레이어나 몬스터 중 하나가 죽으면 스테이지가 종료되고, 그 결과를 출력해줍니다.
    //        - 스테이지가 끝날 때, 플레이어가 살아있다면 보상 아이템 중 하나를 선택하여 사용할 수 있습니다.
    //    - 각 스테이지가 시작할 때 플레이어와 몬스터의 상태를 출력해주세요.
    //    - 각 턴이 진행될 때 천천히 보여지도록 **`thread.sleep`**을 사용하여 1초의 대기시간을 추가해주세요.

//    - **`icharacter`** 라는 인터페이스를 정의하세요.이 인터페이스는 다음의 프로퍼티를 가져야 합니다:
//        - **`name`**: 캐릭터의 이름
//        - **`health`**: 캐릭터의 현재 체력
//        - **`attack`**: 캐릭터의 공격력
//        - **`isdead`**: 캐릭터의 생사 상태

//        그리고 다음의 메서드를 가져야 합니다:

//        - **`takedamage(int damage)`**: 캐릭터가 데미지를 받아 체력이 감소하는 메서드
//        - **`warrior`**는 플레이어의 캐릭터를 나타내며, **`monster`**는 몬스터를 나타냅니다.


//    - **`icharacter`** 인터페이스를 구현하는 **`warrior`**와**`monster`**라는 두 개의 클래스를 만들어주세요.
//        - **`monster`** 클래스에서 파생된 **`goblin`**과**`dragon`**이라는 두 개의 클래스를 추가로 만들어주세요.



    //    - **`iitem`**이라는 인터페이스를 정의하세요.이 인터페이스는 다음의 프로퍼티를 가져야 합니다:
    //        - **`name`**: 아이템의 이름

    //        그리고 다음의 메서드를 가져야 합니다:

    //        - **`use(warrior warrior)`**: 아이템을 사용하는 메서드, 이 메서드는 **`warrior`** 객체를 파라미터로 받습니다.

    //    - **`iitem`** 인터페이스를 구현하는 **`healthpotion`**과**`strengthpotion`**이라는 두 개의 클래스를 만들어주세요.

