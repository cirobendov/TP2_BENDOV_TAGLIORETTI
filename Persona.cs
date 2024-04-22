class Persona{

    public string Nombre {get; set;}

    public string Apellido {get; set;}

    public int DNI {get; set;}

    public DateTime FechaNacimiento {get; set;}

    public string Email {get;set;}

    public bool puedeVotar(int edad){
        if(edad < 16)
        return false;
        else 
        return true;
    }
    public int ObtenerEdad(){
        int edad;
        edad = DateTime.Now.Year - FechaNacimiento.Year;
        if(DateTime.Now.Month < FechaNacimiento.Month || DateTime.Now.Day < FechaNacimiento.Day)
        edad--; 
        return edad;
    }
    public Persona(string nombre, string apellido, int dni, DateTime fechanac, string mail){
        Nombre = nombre;
        Apellido = apellido;
        DNI = dni;
        FechaNacimiento = fechanac;
        Email = mail;
    }
    
}