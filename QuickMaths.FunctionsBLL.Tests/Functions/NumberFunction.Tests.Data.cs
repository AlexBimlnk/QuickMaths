using QuickMaths.FunctionsBLL.Functions;
using QuickMaths.General.Abstractions;

using Xunit;

namespace QuickMaths.FunctionsBLL.Tests.Functions;

public class NumberFunctionTestsData
{
    public static TheoryData<NumberFunction, IFunction, bool> EqualsNFAndOtherFunctionData = new()
    {
        // NumberFunction
        {
            new NumberFunction(1),
            new NumberFunction(2),
            false
        },
        {
            new NumberFunction(1),
            new NumberFunction(1),
            true
        },
        // LinearFunction
        {
            new NumberFunction(1),
            new LinearFunction(new NumberFunction(1)),
            true
        },
        {
            new NumberFunction(1),
            new LinearFunction(new NumberFunction(1), new NumberFunction(2)),
            false
        },
        {
            new NumberFunction(1),
            new LinearFunction(new NumberFunction(2)),
            false
        },
        {
            new NumberFunction(1),
            new LinearFunction(new VariableFunction("x")),
            false
        }
    };
}