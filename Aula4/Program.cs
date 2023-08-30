// See https://aka.ms/new-console-template for more information

using Aula4.Controllers;
using Aula4.Repositories;

namespace Aula4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("*** ESCOLHA AÇÃO PARA REALIZAR! EMPRESA(1) FUNCIONARIO(2) ***");
            var opcaoAcao = int.Parse(Console.ReadLine());

            if (opcaoAcao is 1)
            {
                var empresaController = new EmpresaController();

                Console.WriteLine("*** ESCOLHA AÇÃO PARA REALIZAR NA EMPRESA ***");
                Console.Write("*** Cadastrar: 1, Editar: 2, Consular Empresas: 3 Deletar: 4 ***");
                var opcaoOperacaoEmpresa = int.Parse(Console.ReadLine());

                switch (opcaoOperacaoEmpresa)
                {
                    case 1:
                        empresaController.CadastrarEmpresa();
                        break;
                    case 2:
                        empresaController.AtualizarEmpresa();
                        break;
                    case 3:
                        empresaController.ConsultarEmpresa();
                        break;
                    case 4:
                        empresaController.DeletarEmpresa();
                        break;
                    default: throw new Exception("Opção invalida");
                }

                Console.WriteLine("DESEJA REALIZAR OUTRA OPERAÇÃO: Sim (S), Não (N)");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Main(args); //Recursividade
                }

                Console.WriteLine("FIM DO PROGRAMA");
            }

            else if (opcaoAcao is 2)
            {
                var funcionarioController = new FuncionarioController();

                Console.WriteLine("*** ESCOLHA AÇÃO PARA REALIZAR NO FUNCIONARIO ***");
                Console.Write("*** Cadastrar: 1, Editar: 2, Consular Funcionarios: 3 Deletar: 4 ***");
                var opcaoOperacaoEmpresa = int.Parse(Console.ReadLine());

                switch (opcaoOperacaoEmpresa)
                {
                    case 1:
                        funcionarioController.CadastrarFuncionario();
                        break;
                    case 2:
                        funcionarioController.AtualizarFuncionario();
                        break;
                    case 3:
                        funcionarioController.ConsultarFuncionario();
                        break;
                    case 4:
                        funcionarioController.DeletarFuncionario();
                        break;
                    default: throw new Exception("Opção invalida");
                }

                Console.WriteLine("DESEJA REALIZAR OUTRA OPERAÇÃO: Sim (S), Não (N)");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Main(args); //Recursividade
                }

                Console.WriteLine("FIM DO PROGRAMA");
            }

            else
            {
                throw new Exception("OPÇÂO INVÁLIDA");
            }
        }
    }
}


