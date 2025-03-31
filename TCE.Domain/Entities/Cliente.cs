using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Domain.Common;

namespace TCE.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        private Cliente() { }
        public Cliente(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataCadastro = DateTime.Now;
        }

        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public string? Telefone { get; private set; }

        public DateTime DataCadastro { get; private set; }


        private List<Compra> _compras = [];
        public IReadOnlyCollection<Compra> Compras => _compras.AsReadOnly();

        public void AdicionarCompra(Compra compra)
        {
            if (compra == null)
                throw new Exception("Compra não pode ser nula");

            _compras.Add(compra);
        }
    }

}
