
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

