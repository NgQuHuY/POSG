using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class Defender
{
    public static bool Contain_R(Edge edge)
    {
        for (int i = 0; i < edge.Connected_Node.Count(); i++)
        {
            if (edge.Connected_Node[i].State == Const.RESISTANT)
            {
                return true;
            }
        }
        return false;
    }

    public static void RDS(Edge[] edges, int iHoneypot) 
    {
        Random rnd = new Random();
        List<int> i_node = new List<int>();

        while (i_node.Count <= iHoneypot)
        {
            int num = rnd.Next(0, edges.Length);
            if (!(i_node.Contains(num) || edges[num].is_Honeypot == true))
            {
                edges[num].is_Honeypot = true;
                i_node.Add(num);
            }

        }

    }
    public static void SDS(Edge[] edges, Node[] nodes, int h, int k, ref List<Const.Trapped_info> trappeds ) 
    {
        
        if (trappeds.Count == 0)
        {
            RDS(edges, h);
           // Console.WriteLine("RDS run \n");
            return;
        }
        else
        {
            //Console.WriteLine("SDS run \n");
            Random rng = new Random();
            int num = 0;
            // chon bat ki tu cac thiet bi trap khi trap > 1
            if (trappeds.Count > 1)
            {
                num = rng.Next(0, trappeds.Count);
            }
            

            int d = 0;

            List<int> arr_id_edge = new List<int>();

            for (int i = 0; i < edges.Length; i++)
            {
                if (
                    edges[i].Connected_Node.Contains(edges[trappeds[num].i_Edge].Connected_Node[trappeds[num].i_Node])
                    &&
                    i != trappeds[num].i_Edge
                    &&
                    !Contain_R(edges[i])
                   )
                { 
                    arr_id_edge.Add(i);
                }
            }

            d = arr_id_edge.Count; // so edge co the ket noi
           // Console.WriteLine("d : " + d + "\n");

            // truong hop neu edge cua node(d) < he so k, lay so honeypot theo d, h - d con lai random
            if ( d < k )
            {
                
                // placing d honeypot
                for (int i = 0; i < d; i++)
                {
                    edges[arr_id_edge[i]].is_Honeypot = true;
                }

                // placing h - d honeypot
                RDS(edges, h - d);
            }
            // truong hop neu d >= k ( node du edge so voi k ) , random k honeypot edge bat ki tu d edge node, h - k random
            else
            {
                // placing k honeypot
                for (int i = 0; i < k; i++)
                {
                    int id = rng.Next(0, arr_id_edge.Count);
                    edges[arr_id_edge[id]].is_Honeypot = true;
                }

                // placing h - k honeypot
                RDS(edges, h - k);
            }

            trappeds.RemoveRange(0,trappeds.Count);
        }



    }
}

