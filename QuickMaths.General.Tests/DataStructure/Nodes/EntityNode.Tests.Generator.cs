using System.Collections.Generic;
using System.Linq;

using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

using Xunit;


namespace QuickMaths.General.DataStructure.Nodes.Tests;
internal class EntityNodeTestsData
{
    private static string s_simpleEntity1 = "1";
    private static EntityNode<string> s_simpleEntityNode1 = new EntityNode<string>(s_simpleEntity1);

    private static string s_simpleEntity2 = "2";
    private static EntityNode<string> s_simpleEntityNode2 = new EntityNode<string>(s_simpleEntity2);

    private static string s_simpleEntity3 = "3";
    private static EntityNode<string> s_simpleEntityNode3 = new EntityNode<string>(s_simpleEntity3);

    private static OperatorNodePrototype? s_operatorNode4;

    private static IArithmeticOperator s_noneOerator = ArithmeticOperator.None;

    private static OperatorNodePrototype? s_result1Minus2OperatorNode;
    private static IArithmeticOperator s_merge1Minus2Operator = ArithmeticOperator.Minus;

    private static OperatorNodePrototype? s_result1Divide4OperatorNode;
    private static IArithmeticOperator s_merge1Divide4Operator = ArithmeticOperator.Divide;

    private static OperatorNodePrototype? s_result1Minus4OperatorNode;
    private static IArithmeticOperator s_merge1Minus4Operator = ArithmeticOperator.Minus;

    private static OperatorNodePrototype OperatorNode4
    {
        get
        {
            s_operatorNode4 = new OperatorNodePrototype(ArithmeticOperator.Plus);
            s_operatorNode4.AddOperand(ArithmeticOperator.Plus, s_simpleEntityNode2);
            s_operatorNode4.AddOperand(ArithmeticOperator.Minus, s_simpleEntityNode3);

            return s_operatorNode4;
        }
    }
    private static OperatorNodePrototype MergeResult1Minus2
    {
        get
        {
            if (s_result1Minus2OperatorNode is null)
            {
                s_result1Minus2OperatorNode = new OperatorNodePrototype(ArithmeticOperator.Plus);
                s_result1Minus2OperatorNode.AddOperand(ArithmeticOperator.Plus, s_simpleEntityNode1);
                s_result1Minus2OperatorNode.AddOperand(s_merge1Minus2Operator, s_simpleEntityNode2);
            }

            return s_result1Minus2OperatorNode;
        }
    }
    private static OperatorNodePrototype MergeResult1Divide4
    {
        get
        {
            if (s_result1Divide4OperatorNode is null)
            {
                s_result1Divide4OperatorNode = new OperatorNodePrototype(ArithmeticOperator.Multiply);
                s_result1Divide4OperatorNode.AddOperand(ArithmeticOperator.Multiply, s_simpleEntityNode1);
                s_result1Divide4OperatorNode.AddOperand(s_merge1Divide4Operator, OperatorNode4);
            }

            return s_result1Divide4OperatorNode;
        }
    }
    private static OperatorNodePrototype MergeResult1Minus4
    {
        get
        {
            if (s_result1Minus4OperatorNode is null)
            {
                s_result1Minus4OperatorNode = new OperatorNodePrototype(ArithmeticOperator.Plus);
                s_result1Minus4OperatorNode.AddOperand(ArithmeticOperator.Plus, s_simpleEntityNode1);
                s_result1Minus4OperatorNode.AddOperand(ArithmeticOperator.Minus, s_simpleEntityNode2);
                s_result1Minus4OperatorNode.AddOperand(ArithmeticOperator.Plus, s_simpleEntityNode3);

            }

            return s_result1Minus4OperatorNode;
        }
    }


    public static TheoryData<EntityNode<string>, ILookup<IArithmeticOperator, INodeExpression>> GetChildEntitiesData
    {
        get
        {
            var data = new TheoryData<EntityNode<string>, ILookup<IArithmeticOperator, INodeExpression>>();

            data.Add(s_simpleEntityNode1,
                new List<INodeExpression>(1).Append(new EntityNode<string>(s_simpleEntity1))
                    .ToLookup(o => ArithmeticOperator.None, o => o));

            return data;
        }
    }
    public static TheoryData<EntityNode<string>, IArithmeticOperator, INodeExpression, INodeExpression> GetMergeNodesData
    {
        get
        {
            var data = new TheoryData<EntityNode<string>, IArithmeticOperator, INodeExpression, INodeExpression>();

            //entiy - entity => (+ entity, - entity)

            data.Add(s_simpleEntityNode1, s_merge1Minus2Operator, s_simpleEntityNode2, MergeResult1Minus2);

            //entiy / operator => * entiy / operator

            data.Add(s_simpleEntityNode1, s_merge1Divide4Operator, OperatorNode4, MergeResult1Divide4);

            //entity1 - (+ entity2, -entity3) => (+ entity1 - entity2 + entity3)

            data.Add(s_simpleEntityNode1, s_merge1Minus4Operator, OperatorNode4, MergeResult1Minus4);

            data.Add(s_simpleEntityNode1, s_noneOerator, s_simpleEntityNode2, MergeResult1Minus2);

            return data;
        }
    }
    public static TheoryData<EntityNode<string>, IArithmeticOperator, INodeExpression> GetMergeNodesWithNullData
    {
        get
        {
            var data = new TheoryData<EntityNode<string>, IArithmeticOperator, INodeExpression>();

            data.Add(s_simpleEntityNode1, null!, s_simpleEntityNode2);
            data.Add(s_simpleEntityNode1, s_merge1Minus2Operator, null!);

            return data;
        }
    }
}
