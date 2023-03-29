using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollectionService.Exceptions
{
    class NullArgumentEcxeption : Exception
    {
        public NullArgumentEcxeption() { }
        
        public NullArgumentEcxeption(string message) : base(message) { }
        
    }
}
