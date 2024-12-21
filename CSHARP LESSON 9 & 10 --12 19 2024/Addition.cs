namespace Calculator
{
    public class Addition : ICalculatorOperation
    {
        public string Name => "Addition";

        public double Execute(double a, double b)
        {
            return a + b;
        }
    }
}