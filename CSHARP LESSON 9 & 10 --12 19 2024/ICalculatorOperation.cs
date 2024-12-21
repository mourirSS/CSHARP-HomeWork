namespace Calculator
{
    public interface ICalculatorOperation
    {
        string Name { get; }
        double Execute(double a, double b);
    }
}