using System;

public interface Inotificacion
{
    void Enviar(string mensaje);
    
}

public class NotificacionEmail : Inotificacion
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando Email : {mensaje} ");
    }
}

public class NotificacionSMS : Inotificacion 
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando SMS : {mensaje} ");
    }
}

// fABRICA

public static class NotificacionFactory
{

    public static Inotificacion Crear(string tipo)
    {
       switch (tipo.ToLower())
       {
            case "email": return new NotificacionEmail();
            case "sms": return new NotificacionSMS();
            default: throw new ArgumentException("Tipo no soportado");
       }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese tipo de notificacion (email / sms): ");
        string tipo = Console.ReadLine();

        Inotificacion notificacion = NotificacionFactory.Crear(tipo);
        notificacion.Enviar("Su mensaje ha sio enviado");
    }
}

