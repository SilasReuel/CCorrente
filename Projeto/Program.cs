// See https://aka.ms/new-console-template for more information
using Projeto;

CCorrente conta = new CCorrente("11234", 500);
List<CCorrente> contas = new List<CCorrente>();

int opc = 0;

do
{
    Console.WriteLine("Escolha: 1)Acesso admnistrativo 2)Caixa Eletrônico 0)Sair");
    opc = Convert.ToInt32(Console.ReadLine());
    if ( opc == 1)
    {
        int opc2 = 0;
        do
        {
            Console.WriteLine("Escolha: 1)Cadastro de Conta Corrente 2)Mostrar Saldos de todas as contas 3)Excluir conta 0)Voltar para Menu Anterior");
            opc2 = Convert.ToInt32(Console.ReadLine());
        } while ( opc2 != 0);
    }else if (opc == 2)
    {
        int opc2 = 0;
        do
        {
            Console.WriteLine("Escolha: 1)Ler Conta Corrente 2)Saque 3)Depósito 4)transferência 0)Voltar para Menu Anterior");
            opc2 = Convert.ToInt32(Console.ReadLine());
        } while (opc2 != 0);
    }
} while (opc!=0);