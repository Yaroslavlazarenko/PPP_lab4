using System;

namespace PPP_lab4
{
    public class CommonFraction
    {
        private int _numerator;
        private int _denominator;

        /// <summary>
        /// Свойство обеспечивает доступ к значению числителя дроби, а также позволяет изменять это значение
        /// </summary>
        public int Numerator 
        { 
            get => _numerator;
            set => _numerator = value;
        }

        /// <summary>
        /// Свойство обеспечивает доступ к значению знаменателя дроби, а также позволяет изменять это значение
        /// </summary>
        public int Denominator
        {
            get => _denominator;
            set 
            { 
                if(value < 0)
                {
                    _numerator = -_numerator;
                    _denominator = -value;
                }
                else if (value == 0)
                {
                    throw new ArgumentException("Знаменатель дроби равен нулю");
                }
                else
                {
                    _denominator = value;
                }
            }
        }

        /// <summary>
        /// Конструктор класса обыкновенной дроби
        /// </summary>
        /// <param name="numerator">Числитель</param>
        /// <param name="denominator">Знаменатель</param>
        public CommonFraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Вычисление суммы двух чисел
        /// </summary>
        /// <param name="left">Первое слагаемое</param>
        /// <param name="right">Второе слагаемое</param>
        /// <returns>Сумма в виде обыкновеной дроби</returns>
        public static CommonFraction operator +(CommonFraction left, CommonFraction right)
        {
            if (left == null || right == null)
            {
                throw new NullReferenceException("При сложении одна из дробей null");
            }
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
            if (left == null || right == null)
            {
                throw new NullReferenceException("При вычитании одна из дробей null");
            }
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
            if (left == null || right == null)
            {
                throw new NullReferenceException("При умножении одна из дробей null");
            }
            int newNumerator = left._numerator * right._numerator;
            int newDenominator = left._denominator * right._denominator;
            int greatestCommonDivisor = GreatestCommonDivisor(newNumerator, newDenominator);
            return new CommonFraction(newNumerator / greatestCommonDivisor, newDenominator / greatestCommonDivisor);
        }

        /// <summary>
        /// Получить обратную обыкновенную дробь
        /// </summary>
        /// <param name="commonFraction">Обыкновенная дробь</param>
        /// <returns>Обратная обыкновенная дробь в формате текста</returns>
        public static CommonFraction InverseCommonFraction(CommonFraction commonFraction)
        {
            if (commonFraction == null)
            {
                throw new NullReferenceException("Дробь для образования обратной дроби null");
            }
            else if (commonFraction.Numerator == 0)
            {
                throw new DivideByZeroException("Числитель дроби для образования обратной равен нулю");
            }

            return new CommonFraction(commonFraction._denominator, commonFraction._numerator);
        }

        /// <summary>
        /// Нахождение наибольшего делителя двух целых чисел
        /// </summary>
        /// <param name="firstNumber">Первое число</param>
        /// <param name="secondNumber">Второе число</param>
        /// <returns>Наибольший делитель</returns>
        private static int GreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            int temp;
            while (secondNumber != 0)
            {
                temp = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = temp;
            }
            return Math.Abs(firstNumber);
        }

        public override string ToString()
        {
            return $"{_numerator}\n{new string('-', Math.Max(Math.Abs(_numerator < 0 ? _numerator * 10 : _numerator), Denominator).ToString().Length)}\n{Denominator}";
        }
    }
}