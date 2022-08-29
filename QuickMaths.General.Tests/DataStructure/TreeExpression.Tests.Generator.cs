using QuickMaths.General.Abstractions;

using Xunit;

namespace QuickMaths.General.DataStructure.Tests;
internal class TreeExpressionTestsData
{

    public static TheoryData<IArithmeticOperator, string> CanCreateData
    {
        get
        {
            var data = new TheoryData<IArithmeticOperator, string>();

            data.Add(ArithmeticOperator.Plus, "1");
            data.Add(ArithmeticOperator.None, "2");
            data.Add(null!, "4");
            
            return data;
        }
    }

    public static TheoryData<IArithmeticOperator, string> CanNotBeCreatedWithNullData
    {
        get
        {
            var data = new TheoryData<IArithmeticOperator, string>();

            data.Add(ArithmeticOperator.None, null!);

            return data;
        }
    }

    public static TheoryData<TreeExpression<string>, IArithmeticOperator, string, TreeExpression<string>> CanSetRootData
    {
        get
        {
            var data = new TheoryData<TreeExpression<string>, IArithmeticOperator, string, TreeExpression<string>>();

            data.Add(new TreeExpression<string>("0"), ArithmeticOperator.Plus, "1", new TreeExpression<string>("1", ArithmeticOperator.Plus));
            data.Add(new TreeExpression<string>("0"), ArithmeticOperator.None, "2", new TreeExpression<string>("2", ArithmeticOperator.None));
            data.Add(new TreeExpression<string>("0"), ArithmeticOperator.Divide, "3", new TreeExpression<string>("3", ArithmeticOperator.None));
            data.Add(new TreeExpression<string>("0"), null!, "4", new TreeExpression<string>("4", null!));

            return data;
        }
    }

    public static TheoryData<TreeExpression<string>, IArithmeticOperator, string> CanNotSetRootWithNullData
    {
        get
        {
            var data = new TheoryData<TreeExpression<string>, IArithmeticOperator, string>();

            data.Add(new TreeExpression<string>("0"), ArithmeticOperator.None, null!);

            return data;
        }
    }

    public static TheoryData<TreeExpression<string>, IArithmeticOperator, string, TreeExpression<string>> CanAddEntityData
    {
        get
        {
            var data = new TheoryData<TreeExpression<string>, IArithmeticOperator, string, TreeExpression<string>>();

            

            return data;
        }
    }

    public static TheoryData<TreeExpression<string>, IArithmeticOperator, string> CanAddEntityWithNullData
    {
        get
        {
            var data = new TheoryData<TreeExpression<string>, IArithmeticOperator, string>();



            return data;
        }
    }

    public static TheoryData<TreeExpression<string>, IArithmeticOperator, TreeExpression<string>, TreeExpression<string>> CanAddTreeData
    {
        get
        {
            var data = new TheoryData<TreeExpression<string>, IArithmeticOperator, TreeExpression<string>, TreeExpression<string>>();

            return data;
        }
    }

    public static TheoryData<TreeExpression<string>, IArithmeticOperator, TreeExpression<string>> CanAddTreeWithNullData
    {
        get
        {
            var data = new TheoryData<TreeExpression<string>, IArithmeticOperator, TreeExpression<string>>();

            return data;
        }
    }
}
