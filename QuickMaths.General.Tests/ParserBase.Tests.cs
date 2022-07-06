using System;
using System.Threading;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Moq;

using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.Tests;

public class ParserBaseTests
{
    #region Методы

    [Fact(DisplayName = "Can split input string by arithmetics operators")]
    [Trait("Category", "Methods")]
    public void CanSplitStringOnOperators()
    {
        //Arrange
        string inputString = "a*b/d+sasdas-f*sd";
        var splitResult = new List<Tuple<ArithmeticOperator, string, int>>()
        {
            (ArithmeticOperator.Plus, "a",0).ToTuple(),
            (ArithmeticOperator.Multiply, "b",0).ToTuple(),
            (ArithmeticOperator.Divide, "d",0).ToTuple(),
            (ArithmeticOperator.Plus, "sasdas",0).ToTuple(),
            (ArithmeticOperator.Minus, "f",0).ToTuple(),
            (ArithmeticOperator.Multiply, "sd",0).ToTuple()
        };

        //Act
        var splitInput = ParserBase<string>.SplitOnOperators(inputString);


        //Assert
        Assert.Equal(splitResult, splitInput);
    }

    [Fact(DisplayName = "Can split input string by arithmetics operators with nested espressions")]
    [Trait("Category", "Methods")]
    public void CanSplitWithBrackets()
    {
        //Arrange
        string inputString1 = "a*(b-c)+(4+a)^2-f*sd+(e1-e2)/(t1-t2)";
        var splitResult1 = new List<Tuple<ArithmeticOperator, string, int>>()
        {
            (ArithmeticOperator.Plus, "a",0).ToTuple(),
            (ArithmeticOperator.Multiply, "()",0).ToTuple(),

            (ArithmeticOperator.Plus, "b",1).ToTuple(),
            (ArithmeticOperator.Minus, "c",1).ToTuple(),

            (ArithmeticOperator.Plus, "()^2",0).ToTuple(),
            
            (ArithmeticOperator.Plus, "4",1).ToTuple(),
            (ArithmeticOperator.Plus, "a",1).ToTuple(),

            (ArithmeticOperator.Minus, "f",0).ToTuple(),
            (ArithmeticOperator.Multiply, "sd",0).ToTuple(),
            (ArithmeticOperator.Plus, "()",0).ToTuple(),

            (ArithmeticOperator.Plus, "e1",1).ToTuple(),
            (ArithmeticOperator.Minus, "e2",1).ToTuple(),

            (ArithmeticOperator.Divide, "()",0).ToTuple(),

            (ArithmeticOperator.Plus, "t1",1).ToTuple(),
            (ArithmeticOperator.Minus, "t2",1).ToTuple(),


        };

        string inputString2 = "sin(a*x^(2*(4-3/2*(sin(2))))+10)";
        var splitResult2 = new List<Tuple<ArithmeticOperator, string, int>>()
        {
            (ArithmeticOperator.Plus, "sin()",0).ToTuple(),

            (ArithmeticOperator.Plus, "a",1).ToTuple(),
            (ArithmeticOperator.Multiply, "x^()",1).ToTuple(),

            (ArithmeticOperator.Plus, "2",2).ToTuple(),
            (ArithmeticOperator.Multiply, "()",2).ToTuple(),

            (ArithmeticOperator.Plus, "4", 3).ToTuple(),
            (ArithmeticOperator.Minus, "3", 3).ToTuple(),
            (ArithmeticOperator.Divide, "2", 3).ToTuple(),
            (ArithmeticOperator.Multiply, "()", 3).ToTuple(),

            (ArithmeticOperator.Plus, "sin()",4).ToTuple(),

            (ArithmeticOperator.Plus, "2",5).ToTuple(),


            (ArithmeticOperator.Plus, "10",1).ToTuple(),
        };

        //Act
        var splitInput1 = ParserBase<string>.SplitOnOperators(inputString1);
        var splitInput2 = ParserBase<string>.SplitOnOperators(inputString2);


        //Assert
        
        Assert.Equal(splitResult1, splitInput1);
        Assert.Equal(splitResult2, splitInput2);
    }

    [Fact(DisplayName = "Can not parse when token was canceled.")]
    [Trait("Category", "Methods")]
    public async void CanNotParseAsyncWhenTokenWasCanceledAsync()
    {
        // Arrange
        var cts = new CancellationTokenSource();
        var moqParser = new Mock<ParserBase<IArithmeticable>>(MockBehavior.Strict);
        moqParser.Setup(x => x.ParseAsync(It.IsAny<string>(), cts.Token))
                 .ThrowsAsync(new OperationCanceledException());

        // Act
        cts.Cancel();
        var exception = await Record.ExceptionAsync(async () =>
            await moqParser.Object.ParseAsync(inputString: "someStr", cts.Token));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<OperationCanceledException>();
    }

    [Fact(DisplayName = "Can call parse async.")]
    [Trait("Category", "Methods")]
    public async void CanParseAsync()
    {
        // Arrange
        var cts = new CancellationTokenSource();

        var arithmetic = new Mock<IArithmeticable>().Object;

        var moqParser = new Mock<ParserBase<IArithmeticable>>(MockBehavior.Strict);
        moqParser.Setup(x => x.Parse(It.IsAny<string>()))
                 .Returns(arithmetic);
        moqParser.Setup(x => x.ParseAsync(It.IsAny<string>(), cts.Token))
                 .Callback(() => moqParser.Object.Parse(It.IsAny<string>()))
                 .ReturnsAsync(arithmetic);

        // Act
        var exception = await Record.ExceptionAsync(async () =>
            await moqParser.Object.ParseAsync(inputString: "someStr", cts.Token));

        // Assert
        exception.Should().BeNull();
    }
    #endregion
}
