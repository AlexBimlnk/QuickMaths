using System.Text;

using QuickMaths.FunctionsBLL.Enums;
using QuickMaths.FunctionsBLL.Functions;

namespace QuickMaths.FunctionsBLL.DataStructure;

internal class Tree //where T : IComparable
{
    public Tree(Node head) => Head = head ?? throw new ArgumentNullException(nameof(head));
    public Tree(IFunction function) => Head = new Node(function ?? throw new ArgumentNullException(nameof(function)));


    public Node Head { get; private set; }
    public int Size => (Head == null) ? 0 : Head.Size;


    private static void Swap<T>(ref T leftValue, ref T rightValue)
    {
        T temp;
        temp = leftValue;
        leftValue = rightValue;
        rightValue = temp;
    }

    /// <summary>
    /// Производит слияние двух деревьев, связанных умножением в одно.
    /// (a*b*c) * (d*e*f) => a*b*c*d*e*f
    /// <br/>
    /// (a*b*c) * (d+e+f) => a*b*c*(d+e+f)
    /// </summary>
    /// <param name="toMerge"> Дерево, являющееся результатом слияния. </param>
    /// <param name="fromMerge"> Дерево, из которого нужно достать узлы для слияния. </param>
    public static void MergeMult(Tree? toMerge, Tree? fromMerge)
    {
        if (fromMerge is null)
            return;
        if (toMerge is null)
        {
            toMerge = fromMerge;
            return;
        }

        if (toMerge.Head.PlusWay is not null)
        {
            return;
        }
        if (fromMerge.Head.PlusWay is not null)
        {
            var newNode = new CompositeFunction(fromMerge);
            toMerge.AddNewMultiplier(newNode);
            return;
        }
        toMerge.Head.Add(fromMerge.Head, NodeWayType.MultiplyWay);
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
    public static Tree? Merge(Tree? tree1, Tree? tree2, MathOperation type)
    {
        //ToDo доделать
        if (tree1 is null && tree2 is null)
            return null;
        if (tree2 is null)
            return tree1;
        if (tree1 is null)
            return tree2;

        switch (type)
        {
            case MathOperation.Plus:

                tree1.Head.Add(tree2.Head, NodeWayType.PlusWay);
                return tree1;

            case MathOperation.Multiply:

                if (tree1.Head.PlusWay is null && tree2.Head.PlusWay is null)
                {
                    tree1.Head.Add(tree2.Head, NodeWayType.MultiplyWay);
                }
                else if (tree1.Head.PlusWay is not null && tree1.Head.PlusWay is not null)
                {
                    var newNode1 = new CompositeFunction(tree1);
                    var newNode2 = new CompositeFunction(tree2);

                    var newTree = new Tree(newNode1);
                    newTree.Head.Add(new Node(newNode2), NodeWayType.MultiplyWay);
                    return newTree;
                }
                else
                {
                    if (tree2.Head.PlusWay is not null)
                        Swap(ref tree1, ref tree2);

                    Node? temp = tree1.Head;

                    while (temp is not null)
                    {
                        Node? fromAdd = tree2.Head;

                        while (fromAdd is not null)
                        {
                            var toAdd = new Node(fromAdd.Data);

                            temp.Add(toAdd, NodeWayType.MultiplyWay);

                            fromAdd = fromAdd.MultiplyWay;
                        }

                        temp = temp.PlusWay;
                    }
                }
                return tree1;

            case MathOperation.Divide:

                break;
            case MathOperation.Minus:

                break;
        }

        throw new InvalidOperationException();
    }

    /// <summary>
    /// Добавляет в дерево узел-множитель.
    /// </summary>
    /// <param name="newMult"> Функция-множитель. </param>
    public void AddNewMultiplier(IFunction newMult)
    {
        if (newMult is null)
            throw new ArgumentNullException(nameof(newMult));

        var newNode = new Node(newMult);
        if (Head is null)
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
        if (newSumm is null)
            throw new ArgumentNullException(nameof(newSumm));

        var newNode = new Node(newSumm);
        if (Head is null)
            Head = newNode;
        else
            Head.Add(newNode, NodeWayType.PlusWay);
    }

    /// <summary>
    /// Добавляет в дерево узел-слагаемое и устанавливает его в качестве корня дерева.
    /// </summary>
    /// <param name="newSumm"> Фугкция-слагаемое. </param>
    public void AddNewSummandInRoot(IFunction newSumm)
    {
        if (newSumm is null)
            throw new ArgumentNullException(nameof(newSumm));

        var newNode = new Node(newSumm);
        if (Head is null)
            Head = newNode;
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
        var nodes = new List<Node>();

        Node? temp = Head;

        while (temp is not null)
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
        if (node is null)
            throw new ArgumentNullException(nameof(node));


        var nodes = new List<Node>();

        Node? temp = node;
        while (temp is not null)
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

        Node? treeHead = Head;
        Node? derivativeNode = null;

        //Перебираем узлы-слагаемые
        while (treeHead is not null)
        {
            List<Node> nodes = CreateMultyWayList(treeHead);

            //Перебираем список узлов-множителей
            for (int i = 0; i < nodes.Count; i++)
            {
                Node? summand = null;
                for (int y = 0; y < nodes.Count; y++)
                {
                    //Если мы достигли множителя, от которого следует взять производную
                    if (i == y)
                    {
                        var tempDerivativeNode = new Node(nodes[y].Data.Derivative());
                        if (tempDerivativeNode.Data is null)
                        {
                            summand = null;
                            break;
                        }
                        if (summand is null)
                            summand = tempDerivativeNode;
                        else
                            summand.Add(tempDerivativeNode, NodeWayType.MultiplyWay);
                    }
                    else if (summand is null)
                        summand = new Node(nodes[y].Data);
                    else
                        summand.Add(new Node(nodes[y].Data), NodeWayType.MultiplyWay);
                }
                if (summand is not null)
                {
                    if (derivativeNode is null)
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
        var builTreeStr = new StringBuilder();

        Node? treeHead = Head;

        while (treeHead is not null)
        {
            if (builTreeStr.Length != 0)
                builTreeStr.Append(" + ");

            Node? multiplier = treeHead;

            while (multiplier is not null)
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
}
