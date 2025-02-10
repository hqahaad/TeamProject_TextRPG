using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG
{
     public class Player : Unit, IUnit
     {
          public string className = "전사";

          public void DoAction(Battle battle)
          {
               if (battle.GetFaction(FactionType.Enemy).IsAllDead())
               {
                    return;
               }

               SelectAction(battle);
          }
          #region 플레이어의 행동
          private void SelectAction(Battle battle)
          {
               Console.Clear();
               Utils.Console.WriteLine("Battle!!\n", ConsoleColor.DarkYellow);
               foreach (var iter in battle.GetUnits(FactionType.Enemy) ?? Enumerable.Empty<IUnit>())
               {
                    iter.DisplayStatus();
               }
               DisplayStatus();

               var selecter = OptionSelecter.Create();
               selecter.SetExceptionMessage("잘못된 입력입니다");
               selecter.AddOption("\n1. 공격", "1", () => CastAttack(battle));

               selecter.Display();
               selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
          }

          private void CastAttack(Battle battle)
          {
               var units = battle.GetUnits(FactionType.Enemy);

               if (units == null)
                    return;

               Console.Clear();
               Utils.Console.WriteLine("Battle!\n", ConsoleColor.DarkYellow);

               var selecter = OptionSelecter.Create();
               selecter.SetExceptionMessage("잘못된 입력입니다");
               selecter.AddOption(string.Empty, "0", () => SelectAction(battle));

               Action<IUnit> tryAttack = (u) =>
               {
                    if (u.IsDead())
                    {
                         selecter.Exception("\n대상을 선택해주세요.\n >>  ");
                    }
                    else
                    {
                         Attack(u);
                    }
               };

               for (int i = 0; i < units.Count; i++)
               {
                    int target = i;

                    selecter.AddOption(string.Empty, (i + 1).ToString(), () => tryAttack(units[target]));
                    Console.Write($"[{(i + 1).ToString()}] ");

                    units[i].DisplayStatus();
               }
               DisplayStatus();
               Utils.Console.WriteLine("\n0. 취소", ConsoleColor.Red);

               selecter.Select("\n대상을 선택해주세요.\n>>  ");
          }

          private void Attack(IUnit unit)
          {
               Console.Clear();
               Utils.Console.WriteLine("Battle!!\n", ConsoleColor.DarkYellow);
               Console.WriteLine($"{name} 의 공격!");
               unit.GetDamage(new Damage(attackPower));

               var selecter = OptionSelecter.Create();
               selecter.SetExceptionMessage("잘못된 입력입니다");
               selecter.AddOption("\n0. 다음", "0");
               selecter.Display();
               selecter.Select();
          }

          #endregion

          public void GetDamage(Damage damage)
          {
               float originHp = hp;
               Console.WriteLine($"Lv.{level} {name} 을(를) 맞췄습니다. [{damage.damage}]\n");
               //데미지를 계산 로직

               //
               Console.WriteLine($"Lv.{level} {name}\nHP {originHp}→{hp}");
          }

          public void DisplayStatus()
          {
               Console.WriteLine("\n[내 정보]");
               Console.WriteLine($"Lv.{level} {name} ({className})");
               Console.WriteLine($"HP : {hp}");
          }

          public bool IsDead()
          {
               return hp <= 0;
          }
     }
}