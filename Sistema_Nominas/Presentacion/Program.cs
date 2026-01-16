using Sistema_Nominas.Aplicacion;
using Sistema_Nominas.Dominio;
using Sistema_Nominas.Infraestructura;

namespace Sistema_Nominas.Presentacion
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmpleadoRepositorio repo = new EmpleadoRepositorio();
            EmpleadoServicio servicio = new EmpleadoServicio(repo);

            // Provisional solo para asegurarme de que cumple con el requisito de los 1000 usuarios
            for (int i = 1; i <= 1000; i++)
            {
                var emp = new EmpleadoAsalariado($"Empleado{i}", "Test", i.ToString("D5"), 1000 + i
                );

                servicio.RegistrarEmpleados(emp);
            }


            int seleccion = 0;
            do
            {
                // Variables para permitir la lectura y escritura de los empleados
                string nombre;
                string apellidoPaterno;
                string nss;
                decimal ventasBrutas;
                int tarifaComision;
                decimal sueldoPorHora; 
                decimal salarioSemanal;
                int horasTrabajadas;

                Console.WriteLine("Sistema de Nominas");

                Console.WriteLine("\nMenú");
                Console.WriteLine("1. Agregar empleados");
                Console.WriteLine("2. Actualizar empleados");
                Console.WriteLine("3. Lista de empleados");
                Console.WriteLine("4. Generar reporte semanal");
                Console.WriteLine("5. Limpiar consola");
                Console.WriteLine("0. Salir");

                Console.Write("\nSeleccione una opción (1-5): ");
                seleccion = int.Parse(Console.ReadLine());



                switch (seleccion)
                {
                    case 1:
                        Console.Write("Ingrese el primer nombre: ");
                        nombre = Console.ReadLine();
                        Console.Write("Ingrese el apellido paterno: ");
                        apellidoPaterno = Console.ReadLine();
                        Console.Write("Ingrese su NSS (id): ");
                        nss = Console.ReadLine();

                        Console.WriteLine("\n¿Qué tipo de empleado es?\n1. Asalariado/Asalariado por comisión\n2. Por Horas\n3. Por Comisión");
                        Console.Write("Seleccione el tipo de usuario (1-3): ");
                        int seleccionUsuario = int.Parse(Console.ReadLine());

                        switch (seleccionUsuario)
                        {
                            
                            case 1:
                                Console.Write("Ingrese su salario semanal: ");
                                salarioSemanal = decimal.Parse(Console.ReadLine());

                                Console.Write("¿Es asalariado por comisión? (1. Si / 2. No): ");
                                int esAPC = int.Parse(Console.ReadLine());

                                if(esAPC == 1)
                                {
                                    Console.Write("Ingrese las ventas brutas: ");
                                    ventasBrutas = decimal.Parse(Console.ReadLine());

                                    Console.Write("Ingrese la tarifa de comisión (1-100): ");
                                    tarifaComision = int.Parse(Console.ReadLine());

                                    servicio.RegistrarEmpleados(new EmpleadoAsalariadoPorComision(nombre, apellidoPaterno, nss, salarioSemanal,ventasBrutas, tarifaComision));
                                    Console.WriteLine("Empleado asalariado por comisión agregado exitosamente!");
                                }

                                else
                                {
                                    servicio.RegistrarEmpleados(new EmpleadoAsalariado(nombre, apellidoPaterno, nss, salarioSemanal));
                                    Console.WriteLine("Empleado asalariado agregado exitosamente!");
                                }

                                break;

                            case 2:

                                Console.Write("Ingrese el sueldo por hora: ");
                                sueldoPorHora = decimal.Parse(Console.ReadLine());

                                Console.Write("Ingrese las horas trabajadas: ");
                                horasTrabajadas = int.Parse(Console.ReadLine());

                                servicio.RegistrarEmpleados(new EmpleadoPorHoras(nombre, apellidoPaterno, nss, sueldoPorHora, horasTrabajadas));
                                Console.WriteLine("Empleado por horas agregado correctamente!");
                                break;

                            case 3:
                                Console.Write("Ingrese las ventas brutas: ");
                                ventasBrutas = decimal.Parse(Console.ReadLine());

                                Console.Write("Ingrese la tarifa de comisión (1-100): ");
                                tarifaComision = int.Parse(Console.ReadLine());

                                servicio.RegistrarEmpleados(new EmpleadoPorComision(nombre, apellidoPaterno, nss, ventasBrutas, tarifaComision));
                                Console.WriteLine("Empleado por comision agregado correctamente!");
                                break;

                        }
                        break;

                    case 2:
                        Console.Write("Ingrese el NSS del empleado a actualizar: ");
                        nss = Console.ReadLine();

                        var existente = servicio.BuscarEmpleado(nss);

                        if (existente == null)
                        {
                            Console.WriteLine("Empleado no encontrado. No se puede actualizar.");
                        }
                        else
                        {
                            Console.WriteLine($"Empleado encontrado: {existente}");

                            Console.Write("Ingrese el nuevo nombre (ENTER SI DESEA DEJAR EL MISMO): ");
                            nombre = Console.ReadLine();

                            // Si el usuario da ENTER, se ingresa "" y el nombre se queda igual
                            if(nombre == "")
                            {
                                nombre = existente.PrimerNombre;
                            }

                            Console.Write("Ingrese el nuevo apellido (ENTER SI DESEA DEJAR EL MISMO): ");
                            string apellido = Console.ReadLine();

                            // Si el usuario da ENTER, se ingresa "" y el apellido se queda igual
                            if (apellido == "")
                            {
                                apellido = existente.ApellidoPaterno;
                            }

                            Empleado empActualizado = null;

                            if (existente is EmpleadoAsalariado)
                            {
                                Console.Write("Ingrese el nuevo salario semanal: ");
                                salarioSemanal = decimal.Parse(Console.ReadLine());

                                empActualizado = new EmpleadoAsalariado(nombre, apellido, nss, salarioSemanal);
                               
                            }

                            else if (existente is EmpleadoPorHoras)
                            {
                                Console.Write("Ingrese el nuevo sueldo por hora: ");
                                sueldoPorHora = decimal.Parse(Console.ReadLine());

                                Console.Write("Ingrese las nuevas horas trabajadas: ");
                                horasTrabajadas = int.Parse(Console.ReadLine());

                                empActualizado = new EmpleadoPorHoras(nombre, apellido, nss, sueldoPorHora, horasTrabajadas);
                            }

                            else if (existente is EmpleadoPorComision)
                            {
                                Console.Write("Ingrese las nuevas ventas brutas: ");
                                ventasBrutas = decimal.Parse(Console.ReadLine());

                                Console.Write("Ingrese la nueva tarifa de comisión: ");
                                tarifaComision = int.Parse(Console.ReadLine());

                                empActualizado = new EmpleadoPorComision(nombre, apellido, nss, ventasBrutas, tarifaComision);
                                
                            }

                            else if (existente is EmpleadoAsalariadoPorComision)
                            {
                                Console.Write("Ingrese el nuevo salario semanal: ");
                                salarioSemanal = decimal.Parse(Console.ReadLine());

                                Console.Write("Ingrese las nuevas ventas brutas: ");
                                ventasBrutas = decimal.Parse(Console.ReadLine());

                                Console.Write("Ingrese la nueva tarifa de comisión (1-100): ");
                                tarifaComision = int.Parse(Console.ReadLine());

                                empActualizado = new EmpleadoAsalariadoPorComision(nombre, apellido, nss, salarioSemanal, ventasBrutas, tarifaComision);
                            }

                            // Actualizar en el servicio
                            servicio.ActualizarEmpleado(empActualizado);
                        }
                        break;

                    case 3:
                        List<Empleado> empleados = servicio.ListarEmpleados();
                        Console.WriteLine($"Cantidad de empleados: {Empleado.Contador}");

                        foreach (var e in empleados)
                        {
                            Console.WriteLine(e); 
                        }
                            break;

                        case 4:
                        servicio.GenerarReporte();
                        break;

                    case 5:
                        Console.Clear();
                        break;

                    case 0:
                        Console.WriteLine("Hasta pronto!");
                        break;
                    default:
                        Console.WriteLine("La opción ingresada no existe");
                        break;
                }
            } while (seleccion != 0);
           
        }
    }
}
