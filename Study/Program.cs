Console.Clear();
Console.Write("Enter first number: ");
string Input = Console.ReadLine()!;
float firstNum = float.Parse(Input);
Console.Write("Enter second number: ");
Input = Console.ReadLine()!;
float secondNum = float.Parse(Input);
System.Console.Write("Change a arithmetic operation (+, -, *, /): ");
string operation = Console.ReadLine()!;

if (operation == "+")
{
    System.Console.WriteLine($"Result: {firstNum + secondNum}");
}
else if (operation == "-")
{
    System.Console.WriteLine($"Result: {firstNum - secondNum}");
}
else if (operation == "*")
{
    System.Console.WriteLine($"Result: {firstNum * secondNum}");
}
else if (operation == "/")
{
    if(secondNum != 0)
    System.Console.WriteLine($"Result: {firstNum / secondNum}");
    else
    {
        System.Console.WriteLine("Error! Division on null");
    }
}
else
{
    System.Console.WriteLine("Error! Incorrect operation");
}