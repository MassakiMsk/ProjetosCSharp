using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoGrafos.DataStructure
{
    class NodeComparer : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            if (Convert.ToDouble(y.Info) < Convert.ToDouble(x.Info))
                return 1;
            if (Convert.ToDouble(y.Info) == Convert.ToDouble(x.Info))
                return 0;
            return -1;
        }
    }
}
