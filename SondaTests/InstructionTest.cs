using System;
using Xunit;
using SondaProject;

namespace SondaTests
{

    public class InstructionTest
    {
        const string BAD_INSTRUCTION = "XXXX";
        const string GOOD_INSTRUCTION = "MMRLLMMRMRRMLLL";

        public class ConstructorMethod
        {
            [Fact]
            public void InvalidInstructionThrowsArgumentException()
            {
                IInstruction instruction;
                Assert.Throws<ArgumentException>(() =>
                                                 instruction = new Instruction(BAD_INSTRUCTION));
            }
        }

        public class GetInstructionMethod
        {
            [Fact]
            public void CheckSavedSequence()    
            {
                IInstruction instruction = new Instruction(GOOD_INSTRUCTION);
                char[] savedInstructionToTest = instruction.GetInstruction();

                Assert.Equal(GOOD_INSTRUCTION.ToCharArray(),savedInstructionToTest);
            }
        }
    }
}
