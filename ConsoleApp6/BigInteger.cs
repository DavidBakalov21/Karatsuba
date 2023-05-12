namespace ConsoleApp6;

public class BigInteger
{
    private int[] _numbers;
    public BigInteger(string value)
    {
        var newArray = new List<int>();
        for (int i = value.Length; i >0; i--)
        {
           newArray.Add(int.Parse(value[i-1].ToString()));
        }
        _numbers = newArray.ToArray();
    }
    public override string ToString()
    {
        var res = "";
        for (int i = 0; i <_numbers.Length; i++)
  {
      
      res += _numbers[i].ToString();
  }

        if (res[0]=='0')
        {
            res = res.Substring(1, res.Length - 1);
        }
        return res;
    }
    
    
    public BigInteger Add(BigInteger another)
    {
        var current = new int[_numbers.Length];
        var addAr = new int[another.ToString().Length];
        
        for (int i =0 ; i <current.Length; i++)
        {
            current[i]= _numbers[i];
         //   Console.WriteLine(current[i]);
        }
        for (int i =0 ; i<addAr.Length; i++)
        {
            addAr[i]= int.Parse(another.ToString()[i].ToString());
        //    Console.WriteLine(addAr[i]);
        }
        var c = 0;
        var ResList =new int[Math.Max(current.Length, addAr.Length)+1];
        for (int i = 0; i < Math.Max(current.Length, addAr.Length); i++)
        {
            if ((current[i ] + addAr[i ])>=10)
            {
                var split = (current[i ] + addAr[i ]+c).ToString();
                
                c = int.Parse(split[0].ToString());
                ResList[i] = int.Parse(split[1].ToString());
                
            }
            else
            {
                ResList[i] = current[i ] + addAr[i ]+c;
                c = 0;
            }
        }

        if (c>0)
        {
            ResList[Math.Max(current.Length, addAr.Length) ] = c;
        }
        var resText = "";
        for (int i = 0; i <ResList.Length ; i++)
        {
            resText += ResList[i].ToString();
        }

        var result =new BigInteger(resText);
        // return new BigInteger, result of current + another
        return result;
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
