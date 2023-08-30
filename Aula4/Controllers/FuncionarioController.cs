using Aula4.Entities;
using Aula4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4.Controllers
{
    public class FuncionarioController
    {
        //Atributo
        private readonly FuncionarioRepository _funcionarioRepository;

        //Construtor
        public FuncionarioController()
        {
            //Inicializando o(os) atributo(os)
            _funcionarioRepository = new FuncionarioRepository();
        }
        public void CadastrarFuncionario()
        {
            try
            {
                var Funcionario = new Funcionario();
                Console.WriteLine("*** CADASTRO DE FUNCIONARIO ***");

                Console.Write("Informe Nome: ");
                Funcionario.Nome = Console.ReadLine();

                Console.Write("Informe CPF: ");
                Funcionario.Cpf = Console.ReadLine();

                Console.Write("Informe Matricula: ");
                Funcionario.Matricula = Console.ReadLine();

                _funcionarioRepository.Add(Funcionario);


                Console.WriteLine("FUNCIONARIO CADASTRADA COM SUCESSO");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("DESEJA CADASTRAR OUTRO FUNCIONARIO? SIM: (S), NÃO (N)");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                    CadastrarFuncionario();
            }
        }

        public void AtualizarFuncionario()
        {
            try
            {
                Console.WriteLine("*** ATUALIZAR FUNCIONARIO ***");


                Console.Write("Informe Id dO Funcionario: ");
                var FuncionarioId = Guid.Parse(Console.ReadLine());

                var Funcionario = _funcionarioRepository.GetById(FuncionarioId);

                if (Funcionario is null)
                    throw new Exception("Funcionario não encontrada");

                Console.Write("Informe Nome: ");
                Funcionario.Nome = Console.ReadLine();

                Console.Write("Informe CPF: ");
                Funcionario.Cpf = Console.ReadLine();

                Console.Write("Informe Matricula: ");
                Funcionario.Matricula = Console.ReadLine();

                _funcionarioRepository.Update(Funcionario);

                Console.WriteLine("FUNCIONARIO ATUALIZADO COM SUCESSO");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeletarFuncionario()
        {
            try
            {
                Console.WriteLine("*** DELETAR FUNCIONARIO ***");
                Console.Write("Digite Id do Funcionario que deseja deletar: ");
                var FuncionarioId = Guid.Parse(Console.ReadLine());
                var Funcionario = _funcionarioRepository.GetById(FuncionarioId);

                if (Funcionario is null)
                    throw new Exception("Funcionario não encontrada");

                Console.WriteLine("*** DADOS DA Funcionario ***");
                Console.WriteLine($"Nome: {Funcionario.Nome}");
                Console.WriteLine($"CPF: {Funcionario.Cpf}");
                Console.WriteLine($"Matricula: {Funcionario.Matricula}");

                Console.Write("DESEJA REALMENTE DELETAR ESTÁ FUNCIONARIO? Sim (S) Não (N)");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    _funcionarioRepository.Delete(Funcionario);
                    Console.WriteLine("FUNCIONARIO DELETADA COM SUCESSO");
                }
                else
                {
                    Console.WriteLine("OPERAÇÃO CANCELADA");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("*** DESEJA DELETAR OUTRO FUNCIONARIO: ***");
                Console.Write("Sim (S), Não (N)");
                var opcao = Console.ReadLine();
                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                    DeletarFuncionario();
            }
        }

        public void ConsultarFuncionario()
        {
            try
            {
                Console.WriteLine("CONSULTA DE FUNCIONARIOS");

                var funcionarios = _funcionarioRepository.GetAll();

                if (!funcionarios.Any())
                    throw new Exception("Não há registro de Funcionarios");

                Console.WriteLine("*** DADOS DAS FuncionarioS ***\n");
                foreach (var funcionario in funcionarios)
                {
                    Console.WriteLine($"\nNome: {funcionario.Nome}");
                    Console.WriteLine($"CPF: {funcionario.Cpf}");
                    Console.WriteLine($"Matricula: {funcionario.Matricula}\n");
                }

                Console.WriteLine($"QUANTIDADE DE FUNCIONARIOS: {funcionarios.Count()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
            }
        }
    }
}

