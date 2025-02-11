using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG
{
   
        public class StressGauge
        {
            private int maxStress;
            private int currentStress;

            public StressGauge(int maxStress)
            {
                this.maxStress = maxStress;
                this.currentStress = 0;
            }

            public void IncreaseStress(int amount)
            {
                currentStress += amount;
                if (currentStress > maxStress)
                {
                    currentStress = maxStress;
                }
                UpdateDisplay();
            }

            public void DecreaseStress(int amount)
            {
                currentStress -= amount;
                if (currentStress < 0)
                {
                    currentStress = 0;
                }
                UpdateDisplay();
            }
        public double GetStressPercentage()// 게이지 퍼센트
        {
            return (double)currentStress / maxStress;
        }

        public void UpdateDisplay()
            {
                

                int filledLength = (int)((double)currentStress / maxStress * 20); // 게이지 길이 (조절 가능)
                string filledPart = new string('■', filledLength); // 채워진 부분 (문자 변경 가능)
                string emptyPart = new string(' ', 20 - filledLength); // 빈 부분

                ConsoleColor gaugeColor;
                if (currentStress < maxStress * 0.3)       // 30% 미만: 녹색
                {
                    gaugeColor = ConsoleColor.Green;
                }
                else if (currentStress < maxStress * 0.7)  // 70% 미만: 노란색
                {
                    gaugeColor = ConsoleColor.Yellow;
                }
                else                                         // 70% 이상: 빨간색
                {
                    gaugeColor = ConsoleColor.Red;
                }


                // 색상 설정 
                Utils.Console.Write("[", ConsoleColor.Red);                               
                Utils.Console.Write("{0}", gaugeColor, true, filledPart);                                
                Utils.Console.Write("{0}", ConsoleColor.Gray, true, emptyPart);               
                Utils.Console.Write("]", ConsoleColor.Red);
                Console.ResetColor(); // 색상 초기화

                Console.WriteLine($" {currentStress}/{maxStress}"); // 스트레스 수치 표시
            }

            
        }
    }

