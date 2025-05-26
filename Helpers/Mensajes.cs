namespace MandrilAPI.Helpers;

public static class Mensajes // namespace para agrupar mensajes de error y éxito
{
    public static class Mandril // Mensajes relacionados con Mandriles
    {

        public const string NotFound = "El mandril solicitado no existe";
    }

    public static class Habilidad // Mensajes relacionados con Habilidades
    {
        public const string NotFound = "La habilidad solicitada no existe";
        public const string BadRequest = "Ya existe una habilidad con ese nombre";
    }

   
}