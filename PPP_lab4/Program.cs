namespace PPP_lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new();

            CommonFraction firstCommonFraction = new CommonFraction(random.Next(-100, 101), random.Next(-100, 101));
            CommonFraction secondCommonFraction = new CommonFraction(random.Next(-100, 101), random.Next(-100, 101));
            CommonFraction thirdCommonFraction = new CommonFraction(random.Next(-100, 101), random.Next(-100, 101));

            CommonFraction R = (firstCommonFraction + secondCommonFraction) * (firstCommonFraction - thirdCommonFraction);

            Console.WriteLine($"R:\n{R}");
            Console.WriteLine($"\n1/R:\n{CommonFraction.inverseCommonFraction(R)}");
        }
    }
}