using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class CPoupanca : Conta
    {

        public CPoupanca()
        {
            limite = 0;
        }

        public CPoupanca(string numero):base(numero) 
        {
            limite = 0;
        }
    }
}
