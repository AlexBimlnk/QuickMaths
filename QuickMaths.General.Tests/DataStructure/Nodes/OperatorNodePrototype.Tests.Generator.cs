using System.Linq;

using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

using Xunit;
namespace QuickMaths.General.DataStructure.Nodes.Tests;
internal class OperatorNodePrototypeTestsData
{
    private static (IArithmeticOperator, INodeExpression)[] s_fillPriority1_1 = new (IArithmeticOperator, INodeExpression)[] {
        (ArithmeticOperator.Plus, new EntityNode<string>(" 1_1 ")),
        (ArithmeticOperator.Plus, new EntityNode<string>(" 1_2 ")),
        (ArithmeticOperator.Minus,new EntityNode<string>(" 1_3 ")),
        (ArithmeticOperator.Minus,new EntityNode<string>(" 1_4 ")),
        (ArithmeticOperator.Minus,new EntityNode<string>(" 1_5 "))
    };
    private static OperatorNodePrototype s_priority1OperatorNode1 = new OperatorNodePrototype(ArithmeticOperator.Plus, s_fillPriority1_1.ToLookup(o => o.Item1, o => o.Item2));

    private static EntityNode<string> s_entityNode2 = new EntityNode<string>(" 2_1 ");

    private static (IArithmeticOperator, INodeExpression)[] s_fillPriority1_3 = new (IArithmeticOperator, INodeExpression)[] {
        (ArithmeticOperator.Minus, new EntityNode<string>(" 3_1 ")),
        (ArithmeticOperator.Plus, new EntityNode<string>(" 3_2 "))
    };
    private static OperatorNodePrototype s_priority1OperatorNode3 = new OperatorNodePrototype(ArithmeticOperator.Plus, s_fillPriority1_3.ToLookup(o => o.Item1, o => o.Item2));

    private static (IArithmeticOperator, INodeExpression)[] s_fillPriority2_4 = new (IArithmeticOperator, INodeExpression)[] {
        (ArithmeticOperator.Multiply, new EntityNode<string>(" 4_2 ")),
        (ArithmeticOperator.Multiply, new EntityNode<string>(" 4_3 ")),
        (ArithmeticOperator.Multiply, new EntityNode<string>(" 4_4 "))
    };
    private static OperatorNodePrototype s_priority2OperatorNode4 = new OperatorNodePrototype(ArithmeticOperator.Multiply, s_fillPriority2_4.ToLookup(o => o.Item1, o => o.Item2));

    private static IArithmeticOperator s_mergeOperator1Divide2 = ArithmeticOperator.Divide;
    private static OperatorNodePrototype s_mergeResult1Divide2 = new OperatorNodePrototype(ArithmeticOperator.Divide, 
        new (IArithmeticOperator, INodeExpression)[] { 
            (ArithmeticOperator.Multiply,s_priority1OperatorNode1),
            (s_mergeOperator1Divide2, s_entityNode2)
        }.ToLookup(o => o.Item1, o => o.Item2));

    private static IArithmeticOperator s_mergeOperator1Divide3 = ArithmeticOperator.Divide;
    private static OperatorNodePrototype s_mergeResult1Divide3 = new OperatorNodePrototype(ArithmeticOperator.Divide,
        new (IArithmeticOperator, INodeExpression)[] {
            (ArithmeticOperator.Multiply,s_priority1OperatorNode1),
            (s_mergeOperator1Divide2, s_priority1OperatorNode3)
        }.ToLookup(o => o.Item1, o => o.Item2));

    private static IArithmeticOperator s_mergeOperator1Divide4 = ArithmeticOperator.Divide;
    private static OperatorNodePrototype s_mergeResult1Divide4 = new OperatorNodePrototype(ArithmeticOperator.Divide,
        s_fillPriority2_4
        .Append((ArithmeticOperator.Multiply, s_priority1OperatorNode1))
        .ToLookup(o => (o.Item1 == ArithmeticOperator.Multiply && o.Item2 != s_priority1OperatorNode1
                            ? ArithmeticOperator.Divide
                            : ArithmeticOperator.Multiply), o => o.Item2));

    private static IArithmeticOperator s_mergeOperator1Minus4 = ArithmeticOperator.Minus;
    private static OperatorNodePrototype s_mergeResult1Minus4 = new OperatorNodePrototype(ArithmeticOperator.Minus,
        s_fillPriority1_1
        .Append((s_mergeOperator1Minus4, s_priority2OperatorNode4))
        .ToLookup(o => o.Item1, o => o.Item2));

    private static IArithmeticOperator s_mergeOperator1Minus3 = ArithmeticOperator.Minus;
    private static OperatorNodePrototype s_mergeResult1Minus3 = new OperatorNodePrototype(ArithmeticOperator.Minus,
        s_fillPriority1_1
        .Concat(s_fillPriority1_3.Select(o => ((o.Item1 == ArithmeticOperator.Minus
                            ? ArithmeticOperator.Plus
                            : ArithmeticOperator.Minus), o.Item2)))
        .ToLookup(o => o.Item1 , o => o.Item2));

    private static IArithmeticOperator s_addOperaotr1Minus4 = ArithmeticOperator.Minus;
    private static OperatorNodePrototype s_addOperand1Minus4 = new OperatorNodePrototype(ArithmeticOperator.Minus,
        s_fillPriority1_1.Append((s_addOperaotr1Minus4, s_priority2OperatorNode4)).ToLookup(o => o.Item1, o => o.Item2));

    private static IArithmeticOperator s_addOperaotr1Minus2 = ArithmeticOperator.Minus;
    private static OperatorNodePrototype s_addOperand1Minus2 = new OperatorNodePrototype(ArithmeticOperator.Minus,
        s_fillPriority1_1.Append((s_addOperaotr1Minus2,s_entityNode2)).ToLookup(o => o.Item1, o => o.Item2));

    private static OperatorNodePrototype GetPriority1OperatorNode => new OperatorNodePrototype(ArithmeticOperator.Plus, s_fillPriority1_1.ToLookup(o => o.Item1, o => o.Item2));

    public static TheoryData<IArithmeticOperator ,ILookup<IArithmeticOperator, INodeExpression>> CanCreateWithLookupData
    {
        get
        {
            var data = new TheoryData<IArithmeticOperator, ILookup<IArithmeticOperator, INodeExpression>>();

            data.Add(ArithmeticOperator.Plus ,s_fillPriority1_1.ToLookup(o => o.Item1, o => o.Item2));

            return data;
        }
    }
    public static TheoryData<OperatorNodePrototype, ILookup<IArithmeticOperator, INodeExpression>> GetChildEntitiesData
    {
        get
        {
            var data = new TheoryData<OperatorNodePrototype, ILookup<IArithmeticOperator, INodeExpression>>();

            data.Add(s_priority1OperatorNode1, s_fillPriority1_1.ToLookup(o => o.Item1, o => o.Item2));

            return data;
        }
    }
    public static TheoryData<OperatorNodePrototype, IArithmeticOperator, INodeExpression, INodeExpression> GetMergeNodesData
    {
        get
        {
            var data = new TheoryData<OperatorNodePrototype, IArithmeticOperator, INodeExpression, INodeExpression>();

            //merge with entity

            data.Add(s_priority1OperatorNode1, s_mergeOperator1Divide2, s_entityNode2, s_mergeResult1Divide2);

            //merge with other operator

            data.Add(s_priority1OperatorNode1, s_mergeOperator1Divide3, s_priority1OperatorNode3, s_mergeResult1Divide3);

            //merge on same priorotiy

            data.Add(s_priority1OperatorNode1, s_mergeOperator1Minus4, s_priority2OperatorNode4, s_mergeResult1Minus4);

            //merge on and to equal priority

            data.Add(s_priority1OperatorNode1, s_mergeOperator1Divide4, s_priority2OperatorNode4, s_mergeResult1Divide4);

            //all same priority

            data.Add(s_priority1OperatorNode1, s_mergeOperator1Minus3, s_priority1OperatorNode3, s_mergeResult1Minus3);

            data.Add(s_priority1OperatorNode1, ArithmeticOperator.None, s_priority1OperatorNode3, s_mergeResult1Minus3);

            return data;
        }
    }
    public static TheoryData<OperatorNodePrototype, IArithmeticOperator, INodeExpression> GetMergeNodesWithNullData
    {
        get
        {
            var data = new TheoryData<OperatorNodePrototype, IArithmeticOperator, INodeExpression>();

            data.Add(s_priority1OperatorNode1, null!, s_entityNode2);

            data.Add(s_priority1OperatorNode1, s_mergeOperator1Divide2, null!);

            return data;
        }
    }
    public static TheoryData<OperatorNodePrototype, IArithmeticOperator, INodeExpression, INodeExpression> GetAddOperandData
    {
        get
        {
            var data = new TheoryData<OperatorNodePrototype, IArithmeticOperator, INodeExpression, INodeExpression>();

            //node operator entity

            data.Add(GetPriority1OperatorNode, s_addOperaotr1Minus2, s_entityNode2, s_addOperand1Minus2);

            //node opertator node another priority

            data.Add(GetPriority1OperatorNode, s_addOperaotr1Minus4, s_priority2OperatorNode4, s_addOperand1Minus4);

            //node operator node same priority

            data.Add(GetPriority1OperatorNode, s_mergeOperator1Minus3, s_priority1OperatorNode3, s_mergeResult1Minus3);

            data.Add(GetPriority1OperatorNode, ArithmeticOperator.Multiply, s_entityNode2, s_addOperand1Minus2);

            //data.Add(new OperatorNodePrototype(ArithmeticOperator.Divide), ArithmeticOperator.Divide, s_entityNode2, AddOperandResult1Minus2);

            return data;
        }
    }
}
