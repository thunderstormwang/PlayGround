namespace NetCoreWebApiPlayGround.Services
{
    public class CalculateService : ICalculateService
    {
        public double Add(double x,
            double y)
        {
            return x + y;
        }

        public double Minus(double x,
            double y)
        {
            return x - y;
        }

        public double Multiply(double x,
            double y)
        {
            return x * y;
        }

        public double Divide(double x,
            double y)
        {
            return x / y;
        }
    }
}