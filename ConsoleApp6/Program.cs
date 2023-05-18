
using ConsoleApp6;


string sample = Console.ReadLine();
var elements = sample.Split(" ");



var a=new BigInteger(elements[0]);
var b=new BigInteger(elements[2]);
var sign=elements[1];
var res = new BigInteger("1");
if (sign=="-")
{
     res = a - b;
}else if (sign=="+")
{
     res = a + b; 
}
else if (sign=="*")
{
    res = a * b; 
}

Console.WriteLine(res.ShowFinal());
//Console.WriteLine(res.ToString());