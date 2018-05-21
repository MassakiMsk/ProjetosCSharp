using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrafos.DataStructure
{
    /// <summary>
    /// Classe que representa um grafo.
    /// </summary>

    public class Graph
    {
        public List<Node> nodes = new List<Node>();

        public List<Node> ShortestPath(string begin, string end)
        {
            ZeraNodes();
            int cont = 1;
            Graph solucao = new Graph();
            List<Node> list = new List<Node>();
            solucao.AddNode(begin, "0");
            BuscaNode(begin).Visited = true;
            list.Add(BuscaNode(begin));
            while (solucao.BuscaNode(end) == null)
            {
                Edge ed = null;
                Node n1 = solucao.BuscaNode(begin);
                foreach (Node n in solucao.nodes)
                {
                    Node no = BuscaNode(n.Name);
                    foreach (Edge e in no.Edges)
                    {
                        if (ed == null && Convert.ToDouble(n1.Info) == 0 && e.To.Visited == false)
                        {
                            ed = e;
                            n1 = n;
                        }
                        if (ed != null)
                            if (Convert.ToDouble(n.Info) + e.Cost <= Convert.ToDouble(n1.Info) + ed.Cost && e.To.Visited == false)
                            {
                                ed = e;
                                n1 = n;
                            }
                    }
                }
                if (ed != null)
                {
                    ed.To.Visited = true;
                    solucao.AddNode(ed.To.Name, Convert.ToString(ed.Cost + Convert.ToDouble(n1.Info)));
                    list.Add(ed.To);
                    BuscaNode(ed.To.Name).Parent = BuscaNode(n1.Name);
                }

                cont++;
                if (cont > solucao.nodes.Count)
                    break;
            }
            return list;
        } 

        public List<Node> ShortestPath1(string begin, string end)
        {
            ZeraNodes();
            Fila fila = new Fila();
            List<Node> list = new List<Node>();

            fila.Enfilerar(new Node(begin, "0"));
            while(fila.Count > 0)
            {
                Node n = fila.Dequeue();
                Node no = BuscaNode(n.Name);
                if(!no.Visited)
                {
                    no.Visited = true;
                    list.Add(no);
                    foreach (Edge e in no.Edges)
                        if (!e.To.Visited)
                        {
                            e.To.Parent = no;
                            fila.Enfilerar(new Node(e.To.Name, Convert.ToString(Convert.ToDouble(n.Info) + e.Cost)));
                        }
                    if (n.Name.Equals(end))
                        break;
                }
            }
            return list;
        }
        

        public List<Node> ShortestPath2(string begin, string end)
        {
            ZeraNodes();
            SortedSet<Node> fila = new SortedSet<Node>(new NodeComparer());
            List<Node> list = new List<Node>();

            fila.Add(new Node(begin, "0"));
            while (fila.Count > 0)
            {
                Node n = fila.ElementAt(0);
                fila.Remove(n);
                Node no = BuscaNode(n.Name);
                if (!no.Visited)
                {
                    no.Visited = true;
                    list.Add(no);
                    foreach (Edge e in no.Edges)
                        if (!e.To.Visited)
                        {
                            e.To.Parent = no;
                            fila.Add(new Node(e.To.Name, Convert.ToString(Convert.ToDouble(n.Info) + e.Cost)));
                        }
                    if (n.Name.Equals(end))
                        break;
                }
            }
            return list;
        }

        public List<Node> BreadthFirstSearch(string begin)
        {
            ZeraNodes();
            Node player = BuscaNode(begin);
            Queue<Node> queue = new Queue<Node>();
            List<Node> list = new List<Node>();

            player.Visited = true;
            queue.Enqueue(player);

            while (queue.Count > 0)
            {
                Node no = queue.Dequeue();
                list.Add(no);
                foreach (Edge edge in no.Edges)
                {
                    if (edge.To.Visited == false)
                    {
                        edge.To.Parent = no;
                        edge.To.Visited = true;
                        queue.Enqueue(edge.To);
                    }
                }
            }

            return list;
        }

        public List<Node> DepthFirstSearch(string begin)
        {
            ZeraNodes();
            Node player = BuscaNode(begin);
            Stack<Node> stack = new Stack<Node>();
            List<Node> list = new List<Node>();

            player.Visited = true;
            stack.Push(player);

            while (stack.Count > 0)
            {
                Node no = stack.Pop();
                list.Add(no);
                foreach (Edge edge in no.Edges)
                {
                    if (edge.To.Visited == false)
                    {
                        edge.To.Parent = no;
                        edge.To.Visited = true;
                        stack.Push(edge.To);
                    }
                }
            }

            return list;
        }
        

        public List<Node> DepthFirstSearch1(string begin)
        {
            Node player = BuscaNode(begin);
            List<Node> list = new List<Node>();
            list.Add(player);
            player.Visited = true;
            //player.Edges.Reverse();
            foreach (Edge edge in player.Edges)
            //for (int i = player.Edges.Count - 1; i >= 0; i--)
            {
                //Edge edge = player.Edges.ElementAt(i);
                if (edge.To.Visited == false)
                {
                    edge.To.Parent = player;
                    edge.To.Visited = true;
                    list.AddRange(DepthFirstSearch1(edge.To.Name));
                }
            }


            return list;
        }
           
        public void AddNode(string name, string info)
        {
            nodes.Add(new Node(name, info));
        }

        public void AddEdge(string nameFrom, string nameTo, int cost)
        {
            Node nodeFrom, nodeTo;
            nodeFrom = BuscaNode(nameFrom);
            nodeTo = BuscaNode(nameTo);
            if (nodeFrom != null && nodeTo != null)
                nodeFrom.Edges.Add(new Edge(nodeFrom, nodeTo, cost));
        }

        public Node BuscaNode(string name)
        {
            foreach (Node node in nodes)
            {
                if (node.Name.Equals(name))
                    return node;
            }
            return null;
        }

        public void ZeraNodes()
        {
            foreach (Node n in nodes)
                n.Visited = false;
        }

    }
}
