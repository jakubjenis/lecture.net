using System;

namespace AdoNetSample
{
    internal class AdoLibException : Exception
    {
        public AdoLibException(string message): base(message)
        {
            
        }
    }
}