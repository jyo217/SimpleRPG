using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    //    - **`iitem`**이라는 인터페이스를 정의하세요.이 인터페이스는 다음의 프로퍼티를 가져야 합니다:
    //        - **`name`**: 아이템의 이름

    //        그리고 다음의 메서드를 가져야 합니다:

    //        - **`use(warrior warrior)`**: 아이템을 사용하는 메서드, 이 메서드는 **`warrior`** 객체를 파라미터로 받습니다.


    //    - **`iitem`** 인터페이스를 구현하는 **`healthpotion`**과**`strengthpotion`**이라는 두 개의 클래스를 만들어주세요.
    internal interface IItem
    {
        //프로퍼티
        public string Name { get; set; }

        //메소드
        public string Use(Warrior warrior);
    }
}
