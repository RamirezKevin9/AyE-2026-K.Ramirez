using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> resultados = new List<string>();

        Ejercicio1(resultados);
        Ejercicio2(resultados);
        Ejercicio3(resultados);
        Ejercicio4(resultados);
        Ejercicio5(resultados);
        Ejercicio6(resultados);
        Ejercicio7(resultados);
        Ejercicio8(resultados);
        Ejercicio9(resultados);
        Ejercicio10(resultados);

        GuardarResultados(resultados);
        MostrarResultados();
    }

    static void Ejercicio1(List<string> resultados)
    {
        Console.WriteLine("Ingrese un número de dos cifras:");
        int num1 = Convert.ToInt32(Console.ReadLine());

        resultados.Add("Ejercicio 1");

        if (num1 >= 10 && num1 <= 99)
        {
            resultados.Add("Unidades: " + (num1 % 10));
            resultados.Add("Decenas: " + (num1 / 10));
        }
        else resultados.Add("Error");
    }

    static void Ejercicio2(List<string> resultados)
    {
        Console.WriteLine("Indicar un número de tres cifras:");
        int num2 = Convert.ToInt32(Console.ReadLine());

        resultados.Add("Ejercicio 2");

        if (num2 >= 100 && num2 <= 999)
        {
            resultados.Add("Valor: " + num2);
            resultados.Add("Cifra central: " + ((num2 / 10) % 10));
        }
        else resultados.Add("Error");
    }

    static void Ejercicio3(List<string> resultados)
    {
        Console.WriteLine("Indicar precio de lista:");
        int precio = Convert.ToInt32(Console.ReadLine());

        resultados.Add("Ejercicio 3");

        if (precio > 0)
        {
            int descuento = precio * 18 / 100;
            int precioFinal = precio - descuento;

            resultados.Add("Precio con descuento: $" + precioFinal);
        }
        else resultados.Add("Error");
    }

    static void Ejercicio4(List<string> resultados)
    {
        Console.WriteLine("Número de dos cifras:");
        int num4 = Convert.ToInt32(Console.ReadLine());

        resultados.Add("Ejercicio 4");

        if (num4 >= 10 && num4 <= 99)
        {
            int perm = (num4 % 10) * 10 + (num4 / 10);
            resultados.Add("Permutado: " + perm);
        }
        else resultados.Add("Error");
    }

    static void Ejercicio5(List<string> resultados)
    {
        Console.WriteLine("Fecha (6 dígitos):");
        int fecha = Convert.ToInt32(Console.ReadLine());

        resultados.Add("Ejercicio 5");

        if (fecha >= 100000 && fecha <= 999999)
        {
            int mes = (fecha / 100) % 100;

            if (mes >= 1 && mes <= 12)
                resultados.Add("Mes: " + mes);
            else
                resultados.Add("Mes inválido");
        }
        else resultados.Add("Error");
    }

    static void Ejercicio6(List<string> resultados)
    {
        Console.WriteLine("Lado del cuadrado:");
        int lado = Convert.ToInt32(Console.ReadLine());

        resultados.Add("Ejercicio 6");

        if (lado > 0)
        {
            resultados.Add("Perímetro: " + (lado * 4));
            resultados.Add("Superficie: " + (lado * lado));
        }
        else resultados.Add("Error");
    }

    static void Ejercicio7(List<string> resultados)
    {
        Console.WriteLine("Valor por hora:");
        int valor = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Horas trabajadas:");
        int horas = Convert.ToInt32(Console.ReadLine());

        resultados.Add("Ejercicio 7");

        if (valor > 0 && horas >= 0)
            resultados.Add("Sueldo: " + (valor * horas));
        else
            resultados.Add("Error");
    }

    static void Ejercicio8(List<string> resultados)
    {
        Console.WriteLine("Temperatura en Fahrenheit:");
        int f = Convert.ToInt32(Console.ReadLine());

        int c = (f - 32) * 5 / 9;

        resultados.Add("Ejercicio 8");
        resultados.Add("Celsius: " + c);
    }

    static void Ejercicio9(List<string> resultados)
    {
        Console.WriteLine("Hora 1:");
        int h1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Minutos 1:");
        int m1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Segundos 1:");
        int s1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Hora 2:");
        int h2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Minutos 2:");
        int m2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Segundos 2:");
        int s2 = Convert.ToInt32(Console.ReadLine());

        resultados.Add("Ejercicio 9");

        if (h1 >= 0 && h1 < 24 && m1 >= 0 && m1 < 60 &&
            s1 >= 0 && s1 < 60 && h2 >= 0 && h2 < 24 &&
            m2 >= 0 && m2 < 60 && s2 >= 0 && s2 < 60)
        {
            int t1 = h1 * 3600 + m1 * 60 + s1;
            int t2 = h2 * 3600 + m2 * 60 + s2;

            resultados.Add("Intervalo: " + (t2 - t1) + " segundos");
        }
        else resultados.Add("Error");
    }

    static void Ejercicio10(List<string> resultados)
    {
        Console.WriteLine("Número de 3 cifras:");
        int num10 = Convert.ToInt32(Console.ReadLine());

        resultados.Add("Ejercicio 10");

        if (num10 >= 100 && num10 <= 999)
        {
            resultados.Add("Unidades: " + (num10 % 10));
            resultados.Add("Decenas: " + ((num10 / 10) % 10));
            resultados.Add("Centenas: " + (num10 / 100));
        }
        else resultados.Add("Error");
    }

    static void GuardarResultados(List<string> resultados)
    {
        using (StreamWriter writer = new StreamWriter("resultados.txt", false))
        {
            foreach (string resultado in resultados)
            {
                writer.WriteLine(resultado);
            }
        }
    }

    static void MostrarResultados()
    {
        Console.WriteLine("Resultados leídos del archivo:");

        using (StreamReader reader = new StreamReader("resultados.txt"))
        {
            while (!reader.EndOfStream)
            {
                string? linea = reader.ReadLine();
                Console.WriteLine(linea);
            }
        }
    }
}