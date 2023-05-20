using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class State1
{
    public static void Run (Edge[] edges, ref List<Const.Trapped_info> trappeds)
    {
        for (int i = 0; i < edges.Length; i++)
        {
            if (edges[i].is_Probagate && edges[i].is_Honeypot)
            {
                Const.Trapped_info trap = new Const.Trapped_info();

                if (edges[i].Connected_Node[0].State == Const.INFECTED)
                    trap.i_Node = 0;
                else
                    trap.i_Node = 1;

                trap.i_Edge = i;

                trappeds.Add(trap);

                edges[i].Connected_Node[0].State = edges[i].Connected_Node[1].State = Const.SUSCEPTIBLE;

                //Console.WriteLine("Honey detect \n");


            }
            
            if (edges[i].is_Probagate)
            {
                if (edges[i].Connected_Node[0].State == Const.SUSCEPTIBLE)
                    edges[i].Connected_Node[0].State = Const.INFECTED;
                else
                    edges[i].Connected_Node[1].State = Const.INFECTED;


            }

        }

        foreach (var i in edges)
        {
            i.is_Honeypot = false;
            i.is_Probagate = false;
        }
    }
}

