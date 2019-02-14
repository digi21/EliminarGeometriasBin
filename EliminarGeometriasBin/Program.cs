using Digi21.DigiNG.IO;
using Digi21.Math;
using Digi21.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EliminarGeometriasBin
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AnalizaParámetros( args, out var rutaArchivoEntrada, out var rutaArchivoSalida, out var códigosEliminar);

                using (var archivoSalida = new Bin(args[1], 2, new Point3D()))
                using (var archivoEntrada = new Bin(args[0], 2, new Point3D())) 
                {
                    foreach (var entidad in archivoEntrada.Where(e => e.TieneAlgúnCódigo(códigosEliminar)))
                        archivoSalida.Add(entidad.Clone());
                }
            }
            catch (Exception e)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine($"Error: {e.Message}");
                Console.ForegroundColor = oldColor;
                return;
            }
        }

        static private void AnalizaParámetros(string[] args, out string rutaArchivoEntrada, out string rutaArchivoSalida, out List<string> códigosEliminar)
        {
            if (args.Length < 3)
                throw new Exception("Error. No se han especificado suficientes parámetros\nEliminarGeometriasBin [archivo .bin original] [archivo .bin destino] [código1 a eliminar] ... [código n a eliminar]");

            if (!File.Exists(args[0]))
                throw new Exception($"Error: No existe el archivo: {args[0]}");

            if (File.Exists(args[1]))
                throw new Exception($"Error. El archivo de salida ya existe: {args[1]}");

            rutaArchivoEntrada = args[0];
            rutaArchivoSalida = args[1];
            códigosEliminar = args.Skip(2).ToList();
        }
    }
}
