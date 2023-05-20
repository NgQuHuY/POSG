using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Setup
{
    public static void Run(Edge[] edges, Node[] nodes, string Att_type, string Def_type, int k=1) 
    {
        if (Att_type == Const.BROADCAST)
        {
            Attacker.Att_Broadcast(nodes,edges);
        }
        else
        {
            Attacker.Att_Unicast(nodes,edges);
        }

        if (Def_type == Const.RDS) 
        {
            Defender.RDS();
        }
        else
        {
            Defender.SDS(k);
        }
    }
}

