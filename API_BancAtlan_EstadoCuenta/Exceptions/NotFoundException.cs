namespace API_BancAtlan_EstadoCuenta.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string message)
        : base(message) { }
        public NotFoundException(string message, Exception inner)
        : base(message, inner) { }
    }
}
