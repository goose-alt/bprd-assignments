static int[] Merge(int[] xs, int[] ys)
{
    int xsPointer = 0, ysPointer = 0;
    int[] aux = new int[xs.Length + ys.Length];

    for(int i = 0; i < aux.Length; i++)
    {
        if (xsPointer == xs.Length)
        {
            aux[i] = ys[ysPointer];
            ysPointer++;
            continue;
        }
        else if (ysPointer == ys.Length)
        {
            aux[i] = xs[xsPointer];
            xsPointer++;
            continue;
        }

        int x = xs[xsPointer];
        int y = ys[ysPointer];

        if(x <= y)
        {
            aux[i] = x;
            xsPointer++;
        }
        else 
        {
            aux[i] = y;
            ysPointer++;
        }
    }

    return aux;
}

var res = Merge(new int[]{3,5,12}, new int[]{2,3,4,7});

foreach (int item in res)
    System.Console.Write($"{item} ");
System.Console.WriteLine();