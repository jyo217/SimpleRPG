using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

namespace SimpleRPG
{
    internal interface ICharacter
    {
        //프로퍼티
        public string Name { get; set; }
        public int Health { get; set; }
        public int Atk { get; set; }
        public bool IsDead { get; set; }

        //메소드
        public void TakeDamage(int damage);
    }
}
