using MyApp;

class Program
{
    static void Main()
    {
        var calc = new Calculator();
        int result = calc.Add(8, 5);
        float result2 = calc.Subtract(10, 15);
        int result3 = calc.Multiplie(3, 15);
        double result4 = calc.Divide(6.5, 10.25);
        Console.WriteLine($"Hasil: {result}");
        Console.WriteLine($"Hasil: {result2}");
        Console.WriteLine($"Hasil: {result3}");
        Console.WriteLine($"Hasil: {result4}");
    }
}