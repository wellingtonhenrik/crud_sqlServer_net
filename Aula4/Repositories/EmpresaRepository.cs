using Aula4.Entities;
using Aula4.Helper;
using Aula4.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly string? _connetionString;

        public EmpresaRepository()
        {
            _connetionString = ConfigurationHelper.GetConnectionString();
        }
        public void Add(Empresa empresa)
        {
            var query = @"
                        INSERT INTO EMPRESA(EMPRESAID, NOMEFANTASIA, RAZAOSOCIAL, CNPJ)
                        VALUES(NEWID(), @NomeFantasia, @RazaoSocial, @Cnpj)
                        ";
            using (var connection = new SqlConnection(_connetionString))
            {
                connection.Execute(query, empresa);
            }
        }

        public void Delete(Empresa empresa)
        {
            var query = @"DELETE EMPRESA WHERE EMPRESAID = @EMPRESAID";

            using (var connection = new SqlConnection(_connetionString))
            {
                connection.Execute(query, empresa);
            }
        }

        public List<Empresa> GetAll()
        {
            var query = @"SELECT EMPRESAID AS EmpresaId,  
                        NOMEFANTASIA AS NomeFantasia, 
                        RAZAOSOCIAL AS RazaoSocial, 
                        CNPJ AS Cnpj                
                        FROM EMPRESA
                        ORDER BY NOMEFANTASIA";

            using (var connection = new SqlConnection(_connetionString))
            {
                var empresas = connection.Query<Empresa>(query).ToList();
                return empresas;
            }
        }

        public Empresa? GetById(Guid id)
        {
            var query = $"SELECT * FROM EMPRESA WHERE EMPRESAID = @id";

            using(var connection = new SqlConnection(_connetionString))
            {
                var empresa = connection.Query<Empresa>(query, new {id}).FirstOrDefault();
                return empresa;
            }
        }

        public void Update(Empresa empresa)
        {
            var query = @"UPDATE EMPRESA 
                          SET NOMEFANTASIA = @NOMEFANTASIA,
                          RAZAOSOCIAL = @RAZAOSOCIAL,
                          CNPJ = @CNPJ
                          WHERE EMPRESAID = @EMPRESAID
                          ";

            using (var connection = new SqlConnection(_connetionString))
            {
                connection.Execute(query, empresa);  
            }
        }
    }
}
