using System;





namespace String_trim

{

    class Program

    {

        static void Main(string[] args)

        {

            String aa = "  cdef ";



            Console.WriteLine("����        == |{0}|", aa);



            Console.WriteLine("Trim()      == |{0}|", aa.Trim()); // ��, �� ���� ����



            Console.WriteLine("TrimStart() == |{0}|", aa.TrimStart()); // �� ���� ����



            Console.WriteLine("TrimEnd()   == |{0}|", aa.TrimEnd());  // �� ���� ����



            Console.ReadLine();





            // ������ ���� ����

            char[] removal = { '*', ' ', '\'', '1', '2' };  // ��ǥ, ����, ������Ʈ����, 1, 2



            String bb = " *  2cdef 1* ";



            Console.WriteLine("����        == |{0}|", bb);



            Console.WriteLine("Trim()      == |{0}|", bb.Trim(removal)); // ��, ��  �ش繮�� ����



            Console.WriteLine("TrimStart() == |{0}|", bb.TrimStart(removal)); // �� �ش繮�� ����



            Console.WriteLine("TrimEnd()   == |{0}|", bb.TrimEnd(removal));  // �� �ش繮�� ����



            Console.ReadLine();





        }

    }

}