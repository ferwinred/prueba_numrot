namespace ejercicio_1;
using System;

public class EcuacionCuadratica
{
    static void Main(string[] args)
    {

        Console.WriteLine("Solucionemos la Ecuación cuadrática A**2 + B**2 = C**2");

        // Mostrar el menú
        Console.WriteLine("\nSeleccione una opción:");

        Console.WriteLine("1. Calcular soluciones generales para A y B en función de C");

        Console.WriteLine("2. Calcular solucion particular para A dados B y C");
        
        Console.WriteLine("3. Calcular solucion particular para B dados A y C");
        
        Console.WriteLine("4. Validar si se cumple la función cuadratica dados los valores de A, B y C");

        Console.WriteLine("5. Salir");

        // Leer la opción del usuario
        Console.Write("Ingrese el número de la opción deseada: ");
        string opcion = Console.ReadLine();

        // Ejecutar la opción seleccionada
        switch (opcion)
        {
            case "1":
                CalcularSolucionesGenerales();
                break;
            case "2":
                CalcularADadosBC();
                break;
            case "3":
                CalcularBDadosAC();
                break;
            case "4":
                ComprobarEcuacionDadosValores();
                break;
            case "5":
                Console.WriteLine("Saliendo del programa...");
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }

    static void CalcularSolucionesGenerales()
    {
        Console.WriteLine("\nSoluciones para A y B en función de C en la ecuación A^2 + B^2 = C^2:");

        // Calcular la solución para A
        string solucionA = "A = √(C^2 - B^2) \nA = -√(C^2 - B^2)";

        // Calcular la solución para B
        string solucionB = "B = √(C^2 - A^2) \nB = -√(C^2 - A^2)";

        // Imprimir las soluciones generales
        Console.WriteLine($"Solución A: {solucionA}");
        Console.WriteLine($"Solución B: {solucionB}");

        Console.WriteLine("\nNota: Se muestra las soluciones en función de C, pero no se calculan valores numéricos específicos.");
    }

    static void CalcularADadosBC()
    {
        Console.WriteLine("Ingrese los valores de B y C en la ecuación A^2 + B^2 = C^2:");

        // Solicitar los valores de B y C en la ecuación
        Console.Write("Valor de B: ");
        if(!(Console.ReadLine().GetType() == Type.GetType("System.Int32")))
        {
            Console.WriteLine("Valor inválido, B deber ser un valor númerico");
            return;
        }
        double b = double.Parse(Console.ReadLine());

        Console.Write("Valor de C: ");
        if(!(Console.ReadLine().GetType() == Type.GetType("System.Int32")))
        {
            Console.WriteLine("Valor inválido, C deber ser un valor númerico");
            return;
        }
        double c = double.Parse(Console.ReadLine());

        // Calcular B dados A y C en la ecuación
        if (c == 0 || c < b)
        {
            Console.WriteLine("Sin Solución: Sí C es igual a cero o menor que B, la ecuación no tendría solución.");
            return;
        }

        if (b < 0 || c < 0)
        {
            Console.WriteLine("Sin Solución: Si loos valores de B, y C son menores a cero la ecuación no tiene solución.");
            return;
        }

        double valorA = Math.Sqrt((Math.Pow(c,2))-(Math.Pow(b,2)));


        // Mostrar la solución para B dados A y C en la ecuación
        if (valorA == 0)
        {
            Console.WriteLine($"Solución: A={valorA}");
            Console.WriteLine("\nNota: si B y C son iguales entonces A debe igualarse a 0");

            return;

        }

        Console.WriteLine($"Solución: A={valorA} A={-valorA}");
        Console.WriteLine("\nNota: Como pudo notar mientras se cumpla que C es mayor que B existen dos posibles soluciones para A que cumplirían la igualdad en la ecuación cuadrática  A^2 + B^2 = C^2");
    

    }

    static void CalcularBDadosAC()
    {
        Console.WriteLine("Ingrese los valores de A y C en la ecuación A^2 + B^2 = C^2:");

        // Solicitar los valores de A y C en la ecuación
        Console.Write("Valor de A: ");
        if(!(Console.ReadLine().GetType() == Type.GetType("System.Int32")))
        {
            Console.WriteLine("Valor inválido, A deber ser un valor númerico");
            return;
        }
        double a = double.Parse(Console.ReadLine());

        Console.Write("Valor de C: ");
        if(!(Console.ReadLine().GetType() == Type.GetType("System.Int32")))
        {
            Console.WriteLine("Valor inválido, C deber ser un valor númerico");
            return;
        }
        double c = double.Parse(Console.ReadLine());

         if (a < 0 || c < 0)
        {
            Console.WriteLine("Sin Solución: Si loos valores de A, y C son menores a cero la ecuación no tiene solución.");
            return;
        }

        if (c == 0 || c < a)
        {
            Console.WriteLine("Sin Solución: Sí C es igual a cero o menor que A, la ecuación no tendría solución.");
            return;
        }

        // Calcular B dados A y C en la ecuación
        double valorB = Math.Sqrt((Math.Pow(c,2))-(Math.Pow(a,2)));

        // Mostrar la solución para B dados A y C en la ecuación
        if (valorB == 0)
        {
            Console.WriteLine($"Solución: B={valorB}");
            Console.WriteLine("\nNota: si B y C son iguales entonces A debe igualarse a 0");
        } else {
            Console.WriteLine($"Solución: B={valorB} B={-valorB}");
            Console.WriteLine("\nNota: Como pudo notar mientras se cumpla que C es mayor que A existen dos posibles soluciones para B que cumplirían la igualdad en la ecuación cuadrática  A^2 + B^2 = C^2");
        }

    }

    static void ComprobarEcuacionDadosValores()
    {
        Console.WriteLine("Ingrese los valores de A, B y C en la ecuación A^2 + B^2 = C^2:");

        //Solicitar los valores para A, B Y C
        Console.Write("Valor de A: ");
        if(!(Console.ReadLine().GetType() == Type.GetType("System.Int32")))
        {
            Console.WriteLine("Valor inválido, A deber ser un valor númerico");
            return;
        }
        double a = double.Parse(Console.ReadLine());

        Console.Write("Valor de B: ");
        if(!(Console.ReadLine().GetType() == Type.GetType("System.Int32")))
        {
            Console.WriteLine("Valor inválido, B deber ser un valor númerico");
            return;
        }
        double b = double.Parse(Console.ReadLine());

        Console.Write("Valor de C: ");
        if(!(Console.ReadLine().GetType() == Type.GetType("System.Int32")))
        {
            Console.WriteLine("Valor inválido, C deber ser un valor númerico");
            return;
        }
        double c = double.Parse(Console.ReadLine());

        // Resolver la ecuación cuadrática
        if (a < 0 || b < 0 || c < 0)
        {
            Console.WriteLine("Error: Los valores de A, B y C deben ser mayores o iguales a cero.");
            return;
        }

        // Calcular el valor de A y B dados C
        if (c == 0)
        {
            Console.WriteLine("Error: C no puede ser igual a cero.");
            return;
        }

        double aCuadrado = Math.Pow(c, 2) - Math.Pow(b, 2);
        double bCuadrado = Math.Pow(c, 2) - Math.Pow(a, 2);

        // Verificar si los valores de A y B calculados son válidos
        if (aCuadrado < 0 || bCuadrado < 0)
        {
            Console.WriteLine("Error: No hay solución real para la ecuación proporcionada.");
            return;
        }

        // Tomar la raíz cuadrada de los resultados
        double resultadoA = Math.Sqrt(aCuadrado);
        double resultadoB = Math.Sqrt(bCuadrado);

        // Imprimir los resultados
        Console.WriteLine($"Para A = {resultadoA} y B = {resultadoB}, se cumple la ecuación cuadrática A^2 + B^2 = C^2.");
    }

}
