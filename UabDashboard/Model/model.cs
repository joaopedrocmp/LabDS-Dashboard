using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UabDashboard.Classes;

namespace UabDashboard
{
    
    // *****************************************//
    //              Login Model                 //
    // *****************************************//

    public delegate void CheckUserResponseHandlerHandler<Model>(Model sender, CheckUserResponseHandlerEventArgs e);

    // Argumentos do Model Login
    public class CheckUserResponseHandlerEventArgs : EventArgs
    {
        public bool userValidation { get; set; }
    }

    // Model Login
    public class LoginModel
    {
        public event CheckUserResponseHandlerHandler<LoginModel> OnLoginAttemptedResponse;

        CheckUserResponseHandlerEventArgs args = new CheckUserResponseHandlerEventArgs();

        // procura ficheiro com nome do utilizador e verifica o parametro password
         public void CheckUser(string username, string password)
         {
            try
            {
                using (StreamReader r = new StreamReader(@"files\" + username + ".json"))
                {
                    string jsonString = r.ReadToEnd();

                    dynamic results = JsonConvert.DeserializeObject<dynamic>(jsonString);

                    if (results.Password == password)
                    {
                        args.userValidation = true;
                        OnLoginAttemptedResponse.Invoke(this, args);
                    }
                    else
                    {
                        args.userValidation = false;
                        OnLoginAttemptedResponse.Invoke(this, args);
                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                // por razões de segurança não interessa devolver a mensagem de que o ficheiro (username) não existe, mas pode ser apanhada com:
                // ex.Message
                args.userValidation = false;
                OnLoginAttemptedResponse.Invoke(this, args);
            }
         }
    }



    // ****************************************//
    //              Menu Model                 //
    // ****************************************//


    public delegate void LoadTreeResponseHandler<Model>(Model sender, LoadTreeResponseHandlerEventArgs e);

    public delegate void GetTarefaResponseHandler<Model>(Model sender, GetTarefaResponseHandlerEventArgs e);

    public delegate void GuardaDadosResponseHandler<Model>(Model sender, GuardaDadosResponseHandlerEventArgs e);

    // Argumentos do Model menu
    public class LoadTreeResponseHandlerEventArgs : EventArgs
    {
        public StudentData studentData { get; set; }
    }

    public class GetTarefaResponseHandlerEventArgs : EventArgs
    {
        public Tarefa tarefa { get; set; }
        public string nomeUC { get; set; }
        public string nomeTopico { get; set; }
        public long idTopicoAtual { get; set; }
        public long idUcAtual { get; set; }
    }

    public class GuardaDadosResponseHandlerEventArgs : EventArgs
    {
        public bool validation { get; set; }
    }


    public class MenuModel
    {
        public event LoadTreeResponseHandler<MenuModel> OnLoadTreeResponse;

        public void LoadTree(string username)
        {
            LoadTreeResponseHandlerEventArgs args = new LoadTreeResponseHandlerEventArgs();

            using (StreamReader r = new StreamReader(@"files\" + username + ".json"))
            {
                string jsonString = r.ReadToEnd();

                StudentData studentData = new StudentData();

                studentData = JsonConvert.DeserializeObject<StudentData>(jsonString);

                args.studentData = studentData;

                OnLoadTreeResponse.Invoke(this, args);
            }
        }


        public event GetTarefaResponseHandler<MenuModel> OnGetTarefaResponse;

        GetTarefaResponseHandlerEventArgs targs = new GetTarefaResponseHandlerEventArgs();

        public void GetTarefa(string username , int indexUC, int indexTopico, int indexTarefa)
        {
            int i = 0;
            int j;
            int k;
            try
            {
                using (StreamReader r = new StreamReader(@"files\" + username + ".json"))
                {
                    string jsonString = r.ReadToEnd();

                    StudentData studentData = new StudentData();

                    studentData = JsonConvert.DeserializeObject<StudentData>(jsonString);

                    foreach (var uc in studentData.ListaUcs)
                    {
                        if (i == indexUC)
                        {
                            j = 0;
                            foreach (var topico in uc.ListaTopicos)
                            {
                                if (j == indexTopico)
                                {
                                    k = 0;
                                    foreach (var tarefa in topico.ListaTarefas)
                                    {
                                        if (k == indexTarefa)
                                        {
                                            targs.nomeUC = uc.Nome;
                                            targs.nomeTopico = topico.Nome;
                                            targs.tarefa = tarefa;
                                            targs.idUcAtual = studentData.ListaUcs[i].Id;
                                            targs.idTopicoAtual = studentData.ListaUcs[i].ListaTopicos[j].Id;
                                            OnGetTarefaResponse.Invoke(this, targs);
                                        }
                                        k++;
                                    }
                                }
                                j++;
                            }

                        }
                        i++;
                    }

                }
            }
            catch (Exception )
            {
                return;
            }
        }


        public event GuardaDadosResponseHandler<MenuModel> OnGuardaDados;
        GuardaDadosResponseHandlerEventArgs gArgs = new GuardaDadosResponseHandlerEventArgs();

        public void GuardaDados(StudentData studentData)
        {
            try
            {
                File.WriteAllText(@"files\4.json", JsonConvert.SerializeObject(studentData));

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"files\"+ studentData.numero +".json", true))
                {
                    file.WriteLine(studentData);
                }

                gArgs.validation = true;
            }
            catch
            {
                gArgs.validation = false;
            }
            OnGuardaDados(this, gArgs);
        }

        
    }
}
