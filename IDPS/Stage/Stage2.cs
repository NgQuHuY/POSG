using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Stage2
{
    public static void Run(Node[] nodes)
    {
        List<int> S = new List<int>();
        List<int> I = new List<int>();

        for(int i=0; i<nodes.Length; i++)
        {
            if (nodes[i].State == Const.SUSCEPTIBLE)
                S.Add(i);

            if (nodes[i].State == Const.INFECTED) 
                I.Add(i);

        }

        Random rng = new Random();
        
        if (S.Count > 0)
        {
            foreach(int i in S)
            {
                if (new Random().NextDouble() < 0.2)
                {
                    nodes[i].State = Const.RESISTANT;
                }
            }
        }

        if (I.Count > 0)
        { 
            foreach(int i in I)
            {
                if (new Random().NextDouble() < 0.1)
                {
                    nodes[i].State = Const.SUSCEPTIBLE;
                }
            }
                
        }


    }
}

