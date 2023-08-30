using Aula4.Entities;
using Aula4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aula4.Controllers
{
    public class EmpresaController
    {
        //Atributo
        private readonly EmpresaRepository _empresaRepository;

        //Construtor
        public EmpresaController()
        {
            //Inicializando o(os) atributo(os)
            _empresaRepository = new EmpresaRepository();
        }
        public void CadastrarEmpresa()
        {
            try
            {
                var empresa = new Empresa();
                Console.WriteLine("*** CADASTRO DE EMPRESA ***");

                Console.Write("Informe Nome Fantasia: ");
                empresa.NomeFantasia = Console.ReadLine();

                Console.Write("Informe Razão Social: ");
                empresa.RazaoSocial = Console.ReadLine();

                Console.Write("Informe Cnpj: ");
                empresa.Cnpj = Console.ReadLine();

                _empresaRepository.Add(empresa);


                Console.WriteLine("EMPRESA CADASTRADA COM SUCESSO");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("DESEJA CADASTRAR OUTRA EMPRESA? SIM: (S), NÃO (N)");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                    CadastrarEmpresa();
            }
        }

        public void AtualizarEmpresa()
        {            
            try
            {
                Console.WriteLine("*** ATUALIZAR EMPRESA ***");


                Console.Write("Informe Id da empresa: ");
                var empresaId = Guid.Parse(Console.ReadLine());

                var empresa = _empresaRepository.GetById(empresaId);

                if (empresa is null)
                    throw new Exception("Empresa não encontrada");

                Console.Write("Informe Nome Fantasia: ");
                empresa.NomeFantasia = Console.ReadLine();

                Console.Write("Informe Razão Social: ");
                empresa.RazaoSocial = Console.ReadLine();

                Console.Write("Informe Cnpj: ");
                empresa.Cnpj = Console.ReadLine();

                _empresaRepository.Update(empresa);

                Console.WriteLine("EMPRESA ATUALIZADA COM SUCESSO");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeletarEmpresa()
        {
            try
            {
                Console.WriteLine("*** DELETAR EMPRESA ***");
                Console.Write("Digite Id da empresa que deseja deletar: ");
                var empresaId = Guid.Parse(Console.ReadLine());
                var empresa = _empresaRepository.GetById(empresaId);

                if (empresa is null)
                    throw new Exception("Empresa não encontrada");

                Console.WriteLine("*** DADOS DA EMPRESA ***");
                Console.WriteLine($"Nome Fantasia: {empresa.NomeFantasia}");
                Console.WriteLine($"Razão Social: {empresa.RazaoSocial}");
                Console.WriteLine($"CNPJ: {empresa.Cnpj}");

                Console.Write("DESEJA REALMENTE DELETAR ESTÁ EMPRESA? Sim (S) Não (N)");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    _empresaRepository.Delete(empresa);
                    Console.WriteLine("EMPRESA DELETADA COM SUCESSO");
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
                Console.WriteLine("*** DESEJA DELETAR OUTRA EMPRESA: ***");
                Console.Write("Sim (S), Não (N)");
                var opcao = Console.ReadLine();
                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                    DeletarEmpresa();
            }
        }

        public void ConsultarEmpresa()
        {
            try
            {
                Console.WriteLine("CONSULTA DE EMPRESAS");

                var empresas = _empresaRepository.GetAll();

                if (!empresas.Any())
                    throw new Exception("Não há registro de empresas");

                Console.WriteLine("*** DADOS DAS EMPRESAS ***\n");
                foreach (var empresa in empresas)
                {
                    Console.WriteLine($"\nNome Fantasia: {empresa.NomeFantasia}");
                    Console.WriteLine($"Razão Social: {empresa.RazaoSocial}");
                    Console.WriteLine($"CNPJ: {empresa.Cnpj}\n");
                }

                Console.WriteLine($"QUANTIDADE DE EMPRESAS: {empresas.Count()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
            }
        }
    }
}
