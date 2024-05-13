using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class CPoupanca
    {
        public string numero;
        public double saldo;
        public bool status;
        public List<Transacao> transacoes;


        public CPoupanca()
        {

        }

        public CPoupanca(string numero)
        {

        }

        public bool Sacar(double valor)
        {
            if (status == true && saldo >= valor && valor <= 0)
            {
                saldo -= valor;
                transacoes.Add(new Transacao(valor, 'S'));
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
                transacoes.Add(new Transacao(valor, 'D'));
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

        public bool Transferir(CPoupanca destino, double valor)
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
