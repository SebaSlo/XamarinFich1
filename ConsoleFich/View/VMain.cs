using System;
using System.Collections.Generic;
using System.Text;
using XamarinFich1.ViewModels;

namespace ConsoleFich.View
{
    public enum OpcionesConsoleApp { Calculadora, Agenda, Zodiaco, salir };
    
    public class VMain:VMBase
    {

        private OpcionesConsoleApp opCode;
        public OpcionesConsoleApp OpCode
        {
            get { return opCode; }
            set { opCode = value; }
        }

        private OpcionesCalcApp opCalc;
        private VMMain vm;

        public OpcionesCalcApp OpCalc
        {
            get { return opCalc; }
            set { opCalc = value; }
        }

        public VMain(VMMain viemodel)
        {
            Title = "APP CONSOLE FICH. Curso de programación C#";
            Console.Title = Title;
            vm = viemodel;
        }

        /// <summary>
        /// Método que ejecuta un programa cliente de consola con un menú
        /// Ejemplo usado en curso FICH
        /// Este método le da la interfaz de usuario principal a la aplicacion de consola
        /// </summary>
        public void AppConsoleRun()
        {
            do
            {
                EscribirMenu();
                Linea(); //escribe una linea en blanco
                Console.Write("Elija una opcion: ");

                try
                {
                    OpCode = (OpcionesConsoleApp)Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Cometiste un error, te pedí un numero y me diste lo que se te canto." + e + "\n\n\nPresioná [enter] para reiniciar");
                    Console.ReadKey();
                    continue;
                }


                //Decidir qué hacer dependiendo del opCode
                switch (OpCode)
                {
                    case OpcionesConsoleApp.Calculadora:
                        {
                            CalcRun();
                            break;
                        }
                    case OpcionesConsoleApp.Agenda:
                        {
                            //ejecutar la agenda
                            break;
                        }
                    case OpcionesConsoleApp.Zodiaco:
                        {
                            //Ejecutar app zodíaco
                            break;
                        }
                    case OpcionesConsoleApp.salir:
                        {
                            break;
                        }
                    default:
                        {
                            Linea();
                            Console.WriteLine("Elija un número entre 1 y 4");
                            Console.WriteLine("Presione una tecla para reiniciar");
                            Console.ReadKey();

                            break;
                        }
                }

            } while (OpCode != OpcionesConsoleApp.salir);
        }

        /// <summary>
        /// Lógica para manejo de la calculadora
        /// Este método lo que hace es dar una interfaz de uso a la calculadora
        /// </summary>
        private void CalcRun()
        {
            /* El eljemplo de calculadora muestra uso de:
             *  enum
             *  uso de switch con enum
             *  clase internal
             *  paso de parametros de salida
             *  creación de un menú de consola
             *  uso de clases
             *  string.Format()
             *  bloques try-catch
             *  lectura desde teclado de elementos numericos
             */
            double op1 = 0;
            double op2 = 0;

            //borrar consola.
            Console.Clear();

            //Menu calculadora
            do
            {
                Linea();
                Console.WriteLine("Calculadora:");
                Console.WriteLine("------------");
                Console.WriteLine("\n\t1) {0}\n\t2) {1}\n\t3) {2}\n\t4) {3}\n\t5) {4}\n\t6) {5}\n\t7) {6}\n\t8) {7}\n\t {8}",
                    OpcionesCalcApp.Sumar,
                    OpcionesCalcApp.Restar,
                    OpcionesCalcApp.Multiplicar,
                    OpcionesCalcApp.Dividir,
                    OpcionesCalcApp.Potencia,
                    OpcionesCalcApp.Raiz,
                    OpcionesCalcApp.Ecuacion_Cuadratica,
                    OpcionesCalcApp.Vectores,
                    OpcionesCalcApp.Salir);

                Linea();

                //Leer op
                Console.Write("Elija una opcion: ");
                OpCalc = (OpcionesCalcApp)Convert.ToInt32(Console.ReadLine()) - 1;
                VMCalculadora cal = new VMCalculadora(null);
                switch (OpCalc)
                {
                    case OpcionesCalcApp.Sumar:
                        {
                            PedirOperandos(out op1, out op2);
                            cal.Resolver(OpCalc, op1, op2);
                            Console.WriteLine("La suma es: " + cal.Result);
                            break;
                        }
                    case OpcionesCalcApp.Restar:
                        {
                            PedirOperandos(out op1, out op2);
                            cal.Resolver(OpCalc, op1, op2);
                            Console.WriteLine("La Resta es: " + cal.Result);
                            break;
                        }
                    case OpcionesCalcApp.Multiplicar:
                        {
                            PedirOperandos(out op1, out op2);
                            cal.Resolver(OpCalc, op1, op2);
                            Console.WriteLine("El producto es: " + cal.Result);
                            break;
                        }
                    case OpcionesCalcApp.Dividir:
                        {
                            PedirOperandos(out op1, out op2);
                            cal.Resolver(OpCalc, op1, op2);
                            Console.WriteLine("El cociente es: " + cal.Result);
                            break;
                        }
                    case OpcionesCalcApp.Potencia:
                        {
                            PedirOperandos(out op1, out op2);
                            cal.Resolver(OpCalc, op1, op2);
                            Console.WriteLine("La Potencia es: " + cal.Result);
                            break;
                        }
                    case OpcionesCalcApp.Raiz:
                        {
                            Console.Write("operando : ");
                            double.TryParse(Console.ReadLine(), out op1);
                            cal.Resolver(OpCalc, op1, op2);
                            Console.WriteLine("La raíz es: " + cal.Result);
                            break;
                        }
                    case OpcionesCalcApp.Ecuacion_Cuadratica:
                        {
                            double a = 0;
                            double b = 0;
                            double c = 0;

                            Linea();
                            Console.WriteLine("Por favor, escriba los coeficientes de la ecuacion cuadratica");

                            Console.Write("A: ");
                            double.TryParse(Console.ReadLine(), out a);

                            Console.Write("B: ");
                            double.TryParse(Console.ReadLine(), out b);

                            Console.Write("C: ");
                            double.TryParse(Console.ReadLine(), out c);

                            //Resolver la ecuacion
                            cal.Resolver(OpCalc, a, b, c);
                            //Escribir las raíces
                            Console.WriteLine("Raiz 1: {0}\nRaiz 2: {1}", cal.R1, cal.R2);

                            break;
                        }
                    case OpcionesCalcApp.Vectores:
                        {
                            Console.WriteLine("Escriba los vectores separados por espacios.");
                            Console.Write("Vector 1:");
                            cal.Vector1= Console.ReadLine();
                            Console.Write("Vector 2:");
                            cal.Vector2 = Console.ReadLine();

                            cal.ProductoPunto();
                            Console.WriteLine("Producto Punto: {0}", cal.VectorResult);
                            cal.ProductoVectorial();
                            Console.WriteLine("Producto vectorial: {0}", cal.VectorResult);

                            break;
                        }
                    case OpcionesCalcApp.Salir:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Elija una opcion correcta, no me haga renegar.");
                        break;
                }
            } while (OpCalc != OpcionesCalcApp.Salir);

        }

        /// <summary>
        /// Pide dos operandos al usuario por consola
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        private void PedirOperandos(out double op1, out double op2)
        {
            Console.Write("operador 1: ");
            double.TryParse(Console.ReadLine(), out op1);
            Linea();

            Console.Write("operador 2: ");
            double.TryParse(Console.ReadLine(), out op2);
            Linea();
        }

        /// <summary>
        /// Escribe el menú ppal
        /// </summary>
        private void EscribirMenu()
        {
            Console.Clear();
            Linea();
            Console.WriteLine("Curso FICH - Clase 1");
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("\t1) " + OpcionesConsoleApp.Calculadora);
            Console.WriteLine("\t2) " + OpcionesConsoleApp.Agenda);
            Console.WriteLine("\t3) " + OpcionesConsoleApp.Zodiaco);
            Console.WriteLine("\t4) " + OpcionesConsoleApp.salir);

        }

        /// <summary>
        /// Escribe una línea en blanco
        /// </summary>
        private static void Linea() { Console.WriteLine(); }
    }
}
