namespace PPP_lab4
{
    public class CommonFraction
    {
        private int _numerator;
        private int _denominator;
        
        /// <summary>
        /// Конструктор класса обыкновенной дроби
        /// </summary>
        /// <param name="numerator">Числитель</param>
        /// <param name="denominator">Знаменатель</param>
        public CommonFraction(int numerator, int denominator)
        {
            (_numerator, _denominator) = denominator < 0 ? (-numerator, -denominator) : (numerator, denominator == 0 ? 1 : denominator);
        }
        //Если при создании класса обыкновенной дроби ввести знаменатель равный нулю то он будет заменён на 1.


        /// <summary>
        /// Вычисление суммы двух чисел
        /// </summary>
        /// <param name="left">Первое слагаемое</param>
        /// <param name="right">Второе слагаемое</param>
        /// <returns>Сумма в виде обыкновеной дроби</returns>
        public static CommonFraction operator +(CommonFraction left, CommonFraction right)
        {
            int newNumerator, newDenominator;

            if (left._denominator == right._denominator)
            {
                newNumerator = left._numerator + right._numerator;
                newDenominator = left._denominator;
            }
            else
            {
                newNumerator = left._numerator * right._denominator + right._numerator * left._denominator;
                newDenominator = left._denominator * right._denominator;
            }

            int greatestCommonDivisor = GreatestCommonDivisor(newNumerator, newDenominator);
            return new CommonFraction(newNumerator / greatestCommonDivisor, newDenominator / greatestCommonDivisor);
        }

        /// <summary>
        /// Вычисление разности двух обыкновенных дробей
        /// </summary>
        /// <param name="left">Уменьшаемое</param>
        /// <param name="right">Вычитаемое</param>
        /// <returns>Разность в виде обыкновенной дроби</returns>
        public static CommonFraction operator -(CommonFraction left, CommonFraction right)
        {
            return left + new CommonFraction(-right._numerator, right._denominator);
        }

        /// <summary>
        /// Вычисление произведения двух обыкновенных дробей
        /// </summary>
        /// <param name="left">Первый множитель</param>
        /// <param name="right">Второй множитель</param>
        /// <returns>Произведение в виде обыкновенной дроби</returns>
        public static CommonFraction operator *(CommonFraction left, CommonFraction right)
        {
            int newNumerator = left._numerator * right._numerator;
            int newDenominator = left._denominator * right._denominator;
            int greatestCommonDivisor = GreatestCommonDivisor(newNumerator, newDenominator);
            return new CommonFraction(newNumerator / greatestCommonDivisor, newDenominator / greatestCommonDivisor);
        }

        /// <summary>
        /// Получить обратную обыкновенную дробь
        /// </summary>
        /// <param name="commonFraction">Обыкновенная дробь</param>
        /// <returns>Обратная обыкновенная дробь</returns>
        public static CommonFraction InverseCommonFraction(CommonFraction commonFraction)
        {
            return new CommonFraction(commonFraction._denominator, commonFraction._numerator);
        }

        /// <summary>
        /// Нахождение наибольшего делителя двух целых чисел
        /// </summary>
        /// <param name="top">Первое число</param>
        /// <param name="bottom">Второе число</param>
        /// <returns>Наибольший делитель</returns>
        private static int GreatestCommonDivisor(int top, int bottom)
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
            return $"{_numerator}\n{new string('-', Math.Max(Math.Abs(_numerator < 0 ? _numerator*10 : _numerator), _denominator).ToString().Length)}\n{_denominator}";
        }
    }
}