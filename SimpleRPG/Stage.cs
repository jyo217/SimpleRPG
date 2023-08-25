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
        private int stage = 1;

        Warrior player;
        Monster monster;

        public Stage()
        {
            player = new Warrior("Rtan", 100, 10, false);
        }
        /// <summary>
        /// 게임 진행 전반을 담당하는 메소드
        /// </summary>
        public void Start() { }
    }
}
