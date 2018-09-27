using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int A_B_D_;
            int A_B_dd;
            int aaB_D_;
            int aaB_dd;
            int A_bbD_;
            int A_bbdd;
            int aabbD_;
            int aabbdd;

            Console.WriteLine("Enter amount of A_B_D_:");
            A_B_D_ = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter amount of A_B_dd:");
            A_B_dd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter amount of aaB_D_:");
            aaB_D_ = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter amount of aaB_dd:");
            aaB_dd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter amount of A_bbD_:");
            A_bbD_ = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter amount of A_bbdd:");
            A_bbdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter amount of aabbD_:");
            aabbD_ = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter amount of aabbdd:");
            aabbdd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            string outputAB = CompareAB(A_B_D_, A_B_dd, aaB_D_, aaB_dd, A_bbD_, A_bbdd, aabbD_, aabbdd);
            Console.WriteLine("A and B: {0}", outputAB);

            string outputBD = CompareBD(A_B_D_, A_B_dd, aaB_D_, aaB_dd, A_bbD_, A_bbdd, aabbD_, aabbdd);
            Console.WriteLine("B and D: {0}", outputBD);

            string outputAD = CompareAD(A_B_D_, A_B_dd, aaB_D_, aaB_dd, A_bbD_, A_bbdd, aabbD_, aabbdd);
            Console.WriteLine("A and D: {0}", outputAD);


            Console.ReadKey(); 
        }

        static string CompareAB (int A_B_D_, int A_B_dd, int aaB_D_, int aaB_dd, int A_bbD_, int A_bbdd, int aabbD_, int aabbdd)
        {
            int A_B_ = A_B_D_ + A_B_dd;
            int aaB_ = aaB_D_ + aaB_dd;
            int A_bb = A_bbD_ + A_bbdd;
            int aabb = aabbD_ + aabbdd;
            int A_B_Simplified;
            int aaB_Simplified;
            int A_bbSimplified;
            int aabbSimplified;

            int GCF = GCFFinder(A_B_, aaB_, A_bb, aabb);
            Console.WriteLine("AB GCF: {0}", GCF);

            try
            {
                A_B_Simplified = A_B_ / GCF;
            }
            catch (DivideByZeroException e)
            {
                A_B_Simplified = 0;
            }
            try
            {
                aaB_Simplified = aaB_ / GCF;
            }
            catch (DivideByZeroException e)
            {
                aaB_Simplified = 0;
            }
            try
            {
                A_bbSimplified = A_bb / GCF;
            }
            catch (DivideByZeroException e)
            {
                A_bbSimplified = 0;
            }
            try
            {
                aabbSimplified = aabb / GCF;
            }
            catch (DivideByZeroException e)
            {
                aabbSimplified = 0;
            }

            string linkage; 

            if (A_B_Simplified == 9 && aaB_Simplified == 3 && A_bbSimplified == 3 && aabbSimplified == 1)
            {
                linkage = "Independent";
                return linkage;
            }

            if (aaB_Simplified == 3 && aaB_Simplified == 0 && A_bbSimplified == 0 && aabbSimplified == 1)
            {
                linkage = "Coupling";
                return linkage;
            }

            if (aaB_Simplified == 2 && aaB_Simplified == 1 && A_bbSimplified == 1 && aabbSimplified == 0)
            {
                linkage = "Repulsion";
                return linkage;
            }

            return "sah dud";
        }

        static string CompareBD(int A_B_D_, int A_B_dd, int aaB_D_, int aaB_dd, int A_bbD_, int A_bbdd, int aabbD_, int aabbdd)
        {
            int B_D_ = A_B_D_ + aaB_D_;
            int bbD_ = A_bbD_ + aabbD_;
            int B_dd = A_B_dd + aaB_dd;
            int bbdd = A_bbdd + aabbdd;
            int B_D_Simplified;
            int bbD_Simplified;
            int B_ddSimplified;
            int bbddSimplified;

            int GCF = GCFFinder(B_D_, bbD_, B_dd, bbdd);
            Console.WriteLine("BD GCF: {0}", GCF);

            try
            {
                B_D_Simplified = B_D_ / GCF;
            }
            catch (DivideByZeroException e)
            {
                B_D_Simplified = 0;
            }
            try
            {
                bbD_Simplified = bbD_ / GCF;
            }
            catch (DivideByZeroException e)
            {
                bbD_Simplified = 0;
            }
            try
            {
                B_ddSimplified = B_dd / GCF;
            }
            catch (DivideByZeroException e)
            {
                B_ddSimplified = 0;
            }
            try
            {
                bbddSimplified = bbdd / GCF;
            }
            catch (DivideByZeroException e)
            {
                bbddSimplified = 0;
            }

            string linkage;

            if (B_D_Simplified == 9 && bbD_Simplified == 3 && B_ddSimplified == 3 && bbddSimplified == 1)
            {
                linkage = "Independent";
                return linkage;
            }

            if (B_D_Simplified == 3 && bbD_Simplified == 0 && B_ddSimplified == 0 && bbddSimplified == 1)
            {
                linkage = "Coupling";
                return linkage;
            }

            if (B_D_Simplified == 2 && bbD_Simplified == 1 && B_ddSimplified == 1 && bbddSimplified == 0)
            {
                linkage = "Repulsion";
                return linkage;
            }

            return "sah dud";
        }

        static string CompareAD(int A_B_D_, int A_B_dd, int aaB_D_, int aaB_dd, int A_bbD_, int A_bbdd, int aabbD_, int aabbdd)
        {
            int A_D_ = A_B_D_ + A_bbD_;
            int aaD_ = aaB_D_ + aabbD_;
            int A_dd = A_B_dd + A_bbdd;
            int aadd = aaB_dd + aabbdd;
            int A_D_Simplified;
            int aaD_Simplified;
            int A_ddSimplified;
            int aaddSimplified;

            int GCF = GCFFinder(A_D_, aaD_, A_dd, aadd);
            Console.WriteLine("AD GCF: {0}", GCF);
            if(aadd == 0)
            {
                GCF = GCFFinder(A_D_, aaD_, A_dd);
                Console.WriteLine("new AB GCF: {0}", GCF);
            }

            try
            {
                A_D_Simplified = A_D_ / GCF;
            }
            catch (DivideByZeroException e)
            {
                A_D_Simplified = 0;
            }
            try
            {
                aaD_Simplified = aaD_ / GCF;
            }
            catch (DivideByZeroException e)
            {
                aaD_Simplified = 0;
            }
            try
            {
                A_ddSimplified = A_dd / GCF;
            }
            catch (DivideByZeroException e)
            {
                A_ddSimplified = 0;
            }
            try
            {
                aaddSimplified = aadd / GCF;
            }
            catch (DivideByZeroException e)
            {
                aaddSimplified = 0;
            }

            string linkage;

            if (A_D_Simplified == 9 && aaD_Simplified == 3 && A_ddSimplified == 3 && aaddSimplified == 1)
            {
                linkage = "Independent";
                return linkage;
            }

            if (A_D_Simplified == 3 && aaD_Simplified == 0 && A_ddSimplified == 0 && aaddSimplified == 1)
            {
                linkage = "Coupling";
                return linkage;
            }

            if (A_D_Simplified == 2 && aaD_Simplified == 1 && A_ddSimplified == 1 && aaddSimplified == 0)
            {
                linkage = "Repulsion";
                return linkage;
            }

            return "sah dud";
        }

        static int GCFFinder(int a, int b, int c, int d)
        {
            int i;
            int result = 0;

            for (i = 1; i <= a && i <= b && i <= c && i <= d; i++)
            {
                if (a % i == 0 && b % i == 0 && c % i ==0 && d % i ==0)
                    result = i;
            }

            return result;
        }


        static int GCFFinder(int a, int b, int c)
        {
            int i;
            int result = 0;

            for (i = 1; i <= a && i <= b && i <= c; i++)
            {
                if (a % i == 0 && b % i == 0 && c % i == 0)
                    result = i;
            }

            return result;
        }
    }
}
