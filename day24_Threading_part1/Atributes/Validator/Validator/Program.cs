using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            var note = new NotaExamen[]
            {
                new NotaExamen{ Name = "Caligrafie" ,  Nota = 10}
                , new NotaExamen{ Name = "Matematica" ,  Nota = 2}
                , new NotaExamen{ Name = "Romana" ,  Nota = -1}
            };

            var vvalidator = new NotaExamenValidator();

            foreach(var nota in note)
            {
                List<string> errors;

                if(vvalidator.IsValid(nota, out errors))
                {
                    Console.WriteLine(string.Format(@"Exam {0} nota {1} este ok ", nota.Name, nota.Nota));
                }
                else
                {
                    Console.WriteLine(string.Format(@"Exam {0} nota {1} NUU este ok ", nota.Name, nota.Nota));
                    foreach(var error in errors)
                    {
                        Console.WriteLine(error);
                    }
                }
            }

            Console.WriteLine();

            var stringValidator = new StringStartsWithValidator();

            foreach (var nota in note)
            {
                List<string> errors;

                if (stringValidator.StrtsWithAttribute(nota, out errors))
                {
                    Console.WriteLine(string.Format(@"Stringul {0} incepe cu stringul dorit!", nota.Name));
                }
                else
                {
                    Console.WriteLine(string.Format(@"Stringul {0} nu incepe cu stringul dorit!", nota.Name));
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
