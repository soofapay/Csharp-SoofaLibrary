using System;
using System.Collections.Generic;
using System.Text;

namespace Soofa
{
   public class SoofaPayException:Exception
    {
        public SoofaPayException(string message)
            :base(message)
        {

        }
    }
}
