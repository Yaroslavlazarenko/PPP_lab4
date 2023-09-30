namespace PPP_lab4
{
    public class CommonFraction
    {
        private int numerator;
        private int denominator;
        
        /// <summary>
        /// Конструктор класса обыкновенной дроби
        /// </summary>
        /// <param name="top">Числитель</param>
        /// <param name="bottom">Знаменатель</param>
        public CommonFraction(int top, int bottom)
        {
            (numerator, denominator) = bottom < 0 ? (-top, -bottom) : (top, bottom == 0 ? 1 : bottom);
            if (bottom == 0)
            {
                Console.WriteLine("Делить на ноль нельзя, поэтому знаменатель заменен на 1.");
            }
        }

        /// <summary>
        /// Вычисление суммы двух чисел
        /// </summary>
        /// <param name="left">Первое слагаемое</param>
        /// <param name="right">Второе слагаемое</param>
        /// <returns>Сумма в виде обыкновеной дроби</returns>
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

        /// <summary>
        /// Вычисление разности двух обыкновенных дробей
        /// </summary>
        /// <param name="left">Уменьшаемое</param>
        /// <param name="right">Вычитаемое</param>
        /// <returns>Разность в виде обыкновенной дроби</returns>
        public static CommonFraction operator -(CommonFraction left, CommonFraction right)
        {
            return left + new CommonFraction(-right.numerator, right.denominator);
        }

        /// <summary>
        /// Вычисление произведения двух обыкновенных дробей
        /// </summary>
        /// <param name="left">Первый множитель</param>
        /// <param name="right">Второй множитель</param>
        /// <returns>Произведение в виде обыкновенной дроби</returns>
        public static CommonFraction operator *(CommonFraction left, CommonFraction right)
        {
            int newNumerator = left.numerator * right.numerator;
            int newDenominator = left.denominator * right.denominator;
            int gcd = greatestCommonDivisor(newNumerator, newDenominator);
            return new CommonFraction(newNumerator / gcd, newDenominator / gcd);
        }

        /// <summary>
        /// Получить обратную обыкновенную дробь
        /// </summary>
        /// <param name="commonFraction">Обыкновенная дробь</param>
        /// <returns>Обратная обыкновенная дробь</returns>
        public static CommonFraction InverseCommonFraction(CommonFraction commonFraction)
        {
            return new CommonFraction(commonFraction.denominator, commonFraction.numerator);
        }

        /// <summary>
        /// Нахождение наибольшего делителя двух целых чисел
        /// </summary>
        /// <param name="top">Первое число</param>
        /// <param name="bottom">Второе число</param>
        /// <returns>Наибольший делитель</returns>
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