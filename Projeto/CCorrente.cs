using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Projeto
{
    public class CCorrente:Conta
    {
        public bool especial;

        public CCorrente(string numero, double limite):this()
        {

            this.numero = numero;

            this.limite = limite;
        }

        public CCorrente()
        {
            this.saldo = 0;

            this.status = true;

            transacao = new List<Transacao> ();
        }

        public override string ToString()
        {
            return "CC: "+ this.numero +"limite: "+ this.limite;
        }
    }
}
