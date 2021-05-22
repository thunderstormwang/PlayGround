namespace NetCoreWebApiPlayGround.Services
{
    public interface ICalculateService
    {
        double Add(double x,
            double y);
        
        double Minus(double x,
            double y);
        
        double Multiply(double x,
            double y);
        
        double Divide(double x,
            double y);
    }
}