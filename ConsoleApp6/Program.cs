using Karatsuba2;

string sample = Console.ReadLine();
var elements = sample.Split(" ");



var a = new BigInteger(elements[0]);
var b = new BigInteger(elements[2]);
var sign = elements[1];
if (sign == "-")
{
    Console.WriteLine((a - b).ShowFinal());
}
else if (sign == "+")
{
    Console.WriteLine((a + b).ShowFinal());
}
else if (sign == "*")
{
    Console.WriteLine((a * b).ShowFinalMultiply());
}