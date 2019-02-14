# EliminarGeometriasBin

Este repositorio contiene el código fuente del programa de consola **EliminarGeometriasBin**.

Este programa carga un archivo de dibujo .BIN (clásico) y crea un archivo de dibujo .BIN (clásico) con las geometrías del original eliminando aquellas que tengan alguno de los códigos especificados pos parámetros.

El formato para ejecutar el programa es el siguiente: `EliminarGeometriasBin [archivo .BIN original] [archivo .BIN a crear*] [código 1 a filtrar] [código 2 a filtrar] ... [código N a filtrar]`

Ejemplo:

`EliminarGeometriasBin c:\trabajo\h1.bin c:\trabajo\filtrados\h2.bin 020200 020400`

* El archivo .BIN a crear tiene que ser un archivo inexistente.
