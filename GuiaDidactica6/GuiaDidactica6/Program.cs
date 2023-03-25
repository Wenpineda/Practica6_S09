using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaDidactica6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Medicamento> catalogo = new List<Medicamento>();
            catalogo.Add(new Medicamento("Ibuprofeno", TipoEnfermedad.Dolor, Presentacion.Pastillas, 20, FechaVencimiento.Parse("01/01/2024")));
            catalogo.Add(new Medicamento("Paracetamol", TipoEnfermedad.Fiebre, Presentacion.Pastillas, 10, FechaVencimiento.Parse("01/01/2023")));
            catalogo.Add(new Medicamento("Amoxicilina", TipoEnfermedad.Infeccion, Presentacion.Jarabe, 100, FechaVencimiento.Parse("01/01/2025")));
            catalogo.Add(new Medicamento("Betametasona", TipoEnfermedad.Inflamacion, Presentacion.Pomada, 50, FechaVencimiento.Parse("01/01/2023")));

            Console.WriteLine("Bienvenido a la farmacia");
            Console.WriteLine("------------------------");

            Console.WriteLine("Enfermedades disponibles:");
            foreach (TipoEnfermedad enfermedad in Enum.GetValues(typeof(TipoEnfermedad)))
            {
                Console.WriteLine("- " + enfermedad.ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Catálogo de medicamentos:");
            foreach (Medicamento medicamento in catalogo)
            {
                Console.WriteLine(medicamento.ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Ingrese los datos del cliente:");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("DNI: ");
            string dni = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Ingrese el medicamento que desea comprar:");
            string nombreMedicamento = Console.ReadLine();
            Medicamento medicamentoSeleccionado = null;
            foreach (Medicamento medicamento in catalogo)
            {
                if (medicamento.Nombre == nombreMedicamento)
                {
                    medicamentoSeleccionado = medicamento;
                    break;
                }
            }

            if (medicamentoSeleccionado == null)
            {
                Console.WriteLine("El medicamento seleccionado no existe en el catálogo");
            }
            else
            {
                Console.WriteLine("Ingrese la cantidad de unidades que desea comprar:");
                int cantidad = int.Parse(Console.ReadLine());
                if (cantidad > medicamentoSeleccionado.Cantidad)
                {
                    Console.WriteLine("La cantidad ingresada supera el stock disponible");
                }
                else
                {
                    Console.WriteLine("Venta realizada con éxito");
                    Console.WriteLine();
                    Console.WriteLine("Datos de la venta:");
                    Console.WriteLine("- Cliente: " + nombre + " " + apellido + " (" + dni + ")");
                    Console.WriteLine("- Medicamento: " + medicamentoSeleccionado.Nombre);
                    Console.WriteLine("- Cantidad: " + cantidad);
                    Console.WriteLine("- Precio total: $" + (cantidad * medicamentoSeleccionado.Precio));
                }
            }
        }
        public enum TipoEnfermedad
        {
            Dolor,
            Fiebre,
            Infeccion,
            Inflamacion
        }
        public enum Presentacion
        {
            Pastillas,
            Jarabe,
            Inyeccion,
            Pomada
        }

        public class Medicamento
        {
            public string Nombre { get; set; }
            public TipoEnfermedad TipoEnfermedad { get; set; }
            public Presentacion Presentacion { get; set; }
            public int Cantidad { get; set; }
            public double Precio { get; set; }
            public FechaVencimiento FechaVencimiento { get; set; }

            public Medicamento(string nombre, TipoEnfermedad tipoEnfermedad, Presentacion presentacion, int cantidad, FechaVencimiento fechaVencimiento)
            {
                Nombre = nombre;
                TipoEnfermedad = tipoEnfermedad;
                Presentacion = presentacion;
                Cantidad = cantidad;
                FechaVencimiento = fechaVencimiento;

                switch (presentacion)
                {
                    case Presentacion.Pastillas:
                        Precio = 5;
                        break;
                    case Presentacion.Jarabe:
                        Precio = 10;
                        break;
                    case Presentacion.Inyeccion:
                        Precio = 20;
                        break;
                    case Presentacion.Pomada:
                        Precio = 15;
                        break;
                }
            }

            public override string ToString()
            {
                return Nombre + " - " + Presentacion.ToString() + " - " + Cantidad.ToString() + " unidades - " + FechaVencimiento.ToString();
            }
        }

        public class FechaVencimiento
        {
            public int Dia { get; set; }
            public int Mes { get; set; }
            public int Anio { get; set; }

            public FechaVencimiento(int dia, int mes, int anio)
            {
                Dia = dia;
                Mes = mes;
                Anio = anio;
            }

            public static FechaVencimiento Parse(string str)
            {
                string[] partes = str.Split('/');
                int dia = int.Parse(partes[0]);
                int mes = int.Parse(partes[1]);
                int anio = int.Parse(partes[2]);
                return new FechaVencimiento(dia, mes, anio);
            }

            public override string ToString()
            {
                return Dia.ToString("D2") + "/" + Mes.ToString("D2") + "/" + Anio.ToString("D4");
            }
        }
    }
}

