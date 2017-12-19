namespace SMTask3
{
    interface IDistributionFunction
    {
        double F(double x);
        double Left();
        double Right();
    }
}
