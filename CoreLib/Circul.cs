using System;

namespace CoreLib
{
    public record Circul : ICircul
    {
        public double Radius { get; }
        public Circul(double Radius)
        {
            this.Radius = Radius;
            ValidateCircul();
        }

        private void ValidateCircul()
        {
            if (Radius <= 0)
                throw new ArgumentException("Radius can't be negative or zero");
        }

        public double GetSqure()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
