using Delegates.Delegate;

namespace Delegates
{
    #region Declaring Delegates
    public delegate int DelegateMath(int x, int y);
    public delegate void Print(object message);
    #endregion
    internal class Program
    {
             
      
        static void Main(string[] args)
        {
            int[] arr = { 4, 7, 9, 11 };

            #region Declare delegates variables
            DelegateMath Do;
            Print print;
            #endregion

            #region Assign the methods to the delegates
            Do = Helper.Add;
            print= Helper.WriteMessage;
            #endregion

            #region Call the Delegates
            int result = Do(4, 5);
            print(result);
            Do= Helper.Mul;
            result = Do(4, 5);
            print(result);
            #endregion

            #region You can Do a MultiCast Delegate
            Do = Helper.Add;
            Do+=Helper.Mul;
            //the result is the last value returned.
            result= Do(4, 5);
            print(result);
            #endregion

            #region Func is a special case of Delegate. it is a delegate which returns a value.
            //declaring a func saves us the need to also delcare a delegate. it does it for us.
            Func<int[], int, bool> IsTrue;
            IsTrue = Helper.IsExists;
           
            bool answer = IsTrue(arr, 9);
            print(answer);
            IsTrue += Helper.IsAllBigger;
            answer = IsTrue(arr, 9);
            print(answer);
            #endregion

            #region Action is a special case of Delegate. it is a delegate which return void
            //declaring an Action saves us the need to also delcare a delegate. it does it for us.
            Action<object> PrintAnswer= Helper.WriteMessage; 
            answer = IsTrue(arr, 12);
            PrintAnswer(answer);
            #endregion


            #region What if we could pass method as a Parameter?
            PrintAnswer(Helper.Check(arr, 9, Helper.IsAllBigger));
            PrintAnswer(Helper.Check(arr, 9, Helper.IsExists));
            #endregion

            #region But Do we really need to write all these methods for just specific case? -Anonymous methods
            Func<int, bool> bigger = delegate (int val) { return val > 0; };
            PrintAnswer(bigger(4));
            PrintAnswer(bigger(-5));
            PrintAnswer(Helper.Check(arr, 4, delegate (int[] a, int b) { return a[0] == b; }));
            PrintAnswer(Helper.Check(arr, 12, delegate (int[] a, int val) { foreach (int v in a) { if (v == val) return true; }  return false; }));
            #endregion

            #region Writing anonymous delegates...too much typing=>using lambda!
            //=>stands for delegate

            Func<int, bool> positive = (int x) => { return x > 0; };
            PrintAnswer(Helper.Check(arr, 4, (int[] a, int b) => { return a[0] == b; }));
            PrintAnswer(Helper.Check(arr, 12, (int[] a, int val) => { foreach (int v in a) { if (v == val) return true; } return false; }));
            #endregion

            #region Predicate is a Special form of FUNC it has only one paramter and return a bool
            //so basically Predicate is a Func<T,bool>
            Predicate<int> p1 = Helper.IsPositive;
            PrintAnswer(p1(8));
            Predicate<int> p = (x) => x>8;
            #region other ways of writing it
            //Func<int,bool> p= delegate(int x) { return x>8} OR Func<int,bool> p=(x)=>x>8
            #endregion
            PrintAnswer(p(arr[0]));
            PrintAnswer(p(arr[2]));

            #endregion





        }
    }
}