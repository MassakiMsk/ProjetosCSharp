using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoGrafos.DataStructure
{
    class Fila : Queue<Node>
    {
        public void Enfilerar(Node no)
        {
            List<Node> list = this.ToList();
            list.Add(no);
            list.Sort();
            this.Clear();
            foreach (Node n in list)
                this.Enqueue(n);
        }

    }
}
