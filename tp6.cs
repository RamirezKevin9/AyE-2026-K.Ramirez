bool repiticion = true;
string Ejercicio1(int N){
    string resultado;
    if (N > 0)
    {
        resultado = "El número es positivo.";
        return resultado;
    }
    else if (N < 0)
    {
        resultado = "El número es negativo";
        return resultado;
    }
    else
    {
        resultado = "El número es cero";
        return resultado;
    }
}
string Ejercicio2(int Q)
{
    string resultado;
    if (Q >= 18)
    {
        resultado = "¡Bienvenido a la fiesta!.";
        return resultado;
    }
    else
    {
        resultado = "Lo siento, eres muy joven";
        return resultado;
    }
}
string Ejercicio3(string contraseña)
{
    string resultado;
    if (contraseña == "python123")
    {
        resultado = "¡Contraseña correcta! Acceso concedido.";
        return resultado;
    }
    else
    {
        resultado = "¡Contraseña incorrecta, Autodestrucción en 5 minutos!";
        return resultado;
    }
}
string Ejercicio4(int numero)
{
    string resultado;
    if (numero % 2 == 0)
    {
        resultado = "El número es par.";
        return resultado;
    }
    else
    {
        resultado = "El número es impar.";
        return resultado;
    }
}
string Ejercicio5(int edad, bool compro)
{
    string resultado;
    if (edad >= 65 && compro == true)
    {
        resultado = "¡Felicidades! Tienes entrada gratuita al cine.";
        return resultado;
    }
    else
    {
        resultado = "Compra la entrada o raja de acá";
        return resultado;
    }
}


while (repiticion == true)
{
    Console.WriteLine("Ingrese el número del ejercicio que desea ejecutar (1=para numeros pares, 2=para la edad para ingresar la fiesta, 3=para contraseña, 4=para saver si es par/impar, 5=para entra al cine gratis, 0= para dejar de ejecutar):");
    int ejercicio = Convert.ToInt16(Console.ReadLine());
    switch (ejercicio)
    {
        case 0:
            repiticion = false;
            break;
        case 1:
            Console.WriteLine("Ingrese un número:");
            int N = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(Ejercicio1(N));
            break;
        case 2:
            Console.WriteLine("Ingrese su edad:");
            int Q = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(Ejercicio2(Q));
            break;
        case 3:
            Console.WriteLine("Ingrese su contraseña:");
            string contraseña = Console.ReadLine();
            Console.WriteLine(Ejercicio3(contraseña));
            break;
        case 4:
            Console.WriteLine("Ingrese un número:");
            int numero = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(Ejercicio4(numero));
            break;
        case 5:
            Console.WriteLine("Ingrese su edad");
            int edad = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(" ha comprado palomitas de maíz?");
            bool compro = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine(Ejercicio5(edad, compro));
            break;
        default:
            Console.WriteLine("Número de ejercicio no válido. Por favor, ingrese un número entre 1 y 5.");
            break;
    }
}