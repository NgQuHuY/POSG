using System;
using System.Linq;



public class Attacker
{

    public static bool Contain_S(Edge edge)
    {
        for (int i = 0; i < edge.Connected_Node.Count(); i++)
        {
            if (edge.Connected_Node[i].State == Const.SUSCEPTIBLE)
            {
                return true;
            }
        }
        return false;
    }

    public static void Att_Broadcast(Node[] nodes, Edge[] edges)
    {
        for (int i = 0; i < nodes.Count(); i++) // duyet het tat ca cac node
        {
            if (nodes[i].State == Const.INFECTED) // tim node I
            {
                for (int j = 0; j < edges.Count(); j++) // tim tat ca cac edge co lien ket voi node I va node S
                {
                    if (edges[j].Connected_Node.find(nodes[i]) && Contain_S(edges[j]))
                    {
                        edges[j].is_Probagate = true;
                    }
                }
            }
        }
    }

    public static void Att_Unicast(Node[] nodes, Edge[] edges)
    {
        for (int i = 0; i < nodes.Count(); i++) // duyet het tat ca cac node
        {
            if (nodes[i].State == Const.INFECTED) // tim node I
            {
                for (int j = 0; j < edges.Count(); j++)
                {
                    if (edges[j].Connected_Node.find(nodes[i]) && Contain_S(edges[j])) // tim 1 edge co lien ket voi node I va node S
                    {
                        edges[j].is_Probagate = true;
                        break;
                    }
                }
            }
        }
    }
}



