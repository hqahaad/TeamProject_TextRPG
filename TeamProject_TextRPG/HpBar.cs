using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject_TextRPG.Scenes;

namespace TeamProject_TextRPG
{
    public class HpBar
    {
        private float maxHp;
        private float Hp;

        public HpBar(float maxHp)
        {
            this.maxHp = maxHp;
            this.Hp = maxHp; // 초기 HP는 최대 HP로 설정
        }

        public void SetCurrentHp(float hp)
        {
            Hp = hp;
            if (Hp > maxHp) Hp = maxHp;
            if (Hp < 0) Hp = 0;

        }
        public double GetHpPercentage()
        {
            return (double)Hp / maxHp;
        }

        public void UpdateDisplay()
        {
            int filledLength = (int)(GetHpPercentage() * 20); // 게이지 길이 (조절 가능)
            string filledPart = new string('■', filledLength); // 채워진 부분 
            string emptyPart = new string(' ', 20 - filledLength); // 빈 부분

            // 무조건 빨간색으로 설정
            ConsoleColor gaugeColor = ConsoleColor.Red;

            // 색상 설정
            Utils.Console.Write("[", ConsoleColor.Red);
            Utils.Console.Write("{0}", gaugeColor, true, filledPart);
            Utils.Console.Write("{0}", ConsoleColor.Gray, true, emptyPart);
            Utils.Console.Write("]", ConsoleColor.Red);
            Console.ResetColor(); // 색상 초기화

            Console.WriteLine($" {Hp}/{maxHp}"); // HP 수치 표시
        }

    }
}
