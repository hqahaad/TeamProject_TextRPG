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
        private float _maxHp;
        private float _hp;

        public HpBar(float maxHp)
        {
            this.MaxHp = maxHp;
            this.Hp = maxHp; // 초기 HP는 최대 HP로 설정
        }
        public float MaxHp
        {
            get { return _maxHp; }
            set
            {
                // 최대 체력은 0보다 커야 합니다.
                if (value <= 0)
                {
                    Console.WriteLine("최대 체력은 0보다 커야 합니다.");
                    return;
                }

                _maxHp = value; // 최대 체력 업데이트

                // 현재 체력이 최대 체력을 초과하는 경우, 현재 체력을 최대 체력으로 설정합니다.
                if (_hp > _maxHp)
                {
                    _hp = _maxHp;
                    Console.WriteLine($"현재 체력이 최대 체력을 초과하여 조정됨: {_hp}");
                }
            }
        }
        public float Hp
        {
            get { return _hp; }
            set
            {
                _hp = value;
                if (_hp > MaxHp) _hp = MaxHp; // 현재 체력이 최대 체력을 초과하지 않도록 함
                if (_hp < 0) _hp = 0;
            }
        }

        public void SetCurrentHp(float hp)
        {
            Hp = hp;
            
        }
        public double GetHpPercentage()
        {
            return (double)Hp / MaxHp;
        }

        public void UpdateDisplay()
        {
            // 게이지의 총 길이를 설정
            int gaugeLength = 20;

            // 채워진 게이지의 길이를 계산합니다.
            int filledLength = (int)(GetHpPercentage() * gaugeLength);

            // 채워지지 않은 게이지의 길이를 계산
            int emptyLength = gaugeLength - filledLength;

            // 채워진 부분
            string filledPart = new string('■', filledLength);
            string emptyPart = new string(' ', emptyLength);

            // 무조건 빨간색으로 설정
            ConsoleColor gaugeColor = ConsoleColor.Red;

            // 색상 설정
            Utils.Console.Write("[", ConsoleColor.Red);
            Utils.Console.Write("{0}", gaugeColor, true, filledPart);
            Utils.Console.Write("{0}", ConsoleColor.Gray, true, emptyPart);
            Utils.Console.Write("]", ConsoleColor.Red);
            Console.ResetColor(); // 색상 초기화

            Console.WriteLine($" ({(GetHpPercentage() * 100):F0}%)"); // HP 수치 표시
        }

    }
}
