# AyE-2026-K.Ramirez
Algoritmo y Estructuras de datos 2026 Profesor: Ignacio Federico Traverso Raiz
Cifrado Cesar: Implementa un programa que pueda cifrar y descifrar mensajes utilizando el cifrado César.

El cifrado César es un tipo simple de cifrado por sustitución en el que cada letra en el texto es reemplazada por una letra que se encuentra un cierto número de posiciones más adelante o más atrás en el alfabeto.  

Dividir el programa en 2 funciones


Función 1: 
Pide el mensaje a cifrar/descifrar
Se asegura que no tenga caracteres especiales (en caso de tener caracteres pedir que vuelva a poner un mensaje sin estos mismos)
Convierte todo el texto a minúscula Pista (.ToLower())
Devuelve el texto procesado
Función 2:
Recibe lo devuelto en la función 1
Pide al usuario si desea cifrar o descifrar.
Pide la clave  (un número entero, ej. 3 para mover 3 posiciones).
Devuelve el mensaje cifrado o descifrado según lo que se haya pedido, Considera el "desbordamiento" del alfabeto (ej. si la clave es 3 y la letra es 'Z', debería ser 'C' al cifrarse).

Modo de entrega: Branch en su repositorio de GitHub con el nombre del trabajo practico tal cual esta escrito en el classroom.
