using ProjetoGrafos.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EP
{
    public class Comparador : IComparer<Node>
    {
        int[] target, aux;
        public Comparador(int[] Target)
        {
            target = Target;
        }

        public int Compare(Node x, Node y)
        {
            int v1, v2, i;
            v1 = x.Nivel;
            v2 = y.Nivel;
            aux = (int[])x.Info;
            i = 0;
            foreach (int num in aux)
            {
                if (num != target[i])
                    v1++;
                i++;
            }
            aux = (int[])y.Info;
            i = 0;
            foreach (int num in aux)
            {
                if (num != target[i])
                    v2++;
                i++;
            }

            return v1 - v2;
        }
    }
}
