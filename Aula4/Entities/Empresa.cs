using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4.Entities
{
    public class Empresa
    {
        public Empresa()
        {
            EmpresaId = Guid.NewGuid();

        }
        private Guid _empresaId;
        private string? _nomeFantasia;
        private string? _razaoSocial;
        private string? _cnpj;
        private List<Funcionario>? _funcionarios; 

        public Guid EmpresaId
        {
            get => _empresaId;
            set => _empresaId = value;
        }

        public string? NomeFantasia
        {
            get => _nomeFantasia;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Informe nome fantasia");

                _nomeFantasia = value;
            }
        }

        public string? RazaoSocial
        {
            get => _razaoSocial;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Informe razão social");

                _razaoSocial = value;
            }
        }
        public string? Cnpj
        {
            get => _cnpj;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Informe cnpj");

                _cnpj = value;
            }
        }

        public List<Funcionario>? Funcionarios
        {
            get=> _funcionarios;
            set => _funcionarios = value;
        }
    }
}
