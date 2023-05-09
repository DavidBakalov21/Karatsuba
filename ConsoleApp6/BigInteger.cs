namespace ConsoleApp6;

public class BigInteger
{
    private int[] _numbers;
    public BigInteger(string value)
    {
        var newArray = new List<int>();
        for (int i = 0; i <value.Length; i++)
        {
           newArray.Add(int.Parse(value[i].ToString()));
        }
        _numbers = newArray.ToArray();
        foreach (var VARIABLE in _numbers)
        {
            Console.WriteLine(VARIABLE);
        }
    }
    public override string ToString()
    {
        var res = "";
  for (int i = 0; i < _numbers.Length; i++)
  {
      res += _numbers[i].ToString();
  }
  

 
  // convert array back to string and return it
  
  //In case of reverse
 /* for (int i = _numbers.Length; i >0; i--)
  {
      res += _numbers[i-1].ToString();
  }*/
  
  //In case of reverse
  return res;
    }
    
    
    public BigInteger Add(BigInteger another)
    {
        var a = new BigInteger("12345");
        
        // return new BigInteger, result of current + another
        return a;
    }
    
    public BigInteger Sub(BigInteger another)
    {
        // return new BigInteger, result of current - another
        
        var a = new BigInteger("12345");
        return a;
    }
}
















/*

public class BigInteger
{
private int[] _numbers;

public BigInteger(string value)
{
  int[] numbers = new int[] { 1};
  _numbers = numbers;
  for (int i = 0; i <value.Length; i++)
  {
      _numbers = _numbers.Append(int.Parse(value[i].ToString())).ToArray();
  }
  int[] preFinal= new int[_numbers.Length - 1];
  for (int i = 0; i < _numbers.Length; i++)
  {
      if (i!=0)
      {
          preFinal=preFinal.Append(_numbers[i]).ToArray();
      }
  }

  _numbers = preFinal;
  foreach (var VARIABLE in _numbers)
  {
      Console.WriteLine(VARIABLE);
  }


  // convert here string representation to inner int array
  // for example, "123434" must be converted to _numbers = {1, 2, 3, 4, 3, 4}
}
}
*/
