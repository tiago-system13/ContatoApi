using System;

namespace bdiNegocios.Exceptions
{
    [Serializable]
    public class NegocioException: Exception
    {
        public NegocioException(string message) : base(message) { }
    }
}
