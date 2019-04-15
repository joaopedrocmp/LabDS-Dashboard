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
    public delegate void ModelHandler<Model>(Model sender, ModelEventArgs e);
        // The ModelEventArgs class which is derived from th EventArgs class to 
    // be passed on to the controller when the value is changed
    public class ModelEventArgs : EventArgs
    {
        public bool userValidation;
        public ModelEventArgs(bool validation)
        {
            userValidation = validation;
        }
    }

    // The interface which the form/view must implement so that, the event will be
    // fired when a value is changed in the model.
    public interface IModelObserver
    {
        void ReturnValidation(IModel model, ModelEventArgs e);
    }

    public interface IModel
    {
        void Validate(IModelObserver imo);
        void CheckUser(string username, string password);
    }

    public class LoginModel : IModel
    {
        public event ModelHandler<LoginModel> Changed;
       // int value;
        bool validaUser = false;

        // implementation of IModel interface set the initial value to 0

        public void CheckUser(string username, string password)
        {
            Aluno aluno;
            try
            {
                using (StreamReader r = new StreamReader(@"files\" + username + ".json"))
                {
                    string json = r.ReadToEnd();
                    aluno = JsonConvert.DeserializeObject<Aluno>(json);

                    if (aluno.GetPassword() == password)
                    {
                        Changed.Invoke(this, new ModelEventArgs(true));
                    }
                    else
                    {
                        Changed.Invoke(this, new ModelEventArgs(false));
                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                // por razões de segurança não interessa devolver a mensagem de que o ficheiro (username) não existe, mas pode ser apanhada com:
                // ex.Message
                Changed.Invoke(this, new ModelEventArgs(false));
            }




        }
        // Attach the function which is implementing the IModelObserver so that it can be
        // notified when a value is changed
        public void Validate(IModelObserver imo)
        {
            Changed += new ModelHandler<LoginModel>(imo.ReturnValidation);
        }
    }
}
