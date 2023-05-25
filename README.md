# Demo report for NT204
This is a demo report for NT204. The program returns the data results of the Partially Observable Stochastic Game (POSG) model for detecting botnets on the Erdos-Renyi random graph network model with 19 initially infected devices.

## File Structure
The program file structure is as follows:

- /Action

  - Attacker.cs: contains the function definitions for two types of attacks, Broadcast and Unicast, and supporting functions.
  - Defender.cs: contains the function definitions for two proposed strategies, RDS and k-SDS, in the paper and supporting functions.

- /State
  - Initiate.cs: contains the Init class, which initializes parameters for 19 infected nodes and randomly connects nodes and edges based on the Erdos-Renyi model.
  - Setup.cs: creates the first state of the network nodes in that time slot: the Attacker finds edges to propagate and the Defender chooses edges to place honeypots.
  - Stage1.cs: returns the result of Setup: if two nodes of an edge have both honeypot (def) and propagate (att) attributes, they will transition to state S. Otherwise, if there is only propagate, the node in state S will transition to state I.
  - State2.cs: ends State 1, infected nodes have a 10% chance of transitioning to state S, and nodes in state S have a 20% chance of transitioning to state R.
 
- /Variable

  - Constants.cs: contains the definitions of const variables (for easy coding).
  - Edge_Node.cs: defines the Edge and Node classes and their constructors.
  - ErdosRenyi.cs: defines the ErdosRenyiGenerator class to generate the ErdosRenyi model based on the number of nodes (n) and the edge probability of each node (p).
  - Main.cs: the main program file, corresponding to each attack and defense strategy option to run the model 500 times and return two results: the average number of timeslots required for the botnet to end and the maximum number of nodes in state I.

## Program Interface
<p align="center"><img width="387" alt="Screenshot 2023-05-25 000748" src="https://github.com/NgQuHuY/POSG/assets/105098386/77bacf3c-b075-4c91-9223-0a0e7b30e318"></p>

## Demo Results
The program's output differs from the results presented in the paper, so it is unclear whether the source code has an algorithm error or the demo model is different from the author's model. In my opinion, the problem may come from these two :
- _Initial infected devices set I0_ : which I can't clearly understand what it define for : The number of S devices at each time-slot to contaminate, or the number of I devices initiate at the first time slot. So I fix it with 19 Infected devices starting.
- _The way stage 2 working_ : At the section III. Model Description, it's state that each device I and S have respetively 10% and 20% probability to change its state. But in the end of section IV. Solution Description, the paper defines probability mentioned above as 10% of devices I and 20% of devices S will change its state. Which is true ??!! :> . I tried both options at the same time but the model became endless loop when running RDS. So I still chosed the first option

These are results collected from the above model when run it but with 100 time  
<p align="center"><img width="356" alt="Screenshot 2023-05-25 133558" src="https://github.com/NgQuHuY/POSG/assets/105098386/1febc178-52c8-4470-8964-ef968819d143"></p>

<p align="center"><img width="374" alt="Screenshot 2023-05-25 134406" src="https://github.com/NgQuHuY/POSG/assets/105098386/5e6e08ff-235c-45e1-b3c1-5d7afb974b85"></p>

<p align="center"><img width="408" alt="Screenshot 2023-05-25 140312" src="https://github.com/NgQuHuY/POSG/assets/105098386/6bf9ec33-2c46-40a7-b202-71364f2df42b"></p>

<p align="center"> <img width="409" alt="Screenshot 2023-05-25 140349" src="https://github.com/NgQuHuY/POSG/assets/105098386/81a95168-a44c-4daf-8ca9-a2182cac2697"></p>


