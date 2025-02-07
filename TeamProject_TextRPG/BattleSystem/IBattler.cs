﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.BattleSystem
{
     public interface IBattler
     {
          void Attack(IBattler battler);
          void GetDamage(IDamageable damage);
     }
}
