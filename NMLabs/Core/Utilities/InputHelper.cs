namespace NMLabs.Core.Utilities;

public static class InputHelper
{
    public static int GetIntFromConsole(string hint) 
    {
        int result;
        Console.Write(hint);

        while (!int.TryParse(Console.ReadLine(), out result)) 
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите целое число.");
            Console.Write(hint);
        }
        return result;
    }

    public static double GetDoubleFromConsole(string hint)
    {
        double result;
        Console.Write(hint);

        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите вещественное число.");
            Console.Write(hint);
        }
        return result;
    }
}
