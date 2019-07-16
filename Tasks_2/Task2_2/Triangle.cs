using System;

namespace Task2_2
{
    class Triangle
    {
        private double _A;
        private double _B;
        private double _C;

        private double area;
        private double perimetr;

        public double A
        {
            get => _A;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side must be positive");
                }
                _A = value;
            }
        }

        public double B
        {
            get => _B;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side must be positive");
                }
                _B = value;
            }
        }

        public double C
        {
            get => _C;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side must be positive");
                }
                _C = value;
            }
        }


        public Triangle(double a, double b, double c)
        {
            if (a + b >= c && a + c >= b && b + c >= a)
            {
                A = a;
                B = b;
                C = c;
                CalculateParams();
            }
            else
            {
                throw new ArgumentException("Error in triangle sides");
            }
        }
        private void CalculateParams()
        {
            perimetr = CalcPerimetr();
            area = CalcArea();
        }

        private double CalcPerimetr()
        {
            return A + B + C;
        }

        private double CalcArea()
        {
            var semiper = perimetr / 2;
            return Math.Sqrt(semiper * (semiper - _A) * (semiper - _B) * (semiper - _C));
        }

        public double GetPerimetr => perimetr;
        public double GetArea => area;

        public override string ToString()
        {
            return $"Triangle with sides {_A} {_B} {_C}";
        }
    }
}
