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
            set { SetProperty(ref r1, value); }
        }

        public double oper1;
        public double oper2;
        public double oper3;
        public double Oper1 { get { return oper1; } set { SetProperty(ref oper1, value); } }
        public double Oper2 { get { return oper2; } set { SetProperty(ref oper2, value); } }
        public double Oper3 { get { return oper3; } set { SetProperty(ref oper3, value); } }

        private ICommand calculateCommand;

        public ICommand CalculateCommand
        {
            get { return calculateCommand; }
            set { calculateCommand = value; }
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
    }
}
