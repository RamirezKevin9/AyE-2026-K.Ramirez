
import random

# ejercicio 1
def ejercicio1():
    secreto = random.randint(1, 10)

    while True:
        numero = int(input("Adivine el numero del 1 al 10: "))

        if numero == secreto:
            print("Adivinaste!")
            break
        elif numero > secreto:
            print("El numero secreto es menor")
        else:
            print("El numero secreto es mayor")


# ejercicio 2
def ejercicio2():
    numero = int(input("Ingrese un numero: "))

    if numero == 0:
        print("El cero tiene infinitos divisores")
    else:
        for i in range(1, abs(numero) + 1):
            if numero % i == 0:
                print(i)


# ejercicio 3
def ejercicio3():
    numero1 = 0
    numero2 = 1

    for i in range(20):
        print(numero1)

        siguiente = numero1 + numero2
        numero1 = numero2
        numero2 = siguiente


# ejercicio 4
def ejercicio4():
    print("1. Suma")
    print("2. Resta")
    print("3. Multiplicacion")
    print("4. Division")

    opcion = int(input("Seleccione una operacion: "))

    numero1 = float(input("Ingrese el primer numero: "))
    numero2 = float(input("Ingrese el segundo numero: "))

    if opcion == 1:
        print("Resultado:", numero1 + numero2)
    elif opcion == 2:
        print("Resultado:", numero1 - numero2)
    elif opcion == 3:
        print("Resultado:", numero1 * numero2)
    elif opcion == 4:
        if numero2 != 0:
            print("Resultado:", numero1 / numero2)
        else:
            print("No se puede dividir por cero")
    else:
        print("Opcion incorrecta")


# ejercicio 5
def ejercicio5():
    numero = int(input("Ingrese un numero: "))
    factorial = 1

    if numero < 0:
        print("No existe factorial para numeros negativos")
    else:
        for i in range(1, numero + 1):
            factorial *= i

        print("El factorial es:", factorial)


# ejercicio 6
def ejercicio6():
    nombres = []

    while True:
        nombre = input("Ingrese un nombre o fin para terminar: ")

        if nombre.lower() == "fin":
            break

        nombres.append(nombre)

    contador = 1

    for nombre in nombres:
        print("Turno", contador, ":", nombre)
        contador += 1


# ejercicio 7
def ejercicio7():
    contador = 0

    for i in range(1, 101):
        if i % 2 == 0:
            contador += 1

    print("La cantidad de numeros pares es:", contador)


# ejercicio 8
def ejercicio8():
    while True:
        celsius = input("Ingrese temperatura en Celsius o salir: ")

        if celsius.lower() == "salir":
            break

        celsius = float(celsius)
        fahrenheit = (celsius * 9 / 5) + 32

        print("Temperatura en Fahrenheit:", fahrenheit)


# ejercicio 9
def ejercicio9():
    numero = int(input("Ingrese un numero: "))
    primo = True

    if numero <= 1:
        primo = False
    else:
        for i in range(2, numero):
            if numero % i == 0:
                primo = False
                break

    if primo:
        print("Es primo")
    else:
        print("No es primo")


# ejercicio 10
def ejercicio10():
    nombres = []

    while True:
        nombre = input("Ingrese un nombre o fin para terminar: ")

        if nombre.lower() == "fin":
            break

        nombres.append(nombre)

    for nombre in nombres:
        print("Hola", nombre)


# ejercicio 11
def ejercicio11():
    nombres = []
    contador = 0

    while True:
        nombre = input("Ingrese un nombre: ")

        if nombre in nombres:
            print("Nombre repetido")
            print("Nombres ingresados antes del duplicado:", contador)
            break

        nombres.append(nombre)
        contador += 1


# ejercicio 12
def ejercicio12():
    for i in range(100, 201):
        if i % 7 == 0 and i % 10 == 3:
            print(i)


# ejercicio 13
def ejercicio13():
    total = 0
    contador = 0

    while total <= 1000:
        precio = float(input("Ingrese el precio del producto: "))

        total += precio
        contador += 1

    print("Total acumulado:", total)
    print("Cantidad de productos:", contador)


# ejercicio 14
def ejercicio14():
    nombre = input("Ingrese su nombre: ")
    edad = input("Ingrese su edad: ")

    while not edad.isdigit():
        print("La edad debe ser un numero")
        edad = input("Ingrese su edad: ")

    mail = input("Ingrese su mail: ")

    while "@" not in mail:
        print("El mail debe contener @")
        mail = input("Ingrese su mail: ")

    print("Nombre:", nombre)
    print("Edad:", edad)
    print("Mail:", mail)


# ejercicio 15
def ejercicio15():
    numero = input("Ingrese un numero: ")

    for digito in numero:
        if digito.isdigit():
            print(digito)


# ejercicio 16
def ejercicio16():
    puntos_usuario = 0
    puntos_maquina = 0
    opciones = ["Piedra", "Papel", "Tijera"]

    for i in range(3):
        print("1. Piedra")
        print("2. Papel")
        print("3. Tijera")

        usuario = int(input("Seleccione una opcion: "))

        while usuario < 1 or usuario > 3:
            print("Opcion incorrecta")
            usuario = int(input("Seleccione una opcion: "))

        maquina = random.randint(1, 3)

        print("La maquina eligio:", opciones[maquina - 1])

        if usuario == maquina:
            print("Empate")
        elif usuario == 1 and maquina == 3:
            print("Ganaste la ronda")
            puntos_usuario += 1
        elif usuario == 2 and maquina == 1:
            print("Ganaste la ronda")
            puntos_usuario += 1
        elif usuario == 3 and maquina == 2:
            print("Ganaste la ronda")
            puntos_usuario += 1
        else:
            print("La maquina gano la ronda")
            puntos_maquina += 1

    print("Puntos del usuario:", puntos_usuario)
    print("Puntos de la maquina:", puntos_maquina)

    if puntos_usuario > puntos_maquina:
        print("Ganaste el juego")
    elif puntos_maquina > puntos_usuario:
        print("Gano la maquina")
    else:
        print("El juego termino en empate")


# ejercicio 17
def ejercicio17():
    contador = 0

    for i in range(10):
        numero = random.randint(1, 100)

        print("Numero generado:", numero)

        if numero > 50:
            contador += 1

    print("Numeros mayores a 50:", contador)


# ejercicio 18
def ejercicio18():
    total = 0
    mejor_nota = -1
    mejor_nombre = ""

    for i in range(5):
        nombre = input("Ingrese el nombre: ")
        nota = float(input("Ingrese la nota: "))

        total += nota

        if i == 0 or nota > mejor_nota:
            mejor_nota = nota
            mejor_nombre = nombre

    promedio = total / 5

    print("Promedio general:", promedio)
    print("Mejor nota:", mejor_nota)
    print("Alumno con mejor nota:", mejor_nombre)


# ejercicio 19
def ejercicio19():
    abecedario = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"

    for i in range(len(abecedario) - 1, -1, -1):
        print(abecedario[i])


while True:
    print("El papu menu")
    print("1. Adivinar numero")
    print("2. Mostrar divisores")
    print("3. Serie Fibonacci")
    print("4. Calculadora")
    print("5. Factorial")
    print("6. Sistema de turnos")
    print("7. Contar numeros pares")
    print("8. Celsius a Fahrenheit")
    print("9. Comprobar numero primo")
    print("10. Lista de nombres")
    print("11. Detectar nombres repetidos")
    print("12. Multiplos de 7 terminados en 3")
    print("13. Cargar precios")
    print("14. Formulario")
    print("15. Mostrar digitos")
    print("16. Piedra papel o tijera")
    print("17. Numeros aleatorios")
    print("18. Promedio y mejor nota")
    print("19. Abecedario inverso")
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
    elif opcion == 19:
        ejercicio19()
    elif opcion == 0:
        print("Saliendo del programa...")
        break
    else:
        print("Opcion incorrecta")
