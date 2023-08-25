using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    internal class Dragon : Monster
    {
        //자식 클래스의 생성자 선언. 받아온 값을 부모 클래스의 생성자에 집어넣고 호출한다.
        //이렇게 하지 않으면 부모 클래스의 매개변수가 없는 생성자가 나오게 된다.
        //단, 부모 클래스에 접근 가능한 기본 생성자가 하나도 없다면 
        //자식 클래스는 생성자에서 반드시 base 클래스를 사용해야 한다.
        public Dragon(string name, int health, int atk, bool isDead) : base(name, health, atk, isDead) { }
    }
}


