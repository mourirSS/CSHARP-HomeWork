namespace Calculator
{
    public class Multiplication : ICalculatorOperation
    {
        public string Name => "Multiplication";

        public double Execute(double a, double b)
        {
            return a * b;
        }
    }
}