using System;


public static class Initiate
{
    public static void Init(Edge[] edges, Node[] nodes)
    {

        Random rnd = new Random();

        List<int> i_node = new List<int>();
        while (i_node.Count < 19)
        {
            int num = rnd.Next(0,nodes.Length);
            if (!i_node.Contains(num))
            {
                nodes[num].State = Const.INFECTED;
                i_node.Add(num);
            }
            
        }
        

        var ER_edge = new List<Tuple<int, int>>();
        do
        {
            ER_edge = ErdosRenyiGraphGenerator.Generate(50,0.06);
        } while (ER_edge.Count != 75);

        for (int i = 0; i < edges.Length; i++)
        {
            edges[i].Connected_Node[0] = nodes[ER_edge[i].Item1] ;
            edges[i].Connected_Node[1] = nodes[ER_edge[i].Item2] ;
        }





    }

}



