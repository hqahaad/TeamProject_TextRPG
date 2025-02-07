using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.Scenes
{
     public class TitleScene : IScene
     {
          public void Awake()
          {
          }

          public void Start()
          {
               Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
               Console.WriteLine("이제 전투를 시작할 수 있습니다.");
               Console.WriteLine();
               Console.WriteLine("원하시는 행동을 입력해주세요.");

               OptionSelecter otp = OptionSelecter.Create();


               otp.AddOption("1.상태 보기", "1");
               otp.AddOption("2.전투 시작", "2", () => SceneManager.Instance.LoadScene("배틀 씬"));
               otp.SetExceptionMessage("잘못된 입력입니다.");


               otp.Display();
               otp.Select();
          }

          public void End()
          {
          }
     }
}
