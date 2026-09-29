using System;

namespace HelloWorld;

class Program
{
    static void Main(string[] args)
    {
        // Datos
        int numero1;
        long numeroLargo;
        char caracter;
        string palabra;
        float radio;
        double pi;
        bool encendido;

        // Entrada de datos
        Console.Write("Escriba un numero entero: ");
        numero1 = int.Parse(Console.ReadLine());

        Console.Write("Escriba un numero largo: ");
        numeroLargo = long.Parse(Console.ReadLine());

        Console.Write("Escribe un caracter: ");
        caracter = char.Parse(Console.ReadLine());

        Console.Write("Escriba una palabra: ");
        palabra = Console.ReadLine();

        Console.Write("Escriba un numero con punto: ");
        radio = float.Parse(Console.ReadLine());

        Console.Write("Escribe el valor de PI: ");
        pi = double.Parse(Console.ReadLine());

        Console.Write("¿Está apagado? (true/false): ");
        encendido = bool.Parse(Console.ReadLine());
        

        //salida
        Console.WriteLine("Sus valores son: ");
        Console.WriteLine(numero1);
        Console.WriteLine(numeroLargo);
        Console.WriteLine(caracter);
        Console.WriteLine(palabra);
        Console.WriteLine(radio);
        Console.WriteLine(pi);
        Console.WriteLine(apagado);
        
    }
}
