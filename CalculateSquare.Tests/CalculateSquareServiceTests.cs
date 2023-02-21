using CalculateSquare.Core.Interfaces;
using CalculateSquare.Core.Models;
using CalculateSquare.Core.Services;

namespace CalculateSquare.Tests;

public class CalculateSquareServiceTests
{
    private readonly ICalculateSquareService _service;

    public CalculateSquareServiceTests()
    {
        _service = new CalculateSquareService();
    }

    [Theory]
    [InlineData(5, 78.5)]
    [InlineData(4, 50.24)]
    [InlineData(3, 28.26)]
    public void CalculateCircleSquare_Valid(double radius, double actual)
    {
        //Arrange
        var circle = new Circle
        {
            Radius = radius
        };
        //Act
        var expected = _service.CalculateCircleSquare(circle);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateCircleSquare_RadiusLessThenZero_ShouldThrowException()
    {
        //Arrange
        var circle = new Circle
        {
            Radius = -1
        };
        //Act
        //Assert
        Assert.Throws<Exception>(() => _service.CalculateCircleSquare(circle));
    }

    [Fact]
    public void CalculateTriangleSquare_Valid()
    {
        //Arrange
        var triangle = new Triangle
        {
            A = 3,
            B = 4,
            C = 5
        };
        var actual = 6;
        //Act
        var expected = _service.CalculateTriangleSquare(triangle);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateTriangleSquare_SideLessThenZero_ShouldThrowException()
    {
        //Arrange
        var triangle = new Triangle
        {
            A = -3,
            B = -4,
            C = 5
        };
        //Act
        //Assert
        Assert.Throws<Exception>(() => _service.CalculateTriangleSquare(triangle));
    }

    [Fact]
    public void CalculateTriangleSquare_UnableToCreate_ShouldThrowException()
    {
        //Arrange
        var triangle = new Triangle
        {
            A = 1,
            B = 1,
            C = 5
        };
        //Act
        //Assert
        Assert.Throws<Exception>(() => _service.CalculateTriangleSquare(triangle));
    }

    [Theory]
    [InlineData(5, 78.5)]
    public void CalculateSquare_ValidCircle(double radius, double actual)
    {
        //Arrange
        var figure = new Circle
        {
            Radius = radius
        };
        //Act
        var expected = _service.CalculateSquare(figure);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateSquare_ValidTriangle()
    {
        //Arrange
        var figure = new Triangle
        {
            A = 3,
            B = 4,
            C = 5
        };
        var actual = 6;
        //Act
        var expected = _service.CalculateSquare(figure);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateSquare_InvalidType_ShouldThrowException()
    {
        //Arrange
        var figure = new List<int>();
        //Act
        //Assert
        Assert.Throws<Exception>(() => _service.CalculateSquare(figure));
    }

    [Theory]
    [InlineData(3, 4, 5)]
    public void CheckRightTriangle_Valid(double A, double B, double C)
    {
        //Arrange
        var triangle = new Triangle
        {
            A = A,
            B = B,
            C = C
        };
        var actual = true;
        //Act
        var expected = _service.CheckRightTriangle(triangle);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(3, 4, 6)]
    public void CheckRightTriangle_Invalid(double A, double B, double C)
    {
        //Arrange
        var triangle = new Triangle
        {
            A = A,
            B = B,
            C = C
        };
        var actual = false;
        //Act
        var expected = _service.CheckRightTriangle(triangle);
        //Assert
        Assert.Equal(expected, actual);
    }
}