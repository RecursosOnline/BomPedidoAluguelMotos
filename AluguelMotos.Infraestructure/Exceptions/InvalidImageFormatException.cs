namespace AluguelMotos.Infraestructure.Exceptions;

public class InvalidImageFormatException : ExceptionBase
{
    public InvalidImageFormatException(string message) : base(message)
    {   
    }
    public InvalidImageFormatException(): 
        base("Tipo de imagem invalido, somente arquivos com a extensão PNG ou BMP são permitidos.")
    {
        
    }
}