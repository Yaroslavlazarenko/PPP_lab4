namespace PPP_lab4
{
    public class CommonFraction
    {
        private int numerator;
        private int denominator;

        public CommonFraction(int top, int bottom)
        {
            (numerator, denominator) = bottom < 0 ? (-top, -bottom) : (top, bottom == 0 ? 1 : bottom);
            if (bottom == 0)
            {
                Console.WriteLine("Делить на ноль нельзя, поэтому знаменатель заменен на 1.");
            }
        }

        public static CommonFraction operator +(CommonFraction left, CommonFraction right)
        {
            int newNumerator, newDenominator;

            if (left.denominator == right.denominator)
            {
                newNumerator = left.numerator + right.numerator;
                newDenominator = left.denominator;
            }
            else
            {
                newNumerator = left.numerator * right.denominator + right.numerator * left.denominator;
                newDenominator = left.denominator * right.denominator;
            }

            int gcd = greatestCommonDivisor(newNumerator, newDenominator);
            return new CommonFraction(newNumerator / gcd, newDenominator / gcd);
        }

        public static CommonFraction operator -(CommonFraction left, CommonFraction right)
        {
            return left + new CommonFraction(-right.numerator, right.denominator);
        }

        public static CommonFraction operator *(CommonFraction left, CommonFraction right)
        {
            int newNumerator = left.numerator * right.numerator;
            int newDenominator = left.denominator * right.denominator;
            int gcd = greatestCommonDivisor(newNumerator, newDenominator);
            return new CommonFraction(newNumerator / gcd, newDenominator / gcd);
        }

        public static CommonFraction inverseCommonFraction(CommonFraction commonFraction)
        {
            return new CommonFraction(commonFraction.denominator, commonFraction.numerator);
        }

        private static int greatestCommonDivisor(int top, int bottom)
        {
            int temp;
            while (bottom != 0)
            {
                temp = bottom;
                bottom = top % bottom;
                top = temp;
            }
            return Math.Abs(top);
        }

        public override string ToString()
        {
            return $"{numerator}\n{new string('-', Math.Max(Math.Abs(numerator < 0 ? numerator*10 : numerator), denominator).ToString().Length)}\n{denominator}";
        }
    }
}