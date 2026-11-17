# ejercicio 1
def ejercicio1():
    for i in range(100):
        if i % 3 == 0:
            print(i)


# ejercicio 2
def ejercicio2():
    edad = int(input("Ingrese su edad: "))
    if edad >= 18:
        print("La edad es mayor a 18")
    elif edad < 18:
        print("La edad es menor a 18")
    else :
        print("La edad es igual a 18")


# ejercicio 3
def ejercicio3():
    palabra = input("Ingrese su palabra: ")
    for letra in palabra:
        print(letra)


# ejercicio 4
def ejercicio4():
    contraseña = "popeyeelmarinomaradonajunyor"
    for i in range(5):
        ingresar = input("Ingrese su ingresar: ")
        if contraseña == ingresar:
            print("Ingresaste bien la contra")
            break
        else:
            print("Los intentos que te quedan son:", 4 - i)


# ejercicio 5
def ejercicio5():
    print("ingrese 10 numeros")
    numeromax = 0
    for i in range(10):
        ingresar = int(input("Ingrese su numero: "))
        if ingresar > numeromax:
            numeromax = ingresar
    print("El numero maximo es:", numeromax)

# ejercicio 6

def ejercicio6():
    nombre = input("Ingrese su nombre: ")

    print("Hola", nombre.title())


# ejercicio 7

def ejercicio7():
    for i in range(1, 11):
        print("7 x", i, "=", 7 * i)


# ejercicio 8

def ejercicio8():
    for i in range(10, 0, -1):
        print(i)

    print("oa")


# ejercicio 9

def ejercicio9():
    numero = int(input("Ingrese un numero: "))

    if numero % 2 == 0:
        print("par")
    else:
        print("impar")


# ejercicio 10

def ejercicio10():
    frase = input("Ingrese una frase: ")
    contador = 0

    for letra in frase.lower():
        if letra in "aeiou":
            contador += 1

    print("La cantidad de vocales es:", contador)


# ejercicio 11

def ejercicio11():
    numero = int(input("Ingrese un numero: "))

    for i in range(1, 13):
        print(numero, "x", i, "=", numero * i)


# ejercicio 12

def ejercicio12():
    total = 0

    while total <= 100:
        numero = int(input("Ingrese un numero: "))
        total += numero

    print("El total acumulado es:", total)


# ejercicio 13

def ejercicio13():
    palabra = input("Ingrese una palabra: ")

    for letra in palabra:
        print(letra)


# ejercicio 14

def ejercicio14():
    edad = int(input("Ingrese su edad: "))

    puede_votar = edad >= 16
    puede_manejar = edad >= 17

    if puede_votar and puede_manejar:
        print("Puede votar y manejar")

    elif puede_votar:
        print("Puede votar")

    elif puede_manejar:
        print("Puede manejar")

    else:
        print("No puede hacer ninguna de las dos cosas")


# ejercicio 15

def ejercicio15():
    for i in range(50, -1, -5):
        print(i)


# ejercicio 16

def ejercicio16():
    while True:
        contraseña1 = input("Ingrese una contraseña: ")
        contraseña2 = input("Repita la contraseña: ")

        if contraseña1 == contraseña2:
            print("Acceso permitido")
            break
        else:
            print("Las contraseñas no coinciden, intente nuevamente")


# ejercicio 17

def ejercicio17():
    while True:
        nombre = input("Ingrese un nombre: ")

        if len(nombre) > 10:
            print("El nombre tiene mas de 10 caracteres")
            break


# ejercicio 18
def ejercicio18():
    oracion = input("Ingrese una oracion: ")
    contador = 0

    for letra in oracion.lower():
        if letra == "a":
            contador += 1

    print("La cantidad de letras a es:", contador)

while True:
    print("El papu menu")
    print("1. Multiplos de 3")
    print("2. Comprobar edad")
    print("3. Contar letras")
    print("4. Contraseña con 5 intentos")
    print("5. Numero maximo de 10 numeros")
    print("6. Saludar con mayusculas")
    print("7. Tabla del 7")
    print("8. Cuenta regresiva")
    print("9. Par o impar")
    print("10. Contar vocales")
    print("11. Tabla de multiplicar")
    print("12. Acumular hasta superar 100")
    print("13. Mostrar cada letra")
    print("14. Comprobar si puede votar o manejar")
    print("15. Numeros del 50 al 0")
    print("16. Confirmar contraseña")
    print("17. Nombre con mas de 10 caracteres")
    print("18. Contar letras a")
    print("0. Salir")

    opcion = int(input("Seleccione una opcion: "))

    if opcion == 1:
        ejercicio1()

    elif opcion == 2:
        ejercicio2()

    elif opcion == 3:
        ejercicio3()

    elif opcion == 4:
        ejercicio4()

    elif opcion == 5:
        ejercicio5()

    elif opcion == 6:
        ejercicio6()

    elif opcion == 7:
        ejercicio7()

    elif opcion == 8:
        ejercicio8()

    elif opcion == 9:
        ejercicio9()

    elif opcion == 10:
        ejercicio10()

    elif opcion == 11:
        ejercicio11()

    elif opcion == 12:
        ejercicio12()

    elif opcion == 13:
        ejercicio13()

    elif opcion == 14:
        ejercicio14()

    elif opcion == 15:
        ejercicio15()

    elif opcion == 16:
        ejercicio16()

    elif opcion == 17:
        ejercicio17()

    elif opcion == 18:
        ejercicio18()

    elif opcion == 0:
        print("Saliendo del programa...")
        break

    else:
        print("Opcion incorrecta")