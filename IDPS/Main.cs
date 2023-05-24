using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Const;

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
        static void count_edge(Edge[] edges)
        {
            int h = 0;
            int p = 0;
            foreach (var node in edges)
            {
                if (node.is_Probagate) { p++; }
                if (node.is_Honeypot) { h++; }
            }

            Console.WriteLine("Honeypot = " + h  + "\n");
            Console.WriteLine("Probagate = " + p + "\n");
            Console.WriteLine("\n");
        }
        static int count_I(Node[] nodes)
        {

            int I = 0;

            foreach (var node in nodes)
            {
                if (node.State == Const.INFECTED)
                    I++;
            }

            return I;

        }
        static void Main()
        {
            List<int> time_ex = new List<int>();
            int max_I = 0;
            int Topology, attackChoice, defenseChoice, k = 0;
            string Att_type = "", Def_type = "";
            int h, edge;

            Console.WriteLine("Welcome to the program!");

            // Choose Network Topology
            Console.WriteLine("\nSelect a network topology:");
            Console.WriteLine("1. Low Connected Network Topology");
            Console.WriteLine("2. High Connected Network Topology");
            Console.Write("Enter your choice: ");
            Topology = int.Parse(Console.ReadLine());
            if (Topology == 1)
            {
                h = 8;
                edge = 75;
            }
            else
            {
                h = 20;
                edge = 384;
            }


            // Choose attack strategy
            Console.WriteLine("\nSelect an attack strategy:");
            Console.WriteLine("1. Unicast");
            Console.WriteLine("2. Broadcast");
            Console.Write("Enter your choice: ");
            attackChoice = int.Parse(Console.ReadLine());
            switch (attackChoice)
            {
                case 1:
                    Console.WriteLine("You selected Unicast Attack");
                    Att_type = Const.UNICAST;
                    break;
                case 2:
                    Console.WriteLine("You selected Broadcast Attack");
                    Att_type = Const.BROADCAST;
                    break;
                default:
                    Console.WriteLine("Invalid choice for attack strategy. Please select again.");
                    Environment.Exit(0);
                    break;

            }

            // Choose defense strategy
            Console.WriteLine("\nSelect a defense strategy:");
            Console.WriteLine("1. RDS");
            Console.WriteLine("2. k-SDS");
            Console.Write("Enter your choice: ");
            defenseChoice = int.Parse(Console.ReadLine());
            //If k-SDS, Choose k
            if (defenseChoice == 2)
            {
                Console.Write("Set k for k-SDS: ");
                k = int.Parse(Console.ReadLine());
            }
            switch (defenseChoice)
            {
                case 1:
                    Console.WriteLine("You selected RDS");
                    Def_type = Const.RDS;
                    break;
                case 2:
                    Console.WriteLine("You selected k-SDS");
                    Def_type = Const.SDS;
                    break;
                default:
                    Console.WriteLine("Invalid choice for defense strategy. Please select again.");
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine("\nStarting program...");


            for (int simulation = 0; simulation < 500; simulation++)
            {
                List<Trapped_info> trapped_Infos = new List<Trapped_info> { new Trapped_info() };


            Node[] arr_node = new Node[50];
            for (int i = 0; i < arr_node.Length; i++) { arr_node[i] = new Node(); }

                Edge[] arr_edge = new Edge[edge];
                for (int i = 0; i < arr_edge.Length; i++) { arr_edge[i] = new Edge(); }

                Initiate.Init(arr_edge, arr_node, Topology);


                int count = 1;
                

                while (count_I(arr_node) != 0)
                {
                   // Console.WriteLine("New \n");
                   // count_edge(arr_edge);

                    //Console.WriteLine("trap : " + trapped_Infos.Count + " \n");
                    Setup.Run(arr_edge, arr_node, Att_type, Def_type, ref trapped_Infos, h, k);
                    //Console.WriteLine("Set up \n");
                    //count_node(arr_node);
                    //count_edge(arr_edge);

                    State1.Run(arr_edge, ref trapped_Infos);
                    //Console.WriteLine("State 1 \n");
                   // count_node(arr_node);
                    //count_edge(arr_edge);

            Stage2.Run(arr_node);
                    //Console.WriteLine("State 2 \n");
                    //count_node(arr_node);
                    //count_edge(arr_edge);

                    //Console.ReadLine();

                    count++;
                    if (count_I(arr_node) > max_I) { max_I = count_I(arr_node); }
                }


                time_ex.Add(count);

            }

                long sum = 0;
            foreach (int item in time_ex )
            {
                sum += (long)item;
            }

            sum = sum / time_ex.Count;

            Console.WriteLine("Result \n");
            Console.WriteLine("avg time for extinction botnet : " + sum);
            Console.WriteLine("max Infected Devices : " + max_I);
        }

    }
}
