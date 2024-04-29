using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Projeto
{
    public class CCorrente
    {
        public string numero;
        public double saldo;
        public double limite;
        public bool status;
        public bool especial;
        public List<Transacao> transacao;

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


        public bool Sacar(double valor)
        {
            if (saldo - valor > -limite)
            {
                saldo -= valor;
                transacao.Add(new Transacao(valor, 'S'));
                return true;
            }
            return false;
        }

        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                transacao.Add(new Transacao(valor, 'D'));
                return true;
            }
            return false;
        }

        public bool Transferir(CCorrente destino, double valor)
        {
            if (destino.status && Sacar(valor) && destino.Depositar(valor)){
                transacao[transacao.Count - 1].duplicata = destino.transacao[destino.transacao.Count - 1];
                destino.transacao[destino.transacao.Count + 1].duplicata = transacao[transacao.Count-1];
                return true;
            }
            return false;
        }
    }
}
