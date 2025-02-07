using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG;

public class TitleScene : IScene
{
    public void Awake()
    {
        throw new NotImplementedException();
    }

    public void End()
    {
        throw new NotImplementedException();
    }

    public void Start()
    {
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("이제 전투를 시작할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        OptionSelecter otp = OptionSelecter.Create();


        otp.AddOption("1.상태 보기", "1");
        otp.AddOption("2.전투 시작", "2");
        otp.SetExceptionMessage("잘못된 입력입니다.");


        otp.Display();
        otp.Select();
    }

    


}

