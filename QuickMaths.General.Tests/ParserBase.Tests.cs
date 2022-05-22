using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using FluentAssertions;
using Moq;

using QuickMaths.General.Abstractions;
using System.Threading;

namespace QuickMaths.General.Tests;

public class ParserBaseTests
{
    #region Методы

    [Fact(DisplayName = "Can not parse when token was canceled.")]
    [Trait("Category", "Methods")]
    public void CanNotParseAsyncWhenTokenWasCanceledAsync()
    {
        // Arrange
        var cts = new CancellationTokenSource();
        cts.Cancel();
        var moqParser = new Mock<ParserBase<IArithmeticable>>(MockBehavior.Strict);
        moqParser.Setup(x => x.ParseAsync(It.IsAny<string>(), cts.Token))
                 .ThrowsAsync(new OperationCanceledException());

        // Act
        var exception = Record.ExceptionAsync(async () =>
            await moqParser.Object.ParseAsync(inputString: "someStr", cts.Token));

        // Assert
        exception.Result.Should().NotBeNull().And.BeOfType<OperationCanceledException>();
    }

    [Fact(DisplayName = "Can call parse async.")]
    [Trait("Category", "Methods")]
    public void CanParseAsync()
    {
        // Arrange
        var cts = new CancellationTokenSource();
        var moqArithmetic = new Mock<IArithmeticable>();
        var moqParser = new Mock<ParserBase<IArithmeticable>>(MockBehavior.Strict);
        moqParser.Setup(x => x.ParseAsync(It.IsAny<string>(), cts.Token))
                 .ReturnsAsync(moqArithmetic.Object);

        // Act
        var exception = Record.ExceptionAsync(async () =>
            await moqParser.Object.ParseAsync(inputString: "someStr", cts.Token));

        // Assert
        exception.Result.Should().BeNull();
    }
    #endregion
}
