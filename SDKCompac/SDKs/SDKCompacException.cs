using System;

namespace SDKCompac {
    public class SDKCompacException : Exception {
        public SDKCompacException() :
            base("Excepción desconocida en SDK") { }
        
        public SDKCompacException(string mensaje) : 
            base("Ocurrió una excepción en SDK: " + mensaje) { }
    }
}