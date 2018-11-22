using System;

namespace Square {
    public interface Shape {
        double GetSquare();
    }

    public struct Vector {
        public float x;
        public float y;

        //конструктора без параметров быть не может

        public Vector(float _x, float _y) {
            x = _x;
            y = _y;
        }

        public Vector(Vector v) {
            x = v.x;
            y = v.y;
        }

        static public Vector operator -(Vector v1, Vector v2) {
            Vector ret;
            ret.x = v1.x - v2.x;
            ret.y = v1.y - v2.y;
            return ret;
        }

        public double Length() {
            return Math.Sqrt(x * x + y * y);
        }
    }

    public class Circle : Shape {
        private float radius;

        //чтоб могли менять радиус в процессе, если надо
        public float Radius {
            get { return radius; }
            set { radius = value; }
        }

        //приватный конструктор чтоб не создавали обьект без явного указания радиуса
        private Circle() { }

        public Circle(float _radius) {
            Radius = _radius;
        }

        //реализация интерфейса
        public double GetSquare() {
            return Math.PI * Radius * Radius;
        }
    }

    public class Triangle : Shape {



        private Vector a, b, c;

        //чтоб могли менять вершины в процессе, если надо
        //структуры копируются а не ссылаются
        public Vector A {
            get { return a; }
            set { a = value; }
        }

        public Vector B {
            get { return b; }
            set { b = value; }
        }

        public Vector C {
            get { return c; }
            set { c = value; }
        }

        //приватный конструктор чтоб не создавали без указания вершин
        private Triangle() { }

        public Triangle(ref Vector _A, ref Vector _B, ref Vector _C) {
            A = _A;
            B = _B;
            C = _C;
        }

        public double GetSquare() {
            Vector AB = new Vector(A - B);
            Vector BC = new Vector(B - C);
            Vector CA = new Vector(C - A);
            double lab = AB.Length();
            double lbc = BC.Length();
            double lca = CA.Length();
            double p = (lab + lbc + lca) / 2;
            return Math.Sqrt(p * (p - lab) * (p - lbc) * (p - lca));
        }
    }
}

