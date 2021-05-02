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

        /// <summary>
        /// Создает список из "+"-узлов во всем дереве.
        /// </summary>
        /// <returns> Список "+"-узлов. </returns>
        public List<Node> CreatePlusWayList()
        {
            List<Node> nodes = new List<Node>();

            Node temp = Head;

            while(temp != null)
            {
                nodes.Add(temp);
                temp = temp.PlusWay;
            }

            return nodes;
        }

        /// <summary>
        /// Создает список из "*"-узлов, связанных с данным узлом.
        /// </summary>
        /// <param name="node"> Узел, для которого создается список. </param>
        /// <returns> Список из "*"-узлов. </returns>
        public List<Node> CreateMultyWayList(Node node)
        {
            List<Node> nodes = new List<Node>();

            Node temp = node;

            while(temp != null)
            {
                nodes.Add(temp);
                temp = temp.MultyWay;
            }

            return nodes;
        }
    }
}
