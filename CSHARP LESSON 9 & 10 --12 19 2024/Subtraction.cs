namespace Calculator
{
    public class Subtraction : ICalculatorOperation
    {
        public string Name => "Subtraction";

        public double Execute(double a, double b)
        {
            return a - b;
        }
    }
}