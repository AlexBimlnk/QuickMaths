using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class Tree //where T : IComparable
    {

        private Node head;

        public Tree(Node _head)
        {
            head = _head;
        }

        public Node Head
        {
            get { return head; }
        }
    }
}
