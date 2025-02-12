using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject_TextRPG.ModifierSystem
{
    public interface IOperationStrategy
    {
        float Culculate(float value);
    }

    public class AddOperation : IOperationStrategy
    {
        private readonly float value;

        public AddOperation(float value)
        {
            this.value = value;
        }

        public float Culculate(float value) => value + this.value;
    }

    public class MultiplyOperation : IOperationStrategy
    {
        private readonly float value;

        public MultiplyOperation(float value)
        {
            this.value = value;
        }

        public float Culculate(float value) => value * this.value;
    }
}
