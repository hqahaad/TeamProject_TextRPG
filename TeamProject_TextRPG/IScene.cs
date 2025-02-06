using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG
{
     public interface IScene
     {
          void Awake();
          void Start();
          void End();
     }
}
