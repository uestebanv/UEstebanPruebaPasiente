using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class CRUD
    {
        public static void Add()
        {
            ML.Pasiente pasiente = new ML.Pasiente();
            
            //ML.Result result = new ML.Result();

            Console.WriteLine("Ingrese los Datos del Pasiente");

            Console.WriteLine("Nombre");
            pasiente.Nombre = Console.ReadLine();

            Console.WriteLine("Apellido Paterno");
            pasiente.ApellidoPaterno = Console.ReadLine();
            
            Console.WriteLine("Apellido Materno");
            pasiente.ApellidoMaterno = Console.ReadLine();

            pasiente.TipoSangre = new ML.TipoSangre();
            Console.WriteLine("Tipo de Sangre");
            pasiente.TipoSangre.IdTipoSangre = byte.Parse(Console.ReadLine());

            Console.WriteLine("FechaNacimiento");
            pasiente.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Sexo");
            pasiente.Sexo = Console.ReadLine();

            Console.WriteLine("Diagnostico del pasiente");
            pasiente.Diagnostico = Console.ReadLine();

            ML.Result result = BL.Pasiente.Add(pasiente);

            
            if(result.Correct)
            {
                Console.WriteLine("Se inserto el registro");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrio un error al insertar el resgitro");
                Console.ReadKey();
            }
            
        }
    }
}
