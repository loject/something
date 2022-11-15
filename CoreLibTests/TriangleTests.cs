using CoreLib;
using NUnit.Framework;

namespace CoreLibTests
{
    /* 
     * в покрытии стоилобы лучше продумать граничные значени€
     * сравнивать даблы с эпсилоном - максимально топорна€ иде€, и по хорошему так не делать
     * */
    public class TriangleTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor()
        {
            double A = 3, B = 4, C = 5;

            ITriangle triangle = new Triangle(A, B, C);
            Assert.Multiple(() =>
            {
                Assert.That(triangle, Is.Not.Null);
                Assert.That(triangle.A, Is.EqualTo(A));
                Assert.That(triangle.B, Is.EqualTo(B));
                Assert.That(triangle.C, Is.EqualTo(C));
            });
        }

        [TestCase(3, 4, 50, true)]
        [TestCase(30, 40, 5000, true)]
        [TestCase(-3, 4, 5, true)]
        [TestCase(3, 4, 5, false)]
        public void ValidateTriangle(double A, double B, double C, bool ExpectException)
        {
            Assert.That(() => new Triangle(A, B, C),
                ExpectException ? Throws.ArgumentException : Throws.Nothing);
        }

        [TestCase(3, 4, 5, 6, ExpectedResult = true)]
        [TestCase(30, 40, 50, 600, ExpectedResult = true)]
        public bool GetSqure(double A, double B, double C, double ExpectSquare)
        {
            ITriangle triangle = new Triangle(A, B, C);
            double square = triangle.GetSqure();

            return Math.Abs(square - ExpectSquare) < Constants.Epsilon;
        }

        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(30, 40, 50, ExpectedResult = true)]
        [TestCase(30, 40, 55, ExpectedResult = false)]
        public bool IsRightTriangle(double A, double B, double C)
        {
            ITriangle triangle = new Triangle(A, B, C);
            bool isRightTriangle = triangle.IsRightTriangle();

            return isRightTriangle;
        }
    }
}