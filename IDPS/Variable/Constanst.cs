using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Const
{
    public const char SUSCEPTIBLE = 's';
    public const char INFECTED = 'i';
    public const char RESISTANT = 'r';

    public const string BROADCAST = "bro";
    public const string UNICAST = "uni";

    public const string RDS = "rds";
    public const string SDS = "sds";

    public const int INT_EDGE_LOW_NETWORK = 75;
    public const int INT_EDGE_HIGH_NETWORK = 384;

    public const int INT_HONEY_LOW = 8;
    public const int INT_HONEY_HIGH = 20;

    public struct Trapped_info 
    { 
        public int i_Edge; public int i_Node; 
        
        public Trapped_info(int i_Edge, int i_Node)
        {
            this.i_Edge = i_Edge;
            this.i_Node = i_Node;
        }
    }








}
