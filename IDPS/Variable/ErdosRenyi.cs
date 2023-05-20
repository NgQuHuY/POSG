using System;
using System.Collections.Generic;

public class ErdosRenyiGraphGenerator
{
    public static Random random = new Random();

    public static List<Tuple<int, int>> Generate(int n, double p)
    {
        var edges = new List<Tuple<int, int>>();

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (random.NextDouble() < p)
                {
                    edges.Add(new Tuple<int, int>(i, j));
                }
            }
        }

        return edges;
    }
}
