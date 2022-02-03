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

        //TODO: доделать производную
        public Tree GetDerivative()
        {
            // x*y*z => x'*y*z + x*y'*z + x*y*z'
            Node tHead = Head;

            Node der = null;

            while (tHead != null)
            {
                Node elem = tHead;
                
                List <Node> nodes = new List<Node>();

                while (elem != null)
                {
                    nodes.Add(elem);
                    elem = elem.MultiplyWay;
                }

                for (int i = 0;i < nodes.Count;i++)
                {
                    Node summ = null;
                    for (int y = 0;y < nodes.Count;y++)
                    {
                        if (i == y)
                        {
                            Node tder = new Node(nodes[y].Data.Derivative());
                            if (tder.Data == null)
                            {
                                summ = null;
                                break;
                            }
                            if (summ == null)
                                summ = tder;
                            else
                                summ.Add(tder, Enums.NodeWayType.MultiplyWay);
                        }
                        else
                        {
                            if (summ == null)
                                summ = new Node(nodes[y].Data);
                            else
                                summ.Add(new Node(nodes[y].Data), Enums.NodeWayType.MultiplyWay);
                        }
                    }
                    if (summ != null)
                        if (der == null)
                            der = summ;
                        else
                            der.Add(summ, Enums.NodeWayType.PlusWay);
                }

                tHead = tHead.PlusWay;
            }

            return new Tree(der);
        }

        //TODO: доделать преобразование в строку
        public override string ToString()
        {
            StringBuilder builtreestr = new StringBuilder();

            Node tHead = Head;

            while (tHead != null)
            {
                if (builtreestr.Length != 0)
                    builtreestr.Append("|  +  |");

                Node summ = tHead;

                while (summ != null)
                {
                    if (summ != tHead)
                        builtreestr.Append('*');

                    builtreestr.Append(summ.Data.ToString());

                    summ = summ.MultiplyWay;
                }

                tHead = tHead.PlusWay;
            }

            return builtreestr.ToString();
        }

        /// <summary>
        /// (a*b*c) * (d*e*f) => a*b*c*d*e*f
        /// 
        /// (a*b*c) * (d+e+f) => a*b*c*(d+e+f)
        /// </summary>
        /// <param name="_Result"></param>
        /// <param name="_Add"></param>
        static public void MergeMult(Tree _Result, Tree _Add)
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
