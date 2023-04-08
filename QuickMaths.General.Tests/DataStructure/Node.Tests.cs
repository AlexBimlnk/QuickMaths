using System;

using FluentAssertions;
using Xunit;

namespace QuickMaths.General.DataStructure.Tests;

public class NodeTests
{
    #region Конструкторы

    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Unit")]
    public void CanBeCreated()
    {
        // Arrange
        var n = new Node();
        // Act

        // Assert
        Assert.True(false);
    }
    #endregion
}
