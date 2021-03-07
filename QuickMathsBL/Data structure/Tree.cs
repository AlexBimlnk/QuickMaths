using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class Tree //where T : IComparable
    {

        public Node Head { get; set; }

        public Tree(Node _head)
        {
            Head = _head;
        }
    }
}
