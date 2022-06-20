// Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, так чтобы в одной группе все числа были взаимно просты (все числа в группе друг на друга не делятся)? Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰.

// Например, для N = 50, M получается 6
// Группа 1: 1
// Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
// Группа 5: 7 16 24 36 40
// Группа 6: 5 32 48


int[] FillArray(int length)
{
    int[] result = new int[length];
    for (int i = 0; i < length; i++)
    {
        result[i] = i + 1;
    }
    return result;
}

int NOD(int a, int b)
{
    int mod;
    int Nod = 0;
    if (a < b)
    {
        int temp = b;
        b = a;
        a = temp;
    }
    if (a % b == 0)
    {
        Nod = b;
        return Nod;
    }
    else
        mod = a % b;
    return NOD(b, mod);
}

void SimpleNumber(int[] array)
{
    int group = 1;
    for (int j = 0; j < array.Length; j++)
    {
        string result = string.Empty;
        if (array[j] != 0)
        {
            result += $"{array[j]} ";
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    int nod = NOD(array[j], array[i]);
                    if (nod == 1)
                    {
                        int candidate = array[i];
                        int Repeat = 0;
                        for (int count = 0; count < result.Length; count++)
                        {
                            if (NOD(result[count], candidate) == 1)
                            {
                                Repeat++;
                            }
                        }
                        if (Repeat == result.Length)
                        {
                            result += $"{candidate} ";
                            array[i] = 0;
                            
                        }
                    }
                }
            }
            array[j] = 0;
            if (result.Length > 1)
            {
                Console.WriteLine($"Группа {group}: {result}");
                group++;
            }
        }


    }
}

int N = 10;
int[] array = FillArray(N);
var str = string.Join(" ", array);
Console.WriteLine("Массив");
Console.WriteLine(str);
Console.WriteLine();
SimpleNumber(array);

