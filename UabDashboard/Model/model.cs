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

    // Argumentos do Model Login
    public class LoadTreeResponseHandlerEventArgs : EventArgs
    {
        public StudentData studentData { get; set; }
    }

    public class MenuModel
    {
        public event LoadTreeResponseHandler<MenuModel> OnLoadTreeResponse;

        LoadTreeResponseHandlerEventArgs args = new LoadTreeResponseHandlerEventArgs();

        public void LoadTree(string username)
        {
            using (StreamReader r = new StreamReader(@"files\" + username + ".json"))
            {
                string jsonString = r.ReadToEnd();

                StudentData studentData = new StudentData();

                studentData = JsonConvert.DeserializeObject<StudentData>(jsonString);

                args.studentData = studentData;

                OnLoadTreeResponse.Invoke(this, args);
            }
        }


        
    }
    

}
