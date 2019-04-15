using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UabDashboard.Classes
{
    class Aluno
    {
        int Numero { get; set; }
        string Nome { get; set; }
        string Password { get; set; }
        string Curso { get; set; }
        string Mail { get; set; }

        public Aluno(int numero, string nome, string password, string curso, string mail)
        {
            this.Numero = numero;
            this.Nome = nome;
            this.Password = password;
            this.Curso = curso;
            this.Mail = mail;
        }

        public int GetUser()
        {
            return this.Numero;
        }

        public string GetPassword()
        {
            return this.Password;
        }
    }
}
