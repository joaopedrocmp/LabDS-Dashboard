using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UabDashboard.Classes
{
    public class Uc
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string AnoLetivo { get; set; }

        public IList<Topico> ListaTopicos { get; set; }

    }


}
