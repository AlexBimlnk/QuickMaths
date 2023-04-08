using System;
using System.Threading;

using FluentAssertions;
using Xunit;
using Moq;

using QuickMaths.General.Abstractions;

namespace QuickMaths.General.Tests;

public class ParserBaseTests
{
    #region Методы

    [Fact(DisplayName = "Can not parse when token was canceled.")]
    [Trait("Category", "Unit")]
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
    [Trait("Category", "Unit")]
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
