using System;
using System.Linq;

public static class ArmstrongExtensions
{
    public static bool IsArmstrong(this int number)
    {
        if (number < 0)
            throw new ArgumentException("O número deve ser positivo.");

        var digits = number.ToString().Select(d => int.Parse(d.ToString())).ToArray();
        int numberOfDigits = digits.Length;
        int sum = digits.Sum(d => (int)Math.Pow(d, numberOfDigits));

        return sum == number;
    }
}

public class Program
{
    public static void Main()
    {
        for (int i = 1; i <= 10000; i++)
        {
            if (i.IsArmstrong())
            {
                Console.WriteLine(i);
            }
        }
    }
}