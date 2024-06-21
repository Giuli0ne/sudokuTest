using System.ComponentModel.Design;
using System.Reflection;

public class Sudoku
{
    public static int[] GetLine(int[,] m, int line)
    {
        var res = new int[9];
        for (int i = 0; i < 9; i++)
        {
            res[i] = m[line, i];
        }
        return res;
    }

    public static int[] GetColumn(int[,] m, int col)
    {
        var res = new int[9];
        for (int i = 0; i < 9; i++)
        {
            res[i] = m[i, col];
        }
        return res;
    }

    public static int[] GetSquare(int[,] m, int sq)
    {
        var res = new int[9];
        int coordLine = sq / 3;
        int coordCol = sq % 3;
        int count = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (i / 3 == coordLine && j / 3 == coordCol)
                {
                    res[count] = m[i, j];
                    count++;
                }
            }
        }
        return res;
    }

    public static bool Check(int[] v)
    {
        Array.Sort(v);
        for (int i = 0; i < 8; i++)
        {
            if (v[i] != 0)
            {
                if (v[i] == v[i + 1])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool CheckAll(int[,] m)
    {
        for (int i = 0; i < 9; i++)
        {
            if (!Check(GetLine(m, i)))
            {
                return false;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if (!Check(GetColumn(m, i)))
            {
                return false;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if (!Check(GetSquare(m, i)))
            {
                return false;
            }
        }
        return true;
    }

    public static int Multiply(int[] v1, int[] v2)
    {
        int res = 0;
        for (int i = 0; i < 9; i++)
        {
            res += v1[i] * v2[i];
        }
        return res;
    }

    public static int[] Multiply(int[,] m, int[] v)
    {
        int[] res = new int[9];
        for (int i = 0; i < 9; i++)
        {
            res[i] = Multiply(GetLine(m, i), v);
        }
        return res;
    }




    public static int[,] Multiply(int[,] m1, int[,] m2)
    {
        int[,] res = new int[9, 9];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                res[i, j] = Multiply(GetLine(m1, i), GetColumn(m2, j));
            }
        }
        return res;
    }

}