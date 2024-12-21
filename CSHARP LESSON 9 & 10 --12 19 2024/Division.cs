namespace Calculator
{
    public class Division : ICalculatorOperation
    {
        public string Name => "Division";

        public double Execute(double a, double b)
        {
            if (b == 0 || a == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return a / b;
        }
    }
}