using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Sprint5.Models
{
    public class Cidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }

        public IList<Clientes> ClientesQueHabitam { get; set; }
        public Cidades()
        {
            ClientesQueHabitam = new List<Clientes>();
        }
    }
}
