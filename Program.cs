using System;

namespace Test {
    class Test {
        //пока не инициализированы
        Square.Circle c1;
        Square.Triangle t1;

        //эти скорее всего уже из файла с мешем загружены
        Square.Vector a = new Square.Vector(0, 0);
        Square.Vector b = new Square.Vector(1, 0);
        Square.Vector c = new Square.Vector(0, 1);
        
        public Test() {
            c1 = new Square.Circle(1.0f);
            t1 = new Square.Triangle(ref a, ref b, ref c);
        }

        //в параметре указан интерфейс
        public void CalculateSquareOfAShape(Square.Shape shape) {
            Console.WriteLine("Square:{0}",shape.GetSquare());
        }

        //оба класса реализуют интерфейс и могут быть использованы
        public void Run() {
            CalculateSquareOfAShape(c1);
            CalculateSquareOfAShape(t1);
        }
    }

    class Program {
        static void Main(string[] args) {
            Test test=new Test();
            test.Run();
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
