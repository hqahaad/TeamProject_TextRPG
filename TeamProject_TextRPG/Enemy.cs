﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;
using TeamProject_TextRPG.GameTables;

namespace TeamProject_TextRPG
{
     public class Enemy : Unit, IUnit
     {
          public Enemy() { }

          public Enemy(string name, int level, int hp, float attackPower, float defensivePower)
          {
               this.name = name;
               this.level = level;
               this.hp = hp;
               this.attackPower = attackPower;
               this.defensivePower = defensivePower;
          }

          public void DoAction(Battle battle)
          {
               if (battle.GetFaction(FactionType.Player).IsAllDead())
               {
                    return;
               }
               Console.Clear();
               Utils.Console.WriteLine("Battle!!\n", ConsoleColor.DarkYellow);
               Console.WriteLine($"Lv.{level} {name}의 공격!");
               ////(임시) 단일 플레이어만 공격
               battle.GetUnits(FactionType.Player)?.First().GetDamage(new Damage(attackPower));

               var selecter = OptionSelecter.Create();
               selecter.SetExceptionMessage("잘못된 입력입니다");
               selecter.AddOption("\n0. 다음", "0");
               selecter.Display();
               selecter.Select("\n대상을 선택해주세요.\n>>  ");
          }

          public void GetDamage(Damage damage)
          {
               float originHp = hp;
               Console.WriteLine($"Lv.{level} {name} 을(를) 맞췄습니다. [{damage.damage}]\n");
               //데미지를 계산 로직
               hp -= (int)damage.damage;
               //
               Console.WriteLine($"Lv.{level} {name}\nHP {originHp}→{hp}");
          }

          public void DisplayStatus()
          {
               if (IsDead())
               {
                    Utils.Console.WriteLine($"Lv.{level} {name} [Dead]", ConsoleColor.DarkGray);
               }
               else
               {
                    Console.WriteLine($"Lv.{level} {name} HP {hp}");
               }
          }

          public bool IsDead()
          {
               return hp <= 0;
          }
     }
}
