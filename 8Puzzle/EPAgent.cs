using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using ProjetoGrafos.DataStructure;
using System.Linq;

namespace EP
{
    /// <summary>
    /// EPAgent - searchs solution for the eight puzzle problem
    /// </summary>
    public class EightPuzzle : Graph
    {
        private int[] initState;
        private int[] target;

        /// <summary>
        /// Creating the agent and setting the initialstate plus target
        /// </summary>
        /// <param name="InitialState"></param>
        public EightPuzzle(int[] InitialState, int[] Target)
        {
            initState = InitialState;
            target = Target;
        }

        /// <summary>
        /// Accessor for the solution
        /// </summary>
        public int[] GetSolution()
        {
            int i;
            for (i = 0; i < initState.Length; i++)
                if (initState[i] != target[i])
                    break;
            if (i == initState.Length)
                return new int[0];
            Node n = new Node();
            n.Info = initState;
            n.Nivel = 0;
            return FindSolution(n);
        }

        /// <summary>
        /// Função principal de busca
        /// </summary>
        /// <returns></returns>
        private int[] FindSolution(Node n)
        {
            PrioQueue fila = new PrioQueue();
            List<Node> lista = new List<Node>();
            Node aux;

            fila.inserir(n);

            while (fila.Size() > 0)
            {
                aux = fila.getFirst();
                if (Enumerable.SequenceEqual(target, (int[])aux.Info))
                {
                    List<Int32> intList = new List<int>();
                    while (aux.Parent != null)
                    {
                        intList.Add(Convert.ToInt32(aux.Name));
                        aux = aux.Parent;
                    }
                    intList.Reverse();
                    return intList.ToArray();
                }
                lista = GetSucessors(aux);
                foreach (Node no in lista)
                {
                    fila.inserir(no);
                }
            }
            return null;
        }

        private int[] FindSolution(Node n, int abc)
        {
            Queue<Node> fila = new Queue<Node>();
            List<Node> lista = new List<Node>();
            HashSet<Node> set = new HashSet<Node>();
            Node aux;
            Boolean flag;
            int[] targetAux, state, targetAuxAux;
            int lar, larAux;

            targetAux = new int[target.Length];
            target.CopyTo(targetAux, 0);
            fila.Enqueue(n);
            set.Add(n);

            while (fila.Count > 0)
            {
                flag = false;
                aux = fila.Dequeue();
                lista = GetSucessors(aux);
                targetAuxAux = new int[targetAux.Length];
                targetAux.CopyTo(targetAuxAux, 0);
                foreach (Node no in lista)
                {
                    lar = (int)Math.Sqrt(((int[])no.Info).Length);
                    state = (int[])no.Info;

                    if (Enumerable.SequenceEqual(targetAuxAux, state))
                    {
                        List<Int32> intList = new List<int>();
                        Node nAux = no;
                        while (nAux.Parent != null)
                        {
                            intList.Add(Convert.ToInt32(nAux.Name));
                            nAux = nAux.Parent;
                        }
                        intList.Reverse();
                        return intList.ToArray();
                    }
                    int i;
                    for (i = lar - 1; i < lar * (lar - 1); i += lar)
                        if (state[i] != targetAuxAux[i])
                            break;
                    if (i == lar * lar - 1)
                    {
                        for (i = lar * (lar - 1); i < lar * lar; i++)
                            if (state[i] != targetAuxAux[i])
                                break;
                        if (i == lar * lar)
                        {
                            int[] stateAux = new int[(lar - 1) * (lar - 1)];
                            targetAux = new int[(lar - 1) * (lar - 1)];
                            int j, k = 0;
                            for (i = 0; i < lar - 1; i++)
                                for (j = 0; j < lar - 1; j++)
                                {
                                    targetAux[k] = targetAuxAux[i * lar + j];
                                    stateAux[k] = state[i * lar + j];
                                    k++;
                                }
                            no.Info = stateAux;
                            if (!flag)
                            {
                                fila = new Queue<Node>();
                                set = new HashSet<Node>();
                                fila.Enqueue(no);
                                set.Add(no);
                                flag = true;
                            }
                            else if (!set.Contains(no))
                            {
                                fila.Enqueue(no);
                                set.Add(no);
                            }
                        }
                    }

                    if (!set.Contains(no) && !flag)
                    {
                        fila.Enqueue(no);
                        set.Add(no);
                    }
                }

            }
            return null;
        }

        private List<Node> GetSucessors(Node n)
        {
            List<Node> lista = new List<Node>();
            int[] atual = (int[])n.Info;
            int[] aux;
            int i, tam;
            tam = (int)Math.Sqrt(atual.Length);

            for (i = 0; i < atual.Length; i++)
                if (atual[i] == 0)
                    break;
        
            if(i - tam >= 0)//Cima
            {
                if (Convert.ToInt32(n.Name) != atual[i - tam])
                {
                    Node no = new Node();
                    no.Name = Convert.ToString(atual[i - tam]);
                    no.Parent = n;
                    no.Nivel = n.Nivel + 1;
                    aux = new int[atual.Length];
                    atual.CopyTo(aux, 0);
                    aux[i] = aux[i - tam];
                    aux[i - tam] = 0;
                    no.Info = aux;
                    lista.Add(no);
                }
            }
            if(i + tam < atual.Length )//Baixo
            {
                if (Convert.ToInt32(n.Name) != atual[i + tam])
                {
                    Node no = new Node();
                    no.Name = Convert.ToString(atual[i + tam]);
                    no.Parent = n;
                    no.Nivel = n.Nivel + 1;
                    aux = new int[atual.Length];
                    atual.CopyTo(aux, 0);
                    aux[i] = aux[i + tam];
                    aux[i + tam] = 0;
                    no.Info = aux;
                    lista.Add(no);
                }
            }
            if(i % tam > 0)//Esquerda
            {
                if (Convert.ToInt32(n.Name) != atual[i - 1])
                {
                    Node no = new Node();
                    no.Name = Convert.ToString(atual[i - 1]);
                    no.Parent = n;
                    no.Nivel = n.Nivel + 1;
                    aux = new int[atual.Length];
                    atual.CopyTo(aux, 0);
                    aux[i] = aux[i - 1];
                    aux[i - 1] = 0;
                    no.Info = aux;
                    lista.Add(no);
                }
            }
            if(i % tam < tam - 1) // Direita
            {
                if (Convert.ToInt32(n.Name) != atual[i + 1])
                {
                    Node no = new Node();
                    no.Name = Convert.ToString(atual[i + 1]);
                    no.Parent = n;
                    no.Nivel = n.Nivel + 1;
                    aux = new int[atual.Length];
                    atual.CopyTo(aux, 0);
                    aux[i] = aux[i + 1];
                    aux[i + 1] = 0;
                    no.Info = aux;
                    lista.Add(no);
                }
            }

            return lista;
        }
        
        private int[] BuildAnswer(Node n)
        {
            throw new NotImplementedException();
        }

        private bool TargetFound(Node n)
        {
            throw new NotImplementedException();
        }
    }
}

