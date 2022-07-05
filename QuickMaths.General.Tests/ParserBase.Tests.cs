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

    [Fact(DisplayName = "Can split input strign by arithmetics operators")]
    [Trait("Category", "Methods")]
    public void CanSplitStringOnOperators()
    {
        //Arrange
        string inputString = "a*b/d+sasdas-f*sd";
        var splitResult = new List<List<Tuple<ArithmeticOperator, string>>>()
        {
            new List<Tuple<ArithmeticOperator, string>>()
            { 
                (ArithmeticOperator.Multiply, "a").ToTuple(), 
                (ArithmeticOperator.Divide, "b").ToTuple(), 
                (ArithmeticOperator.Plus, "d").ToTuple() 
            },
            new List<Tuple<ArithmeticOperator, string>>()
            { 
                (ArithmeticOperator.Minus, "sasdas").ToTuple() 
            },
            new List<Tuple<ArithmeticOperator, string>>()
            { 
                (ArithmeticOperator.Multiply, "f").ToTuple(), 
                (ArithmeticOperator.Plus, "sd").ToTuple() 
            }
        };

        //Act
        var splitInput = ParserBase<string>.SplitOnOperators(inputString);


        //Assert
        Assert.Equal(splitResult, splitInput);
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
