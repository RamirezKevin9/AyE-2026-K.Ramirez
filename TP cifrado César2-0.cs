Console.WriteLine("ingrese una frase para cifrarla o descifrarla: ");
string frase = Console.ReadLine().ToLower();
Console.WriteLine("ingrese el numero de desplazamiento: ");
int desplazamiento = Convert.ToInt16(Console.ReadLine());

static string Cifrar(string texto, int desplazamiento)
{
    desplazamiento = desplazamiento % 26;
    string resultado = "";
    for (int i = 0; i < texto.Length; i++)
    {
    char letra = texto[i];
        if (letra >= 'a' && letra <= 'z')
        {
            char baseLetra = 'a';
            char nueva = (char)(((letra - baseLetra + desplazamiento + 26) % 26) + baseLetra);
            resultado += nueva;
        }
        else
        {
            Console.WriteLine("No se permite caracteres especiales ingrese una frase válida.");
            break;
        }
    }
    return resultado;
}

static string Descifrar(string texto, int desplazamiento)
{
    desplazamiento = desplazamiento % 26;
    string resultado = "";
    for (int i = 0; i < texto.Length; i++)
    {
        char letra = texto[i];
        if (letra >= 'a' && letra <= 'z')
        {
            char baseLetra = 'a';
            char nueva = (char)(((letra - baseLetra - desplazamiento + 26) % 26) + baseLetra);
            resultado += nueva;
        }
        else
        {
            Console.WriteLine("No se permite caracteres especiales ingrese una frase válida.");
        }
    }
    return resultado;
}
Console.WriteLine("ingrese una frase para cifrarla o descifrarla: (c/d)");
string opcion = Console.ReadLine().ToLower();
if (opcion == "c")
{
    string cifrado = Cifrar(frase, desplazamiento);
    Console.WriteLine("Frase cifrada: " + cifrado);
}
else if (opcion == "d")
{
    string descifrado = Descifrar(frase, desplazamiento);
    Console.WriteLine("Frase descifrada: " + descifrado);
}
