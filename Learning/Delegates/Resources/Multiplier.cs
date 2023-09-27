namespace Learning.Delegates.Resources
{
    internal class Multiplier
    {
        double _factor;

        public Multiplier(double factor) => _factor = factor;

        public double Multiply(double x) => x * _factor;
    }
}
