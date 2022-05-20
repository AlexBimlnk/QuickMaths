using QuickMaths.General.Abstractions;
using QuickMaths.General.DataStructure.Nodes;
using QuickMaths.General.Enums;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("QuickMaths.General.Tests")]
namespace QuickMaths.General.DataStructure;

public class Tree
{
    private INode? _head;

    public Tree() => _head = null;

    public Tree(IArithmeticable arithmeticElement)
    {
        if (arithmeticElement is null)
        {
            throw new ArgumentNullException("Arihmetic elelent for head node is null");
        }
        _head = new ArihmeticNode(arithmeticElement);
    }

    public void AddAriphmeticElement(MathOperator @operator, IArithmeticable arithmeticElement)
    {
        if (arithmeticElement is null)
        {
            throw new ArgumentNullException($"Arihmetic elelent for {nameof(ArihmeticNode)} is null");
        }

        if (_head is null)
        {
            throw new ArgumentNullException("Head noed is null");
        }

        var nodeForConnect = new ArihmeticNode(arithmeticElement);
        _head = new OperatorNode(@operator, _head, nodeForConnect);
    }

    public void AddAriphmeticElement(MathOperator @operator, Tree tree)
    {
        if (tree._head is null)
        {
            throw new ArgumentNullException($"{nameof(Tree)} for {nameof(ArihmeticNode)} is null");
        }

        if (_head is null)
        {
            throw new ArgumentNullException($"Head node is null");
        }

        _head = new OperatorNode(@operator, _head, tree._head);
    }

    public void SetHeadElement(IArithmeticable arihmeticElement)
    {
        if (arihmeticElement is null)
        {
            throw new ArgumentNullException($"Arihmetic elelent for {nameof(ArihmeticNode)} is null");
        }

        _head = new ArihmeticNode(arihmeticElement);
    }
}