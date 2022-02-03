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
                Head = newNode;
            else
            {
                Head.Add(newNode, Enums.NodeWayType.PlusWay);
            }
        }

        public void AddNewSummandRev(IFunction newSumm)
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

        //TODO: доделать
        public Tree GetDerivative()
        {
            // x*y*z => x'*y*z + x*y'*z + x*y*z'
            Tree _Derivative = new Tree();

            Node tmp = Head;

            while (tmp != null)
            {
                Node elem = tmp;
                Node summ;

                List <Node> nodes = new List<Node>();

                while (elem != null)
                {
                    nodes.Add(elem);
                    elem = elem.MultiplyWay;
                }

                Node ttmp;

                for (int i = 0;i < nodes.Count;i++)
                {
                    
                }

                tmp = tmp.PlusWay;
            }

            return this;
        }

        /// <summary>
        /// (a*b*c) * (d*e*f) => a*b*c*d*e*f
        /// 
        /// (a*b*c) * (d+e+f) => a*b*c*(d+e+f)
        /// </summary>
        /// <param name="_Result"></param>
        /// <param name="_Add"></param>
        static public void Merge(Tree _Result, Tree _Add)
        {
            if (_Add == null)
                return;
            if (_Result == null)
            {
                _Result = _Add;
                return;
            }
            if (_Result.Head.PlusWay != null)
            {
                return;
            }
            if (_Add.Head.PlusWay != null)
            {
                CompositeFunction _newnode = new CompositeFunction(_Add);
                _Result.AddNewMultiplier(_newnode);
                return;
            }
            _Result.Head.Add(_Add.Head, Enums.NodeWayType.MultiplyWay);
        }
    }
}
