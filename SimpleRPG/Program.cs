using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using System.Xml.Linq;

namespace SimpleRPG
{
//    ### 4-1 간단한 텍스트 rpg

//1. 목표: 기본적인 턴 기반 rpg 게임을 만들어 봅니다.

    internal class Program
    {
        static void Main(string[] args)
        {
            Stage stage = new Stage();

            stage.Start();
        }
    }
}