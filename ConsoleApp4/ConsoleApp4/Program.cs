using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интеграл
{
	class massiv 
	{
		static double Fx(double xm)
		{
            return Math.Cos(0.4 * Math.Pow(xm, 2) + 1.0) / (2.3 + Math.Sin(1.5 * xm + 0.3));

		}
		static public void TabXY(double x1, double h, params double[] y)
		{
			double x, x2;
			x2 = x1;
			for (int i = 0; i < y.Length; i++)
			{
				x = x2 + i * h;
				y[i] = Fx(x);
				Console.WriteLine($"\t x{i} {x,4:f2} y{i} {y[i],4:f2}");
				Console.WriteLine();

			}
		}
	
		static public void InRecLg(double h, string InR, ref double IR, params double[] y)
		{
			for (int i = 0; i < y.Length-1; i++)
				IR += y[i];
			IR *= h;
			Console.WriteLine($"\t значение интеграла (0,k-1) IR={IR:f5}" ); 


        }
		static public void InRecPg(double h, string InR, ref double IR, params double[] y)
		{
			for (int i = 1; i < y.Length; i++)
				IR += y[i];
			IR *= h;
			Console.WriteLine($"\t значение интеграла (1,k) IR={IR:f5}");

		}
		static void Main()
		{
            double a = 0.4, b = 1.1, hx = 0.1;

            int k = (int)((b + 1e-4 - a) / hx + 1);
			Console.WriteLine($"\t a={a:f2} b= {b:f2} h={hx:f2} k={k}");
			double[] y = new double[k];
			TabXY(a, hx, y);
			double InR2 = 0; 
			InRecPg(hx, "InR2", ref InR2, y);
            double InR1 = 0;
            InRecLg(hx, "InR1", ref InR1, y);
            a += hx / 2;
			TabXY(a, hx, y);
			double InR3 = 0; 
			InRecLg(hx, "InR3", ref InR3, y);
			Console.ReadLine();
 		}
	}
}
