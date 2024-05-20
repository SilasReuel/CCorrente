using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class Conta
    {
        protected string numero;
        protected double saldo;
        protected double limite;
        protected bool status;
        protected List<Transacao> transacao;

        public Conta()
        {

        }

        public Conta(string numero)
        {
            this.numero = numero;
        }

        public double Saldo
        {
            get => this.saldo;
            set
            {
                this.saldo = value;
            }
        }

        public double Limite
        {
            get => this.limite;
            set
            {
                if (value >= 0)
                {
                    this.limite = value;
                }
            }
        }

        public string Numero
        {
            get => this.numero;
            set
            {
                this.numero = value;
            }
        }

        public bool Status{
            get => this.status;
            set
            {
                this.status = value;
            }
        }

        public List<Transacao> Transacao
        {
            get => this.transacao;
            set
            {
                this.transacao = value;
            }
        }

        public bool Sacar(double valor)
        {
            if (status == true && saldo >= valor && valor <= limite)
            {
                saldo -= valor;
                transacao.Add(new Transacao(valor, 'S', this));
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
                transacao.Add(new Transacao(valor, 'D', this));
                return true;
            }
            else
            {
                Console.WriteLine("Depósito não realizado, verifique seu saldo");
                return false;
            }
        }

        public bool Transferir(Conta destino, double valor)
        {
            if (destino.status && Sacar(valor) && destino.Depositar(valor))
            {
                Console.WriteLine("Transferência realizada com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Tranferência não realizada, verifique se o valor é válido ou se a conta existe");
                return false;
            }
        }
    }
}
