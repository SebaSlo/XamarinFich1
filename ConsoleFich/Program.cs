using ConsoleFich.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XamarinFich1.Models.Text;

namespace ConsoleFich
{
    public abstract class Figure
    {
        public abstract void Perimetro();
        public abstract void Area();
    }

    class Cuadrado:Figure
    {
        public double lado;
        public double area, perimetro;

        public Cuadrado(){}

        public override void Area()
        {
            area = lado * lado;
        }

        public override void Perimetro()
        {
            perimetro = 4 * lado;
        }

        public void ListaCuad()
        {
            List<Figure> lC = new List<Figure>();
            lC.Add(new Cuadrado() {lado=2 });
            lC.Add(new Cuadrado(){lado=4 });
            lC.Add(new Cuadrado(){lado=6 });
            lC.Add(new Cuadrado() { lado = 7 });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region CodeRunApp
            //VMain mainApp = new VMain(new XamarinFich1.ViewModels.VMMain(null)
            //{
            //    Title = "Aplicacion de consola. Curso C# FICH"
            //});
            //mainApp.AppConsoleRun(); 
            #endregion

            /* La clase List<T>
                En C++ se cuenta con la clase vector<T> para manejo de un conjunto de datos adyacentes en memoria.
                La clase vector, no existe en C#. En su lugar, se cuenta con la clase genérica List<T> que funciona de la misma manera que vector en C++.
                Se encuentra implementada por arreglos y se posee el operador de indexación para acceder a los elementos, por lo cual, el acceso es muy veloz.
                Cuenta con operaciones de agregar, eliminar, buscar, insertar, ordenar, etc.
                La ventaja de esta clase es la velocidad de acceso a los elementos, es O(1). Las demás operaciones, tienen un costo algorítmico mucho mayor.
             */
            //Declaracion
            System.Collections.Generic.List<int> L ;
            L = new List<int>(new int[] { 1, 2, 3, 4, 5 });
            L.Add(3);

            L.Insert(2, 5);


            L.RemoveAt(2);

            L.Sort();
            var g = Array.BinarySearch(L.ToArray(), 6);

            L[2] = 10000;
            for (int i = 0; i < L.Count; i++)
            {
                Console.Write("Elemento {0}: {1} ",i, L[i]); 
            }

            Console.WriteLine(g);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();



            /* La clase LinkedList<T> y LinkedListNode<T>
             * En C#, la clase que maneja listas doblemente enlazadas, se llama LinkedList y también es genérica (sus elementos pueden ser cualquier tipo de dato). Para manejar una lista enlazada, se necesita contar con interadores que manejen el acceso a los elementos ya que no posee indexación, es decir, no se puede usar [] para acceder a los elementos. Si o si, necesitamos iniciar un bucle y movernos a travez de la lista para llegar a determinado valor. Esta funcionalidad, está representada por la clase LinkedListNode<T>, genérica.
             * Este tipo de estructura tiene la ventaja de contar con operaciones muy veloces para agregar, eliminar e insertar elementos, pero el acceso a ellos depende de la cantidad de elementos de la lista, es decir, es O(n).
             */
            //Declaracion e inicialización
            System.Collections.Generic.LinkedList<int> oLinked;
            oLinked = new LinkedList<int>(); //Lista con cero elementos
            oLinked = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5, 7 });

            //Recorrer sus elementos
            //Defino un 'iterador' al inicio de la lista
            LinkedListNode<int> it = oLinked.First;
            while (it != null)
            {
                Console.Write(it.Value + " ");
                it = it.Next;                
            }
            //Agregar y eliminar elementos
            it = oLinked.Last;
            oLinked.AddFirst(4); //Agrega un elemento al inicio
            oLinked.AddLast(4); //Agrega un elemento al final
            oLinked.AddBefore(it,5); //Agrega un elemento antes del valor apuntado por it
            oLinked.AddAfter(it,4); //Agrega un elemento despues del valor apuntado por it

            oLinked.Remove(5); //Quita el elemento 5, su primer aparición.
            oLinked.RemoveFirst(); //Quita el primer elemento
            oLinked.RemoveLast(); //Quita el ultimo elemento

            /* La clase ArrayList
             * La clase ArrayList no posee análogo en C++. Esta clase proporciona una colección de elementos los cuales pueden ser de diferentes tipos. Se encuentra dentro del espacio de nombres System.Collections ya que no es genérica. No está incluida en el .NetCore por lo que no se puede utilizar con librerías portables al igual que la clase HashTable. Ambas se ecuentran en el archivo mscorlib.dll que viene sólo en windows. Existen clases más poderosas que estas, por lo tanto, su ausencia no se notará para nada.
             */
             
            /*La clase Dictionary<TKey,TValue>
             * La clase Dictionary representa un par clave valor que podemos utilizar para representar un mapeo de datos. No es más que un mapa.
             * Si un par clave-valor no existe, se crea en el momento de la asignacion.
             * Las claves no pueden repetirse, al querer hacerlo, se pisa el valor anterior. 
             */
            Dictionary<string, int> map = new Dictionary<string, int>();
            map["B"] = 2;
            map["A"] = 1;
            Console.WriteLine(map["A"]);
            
            //Peguntar si existe una clave.
            Console.WriteLine(map.ContainsKey("A"));
            Console.WriteLine(map.ContainsValue(1));
            Console.WriteLine(map.ContainsValue(2));
            //chequear valores
            foreach (var item in map)
            {
                Console.WriteLine(item.Value);
            }
            //Recuperar todas las claves y todos los valores
            var claves = map.Keys;
            var valores = map.Values;

            /*La clase SortedDictionary<T>
             Es igual a la anterior, solo que la estructura se ordena automáticamente según la clave
             */
            SortedDictionary<string, int> Smap = new SortedDictionary<string, int>();
            Smap["B"] = 2;
            Smap["A"] = 1;
            foreach (var item in Smap)
            {
                Console.WriteLine(item.Value);
            }

            Dictionary<string, ConsoleColor> SettingsConsoleColor;
            SettingsConsoleColor = new Dictionary<string, ConsoleColor>();

            SettingsConsoleColor["color fondo"] = ConsoleColor.Magenta;
            SettingsConsoleColor["color texto"] = ConsoleColor.DarkBlue;

            Console.BackgroundColor = SettingsConsoleColor["color fondo"];
            Console.BackgroundColor = SettingsConsoleColor["color texto"];


            /*CONJUNTOS - las clases SortedSet<T> y HashSet<T>
             * Un conjunto está conformado por valores de un determinado tipo. En la teoría de conjuntos, no importa el órden en que estos se encuentran. En programación, los lenguajes suelen poseer clases que manejan conjuntos pero los ordenan automáticamente. El programador debe suponer que no es así.
             * C# proporciona dos clases para esto. Una que se ordena mediante algún criterio, y otra que no se ordena. En ambos, los elementos no se pueden repetir. Al querer agregar repeticiones, la clase se encarga de no agregarlos.
             */
            SortedSet<int> Sset = new SortedSet<int>(new int[] { 7, 2,3 , 4, 5, 6, 1, 7, 7, 7 });
            Console.WriteLine("Conjuntos");
            foreach (var item in Sset)
            {
                Console.Write(item + " ");
            }
            HashSet<int> Hset = new HashSet<int>(new int[] { 4, 5, 7, 1, 9, 3, 6, 3, 3, 3,4,8 });
            Console.WriteLine();
            Console.WriteLine("Conjuntos hash");
            foreach (var item in Hset)
            {
                Console.Write(item + " ");
            }
            /*PILAS Y COLAS - clases Queue<T> y Stack<T>
             * Este tipo de estructuras también están soportadas por el lenguaje. Las pilas (Stack) son del tipo Last In, First Out (ultimo en entrar, primero en salir). Las colas (Queue) son del tipo First In, First Out (primero en entrar, primero en salir).
             * Esto quiere decir que, en las pilas, agregamos y quitamos elementos solo desde el inicio, no podemos tocar el final.
             * En las colas, agregamos en el FINAL, y sacamos elementos por el INICIO.
             */
            Queue<int> cola = new Queue<int>(new int[] { 5, 2, 5, 6, 2 });
            cola.Enqueue(100);
            cola.Dequeue();
            Console.WriteLine();
            foreach (var item in cola)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Stack<int> pila = new Stack<int>(new int[] { 1,2,3,4,5,6});
            pila.Push(100);
            pila.Pop();
            var peek = pila.Peek();
            Console.WriteLine();
            foreach (var item in pila)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            /*La clase ObservableCollection<T>: interesante para los que hagan interfaces de usuario (UI)
             * Esta clase implementa la interfaz IObservable<T> que permite enviar un aviso a la interfaz si algun elemento de la colección se modificó. Y también funciona en sentido contrario. Si algun elemento en la interfaz, se modifica, también lo hace en el código. Esto es útil para no estar implementando eventos entre interfaz y código que manejen este tipo de interacción. ¿El beneficio? lograr separar la lógica de negocio de la lógica de la interfaz. Esto es importante para generar código portable y multiplataforma, o bien, crear una aplicacón con diferentes interfaces por plataforma. Se crea el código y lo único que se debe hacer, es decirle a la interfaz quién es la clase que contiene los datos que debe mostrar.
             * Su funcionalidad es exactamente igual a la de una lista. Permite agregar, buscar y eliminar elementos tal cual la clase List.
             */
            ObservableCollection<int> obs = new ObservableCollection<int>();
        }            
    }
}