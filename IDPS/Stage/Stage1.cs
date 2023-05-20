using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class State1
{
    public static void Run (Edge[] edges)
    {
        for (int i = 0; i < edges.Length; i++)
        {
            if (edges[i].is_Probagate && edges[i].is_Honeypot)
            {
                edges[i].Connected_Node[0].State = edges[i].Connected_Node[1].State = Const.SUSCEPTIBLE;

                edges[i].is_Honeypot = false;
                edges[i].is_Probagate = false;
            }
            
            if (edges[i].is_Probagate)
            {
                if (edges[i].Connected_Node[0].State == Const.SUSCEPTIBLE)
                    edges[i].Connected_Node[0].State = Const.INFECTED;
                else
                    edges[i].Connected_Node[1].State = Const.INFECTED;

                edges[i].is_Probagate = false;
            }
        }
    }
}

