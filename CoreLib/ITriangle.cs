namespace CoreLib
{
    public interface ITriangle : IFigure
    {
        double A { get; }
        double B { get; }
        double C { get; }
        bool IsRightTriangle();
    }
}