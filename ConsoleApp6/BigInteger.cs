namespace Karatsuba2;



public class BigInteger
{
    public string checkerFirst;
    private int[] _numbers;
    public bool _isNegative;
    public bool _IsNegativeKaratsuba;
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
    public static BigInteger operator *(BigInteger a, BigInteger b) => a.KaratsubaTechic(b);
    public static bool operator <(BigInteger a, BigInteger b) => a.Comparison(b);
    public static bool operator >(BigInteger a, BigInteger b) => a.ComparisonFake(b);


    public override string ToString()
    {
        var res = "";
        for (int i = 0; i < _numbers.Length; i++)
        {
            res += _numbers[i].ToString();
        }
        return res;
    }

    public bool Comparison(BigInteger compared)
    {
        bool Bigger = false;
        if (this._numbers.Length < compared._numbers.Length)
        {
            Bigger = true;
        }
        else if(this._numbers.Length == compared._numbers.Length)
        {
            for (int i = compared._numbers.Length - 1; i >= 0; i--)
            {
                if (this._numbers[i] < compared._numbers[i])
                {
                    Bigger = true;
                }
            }
        }
        return Bigger;
    }

    public bool ComparisonFake(BigInteger compared)
    {
        return true;
    }


    public int ToInt()
    {
        return int.Parse(this.ShowFinal());

    }

    public string ShowFinal()
    {
        var res = "";
        for (int i = _numbers.Length - 1; i >= 0; i--)
        {

            res += _numbers[i].ToString();
        }

        if (res[0] == '0')
        {
            res = res.Substring(1, res.Length - 1);
        }

        if (_isNegative)
        {
            res = '-' + res;
        }
        if (res == "")
        {
            res = "0";
        }
        return res;
    }

    public string ShowFinalMultiply()
    {
        var res = "";
        for (int i = _numbers.Length - 1; i >= 0; i--)
        {

            res += _numbers[i].ToString();
        }

        if (res[0] == '0')
        {
            res = res.Substring(1, res.Length - 1);
        }

        if (_IsNegativeKaratsuba)
        {
            res = '-' + res;
        }
        if (res == "")
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

        if (_isNegative && another._isNegative == false)
        {
            _isNegative = false;
            return another.Sub(this);
        }

        if (_isNegative == false && another._isNegative)
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
        var ResList = new int[Math.Max(current.Length, addAr.Length)];
        for (int i = 0; i < Math.Max(current.Length, addAr.Length); i++)
        {
            var res = current[i] + addAr[i] + c;
            c = res / 10;
            ResList[i] = res % 10;
        }
        var resText = "";

        if (c > 0)
        {
            resText = c.ToString();
        }
        for (int i = ResList.Length - 1; i >= 0; i--)
        {
            resText += ResList[i].ToString();
        }
        var result = new BigInteger(resText);
        if (_isNegative && another._isNegative)
        {
            result._isNegative = true;
        }
        return result;
    }

    public BigInteger Sub(BigInteger another)
    {
        int[] first;
        var current = new int[_numbers.Length];
        var addAr = new int[another.ToString().Length];

        for (int i = 0; i < current.Length; i++)
        {
            current[i] = _numbers[i];
        }
        for (int i = 0; i < addAr.Length; i++)
        {
            addAr[i] = int.Parse(another.ToString()[i].ToString());
        }
        if (current[current.Length - 1] == 0)
        {
            Array.Resize(ref current, current.Length-1);
        }
        if (addAr[addAr.Length - 1] == 0)
        {
            Array.Resize(ref addAr, addAr.Length - 1);
        }


        first = current;
        

        var second = addAr;
        var Signnegative = false;

        if (_isNegative && another._isNegative == false)
        {
            another._isNegative = true;
            return Add(another);
        }

        if ((_isNegative == false && another._isNegative) || (_isNegative && another._isNegative))
        {
            another._isNegative = false;
            return Add(another);
        }

        if (long.Parse(checkerFirst) < long.Parse(another.checkerFirst))
        {
            first = addAr;
            second = current;
            Signnegative = true;
        }

        var c = 0;
        var ResList = new int[Math.Max(current.Length, addAr.Length)];
        var resText = "";
        for (int i = 0; i < Math.Max(current.Length, addAr.Length); i++)
        {
            var SubNum = 0;
            if (i < second.Length)
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
        for (int i = ResList.Length - 1; i >= 0; i--)
        {
            resText += ResList[i].ToString();
        }
        var result = new BigInteger(resText);

        result._isNegative = Signnegative;

        return result;
    }

    public BigInteger Addzeros(int m)
    {
        List<int> res = new List<int>();
        for (int i = 0; i < m; i++)
        {
            res.Add(0);
        }
        foreach (int value in _numbers)
        {
            res.Add(value);
        }
        _numbers = res.ToArray();
        return this;
    }

   public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    /*
    public string GetFirstHalf(int m, int n)
    {
        string res = "";
        int[] zeros = new int[n];
        for (int i =0; i<n; i++)
        {
            zeros[i] = 0;
        }
        for (int i = 0; i < this._numbers.Length; i++)
        {
            zeros[i] = this._numbers[i];
        }
        for (int i = 0; i < m; i++)
        {
            res += this._numbers[i];
        }
        string resinv = Reverse(res);
        return resinv;
    }

    public string GetSecondHalf(int m, int n)
    {
        string res = "";
        for (int i = m; i < _numbers.Length; i++)
        {
            res += this._numbers[i];
        }
        string resinv = Reverse(res);
        return resinv;
    }
    */
    
     public string GetSecondHalf(int m, int n)
     {
         string res = "";
         string resinv = "";
         string finale = "";
          string finale2 = "";
         for (int i = 0; i < this._numbers.Length; i++)
         {
             res += this._numbers[i].ToString();
         }
        resinv = res;
       
            resinv = resinv.PadRight(m, '0');

        finale = resinv.Substring(0, m);
         finale = finale.TrimEnd('0');
         if (finale == "")
         {
             finale = "0";
         }
        for (int i = finale.Length - 1; i >= 0; i--)
        {
            finale2 += finale[i];
        }
        if (finale2 == "")
        {
            finale2 = "0";
        }
        return finale2;


     }
     public string GetFirstHalf(int m, int n)
     {
         string res = "";
         string resinv = "";
         string finale = "";
        string finale2 = "";
        for (int i = 0; i < this._numbers.Length; i++)
         {
             res += this._numbers[i].ToString();
         }
         resinv = res;
       
            resinv = resinv.PadRight(m, '0');

        finale = resinv.Substring(m);
        finale = finale.TrimEnd('0');
         if (finale == "")
         {
             finale = "0";
         }
        for (int i = finale.Length - 1; i >= 0; i--)
        {
            finale2 += finale[i];
        }
        if (finale2 == "")
        {
            finale2 = "0";
        }
        return finale2;


     }
    
    public BigInteger KaratsubaTechic(BigInteger another)
    {

        if (this < new BigInteger("10") || another < new BigInteger("10"))
        {
            return new BigInteger((this.ToInt() * another.ToInt()).ToString());
        }

        int n = Math.Max(this.ToString().Length, another.ToString().Length);
        int m = (int)Math.Floor(n / 2.0);
        BigInteger x0 = new BigInteger(this.GetFirstHalf(m, n));
        BigInteger x1 = new BigInteger(this.GetSecondHalf(m, n));
        BigInteger y0 = new BigInteger(another.GetFirstHalf(m, n));
        BigInteger y1 = new BigInteger(another.GetSecondHalf(m, n));
        BigInteger z0 = x1 * y1;
        BigInteger z2 = x0 * y0;
        BigInteger z1 = (x0 + x1) * (y0 + y1) - z0 - z2;
        BigInteger result = z2.Addzeros(m * 2) + z1.Addzeros(m) + z0;
        if ((_isNegative && another._isNegative == false) || (_isNegative == false && another._isNegative))
        {
            result._IsNegativeKaratsuba = true;
        }
        return result;
    }
}