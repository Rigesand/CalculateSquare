using CalculateSquare.Core.Interfaces;
using CalculateSquare.Core.Models;

namespace CalculateSquare.Core.Services;

public class CalculateSquareService : ICalculateSquareService
{
    private void ValidationTriangle(Triangle triangle)
    {
        if (triangle.A < 0 || triangle.B < 0 || triangle.C < 0)
        {
            throw new Exception("The sides cannot be less than zero");
        }

        if (triangle.A + triangle.B < triangle.C
            || triangle.A + triangle.C < triangle.B
            || triangle.B + triangle.C < triangle.A)
        {
            throw new Exception("The side must be less than the sum of the other two sides");
        }
    }

    public double CalculateCircleSquare(Circle circle)
    {
        if (circle.Radius < 0)
        {
            throw new Exception("The radius cannot be less than zero");
        }

        return Math.Pow(circle.Radius, 2) * Constants.Pi;
    }

    public double CalculateTriangleSquare(Triangle triangle)
    {
        ValidationTriangle(triangle);
        var semiPerimeter = (triangle.A + triangle.B + triangle.C) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - triangle.A)
                                       * (semiPerimeter - triangle.B)
                                       * (semiPerimeter - triangle.C));
    }

    public double CalculateSquare<T>(T figure)
    {
        switch (figure)
        {
            case Circle circle:
                return CalculateCircleSquare(circle);
            case Triangle triangle:
                return CalculateTriangleSquare(triangle);
            default:
                throw new Exception("It is impossible to calculate the area of this type");
        }
    }

    public bool CheckRightTriangle(Triangle triangle)
    {
        ValidationTriangle(triangle);

        if (Math.Pow(triangle.A, 2) + Math.Pow(triangle.B, 2) == Math.Pow(triangle.C, 2)
            || Math.Pow(triangle.A, 2) + Math.Pow(triangle.C, 2) == Math.Pow(triangle.B, 2)
            || Math.Pow(triangle.C, 2) + Math.Pow(triangle.B, 2) == Math.Pow(triangle.A, 2))
        {
            return true;
        }

        return false;
    }
}