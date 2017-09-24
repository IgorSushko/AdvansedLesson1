using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace changefile
{
    class WorkWithText
    {
        public static void DoJob(ref string[] array, int start, int stop)
        {
            for (var i=start; i<stop+1; i++)
            {
                var tempstr = UpperLoverCase(array[i]);
                array[i] = tempstr;
                //Console.WriteLine(Thread.CurrentThread.Name);
                //Console.WriteLine(array[i]);
                //Console.WriteLine("******");
            }
            
            
        }
		
        private static string UpperLoverCase(string s)
        {
           
            char[] a = s.ToCharArray();
            for (int i = 0; i < a.Length; i++) 
			{
                if (char.IsUpper(a[i]))
                {
                    a[i] = char.ToLower(a[i]);
                } 
				else { a[i] = char.ToUpper(a[i]); }
            }
            
           // return new StringBuilder().Append(a).ToString();
           return new string(a);
        }
    }
}
