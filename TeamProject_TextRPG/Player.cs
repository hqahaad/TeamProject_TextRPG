using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TeamProject_TextRPG.Player;

namespace TeamProject_TextRPG
{
     public class Player : GameObject
     {
          private string? className;

          public void Display()
          {
               Console.WriteLine("Player Display");
          }

     //     public class PlayerData
     //     {
     //          public string? UserName { get; set; } // 캐릭터 이름
     //          public string? Job { get; } // 캐릭터 직업
     //          public int Level { get; set; } = 1;// 캐릭터 레벨
     //          public string? ClassName { get; set; }
     //          public int BaseAttack { get; set; } // 기본 공격력
     //          public int BaseDefense { get; set; } // 기본 방어력
     //          public int Hp { get; set; } // 현재 체력
     //          public int Gold { get; set; } // 보유 골드
     //     }
     //     public PlayerData? playerData = new();

     //     public string UserName => playerData.UserName ?? string.Empty;
     //     public string Job => playerData.Job;
     //     public int Level => playerData.Level;
     //     public string ClassName => playerData.ClassName;
     //     public int BaseAttack => playerData.BaseAttack;
     //     public int BaseDefense => playerData.BaseDefense;
     //     public int Hp => playerData.Hp;
     //     public int Gold => playerData.Gold;

     //     public OptionSelecter optionSelecter { get; } = OptionSelecter.Create();

     //     private ModifierStat<float> strikingPower = new();
     //     private ModifierStat<float> defensivePower = new();

     //     public ModifierStat<float> StrikingPower
     //     {
     //          get
     //          {
     //               strikingPower[StatType.Origin] = BaseAttack;
     //               return strikingPower;
     //          }
     //     }
     //     public ModifierStat<float> DefensivePower
     //     {
     //          get
     //          {
     //               defensivePower[StatType.Origin] = BaseDefense;
     //               return defensivePower;
     //          }
     //     }

     //     private Player() { }

     //     public void Display()
     //     {
     //          Console.Clear();
     //          Console.WriteLine("[상태 보기]");
     //          Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

     //          Console.WriteLine("Lv. {0}", Level.ToString("D2"));
     //          Console.WriteLine("{0} ({1})", UserName, ClassName);
     //          Console.WriteLine($"공격력 : {BaseAttack} {(StrikingPower[StatType.Equipment] != 0f ? StrikingPower[StatType.Equipment].ToString("+#;-#") : "")}");
     //          Console.WriteLine($"방어력 : {BaseDefense} {(DefensivePower[StatType.Equipment] != 0f ? DefensivePower[StatType.Equipment].ToString("+#;-#") : "")}");
     //          Console.WriteLine("체력 : {0}", Hp);
     //     }

     }
}
