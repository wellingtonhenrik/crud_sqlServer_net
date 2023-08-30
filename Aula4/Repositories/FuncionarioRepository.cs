using Aula4.Entities;
using Aula4.Helper;
using Aula4.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Aula4.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly string _connetionString;

        public FuncionarioRepository()
        {
            _connetionString = ConfigurationHelper.GetConnectionString();

        }
        public void Add(Funcionario funcionario)
        {
            var query = @"INSERT INTO FUNCIONARIO(FUNCIONARIOID,NOME,CPF,DATAADMISSAO,EMPRESAID)
                          VALUES(NEWID(),@NOME, @CPF, @DATAADMISSAO, @EMPRESA.EMPRESAID)";

            using (var connetion = new SqlConnection(_connetionString))
            {
                connetion.Execute(query, funcionario);
            }
        }

        public void Delete(Funcionario funcionario)
        {
            var query = @"DELETE FUNCIONARIO WHERE FUNCIONARIOID = @FUNCIONARIOID";

            using (var connection = new SqlConnection(_connetionString))
            {
                connection.Execute(query, funcionario);
            }
        }

        public List<Funcionario> GetAll()
        {
            var query = @"SELECT NOME AS Nome, 
                          CPF AS Cpf,
                          DATAADMISSAO AS DataAdmissao,
                          EMPRESAID AS Empresaid";

            using (var connection = new SqlConnection(_connetionString))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }
        public Funcionario GetById(Guid id)
        {
            var query = @"SELECT  NOME AS Nome, 
                          CPF AS Cpf,
                          DATAADMISSAO AS DataAdmissao,
                          EMPRESAID AS Empresaid
                          WHERE FUNCIONARIOID = @id";

            using (var connection = new SqlConnection(_connetionString))
            {
                var funcionario = connection.Query<Funcionario>(query, new { id }).FirstOrDefault();
                return funcionario;
            }
        }

        public void Update(Funcionario funcionario)
        {
            var query = @"UPDATE FUNCIONARIO SET CPF = @Cpf, 
                          DATAEMISSAO = @Dataemissao, 
                          EMPRESAID = @EmpresaId 
                          WHERE FUNCIONARIOID = @FuncionarioId";

            using (var connection = new SqlConnection(_connetionString))
            {
                connection.Execute(query, funcionario);
            }
        }
    }
}
