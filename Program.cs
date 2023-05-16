//библиотеки
using System;
using System.Numerics;
using static System.Console;

//код
namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            /* p и q простые числа. Они не равны друг другу. Желательно использовать большие числа*/
            int p; 
            int q;

            do
            { 
                Write("Введите простое число p: ");
                p = Int32.Parse(ReadLine()); 
                Write("Введите простое число q: "); 
                q = Int32.Parse(ReadLine());
                if (p == q)
                {
                    WriteLine("Числа должны быть разными!");
                }
                
                if ( GCD(p,q) != 1)
                {
                    WriteLine("Числа не взаимно простые!");
                }  
            }while(p == q || GCD(p,q) != 1 );

            int n = p * q; //находим n
            WriteLine($"Число n = {n}");

            int EilerFun = (p-1)*(q-1); //находим функцию Эйлера (тотиент)
           // WriteLine($"Функция Эйлера = {EilerFun}");

            int d;
            do
            {
                Write("Введите число d:");
                d = Int32.Parse(ReadLine());

            } while (GCD(d,EilerFun) != 1);
            int e;
            int k = 1;
            do
            {
                e = (1 + k*(EilerFun))/d;
                k++;
            } while (Double.IsNaN(e));
            WriteLine($"Число е: {e}");
            /*
                Шифрование текста
                                    */
            Write("Введите случайное число, каторое хотите заифровать: ");
            int m = Int32.Parse(ReadLine()); //какой-то текст
            int c = 1; //шифрованный текст

            //шифрование: c = m^e(mod n)
            for (int i = 0; i < e; i++)
            {
                c *= m;
            }
            c = c%n;
            WriteLine("Текст зашифрован");
            WriteLine($"Результат: {c}");

            //дешифровка: m = c^d (mod n)
            m = 1;
            for (int i = 0; i < d; i++)
            {
                m = m*c;
            }
            m = m%n;
            WriteLine("Текст дешифрован");
            WriteLine($"Результат: {m}");
        }
        private static int GCD(int a, int b)// НОД 2-х чисел
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        //функция Эйлера
        private static int Eyler(int n) 
        {
            long res = n, en = Convert.ToUInt32(Math.Sqrt(n) + 1);
            for (int i = 2; i <= en; i++)
                if ((n % i) == 0)
                {
                    while ((n % i) == 0)
                        n /= i;
                    res -= (res / i);
                }
            if (n > 1) res -= (res / n);
            return (int)res;
        }

    }
}
