using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Delegate
{
   
    



    public static class Helper
    {
       
       
        public static void WriteMessage(object o)
        {
            Console.WriteLine($"result:{o.ToString()}");
        }
          public static int Add(int x, int y)
        {
           
            return x + y;
        }

        public static int Mul(int x, int y)
        {
            return x * y;
        }

       
        
        public static bool IsExists<T>(T[] arr, T val)
        {
            foreach (T x in arr)
            {
                if (x.Equals(val))
                    return true;
            }
            return false;
        }
        public static bool IsAllBigger(int[] arr, int val)
        {
            foreach (int p in arr)
            {
                if (p >= val)
                    return false;
            }
            return true;
        }

        public static bool IsPositive(int val)
        {
            return val > 0;
        }

        #region Using Delegate as Parameter
        public static bool Check(int[] arr, int x, Func<int[], int, bool> dlg)
        {
            //return dlg.Invoke(arr,x);
            return dlg(arr, x);
        }
        #endregion

    }
}
