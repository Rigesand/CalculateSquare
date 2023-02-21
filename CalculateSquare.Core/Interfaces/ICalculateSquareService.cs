using CalculateSquare.Core.Models;

namespace CalculateSquare.Core.Interfaces;

public interface ICalculateSquareService
{ 
    double CalculateCircleSquare(Circle circle);
    double CalculateTriangleSquare(Triangle triangle);
    double CalculateSquare<T>(T figure);
    bool CheckRightTriangle(Triangle triangle);
}