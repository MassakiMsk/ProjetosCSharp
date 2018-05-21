using ProjetoGrafos.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EP
{
    class PrioQueue
    {
        Dictionary<int, Queue<Node>> fila = new Dictionary<int, Queue<Node>>();
        Dictionary<int, Node> dicionario = new Dictionary<int, Node>();
        int key;

        public void inserir(Node n)
        {
            n.FuncHeuristic();
            if(!dicionario.ContainsKey(n.Info.GetHashCode()))
            {
                dicionario.Add(n.Info.GetHashCode(), n);
                if(!fila.ContainsKey(n.HeuristicValue))
                    fila.Add(n.HeuristicValue, new Queue<Node>());
                fila[n.HeuristicValue].Enqueue(n);
            }
        }

        public Node getFirst()
        {
            key = fila.Keys.Min();
            Node n = fila[key].Dequeue();
            if (fila[key].Count == 0)
                fila.Remove(key);
            return n;
        }

        public int Size()
        {
            return fila.Count;
        }
    }
}
