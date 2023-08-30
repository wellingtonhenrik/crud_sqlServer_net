using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4.Entities
{
    public class Funcionario
    {
        public Funcionario()
        {
            FuncionarioId = Guid.NewGuid();
            Empresa= new Empresa();
        }
        private Guid _funcionarioId;
        private string? _nome;
        private string? _cpf;
        private string? _matricula;
        private DateTime? _dataAdmissao;
        private Empresa? _empresa; 

        public Guid FuncionarioId 
        {
            get => _funcionarioId;
            set => _funcionarioId = value;            
        }   

        public string? Nome 
        {
            get => _nome; 
            set 
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Informe Nome");
                _nome = value; 
            } 
        }

        public Empresa? Empresa 
        { 
            get => _empresa;
            set => _empresa = value;
        }
        public string? Cpf 
        { 
            get => _cpf;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Informe Cpf");
                _cpf = value; 
            }  
        }
        public string? Matricula
        { 
            get => _matricula; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Informe Cpf");
            }
        }
        public DateTime? DataAdmissao 
        { 
            get => _dataAdmissao;
            set
            {
                if (!value.HasValue)
                    throw new ArgumentException("Informe data admissão");
                _dataAdmissao = value;
            }
        }
    }

}
