using ShapeLibrary.Interfaces;

namespace ShapeLibrary.Shapes
{
    public class Triangle : IShape
    {
        private readonly double _firstSide;
        private readonly double _secondSide;
        private readonly double _thirdSide;

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {

            if (firstSide <= 0)
            {
                throw new ArgumentException("Invalid first side value. Side must be positive and non-zero.");
            }
            if (secondSide <= 0)
            {
                throw new ArgumentException("Invalid second side value. Side must be positive and non-zero.");
            }
            if (thirdSide <= 0)
            {
                throw new ArgumentException("Invalid third side value. Side must be positive and non-zero.");
            }

            if (firstSide + secondSide <= thirdSide || secondSide + thirdSide <= firstSide || thirdSide + firstSide <= secondSide)
            {
                throw new ArgumentException("A triangle with these sides cannot exist");
            }

            _firstSide = firstSide;
            _secondSide = secondSide;
            _thirdSide = thirdSide;
        }

        public double CalculateArea()
        {
            var p = (_firstSide + _secondSide + _thirdSide) / 2;

            return Math.Sqrt(p * (p - _firstSide) * (p - _secondSide) * (p - _thirdSide));
        }

        public bool IsRight()
        {
            return (_firstSide == Math.Sqrt(Math.Pow(_secondSide, 2) + Math.Pow(_thirdSide, 2))
                     || _secondSide == Math.Sqrt(Math.Pow(_firstSide, 2) + Math.Pow(_thirdSide, 2))
                     || _thirdSide == Math.Sqrt(Math.Pow(_firstSide, 2) + Math.Pow(_secondSide, 2)));
        }
    }
}
