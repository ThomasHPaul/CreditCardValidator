using System;

namespace CreditCardValidator
{
    class Program
    {
        static void Main()
        {
            string testInputValid = "379354508162306";
            string testInputInvalid = "4388576018402626";

            CreditCardValidator.IsValid(testInputValid);
            CreditCardValidator.IsValid(testInputInvalid);
            
        }
    }

    static class CreditCardValidator
    {
        static public void IsValid(string CardNumber)
        {
            string tempTestInput = "dummy holder";
            int step2Sum = 0;
            int step3Sum = 0;
            tempTestInput = CardNumber;
            for (int i = 1; i < CardNumber.Length; i += 2)
            {
                int tempInt = int.Parse(CardNumber.Substring(i, 1)) * 2;

                if (tempInt > 9)
                {
                    tempInt = int.Parse(tempInt.ToString().Substring(0, 1)) + int.Parse(tempInt.ToString().Substring(1, 1));
                }

                tempTestInput = tempTestInput.Substring(0, i) + tempInt.ToString() + CardNumber.Substring(i + 1);
                step2Sum += tempInt;
            }

            for (int i = 0; i < CardNumber.Length; i += 2)
            {
                step3Sum += int.Parse(CardNumber.Substring(i, 1));
            }

            if ((step2Sum + step3Sum) % 10 == 0)
            {
                Console.WriteLine($"{CardNumber} is valid");
            }
            else
            {
                Console.WriteLine($"{CardNumber} is not valid");
            }

            Console.WriteLine($"CardNumber: {CardNumber}");
            Console.WriteLine($"tempTestInput : {tempTestInput}");
        }
    }
}
