using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Extensions
{
    public static bool find<T>(this T[] array, T target)
    {
        return array.Contains(target);
    }


}

public class Node
{
    public char State { get; set; } // Stage of a Device (I;R;S)


    public Node()
    {
        State = Const.SUSCEPTIBLE;
    }


}

public class Edge
{
    public bool is_Honeypot { get; set; }
    public bool is_Probagate { get; set; }
    public Node[] Connected_Node { get; set; }

    public Edge()
    {
        is_Honeypot = false;
        is_Probagate = false;
        Connected_Node = new Node[2];
        Connected_Node[0] = new Node();
        Connected_Node[1] = new Node();
    }
}
    

