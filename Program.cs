class Laba4
{
    public static void solution(decimal[] x, decimal[] y, decimal xx)
    {
        for (int j = 0; j < 3; j++)// поиск трех ближайщих к xx точек
            if (Math.Abs(x[j] - xx) > Math.Abs(x[j + 1] - xx))
            {
                (x[j], x[j + 1]) = (x[j + 1], x[j]);
                (y[j], y[j + 1]) = (y[j + 1], y[j]);
            }
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(x[i]);
            Console.WriteLine(y[i]);
            Console.WriteLine("---");
        }

        if (x[0] != x[1] && x[0] != x[2] && x[1] != x[2] && x[0] != x[3] && x[1] != x[3] && x[2] != x[3])
        {
            Console.WriteLine("Status: 0");
            decimal yy;
            decimal[] A = new decimal[4];
            for (int i = 0; i < 3; i++) // вычисляем А, "исключая i-й сомножитель"
            {
                A[i] = 1;
                for (int j = 0; j < 3; j++)
                    if (i != j)
                        A[i] *= (x[i] - x[j]);
                A[i] = 1 / A[i];
            }
            decimal num = 0, den = 0; // числитель и знаменатель многочлена
            for (int i = 0; i < 3; i++) // строим многочлен второй степени и считаем yy
            {
                num += A[i] / (xx - x[i]) * y[i];
                den += A[i] / (xx - x[i]);
            }
            yy = num / den;
            Console.WriteLine("YY: " + yy);

            decimal yy3, eps;
            for (int i = 0; i < 4; i++) // вычисляем А, "исключая i-й сомножитель"
            {
                A[i] = 1;
                for (int j = 0; j < 4; j++)
                    if (i != j)
                        A[i] *= (x[i] - x[j]);
                A[i] = 1 / A[i];
            }
            num = 0; den = 0; // числитель и знаменатель многочлена
            for (int i = 0; i < 4; i++) // строим многочлен третьей степени и считаем yy3
            {
                num += A[i] / (xx - x[i]) * y[i];
                den += A[i] / (xx - x[i]);
            }
            yy3 = num / den;
            eps = Math.Abs(yy - yy3); // оценка точности
            Console.WriteLine("EPS: " + eps);

        }
        else
        {
            Console.WriteLine("Status: 1");
        }
    }
    public static void Main(string[] args)
    {
        string str;
        string[] str1;
        str = Console.ReadLine();
        str1 = str.Split(' ');
        decimal[] x = new decimal[4];
        for (int i = 0; i < 4; i++)
            x[i] = Convert.ToDecimal(str1[i]);

        str = Console.ReadLine();
        str1 = str.Split(' ');
        decimal[] y = new decimal[4];
        for (int i = 0; i < 4; i++)
            y[i] = Convert.ToDecimal(str1[i]);

        decimal xx = Convert.ToDecimal(Console.ReadLine());

        solution(x, y, xx);
    }
}
