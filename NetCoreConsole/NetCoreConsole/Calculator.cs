namespace NetCoreConsole
{
    public class Calculator : ICalculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Minus(int x, int y)
        {
            return x - y;
        }
    }
}