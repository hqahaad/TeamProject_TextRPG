using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.ModifierSystem
{
    //수정 전략
    public interface IOperationStrategy
    {
        int Culculate(int value);
    }

    public class AddOperation
    {
        private readonly int value;

        public AddOperation(int value)
        {
            this.value = value;
        }

        int Culculate(int value) => value + this.value;
    }

    public class MultiplyOperation
    {
        private readonly int value;

        public MultiplyOperation(int value)
        {
            this.value = value;
        }

        int Culculate(int value) => value * this.value;
    }
}
