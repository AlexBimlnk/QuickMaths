using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.Functions;
using QuickMaths.BL.Enums;

namespace QuickMaths.BL.DataStructure
{
    public class Tree //where T : IComparable
    {
        public Tree()
        {
            Head = null;
        }
        public Tree(Node head)
        {
            Head = head;
        }
        public Tree(IFunction head)
        {
            if (head != null)
                Head = new Node(head);
        }


        public Node Head { get; private set; }
        public int Size { get { return (Head == null) ? 0 : Head.Size; } }


        /// <summary>
        /// Добавляет в дерево узел-множитель.
        /// </summary>
        /// <param name="newMult"> Функция-множитель. </param>
        public void AddNewMultiplier(IFunction newMult)
        {
            Node newNode = new Node(newMult);
            if (Head == null)
                Head = newNode;
            else
                Head.Add(newNode, NodeWayType.MultiplyWay);
        }
        /// <summary>
        /// Добавляет в дерево узел-слагаемое.
        /// </summary>
        /// <param name="newSumm"> Функция-слагаемое. </param>
        public void AddNewSummand(IFunction newSumm)
        {
            Node newNode = new Node(newSumm);
            if (Head == null)
                Head = newNode;
            else
            {
                Head.Add(newNode, NodeWayType.PlusWay);
            }
        }
        /// <summary>
        /// Добавляет в дерево узел-слагаемое и устанавливает его в качестве корня дерева.
        /// </summary>
        /// <param name="newSumm"> Фугкция-слагаемое. </param>
        public void AddNewSummandInRoot(IFunction newSumm)
        {
            Node newNode = new Node(newSumm);
            if (Head == null)
                Head= newNode;
            else
            {
                newNode.Add(Head, NodeWayType.PlusWay);
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
        /// <summary>
        /// Возвращает дерево производных, если это возможно.
        /// </summary>
        /// <returns> Дерево производных или null. </returns>
        public Tree? GetDerivative()
        {
            // (x*y*z)' => x'*y*z + x*y'*z + x*y*z'

            Node treeHead = Head;
            Node derivativeNode = null;

            //Перебираем узлы-слагаемые
            while (treeHead != null)
            {
                List<Node> nodes = CreateMultyWayList(treeHead);

                //Перебираем список узлов-множителей
                for (int i = 0; i < nodes.Count; i++)
                {
                    Node summand = null;
                    for (int y = 0; y < nodes.Count; y++)
                    {
                        //Если мы достигли множителя, от которого следует взять производную
                        if (i == y)
                        {
                            Node tempDerivativeNode = new Node(nodes[y].Data.Derivative());
                            if (tempDerivativeNode.Data == null)
                            {
                                summand = null;
                                break;
                            }
                            if (summand == null)
                                summand = tempDerivativeNode;
                            else
                                summand.Add(tempDerivativeNode, NodeWayType.MultiplyWay);
                        }
                        else if (summand == null)
                            summand = new Node(nodes[y].Data);
                        else
                            summand.Add(new Node(nodes[y].Data), NodeWayType.MultiplyWay);
                    }
                    if (summand != null)
                    {
                        if (derivativeNode == null)
                            derivativeNode = summand;
                        else
                            derivativeNode.Add(summand, NodeWayType.PlusWay);
                    }
                }

                treeHead = treeHead.PlusWay;
            }

            return derivativeNode == null ? null : new Tree(derivativeNode);
        }
        //TODO: доделать преобразование в строку
        public override string ToString()
        {
            StringBuilder builTreeStr = new StringBuilder();

            Node treeHead = Head;

            while (treeHead != null)
            {
                if (builTreeStr.Length != 0)
                    builTreeStr.Append(" + ");

                Node multiplier = treeHead;

                while (multiplier != null)
                {
                    if (multiplier != treeHead)
                        builTreeStr.Append("*");

                    builTreeStr.Append(multiplier.Data.ToString());

                    multiplier = multiplier.MultiplyWay;
                }

                treeHead = treeHead.PlusWay;
            }

            return builTreeStr.ToString();
        }


        /// <summary>
        /// Производит слияние двух деревьев, связанных умножением в одно.
        /// (a*b*c) * (d*e*f) => a*b*c*d*e*f
        /// <br/>
        /// (a*b*c) * (d+e+f) => a*b*c*(d+e+f)
        /// </summary>
        /// <param name="toMerge"> Дерево, являющееся результатом слияния. </param>
        /// <param name="fromMerge"> Дерево, из которого нужно достать узлы для слияния. </param>
        static public void MergeMult(Tree toMerge, Tree fromMerge)
        {
            if (fromMerge == null)
                return;
            if (toMerge == null)
            {
                toMerge = fromMerge;
                return;
            }
            if (toMerge.Head.PlusWay != null)
            {
                return;
            }
            if (fromMerge.Head.PlusWay != null)
            {
                CompositeFunction newNode = new CompositeFunction(fromMerge);
                toMerge.AddNewMultiplier(newNode);
                return;
            }
            toMerge.Head.Add(fromMerge.Head, NodeWayType.MultiplyWay);
        }
        static void Swap<T>(ref T leftValue, ref T rightValue)
        {
            T temp;
            temp = leftValue;
            leftValue = rightValue;
            rightValue = temp;
        }

        /// <summary>
        /// Производит слияние двух деревьев, связанных простым математическим оператором.
        /// (a*b*c) * (d*e*f) => a*b*c*d*e*f
        /// (a*b*c) * (d+e+f) => a*b*c*d + a*b*c*e + a*b*c*f
        /// (a+b+c) * (d+e+f) => (a+b+c)*(d+e+f)
        /// </summary>
        /// <param name="tree1"></param>
        /// <param name="tree2"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        static public Tree Merge(Tree tree1, Tree tree2,MathOperation type)
        {
            //ToDo доделать
            if (tree1 == null && tree2 == null)
                return null;
            if (tree2 == null)
                return tree1;
            if (tree1 == null)
                return tree2;
            
            switch(type)
            {
                case MathOperation.Plus:
                    
                    tree1.Head.Add(tree2.Head, NodeWayType.PlusWay);
                    return tree1;

                    break;
                case MathOperation.Multiply:

                    if (tree1.Head.PlusWay == null && tree2.Head.PlusWay == null)
                    {
                        tree1.Head.Add(tree2.Head, NodeWayType.MultiplyWay);
                    }
                    else if (tree1.Head.PlusWay != null && tree1.Head.PlusWay != null)
                    {
                        CompositeFunction newNode1 = new CompositeFunction(tree1);
                        CompositeFunction newNode2 = new CompositeFunction(tree2);

                        Tree newTree = new Tree(newNode1);
                        newTree.Head.Add(new Node(newNode2), NodeWayType.MultiplyWay);
                        return newTree;
                    }
                    else
                    {
                        if (tree2.Head.PlusWay != null)
                            Swap(ref tree1, ref tree2);

                        Node temp = tree1.Head;

                        while (temp != null)
                        {
                            Node fromAdd = tree2.Head;

                            while(fromAdd != null)
                            {
                                Node toAdd = new Node(fromAdd.Data);

                                temp.Add(toAdd, NodeWayType.MultiplyWay);

                                fromAdd = fromAdd.MultiplyWay;
                            }

                            temp = temp.PlusWay;
                        }
                    }
                    return tree1;
                    break;

                case MathOperation.Divide:

                    break;
                case MathOperation.Minus:

                    break;
            }

            return new Tree();
        }
    }
}
