namespace ConsoleApp6;

public class BigInteger
{
    public string checkerFirst;
    private int[] _numbers;
    public bool _isNegative;

    public BigInteger(string value)
    {
       
        if (value[0] == '-')
        {
            _isNegative = true;
            value = value.Substring(1);
        }

        for (int i = 0; i < value.Length; i++)
        {
            checkerFirst += value[i];
        }

        var newArray = new List<int>();
        for (int i = value.Length; i > 0; i--)
        {

            newArray.Add(int.Parse(value[i - 1].ToString()));
        }

        _numbers = newArray.ToArray();
    }
    public static BigInteger operator +(BigInteger a, BigInteger b) => a.Add(b);
    
    public static BigInteger operator -(BigInteger a, BigInteger b) => a.Sub(b);
    public override string ToString()
    {
        var res = "";
        for (int i = 0; i <_numbers.Length; i++)
        {
            res += _numbers[i].ToString();
        }
        return res;
    }
    
    
    
    public string ShowFinal()
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

        if (_isNegative)
        {
            res = '-' + res;
        }
        if (res=="")
        {
            res = "0";
        }
        return res;
    }
    
    
     public BigInteger Add(BigInteger another)
    { 
        
        var current = _numbers;
        var addAr = another._numbers;
        
        /*
        for (int i =0 ; i <current.Length; i++)
        {
            current[i]= _numbers[i];
        }
        for (int i =0 ; i<addAr.Length; i++)
        {
            addAr[i]= int.Parse(another.ToString()[i].ToString());
        }
        */

        if (_isNegative && another._isNegative==false)
        {
            _isNegative = false;
            return another.Sub(this);
        }
        
        if (_isNegative==false && another._isNegative)
        {
            another._isNegative = false;
            return Sub(another);
        }
        if (current.Length > addAr.Length)
        {
            int diff = current.Length - addAr.Length;
            Array.Resize(ref addAr, current.Length);
            for (int i = 0; i < diff; i++)
            {
                addAr[addAr.Length - 1 - i] = 0;
            }
        }
        else if (addAr.Length > current.Length)
        {
            int diff = addAr.Length - current.Length;
            Array.Resize(ref current, addAr.Length);
            for (int i = 0; i < diff; i++)
            {
                current[current.Length - 1 - i] = 0;
            }
        }
        var c = 0;
        var ResList =new int[Math.Max(current.Length, addAr.Length)+1];
        for (int i = 0; i < Math.Max(current.Length, addAr.Length); i++)
        {
            var res = current[i] + addAr[i] + c;
            c = res / 10;
            ResList[i] = res % 10;
        }
        var resText = "";
        
        if (c>0)
        {
            ResList[Math.Max(current.Length, addAr.Length) ] = c;
        }
        for (int i = 0; i <ResList.Length ; i++)
        {
            resText += ResList[i].ToString();
        }
        var result =new BigInteger(resText);
        if (_isNegative && another._isNegative)
        {
            result._isNegative = true;
        }
        return result;
    }
     
     public BigInteger Sub(BigInteger another)
     {
         var current = new int[_numbers.Length];
         var addAr = new int[another.ToString().Length];
        
         for (int i =0 ; i <current.Length; i++)
         {
             current[i]= _numbers[i];
         }
         for (int i =0 ; i<addAr.Length; i++)
         {
             addAr[i]= int.Parse(another.ToString()[i].ToString());
         }

         var first = current;
         var second = addAr;
         var Signnegative = false;

         if (_isNegative && another._isNegative==false)
         {
             another._isNegative = true;
             return Add(another);
         }

         if ((_isNegative==false && another._isNegative)|| (_isNegative && another._isNegative))
         {
             another._isNegative = false;
             return Add(another);
         }
         
             if (int.Parse(checkerFirst)<int.Parse(another.checkerFirst))
         {
             first = addAr;
             second = current;
             Signnegative = true;
         }
         
         var c = 0;
         var ResList =new int[Math.Max(current.Length, addAr.Length)];
         var resText = "";
         for (int i = 0; i < Math.Max(current.Length, addAr.Length); i++)
         {
             var SubNum = 0;
             if (i<second.Length)
             {
                 SubNum = second[i];
             }
             else
             {
                 SubNum = 0;
             }
             int diff = first[i] - c - SubNum;
             if (diff < 0)
             {
                 c = 1;
                 ResList[i] = diff + 10;
             }
             else
             {
                 c = 0;
                 ResList[i] = diff;
             }
         }
         for (int i = 0; i <ResList.Length ; i++)
         {
             resText += ResList[i].ToString();
         }
         var result =new BigInteger(resText);
         
             result._isNegative = Signnegative;
         
         return result;
     }
     public BigInteger KaratsubaTechic(BigInteger another)
     {
         var Ix = int.Parse(checkerFirst);
         var Iy = int.Parse(another.checkerFirst);
         // Base case: if either x or y is less than 10, just use regular multiplication
         if (Ix < 10 || Iy < 10)
         {
             return new BigInteger((Ix * Iy).ToString());
         }

         var stepin = Math.Max(checkerFirst.Length, another.checkerFirst.Length);
         var basee = 10 ^ (stepin/2);
         
         var res = new BigInteger("1");
         return res;
     }
}