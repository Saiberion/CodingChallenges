using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2017
{
	class Instruction(string[] s)
    {
        public string Register { get; internal set; } = s[0];
        public string Operation { get; internal set; } = s[1];
        public int OperationValue { get; internal set; } = int.Parse(s[2]);
		// s[3] ist immer "if"
        public string ConditionRegister { get; internal set; } = s[4];
        public string Condition { get; internal set; } = s[5];
        public int ConditionValue { get; internal set; } = int.Parse(s[6]);

        private bool IsConditionValid(Dictionary<string, int> registers)
		{
			int condRegVal = registers[this.ConditionRegister];
			bool ret;

			switch (this.Condition)
			{
				case ">":
					ret = condRegVal > this.ConditionValue;
					break;
				case "<":
					ret = condRegVal < this.ConditionValue;
					break;
				case "==":
					ret = condRegVal == this.ConditionValue;
					break;
				case ">=":
					ret = condRegVal >= this.ConditionValue;
					break;
				case "<=":
					ret = condRegVal <= this.ConditionValue;
					break;
				case "!=":
					ret = condRegVal != this.ConditionValue;
					break;
				default:
					System.Diagnostics.Debug.WriteLine(string.Format("Missing condition '{0}'", this.Condition));
					ret = false;
					break;
			}
			return ret;
		}

		private void ExecuteOperation(Dictionary<string, int> registers)
		{
			switch (this.Operation)
			{
				case "inc":
					registers[this.Register] += this.OperationValue;
					break;
				case "dec":
					registers[this.Register] -= this.OperationValue;
					break;
				default:
					System.Diagnostics.Debug.WriteLine(string.Format("Missing operation '{0}'", this.Operation));
					break;
			}
		}

		public void Execute(Dictionary<string, int> registers)
		{
			if (IsConditionValid(registers))
			{
				ExecuteOperation(registers);
			}
		}
	}

	public class Day08 : Challenge
	{
		static int ExecuteInstructions(Dictionary<string, int> registers, List<Instruction> instructionList)
		{
			int ret = int.MinValue;
			int val;
			foreach (Instruction instr in instructionList)
			{
				instr.Execute(registers);
				val = GetLargestValue(registers);
				if (val > ret)
				{
					ret = val;
				}
			}
			return ret;
		}

		static int GetLargestValue(Dictionary<string, int> registers)
		{
			int ret = int.MinValue;

			foreach (int val in registers.Values)
			{
				if (val > ret)
				{
					ret = val;
				}
			}
			return ret;
		}

		public override void Solve()
		{
			Dictionary<string, int> registers = [];
			List<Instruction> instructionList = [];
			int largestEver;

			foreach (string line in Input)
			{
				string[] s = line.Split(' ');
				registers.TryAdd(s[0], 0);
                instructionList.Add(new Instruction(s));
			}

			largestEver = ExecuteInstructions(registers, instructionList);

			Part1Solution = GetLargestValue(registers).ToString();
			Part2Solution = largestEver.ToString();
		}
	}
}
