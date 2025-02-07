using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG
{
     public class Singleton<T> where T : class, new()
     {
          private static T? instance = null;

          public static T Instance
          {
               get
               {
                    if (instance == null)
                    {
                         return new T() as T;
                    }

                    return instance;
               }
          }

          protected Singleton() { }
     }
}
