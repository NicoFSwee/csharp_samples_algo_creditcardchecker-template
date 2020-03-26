using System;

namespace CreditCardChecker
{
    public class CreditCardChecker
    {
        /// <summary>
        /// Diese Methode überprüft eine Kreditkartenummer, ob diese gültig ist.
        /// Regeln entsprechend der Angabe.
        /// </summary>
        public static bool IsCreditCardValid(string creditCardNumber)
        {
            int cnt = 0;
            int oddNumberSum = 0;
            int evenNumberSum = 0;
            int checkSum = 0;

            if(creditCardNumber.Length != 16)
            {
                return false;
            }

            foreach (char c in creditCardNumber)
            {
                if (cnt % 2 == 0 && cnt != 15)
                {
                    evenNumberSum += CalculateDigitSum(ConvertToInt(c) * 2);
                }
                else if (cnt % 2 == 1 && cnt != 15)
                {
                    oddNumberSum += ConvertToInt(c);
                }
                else if (cnt == 15)
                {
                    checkSum = ConvertToInt(c);
                }

                cnt++; 
            }

            if(checkSum == CalculateCheckDigit(oddNumberSum, evenNumberSum))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Berechnet aus der Summe der geraden Stellen (bereits verdoppelt) und
        /// der Summe der ungeraden Stellen die Checkziffer.
        /// </summary>
        private static int CalculateCheckDigit(int oddSum, int evenSum)
        {
            int checkSum = oddSum + evenSum;
            int cnt = 0;

            while (checkSum % 10 != 0)
            {
                checkSum++;
                cnt++;
            }

            return cnt;
        }

        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl.
        /// </summary>
        private static int CalculateDigitSum(int number)
        {
            int result = 0;

            while (number != 0)
            {
                result += number % 10;

                number = number / 10;
            }

            return result;
        }

        private static int ConvertToInt(char ch) => ch - '0';
    }
}
