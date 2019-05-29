using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UabDashboard.Classes
{
    public class StudentData
    {
        public long numero { get; set; }

        public string Nome { get; set; }

        public string Password { get; set; }

        public string Curso { get; set; }

        public string Mail { get; set; }

        public IList<Uc> ListaUcs { get; set; }
    }
}
