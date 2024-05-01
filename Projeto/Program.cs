// See https://aka.ms/new-console-template for more information
using Projeto;

/*CCorrente conta = new CCorrente("11234", 500);*/
List<CCorrente> contas = new List<CCorrente>();

int opc = 0;

do
{
    Console.WriteLine("Escolha: \n1)Acesso admnistrativo \n2)Caixa Eletrônico \n0)Sair");
    opc = Convert.ToInt32(Console.ReadLine());
    if ( opc == 1)
    {
        int opc2 = 0;
        do
        {
            Console.WriteLine("Escolha: \n1)Cadastro de Conta Corrente \n2)Mostrar Saldos de todas as contas \n3)Excluir conta \n0)Voltar para Menu Anterior");
            opc2 = Convert.ToInt32(Console.ReadLine());
            switch (opc2) {
                case 1:
                    Console.WriteLine("Digite o número da conta:");
                    string numeroR = Console.ReadLine();
                    Console.WriteLine("Digite o limite da conta:");
                    double limiteR = Convert.ToDouble(Console.ReadLine());
                    CCorrente conta = new CCorrente(numeroR, limiteR);
                    contas.Add(conta);
                    foreach (CCorrente cc in contas)
                    {
                        Console.WriteLine(cc.ToString());
                    }

                   /* for (int i = 0; i < contas.Count; i++)
                    {
                        CCorrente cc = contas[i];
                        Console.WriteLine(cc.ToString());
                    }*/

                    break;
                case 2:
                    foreach (var item in contas)
                    {
                        if (item.status)
                        {
                            Console.WriteLine("Conta: " + item.numero+ " -->> Saldo: " + item.saldo);
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Informe o número da conta a ser excluída: ");
                    string numExc = Console.ReadLine();
                    CCorrente receb = contas.Find(x => x.numero == numExc);
                    if (receb != null)
                    {
                        receb.status = false;
                    }
                    else
                    {
                        Console.WriteLine("Conta: " + numExc + " -->> Não foi encontrada");
                    }
                    break;
            }

        } while ( opc2 != 0);
    }else if (opc == 2)
    {
        int opc2 = 0;
        do
        {
            Console.WriteLine("Escolha: \n1)Ler Conta Corrente \n2)Saque \n3)Depósito \n4)transferência \n0)Voltar para Menu Anterior");
            opc2 = Convert.ToInt32(Console.ReadLine());
            string num = "";
            switch (opc2)
            {
                case 1:
                    Console.WriteLine("Digite a conta que deseja verificar: ");
                    string numR = Console.ReadLine();
                    CCorrente receb = contas.Find(contas => contas.numero == numR);
                    if (receb != null)
                    {
                        if (receb.status == true)
                        {
                            Console.WriteLine("Conta: " + numR + " -->> Existe\nSaldo: " + receb.saldo + "\nLimite: " + receb.limite);
                        }
                        else
                        {
                            Console.WriteLine("Conta: " + numR + " -->> Não existe");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Conta digitada está incorreta!");
                    }
                    break;
                case 2:
                    Console.WriteLine("Digite o número da conta: ");
                    num = Console.ReadLine();
                    receb = contas.Find(contas => contas.numero == num);
                    if (receb != null && receb.status)
                    {
                        Console.WriteLine("Digite o valor do saque: ");
                        if (receb.Sacar(Convert.ToDouble(Console.ReadLine())))
                        {
                            Console.WriteLine("Saque realizado com sucesso!!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Conta não encontrada");
                    }
                    break;
                case 3:
                    Console.WriteLine("Digite o número da conta: ");
                    num = Console.ReadLine();
                    receb = contas.Find(contas => contas.numero == num);
                    if (receb != null && receb.status)
                    {
                        Console.WriteLine("Digite o valor do depósito: ");
                        if (receb.Depositar(Convert.ToDouble(Console.ReadLine())))
                        {
                            Console.WriteLine("Depósito realizado com sucesso!!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Conta não encontrada");
                    }
                    break;
                case 4:
                    Console.WriteLine("Digite o número da conta: ");
                    num = Console.ReadLine();
                    receb = contas.Find(contas => contas.numero == num);
                    if (receb != null && receb.status)
                    {
                        Console.WriteLine("Digite o número da conta destino:");
                        num = Console.ReadLine();
                        CCorrente recebDest = contas.Find(contas => contas.numero == num);
                        if (recebDest != null && recebDest.status)
                        {
                            Console.WriteLine("Digite o valor do depósito: ");
                            if (receb.Transferir(recebDest, Convert.ToDouble(Console.ReadLine())))
                            {
                                Console.WriteLine("Depósito realizado com sucesso!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Conta não encontrada");
                    }
                    break;
            }
        } while (opc2 != 0);
    }
} while (opc!=0);