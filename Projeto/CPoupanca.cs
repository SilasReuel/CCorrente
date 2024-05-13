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

        }

        public CPoupanca(string numero)
        {
            this.numero = numero;
        }
    }
}
