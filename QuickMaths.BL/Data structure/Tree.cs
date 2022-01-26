using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.Functions;

namespace QuickMaths.BL.DataStructure
{
    public class Tree //where T : IComparable
    {
        public Node Head { get; private set; }

        public Tree()
        {
            Head = null;
        }

        public Tree(Node head)
        {
            Head = head;
        }

        public void AddNewMultiplier(IFunction newMult)
        {
            Node newNode = new Node(newMult);
            if (Head == null)
                Head = newNode;
            else
                Head.Add(newNode, Enums.NodeWayType.MultiplyWay);
        }

        public void AddNewSummand(IFunction newSumm)
        {
            Node newNode = new Node(newSumm);
            if (Head == null)
                Head= newNode;
            else
            {
                newNode.Add(Head, Enums.NodeWayType.PlusWay);
                Head = newNode;
            }
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
                temp = temp.MultiplyWay;
            }

            return nodes;
        }
    }
}
