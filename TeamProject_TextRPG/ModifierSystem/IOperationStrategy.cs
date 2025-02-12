using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.ModifierSystem
{
    public interface IOperationStrategy
    {
        int Culculate(int value);
    }

    public class AddOperation : IOperationStrategy
    {
        private readonly int value;

        public AddOperation(int value)
        {
            this.value = value;
        }

        public int Culculate(int value) => value + this.value;
    }

    public class MultiplyOperation : IOperationStrategy
    {
        private readonly int value;

        public MultiplyOperation(int value)
        {
            this.value = value;
        }

        public int Culculate(int value) => value * this.value;
    }
}
