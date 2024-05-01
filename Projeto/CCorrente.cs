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
            if (status == true && saldo >= valor && valor <= limite)
            {
                saldo -= valor;
                transacao.Add(new Transacao(valor, 'S'));
                return true;
            }
            else
            {
                Console.WriteLine("Saque não pode ser realizado. Verifique seu saldo ou limite de saque!");
                return false;
            }
        }

        public bool Depositar(double valor)
        {
            if (status == true && valor > 0)
            {
                saldo += valor;
                transacao.Add(new Transacao(valor, 'D'));
                return true;
            }
            else
            {
                Console.WriteLine("Depósito não realizado, verifique seu saldo");
                return false;
            }
        }

        public bool Transferir(CCorrente destino, double valor)
        {
            if (destino.status && Sacar(valor) && destino.Depositar(valor)){
                /*transacao[transacao.Count - 1].duplicata = destino.transacao[destino.transacao.Count - 1];
                destino.transacao[destino.transacao.Count + 1].duplicata = transacao[transacao.Count-1];*/
                Console.WriteLine("Transferência realizada com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Tranferência não realizada, verifique se o valor é válido ou se a conta existe");
                return false;
            }
        }

        public override string ToString()
        {
            return "CC: "+ this.numero +"limite: "+ this.limite;
        }
    }
}
