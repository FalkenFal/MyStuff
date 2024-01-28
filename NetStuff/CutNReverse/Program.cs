using System;

namespace NETCore{
    class Program{

        public string StringInput = Console.ReadLine();

        static void Main(){
            Console.WriteLine("Please enter text");
            string calledVar = new Program().StringInput; 
            Console.WriteLine(SubbedAndReverse(calledVar));

        }

        static string SubbedAndReverse(string Input){

            var Subbed = Input.Substring(0,Input.Length/2);
            var Subbed2 = Input.Substring(Input.Length/2);

            char[] StringToCharArray = Subbed.ToCharArray();
            char[] StringToCharAttay2 = Subbed2.ToCharArray();

            Array.Reverse(StringToCharArray);
            Array.Reverse(StringToCharAttay2);

            string subbednew1 = new string(StringToCharArray);
            string subbednew2 = new string(StringToCharAttay2);

            return subbednew1 + subbednew2;
        }

    }

}

