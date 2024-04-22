List<Persona> listaPersonas = new List<Persona>();
int opcion, cantPersonas = 0;

do
{
    opcion = mostrarMenu();
    if(opcion == 1)
    {
        ingresarPersona(listaPersonas);
        cantPersonas ++;
    }
    else if (opcion == 2)
    mostrarStats(listaPersonas, cantPersonas);

    else if (opcion == 3)
    buscarPersona(listaPersonas);

    else if(opcion == 4)
    modificarMail(listaPersonas);
    
    
} while (opcion != 5);
Console.WriteLine("¡Gracias por usar nuestro programa!");

static void ingresarPersona(List<Persona> personas)
{
    int dni, i = 0;
    string apellido, nombre, mail;
    DateTime fechanac;
    Console.WriteLine("Ingrese el nombre");
    nombre = Console.ReadLine();
    Console.WriteLine("Ingrese el apellido");
    apellido = Console.ReadLine();
    bool dniRepetido = false;
    do
    {
        Console.WriteLine("Ingrese el dni");
        dni = int.Parse(Console.ReadLine());   
        if(personas.Count > 0)    
        {
            do
        {
            if(personas[i].DNI == dni)
            {
                Console.WriteLine("Ya hay una persona registrada con ese dni.");
                dniRepetido = true;
            }
            i++;
        }
        while(i < personas.Count || dniRepetido == false);   
        } 

    } while(dniRepetido == true);
    Console.WriteLine("Ingrese la fecha de nacimiento");
    fechanac = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el mail");
    mail = Console.ReadLine();
    personas.Add(new Persona(nombre, apellido, dni, fechanac, mail));
}
static void mostrarStats(List<Persona> personas, int cantPersonas)
{
    int personasVotar = 0;
    int edad, promedio = 0;
    Console.WriteLine("Estadisticas del censo:");
    Console.WriteLine("La cantidad de personas es de: " + cantPersonas);
    for (int i = 0; i < personas.Count; i++)
    {
        edad = personas[i].ObtenerEdad();
        if (personas[i].puedeVotar(edad) == true )
        personasVotar ++;
    }
    Console.WriteLine("Las personas que pueden votar son: " + personasVotar);
    for (int i = 0; i < personas.Count; i++)
    {
        promedio += personas[i].ObtenerEdad();
    }
    promedio = promedio/personas.Count;
    Console.WriteLine("El promedio de edad es de " + promedio);
}
static void buscarPersona(List<Persona> listaPersonas)
{
    int dniIngresado;
    int x = 0;
    int edad;
    Console.WriteLine("Ingrese el dni de la persona");
    dniIngresado = int.Parse(Console.ReadLine());
    for (int i = 0; i < listaPersonas.Count; i++)
    {
        if (dniIngresado == listaPersonas[i].DNI)
        x = i;
    }
    edad = listaPersonas[x].ObtenerEdad();
    if (listaPersonas[x].DNI != 0)
    {
        Console.WriteLine("Estadisticas de la persona:");
        Console.WriteLine("Nombre: " + listaPersonas[x].Nombre);
        Console.WriteLine("Apellido: " + listaPersonas[x].Apellido);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("¿Puede votar?: " + listaPersonas[x].puedeVotar(edad));
        Console.WriteLine("Mail: " + listaPersonas[x].Email);
    }
    else
    Console.WriteLine("No se ha encontrado ese dni.");
}
static void  modificarMail(List<Persona> listaPersonas)
{
    int dniIngresado;
    int x = 0;
    Console.WriteLine("Ingrese el dni de la persona");
    dniIngresado = int.Parse(Console.ReadLine());
    for (int i = 0; i < listaPersonas.Count; i++)
    {
        if (dniIngresado == listaPersonas[i].DNI)
        x = i;
    }
    if (listaPersonas[x].DNI != 0 )
    {
        Console.WriteLine("Ingrese el nuevo mail");
        listaPersonas[x].Email = Console.ReadLine();
    }
    else
    Console.WriteLine("No se ha encontrado el dni.");
}

static int mostrarMenu()
{
    int opcion;
    Console.WriteLine("1. Cargar Nueva Persona");
    Console.WriteLine("2. Obtener estadisticas del censo");
    Console.WriteLine("3. Buscar persona");
    Console.WriteLine("4. Modificar mail de una persona");
    Console.WriteLine("5. Salir");
    do
    {
        Console.WriteLine("Ingrese una opcion");
        opcion = int.Parse(Console.ReadLine());
    } while(opcion < 1 || opcion > 5);
    return opcion;
}

