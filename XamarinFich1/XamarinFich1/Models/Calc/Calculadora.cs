using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFich1.Models.Calc
{
    public class Calculadora
    {
        //sumar, restar, multiplicar, dividir, potencia, raiz
        //resolver ecuaciones cuadráticas

        /// <summary>
        /// Constructor por defecto de la clase.
        /// </summary>
        public Calculadora() { }

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
            //Un bloque try-catch sirve para manejar excepciones. Una excepcion es una situacion anómala en un programa que provoca que este se cierre. Cuando una aplicación se cierra inesperadamente, seguro una excepción no se controló de forma correcta. En el bloque try, se colocan todas las sentencias que podrían llegar a lanzar una de estas situaciones anómalas, por ejemplo, una division por cero. En el bloque catch, se coloca la excepcion que se quiere controlar (en este caso, es una conocida, pero si no se conoce se coloca Exception, en lugar de DivideByZeroException) junto con el código que se ejecutará EN LUGAR DE QUE LA APLICACIÓN SE CIERRE. Tener en cuenta que todo en .NET puede lanzar excepciones, un programa bien hecho, debe controlar excepciones con bloques try-catch en, prácticamente, todo el código.
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
            //La clase estática Math, proporciona muchos métodos para calculos matemáticos. Explorarla!
            return Math.Pow(a, pot);
        }
        public double RaizCuadrada(double a)
        {
            return Math.Sqrt(a);
        }

        /*
         * La clase Calculadora, no define rutinas para manejar una ecuación cuadrática ya que esta puede ser tratada como una entidad (objeto) aparte.
         * Por ese motivo, se define una interfaz que haga uso de un objeto de tipo Cuadratic (que definiremos luego). Definimos el objeto, los resultados que nos interesan y un método que haga la llamada a la funcionalidad de Cuadratic para que el usuario de la clase Calculadora pueda hacer cálculos. Cabe señalar que un 'usuario' de una Clase, no se refiere al usuario de la pc como tal, si no a cualquier otra clase que haga uso de un objeto de tipo Calculadora, por ejemplo, el método Main, sería un usuario de Calculadora si es que instancia un objeto de esta clase.
         */
        Cuadratic eq;
        public double Raiz1 { get; set; }
        public double Raiz2 { get; set; }

        /// <summary>
        /// Asigna a las propiedades Raiz1 y Raiz2, los correspondientes valores de la raiz de la ecuacion cuadrática con coeficientes a, b, c donde a es el coeficiente principal.
        /// </summary>
        /// <param name="a">Coeficiente principal</param>
        /// <param name="b">Coeficiente lineal</param>
        /// <param name="c">Término independiente.</param>
        public void Resolvente(double a, double b, double c)
        {
            eq = new Cuadratic(); //Intancio Cuadratic para poder usarlo
            eq.Resolver(a, b, c); //Resuelvo el sistema
            Raiz1 = eq.R1; //Asigno las raíces
            Raiz2 = eq.R2;
        }
        #endregion
    }


    /*
     * Definición de la clase Cuadratic.
     */
    internal class Cuadratic
    {
        #region Propiedades
        /*
         * Recordemos: las propiedades son métodos especiales que referencian una variable interna del objeto, normalmente declaradas privadas para que los usuarios de la clase, no puedan acceder a ellas desde el exterior.
         * Las propiedades son siempre publicas y si o si deben devolver un valor. No reciben parámetros ya que poseen uno implícito llamado value. Ese parámetro sirve para asignarle a la variable interna, un valor que el usuario desee.
         */
        private double _r1;
        public double R1
        {
            //parte get, devuelve la variable
            get { return _r1; }
            //parte set, por medio de value, asigno a la variable interna, el valor que se desea. En este caso, set es privado para permitir solo el seteo dentro de la definicion de la clase Cuadratic. Desde fuera, sólo se podrá recuperar su valor (get).
            private set { _r1 = value; }
        }
        /*
         * USO: supongamos que tenemos un objeto Cuadratic cu ya instanciado (con el operador new). entonces podemos usar R1, de la siguiente forma:
         *              Console.WriteLine(cu.R1);
         *Esa linea escribe en consola el valor de R1 si es que está asignado (por defecto valdrá cero).
         */

        private double _r2;
        public double R2
        {
            get { return _r2; }
            private set { _r2 = value; }
        }
        #endregion

        public Cuadratic()
        {
            R1 = double.NaN;
            R2 = double.NaN;
        }

        /// <summary>
        /// Calcula el determinante de a, b c
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool Discriminante(double a, double b, double c)
        {
            return (Math.Pow(b, 2) - (4 * a * c)) != 0;
        }

        /// <summary>
        /// Si el discriminante es válido, calcula las raíces de la ecuacion dada por a, b, c.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
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

        /// <summary>
        /// Constructor por defecto. Asigna 2 elementos si es que no se proporciona valor al parámetro
        /// </summary>
        /// <param name="cant">Cantidad de elementos que posee el vector</param>
        public Vector(int cant = 0)
        {           
            if (cant == 0) v = new int[2];
            else v = new int[cant];
        }

        /// <summary>
        /// Constructor en base a un arreglo de enteros. Construye un vector con los elementos pasados por parámetro.
        /// </summary>
        /// <param name="a">Vector de elementos que conforman el Vector</param>
        public Vector(int[] a)
        {
            //le asigno a v, la misma cantidad de elementos que a
            v = new int[a.Length];
            //Cant estará determinado para este caso ya que poseerá los mismos elementos de a.
            Cant = a.Length;
            //Copio los valores.
            Array.Copy(a, v, a.Length);
        }
        /// <summary>
        /// Generate a random vector
        /// </summary>
        /// <param name="cant">Cantidad de elementos que desea</param>
        /// <param name="min">Valor mínimo posible de un elemento</param>
        /// <param name="max">Valor máiximo posible de un elemento</param>
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

        /*
         * INDIZADOR: un indizador sirve para acceder de forma indexada a los elementos internos de un Vector. En realidad, brinda la posibilidad a un objeto Vector de usar los corchetes para acceder a los elementos del arreglo interno 'v' en lugar de estar devolviendo ese arreglo.
         */
        public int this[int index]
        {
            get { return v[index]; }
            set { v[index] = value; }
        }

        //Agregar: agrega un elemento al final del vector
        public void Add(int a)
        {
            if (Cant < v.Length)
            {
                v[Cant++] = a;
            }
            else
            {
                int[] aux = new int[1 + Cant];
                Array.Copy(this.v, aux, v.Length);
                v = aux;
                Add(a);
            }
        }

        /*
         * Método de copia. Los métodos de copia serán llamados desde fuera de la clase. Su uso será, para un vector v1 con n elementos y un vector v2 al que se le quiere asignar una copia exacta de v1 (v2 puede ser nulo, por eso el parámetro se define con out):
         *          v1.Copy(out v2);
         * Notar que CopiaMejorado hace una copia con Array.Copy que está optimizado para ser muy veloz.
         */
         /// <summary>
         /// Copia en a, los elementos del objeto que llama al método
         /// </summary>
         /// <param name="a">Vector destino de los datos</param>
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
        public double ProductoPunto(Vector a)
        {
            double result = 0D;
            if (a.Cant != Cant) throw new InvalidOperationException();
            for (int i = 0; i < this.Cant; i++)
            {
                result += this[i] * a[i];
            }
            return result;
        }
        //producto vectorial
        public Vector ProductoVectorial(Vector a)
        {
            if (Cant != 3 || a.Cant != 3) throw new InvalidOperationException();
            Vector aux = new Vector(this.Cant);
            //Componenete x
            aux[0] = this[1] * a[2] - a[1] * this[2];
            aux[1] = this[0] * a[2] - a[0] * this[2];
            aux[2] = this[0] * a[1] - a[0] * this[1];

            return aux;
        }

        public override string ToString()
        {
            return string.Format("[{0} {1} {2}]", v[0], v[1], v[2]);
        }
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
