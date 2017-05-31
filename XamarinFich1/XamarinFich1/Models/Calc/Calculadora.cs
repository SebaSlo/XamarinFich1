using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFich1.Model.Calc
{
    public class Calculadora
    {
        //sumar, restar, multiplicar, dividir, potencia, raiz
        //resolver ecuaciones cuadráticas

        public Calculadora(){ }

        #region Métodos
        public double Suma(double a, double b)
        {
            return a + b;
        }
        public double Resta(double a, double b)
        {
            return a - b;
        }
        public double Producto(double a, double b)
        {
            return a * b;
        }
        public double Cociente(double a, double b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException)
            {
                return double.NaN;
            }
        }
        public double Potencia(double a, int pot)
        {
            return Math.Pow(a, pot);
        }
        public double RaizCuadrada(double a)
        {
            return Math.Sqrt(a);
        }

        Cuadratic eq;
        public double Raiz1 { get; set; }
        public double Raiz2 { get; set; }

        public void Resolvente(double a, double b, double c)
        {
            eq = new Cuadratic();
            eq.Resolver(a, b, c);
            Raiz1 = eq.R1;
            Raiz2 = eq.R2;
        }
        #endregion
    }

    internal class Cuadratic
    {
        private double _r1;

        public double R1
        {
            get { return _r1; }
            private set { _r1 = value; }
        }

        private double _r2;

        public double R2
        {
            get { return _r2; }
            private set { _r2 = value; }
        }

        public Cuadratic()
        {
            R1 = double.NaN;
            R2 = double.NaN;
        }

        private bool Discriminante(double a, double b, double c)
        {
            return (Math.Pow(b, 2) - (4 * a * c)) != 0;
        }

        public void Resolver(double a, double b, double c)
        {

            if (Discriminante(a, b, c))
            {
                R1 = ((-b) + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
                R2 = ((-b) - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
            }
            else
            {
                return;
            }
        }

    }

    internal class Vector
    {

        public int[] v;
        public int Cant { get; set; }
        public Vector(int cant = 0)
        {
            Cant = cant;
            if (Cant == 0) v = new int[2];
            else v = new int[Cant];
        }
        public Vector(int[] a)
        {
            v = new int[a.Length];
            Cant = a.Length;
            for (int i = 0; i < a.Length; i++)
            {
                v[i] = a[i];
            }
        }
        public Vector(int cant, int min, int max)
        {
            v = new int[cant];
            Cant = cant;
            Random r = new Random();
            for (int i = 0; i < cant; i++)
            {
                v[i] = r.Next(min, max);
            }
        }
        public int this[int index]
        {
            get { return v[index]; }
            set { v[index] = value; }
        }

        //Agregar: agrega un elemento al final del vector
        public void Add(int a)
        {
            int[] aux = new int[++Cant];
            Array.Copy(this.v, aux, Cant - 1);
            //for (int i = 0; i < Cant-1; i++)
            //{
            //    aux[i] = v[i];
            //}
            aux[Cant - 1] = a;
            v = aux;
        }

        public void Copy(out Vector a)
        {
            a = new Vector(Cant);
            for (int i = 0; i < Cant; i++)
            {
                a[i] = this.v[i];
            }
        }
        public void CopyMejorado(out Vector a)
        {
            a = new Vector(Cant);
            Array.Copy(this.v, a.v, Cant);
        }

        //Implementar los siguientes métodos
        //producto punto
        public double ProductoPunto(Vector a, Vector b)
        {
            throw new NotImplementedException();
            
        }
        //producto vectorial
        public Vector ProductoVectorial(Vector a, Vector b)
        {
            throw new NotImplementedException();
        }

        #region Pruebas
        /*
        Calc.Model.Vector vec = new Calc.Model.Vector(new int[] { 2, 3, 4 });
        vec.Add(6);
        for (int i = 0; i<vec.Cant; i++)
        {
            Console.Write(" " + vec[i]);
        }
    Console.WriteLine();
        Console.WriteLine();

        Calc.Model.Vector vecGrande = new Calc.Model.Vector(10000000, 1);
        for (int i = 0; i<vecGrande.Cant; i++)
        {
            Console.Write(" " + vecGrande[i]);
        }

Prueba de velocidad
Calc.Model.Vector vecCopia;
DateTime inicio = DateTime.Now;
vecGrande.Copy(out vecCopia);
        DateTime fin = DateTime.Now;
TimeSpan elapsed = fin.Subtract(inicio);
Console.WriteLine("La copia elemento a alemento duró: " + elapsed.TotalSeconds.ToString("0.00"));
        Console.WriteLine();

        Calc.Model.Vector vecCopia2 = new Calc.Model.Vector(vecGrande.Cant);
inicio = DateTime.Now;
        Array.Copy(vecGrande.v, vecCopia2.v, vecGrande.Cant);
        fin = DateTime.Now;
        elapsed = fin.Subtract(inicio);
        Console.WriteLine("La copia con Array.Copy duró: " + elapsed.TotalSeconds.ToString("0.00"));
        Console.WriteLine();*/
        #endregion
    }

    internal class Matriz2x2
    {
        private int[][] m;

        public Matriz2x2()
        {
            m = new int[2][];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = new int[2];
            }
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public Matriz2x2(int a, int b, int c, int d)
        {
            m = new int[2][];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = new int[2];
            }
            m[0][0] = a;
            m[0][1] = b;
            m[1][0] = c;
            m[1][1] = d;
        }

        public void Copy(ref Matriz2x2 destino)
        {
            destino = new Matriz2x2(this.m[0][0], this.m[0][1], this.m[1][0], this.m[1][1]);
        }

        public double Determinante()
        {
            return m[0][0] * m[1][1] - m[1][0] * m[0][1];
        }

        public override string ToString()
        {
            return string.Format("{0} {1}\n{2} {3}", m[0][0], m[0][1], m[1][0], m[1][1]);
        }

        //Implementar los siguientes métodos
        //Sumar
        //Multiplicar
        //Inversa

        #region Pruebas
        /*
            Calc.Model.Matriz2x2 mat = new Calc.Model.Matriz2x2(2, 3, 1, 4);
            Calc.Model.Matriz2x2 mat2 = new Calc.Model.Matriz2x2();
            mat.Copy(ref mat2);

            Console.WriteLine(mat);
            Console.WriteLine();
            Console.WriteLine(mat2);
         */
        #endregion
    }
}
