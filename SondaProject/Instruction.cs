using System;
using System.Collections.Generic;

namespace SondaProject
{
    public interface IInstruction
    {
        bool IsValidSequence(string sequence);
        char[] GetInstruction();
    }
       
    public class Instruction : IInstruction
    {
        private string _sequence;   
        private List<char> validInstructions = new List<char>()
        {
            'L','M','R'
        };

        public Instruction(string sequence)
        {
            if (!IsValidSequence(sequence))
            {
                throw new ArgumentException (String.Format 
                                             ("Instruction {0} not valid",sequence));
            }

            _sequence = sequence;
        }

        public bool IsValidSequence(string sequence)
        {
            if (sequence  == null)
            {
                return false;
            }

            foreach(char singleCommand in sequence)
            {
                if (!validInstructions.Contains(singleCommand))
                {
                    return false;
                }
            }
            return true;
        }

        public char [] GetInstruction()
        {
            return _sequence.ToCharArray();
        }
    }
}
