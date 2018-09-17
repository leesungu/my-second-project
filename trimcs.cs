using System;





namespace String_trim

{

    class Program

    {

        static void Main(string[] args)

        {

            String aa = "  cdef ";



            Console.WriteLine("원본        == |{0}|", aa);



            Console.WriteLine("Trim()      == |{0}|", aa.Trim()); // 앞, 뒤 공백 제거



            Console.WriteLine("TrimStart() == |{0}|", aa.TrimStart()); // 앞 공백 제거



            Console.WriteLine("TrimEnd()   == |{0}|", aa.TrimEnd());  // 뒤 공백 제거



            Console.ReadLine();





            // 제거할 문자 지정

            char[] removal = { '*', ' ', '\'', '1', '2' };  // 별표, 공백, 아포스트로피, 1, 2



            String bb = " *  2cdef 1* ";



            Console.WriteLine("원본        == |{0}|", bb);



            Console.WriteLine("Trim()      == |{0}|", bb.Trim(removal)); // 앞, 뒤  해당문자 제거



            Console.WriteLine("TrimStart() == |{0}|", bb.TrimStart(removal)); // 앞 해당문자 제거



            Console.WriteLine("TrimEnd()   == |{0}|", bb.TrimEnd(removal));  // 뒤 해당문자 제거



            Console.ReadLine();





        }

    }

}