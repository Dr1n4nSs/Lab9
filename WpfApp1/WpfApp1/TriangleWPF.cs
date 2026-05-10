using System;

namespace TriangleWPF
{
    public class Triangle
    {
        private double _a;
        private double _b;
        private double _c;

        public Triangle(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public double A
        {
            get
            {
                return _a;
            }
            set 
            { 
                if (value <= 0) throw new ArgumentException("Сторона A должна быть > 0");
                _a = value; 
            }
        }

        public double B
        {
            get
            {
                return _b;
            }
            set 
            { 
                if (value <= 0) throw new ArgumentException("Сторона B должна быть > 0");
                _b = value; 
            }
        }

        public double C
        {
            get
            {
                return _c;
            }
            set 
            { 
                if (value <= 0) throw new ArgumentException("Сторона C должна быть > 0");
                _c = value; 
            }
        }

        public bool Exists()
        {
            return (_a + _b > _c) && (_a + _c > _b) && (_b + _c > _a);
        }

        public double GetArea()
        {
            if (!Exists())
            {
                return 0;
            }
            double p = (_a + _b + _c) / 2.0;
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }
        
        public double GetPerimeter()
        {
            if (!Exists())
            {
                return 0;
            }
            return _a + _b + _c;
        }
        
        public static double operator - (Triangle triangle)
        {
            return triangle.GetArea();
        }
        
        public static implicit operator double(Triangle t)
        {
            return t.GetPerimeter();
        }

        public static explicit operator bool(Triangle t)
        {
            return t.Exists();
        }

        public static bool operator <(Triangle t1, Triangle t2)
        {
            return t1.GetArea() < t2.GetArea();
        }

        public static bool operator >(Triangle t1, Triangle t2)
        {
            return t1.GetArea() > t2.GetArea();
        }
    }
}