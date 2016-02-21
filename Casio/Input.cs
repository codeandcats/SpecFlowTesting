using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casio
{
	public abstract class Input
	{
		public class Operand : Input<double>
		{
			public Operand(double value) : base(value)
			{
			}
		}

		public class Operator : Input<Casio.Operator>
		{
			public Operator(Casio.Operator value) : base(value)
			{
			}
		}
	}

	public abstract class Input<T> : Input
	{
		protected Input(T value)
		{
			Value = value;
		}

		public T Value { get; set; }
	}
}
