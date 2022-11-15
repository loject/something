using System;
using System.Configuration;

namespace CoreLib
{
    public record Triangle : ITriangle
    {
        public double A { get; }

        public double B { get; }

        public double C { get; }
        public Triangle(double A, double B, double C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            ValidateTriangle();
        }

        public double GetSqure()
        {
            ValidateTriangle();

            double pp = (A + B + C) / 2;
            double square = Math.Sqrt(pp * (pp - A) * (pp - B) * (pp - C));
            return square;
        }

        private void ValidateTriangle()
        {
            if (A <= 0 || B <= 0 || C <= 0)
                throw new ArgumentException("Length can't be negative or zero");


            if (A + B <= C ||
                B + C <= A ||
                C + A <= B)
                throw new ArgumentException("Passed arguments not make triangle");
        }

        public bool IsRightTriangle()
        {
            double maxEdge = A, b = B, c = C;
            if (b > maxEdge) (maxEdge, b) = (b, maxEdge);
            if (c > maxEdge) (maxEdge, c) = (c, maxEdge);

            return Math.Abs(maxEdge * maxEdge - (b * b + c * c)) < Constants.Epsilon;
        }
    }
}