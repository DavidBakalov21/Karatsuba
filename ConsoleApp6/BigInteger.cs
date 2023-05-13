namespace ConsoleApp6;

public class BigInteger
{
    private int[] _numbers;
    private bool _isNegative=false;
    public BigInteger(string value)
    {   if (value[0]=='-')
        {
            _isNegative = true;
            value = value.Substring(1);  
        }
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
        }
        for (int i =0 ; i<addAr.Length; i++)
        {
            addAr[i]= int.Parse(another.ToString()[i].ToString());
        }
        var c = 0;
        var ResList =new int[Math.Max(current.Length, addAr.Length)+1];
        if (this._isNegative==true || another._isNegative==true)
        {
           return this.Sub(another);
        }
        else
        {
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
            return result;
        }
       

        
        
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
        var c = 0;
        var ResList =new int[Math.Max(current.Length, addAr.Length)];
        var resText = "";
        for (int i = 0; i < Math.Max(current.Length, addAr.Length); i++)
            {
                var SubNum = 0;
                if (i<addAr.Length)
                {
                    SubNum = addAr[i];
                }
                else
                {
                    SubNum = 0;
                }
                int diff = current[i] - c - SubNum;
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
      
        return result;
    }
}