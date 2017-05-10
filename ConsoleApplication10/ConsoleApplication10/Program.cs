using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Filial
    {
       public Mehsul m;

        public double[] a;
        public int k { get; set; }
        public Filial(Mehsul m)
        {
            this.m = m;
            a = m.a;
            k = m.k;

           // mehsullar.Add(m);
          
        }
        public double[] Show()
        {
            return a;
           
        }
    }
    class Mehsul
    {
        public double[] a;
        public int  k { get; set; }
        public Mehsul(double[] a, int k)
        {
            this.a = a;
            this.k = k;
        }
    }

    class Firma
    {
        Filial[] filiallar; List<double> mehsullar = new List<double>(); List<double> y_m_arr = new List<double>();
        List<double> yeni_mehsullar = new List<double>();

        public Firma(params Filial[] filiallar)
        {
            filials(filiallar);
        }
        public void filials(params Filial[] filiallar)
        {
            this.filiallar = filiallar; double[] y = new double[filiallar[0].a.Length];

            for (int i = 0; i < filiallar.Length; i++)
            {
                for (int j = 0; j < filiallar[i].a.Length; j++)
                {
                    mehsullar.Add(filiallar[i].a[j]);

                }
            }
           
            int k=0;

           
            for (int i = 0; i < filiallar.Length; i++)
            {
                k = 0;
                for (int j = 0; j < mehsullar.Count; j++)
                {
                    if (j % filiallar.Length == i)
                    {
                        y[k] = mehsullar[j];
                        k++;  
                    }
                }

                foreach (var item in yeni_qiymet(y))
                {
                    y_m_arr.Add(item);
                }
            }


            for (int i = 0; i < filiallar.Length; i++)
            {
                for (int j = 0; j < mehsullar.Count; j++)
                {
                    if (j % filiallar[0].a.Length == i)
                    {
                        yeni_mehsullar.Add(y_m_arr[j]);
                    }
                   
                }
            }
            k = 1;
            for (int i = 0; i < yeni_mehsullar.Count; i++)
            {
                if (i % filiallar[0].a.Length == 0)
                {
                    Console.WriteLine("{0}-ci filial üçün gelecek defe verilmeli olan mal",k);
                    k++;
                }
                Console.WriteLine(yeni_mehsullar[i]);

            }

        }



        private double emsal(params double[] z)
        {
            int l = filiallar[0].k;

            double s = 0;
            for (int i = 0; i < z.Length; i++)
            {
                s = s + z[i];
            }

            return (l - s) / s;
        }

        private double[] yeni_qiymet(params double[] z)
        {
            double[] d = new double[z.Length];
            for (int i = 0; i < z.Length; i++)
            {

                d[i] = Math.Round(z[i] + z[i] * emsal(z));


            }

            return d;
        }


    }
   
    class Program
    {

        static void Main(string[] args)
        {
            //double[] a = { 2, 6, 20 };
            //double[] b = { 20, 8, 13 };
            //double[] c = { 5, 12, 16 };

            double[] a = { 2, 20, 5 };
            double[] b = { 6, 8, 12 };
            double[] c = { 20, 13, 16 };
            double[] d = { 10, 8, 20 };
            double[] e = { 12, 8, 2 };

            Mehsul m = new Mehsul(a, 80);
            Mehsul k = new Mehsul(b, 80);
            Mehsul j = new Mehsul(c, 80);
            Mehsul z = new Mehsul(d, 80);
            Mehsul t = new Mehsul(e, 80);


            Filial first = new Filial(m);
            
            Filial second = new Filial(k);
            Filial third = new Filial(j);
            Filial fourth = new Filial(z);
            Filial fifth = new Filial(t);

            Firma f = new Firma(first, second, third, fourth, fifth);
           
        }
    }
}