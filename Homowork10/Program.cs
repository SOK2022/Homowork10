ILogger logger = new Logger();
var calculator = new Calculator(logger);
try
{
    Console.WriteLine("Введите первое чило");
    double a = double.Parse(Console.ReadLine());
    Console.WriteLine("Введите второе чило");
    double b = double.Parse(Console.ReadLine());
    calculator.Logger.Event("Калькулятор начинает работу");
    Console.WriteLine(calculator.Add(a, b));
    calculator.Logger.Event("Калькулятор закончил работу");
}
catch (Exception ex)
{
    calculator.Logger.Error("Некорректный ввод");
}
interface IAddition
{
    double Add(double a, double b);
}

class Calculator : IAddition
{
    public ILogger Logger { get; }
    public Calculator(ILogger logger)
    {
        Logger = logger;
    }
    public double Add(double a, double b)
    {
        return a + b;
    }
}

interface ILogger
{
    void Event(string message);
    void Error(string message);
}

class Logger : ILogger
{
    public void Event(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
    }
    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
    }
}