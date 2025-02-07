﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.BattleSystem;

namespace TeamProject_TextRPG
{
     public class Player : GameObject, IBattler
     {
          public string className = "전사";

          public void DoAction(List<IBattler> battlers)
          {
               Console.Clear();
               battlers.ForEach(b => b.DisplayStatus());
               DisplayStatus();

               var ops = OptionSelecter.Create();

               Console.ReadLine();
          }

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

          public bool IsPlayer()
          {
               return true;
          }

          public bool IsDead()
          {
               return hp < 0;
          }
     }
}