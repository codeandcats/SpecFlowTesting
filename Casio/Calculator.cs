using System.Collections.Generic;

namespace Casio
{
	public enum Operator
	{
		Plus,
		Minus,
		Multiply,
		Divide,
		Equals
	}

	public class Calculator
	{
		private List<Input> expression = new List<Input>();

		public void Clear()
		{
			expression.Clear();
		}

		public void EnterNumber(double number)
		{
			expression.Add(new Input.Operand(number));
		}

		private bool WasLastInputAnOperand()
		{
			var lastInput = expression.LastOrDefault();
			
			return lastInput is Input.Operand;
		}

		public void EnterOperator(Operator op)
		{
			switch (op)
			{
				case Operator.Equals:
					break;

				case Operator.Minus:
					if (expression.Count == 0 || WasLastInputAnOperand())
					{
						expression.Add(new Input.Operator(op));
					}
					break;

				default:
					if (WasLastInputAnOperand())
					{
						expression.Add(new Input.Operator(op));
					}
					break;
			}
		}

		public string Display
		{
			get
			{
				
			}
		}
	}
}
