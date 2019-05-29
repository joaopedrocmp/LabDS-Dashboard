using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UabDashboard.Classes
{
    public class Topico
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IList<Tarefa> ListaTarefas { get; set; }
    }
}
