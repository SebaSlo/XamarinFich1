using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinFich1.Helpers;
using XamarinFich1.Model.Calc;
using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    public enum OpcionesCalcApp { Sumar, Restar, Multiplicar, Dividir, Potencia, Raiz, Ecuacion_Cuadratica, Salir };

    public class VMCalculadora : VMBase
    {
        private Calculadora ca = new Calculadora();
        private Vector v1, v2;

        private double result;
        public double Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }


        private double r1;
        public double R1
        {
            get { return r1; }
            set { SetProperty(ref r1, value); }
        }


        private double r2;
        public double R2
        {
            get { return r2; }
            set { SetProperty(ref r2, value); }
        }

        public double oper1;
        public double oper2;
        public double oper3;
        public double Oper1 { get { return oper1; } set { SetProperty(ref oper1, value); } }
        public double Oper2 { get { return oper2; } set { SetProperty(ref oper2, value); } }
        public double Oper3 { get { return oper3; } set { SetProperty(ref oper3, value); } }
        public double a;
        public double b;
        public double c;
        public double A { get { return a; } set { SetProperty(ref a, value); } }
        public double B { get { return b; } set { SetProperty(ref b, value); } }
        public double C { get { return c; } set { SetProperty(ref c, value); } }

        private string vector1;
        public string Vector1
        {
            get { return vector1; }
            set
            {
                SetProperty(ref vector1, value);
            }
        }

        private string vector2;
        public string Vector2
        {
            get { return vector2; }
            set
            {
                SetProperty(ref vector2, value);
            }
        }


        private string vecResult;
        public string VectorResult
        {
            get { return vecResult; }
            set { SetProperty(ref vecResult, value); }
        }


        private ICommand calculateCommand;
        public ICommand CalculateCommand
        {
            get { return calculateCommand; }
            set { calculateCommand = value; }
        }


        private ICommand cuadraticResolve;
        public ICommand CuadraticResolve
        {
            get { return cuadraticResolve; }
            set { cuadraticResolve = value; }
        }

        private ICommand prodPunto;
        public ICommand ProdPunto
        {
            get { return prodPunto; }
            set { prodPunto = value; }
        }

        private ICommand prodVectorial;
        public ICommand ProdVectorial
        {
            get { return prodVectorial; }
            set { prodVectorial = value; }
        }

        public VMCalculadora(INavegable nav)
        {
            Title = "Calculadora re trucha";
            Navigator = nav;

            //Comanders
            CalculateCommand = new Command<string>(
                (i) =>
                {
                    var op = (OpcionesCalcApp)int.Parse(i);
                    Resolver(op, Oper1, Oper2, Oper3);
                },
                null);
            CuadraticResolve = new Command<string>(
                (i) =>
            {
                var op = (OpcionesCalcApp)int.Parse(i);
                Resolver(op, A, B, C);
            },
                (i) =>
            {
                return A != 0 && B != 0 && C != 0;
            });
            ProdPunto = new Command<string>(
                (a) =>
            {
                try
                {
                    this.AuxVectorTratment(Vector1, ref v1);
                    this.AuxVectorTratment(Vector2, ref v2);
                    VectorResult = v1.ProductoVectorial(v2).ToString();
                }
                catch (NullReferenceException e)
                {
                    this.VectorResult = "Poné bien los vectores! no admite el vector nulo!";
                    return;
                }
                catch (InvalidOperationException e)
                {
                    this.VectorResult = "Poné bien los vectores! Tienen que tener la misma cantidad de elementos!";
                    return;
                }
            }, null);
            ProdVectorial = new Command<string>(
                (a) =>
            {
                try
                {
                    this.AuxVectorTratment(Vector1,ref v1);
                    this.AuxVectorTratment(Vector2,ref v2);
                    VectorResult = v1.ProductoVectorial(v2).ToString();
                }
                catch (NullReferenceException e)
                {
                    this.VectorResult = "Poné bien los vectores! no admite el vector nulo!";
                    return;
                }
                catch (InvalidOperationException e)
                {
                    this.VectorResult = "Poné bien los vectores! Tienen que tener la misma cantidad de elementos!";
                    return;
                }
            }, null);
        }

        public void Resolver(OpcionesCalcApp opCalc, double op1 = 0, double op2 = 0, double op3 = 0)
        {
            switch (opCalc)
            {
                case OpcionesCalcApp.Sumar:
                    Result = ca.Suma(op1, op2);
                    break;
                case OpcionesCalcApp.Restar:
                    Result = ca.Resta(op1, op2);
                    break;
                case OpcionesCalcApp.Multiplicar:
                    Result = ca.Producto(op1, op2);
                    break;
                case OpcionesCalcApp.Dividir:
                    Result = ca.Cociente(op1, op2);
                    break;
                case OpcionesCalcApp.Potencia:
                    Result = ca.Potencia(op1, (int)op2);
                    break;
                case OpcionesCalcApp.Raiz:
                    Result = ca.RaizCuadrada(op1);
                    break;
                case OpcionesCalcApp.Ecuacion_Cuadratica:
                    {
                        ca.Resolvente(op1, op2, op3);
                        R1 = ca.Raiz1;
                        R2 = ca.Raiz2;
                        break;
                    }
                case OpcionesCalcApp.Salir:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Método que convierte un string con números en un Vector
        /// </summary>
        /// <param name="s">string source de los datos</param>
        /// <param name="v">Vector destino de los datos</param>
        private void AuxVectorTratment(string s,ref Vector v)
        {
            s.Trim();
            var aux = s.Split(' ');
            v = new Vector();
            foreach (string item in aux)
            {
                if (item != string.Empty && item != "") v.Add(int.Parse(item));
            }
        }
    }
}
