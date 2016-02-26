using System;

namespace BookFace.Core.Infrastructure
{
    public interface IClock
    {
        DateTime Now { get; }
    }

    public class Clock : IClock
    {
        public Clock()
        {
            _nowFunc = () => DateTime.Now;
        }

        public Clock(Func<DateTime> nowFunc)
        {
            _nowFunc = nowFunc;
        }

        public DateTime Now { get { return _nowFunc(); } }

        private readonly Func<DateTime> _nowFunc;
    }
}
