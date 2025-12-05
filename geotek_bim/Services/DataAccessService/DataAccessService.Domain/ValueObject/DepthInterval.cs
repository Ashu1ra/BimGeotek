using System;

namespace Domain.ValueObjects
{
    public class DepthInterval
    {
        public double From { get; private set; }
        public double To { get; private set; }

        private DepthInterval() { }

        public DepthInterval(double from, double to)
        {
            if (from < 0 || to < 0) throw new ArgumentOutOfRangeException("Depth cannot be negative");
            if (from > to) throw new ArgumentException("From depth cannot be greater than To depth");

            From = from;
            To = to;
        }

        public double Length => To - From;

        public DepthInterval Update(double from, double to)
        {
            return new DepthInterval(from, to);
        }
    }
}
