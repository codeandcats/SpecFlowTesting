using Casio;
using Should;
using System;
using TechTalk.SpecFlow;

namespace Casio.Specs
{
	[Binding]
	public class CalculatorSteps
	{
		private Calculator calculator;

		[BeforeScenario]
		public void Setup()
		{
			calculator = new Calculator();
		}

		[Given]
		public void GivenIHaveEntered_NUMBER(double number)
		{
			calculator.EnterNumber(number);
		}
		
		[Given(@"I press the (.*?) key"), When(@"I press the (.*?) key")]
		public void GivenIPressThe_OPERATOR_Key(string key)
		{
			var op = (Operator)Enum.Parse(typeof(Operator), key);

			calculator.EnterOperator(op);
		}
		
		[Then]
		public void ThenItShouldDisplay_NUMBER(double number)
		{
			calculator.Display.ShouldEqual(number.ToString());
		}
	}
}
