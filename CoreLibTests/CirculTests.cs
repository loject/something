using CoreLib;
using NUnit.Framework;

namespace CoreLibTests
{
    /*
     * сравнивать даблы с эпсилоном - максимально топорная идея, и по хорошему так не делать
     * */
    public class CirculTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor()
        {
            double Radius = 10;

            ICircul figure = new Circul(Radius);
            Assert.Multiple(() =>
            {
                Assert.That(figure, Is.Not.Null);
                Assert.That(figure.Radius, Is.EqualTo(Radius));
            });
        }

        [TestCase(3, false)]
        [TestCase(-3, true)]
        public void ValidateCircul(double Radius, bool ExpectException)
        {
            Assert.That(() => new Circul(Radius),
                ExpectException ? Throws.ArgumentException : Throws.Nothing);
        }

        [TestCase(3, Math.PI * 9, ExpectedResult = true)]
        [TestCase(30, Math.PI * 900, ExpectedResult = true)]
        public bool GetSqure(double Radius, double ExpectSquare)
        {
            IFigure figure = new Circul(Radius);
            double square = figure.GetSqure();

            return Math.Abs(square - ExpectSquare) < Constants.Epsilon;
        }
    }
}