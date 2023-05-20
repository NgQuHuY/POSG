using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDPS
{
   
    public class Program
    {
        
        static void count_node(Node[] nodes)
        {
            int S = 0;
            int I = 0;
            int R = 0;
            foreach (var node in nodes)
            {
                if (node.State == Const.INFECTED )
                    I++;
                if (node.State == Const.SUSCEPTIBLE)
                    S++;
                if (node.State == Const.RESISTANT)
                    R++;
            }

            Console.WriteLine("S = " +  S + "\n");
            Console.WriteLine("I = " + I + "\n");
            Console.WriteLine("R = " + R + "\n");
            Console.WriteLine("\n");
        }
        static void Main()
        {
            Node[] arr_node = new Node[50];
            for (int i = 0; i < arr_node.Length; i++) { arr_node[i] = new Node(); }

            Edge[] arr_edge = new Edge[75];
            for (int i = 0;i < arr_edge.Length;i++) { arr_edge[i] = new Edge(); }

            Initiate.Init(arr_edge, arr_node);

            Console.WriteLine("Intit : \n");
            count_node(arr_node);

            Setup.Run(arr_edge,arr_node,Const.UNICAST,Const.SDS);

            State1.Run(arr_edge);
            Console.WriteLine("Stage1 : \n");
            count_node(arr_node);

            Stage2.Run(arr_node);
            Console.WriteLine("Stage2 : \n");
            count_node(arr_node);


            Console.WriteLine("done");
        }

    }
}
