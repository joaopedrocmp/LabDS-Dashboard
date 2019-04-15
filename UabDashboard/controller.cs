using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UabDashboard
{
    public interface IController
    {
        void CheckUser(string username, string password);
    }

    public class LoginController : IController
    {
        IView view;
        IModel model;

        public LoginController(IView v, IModel m)
        {
            view = v;
            model = m;
            view.SetController(this);
            model.Validate((IModelObserver)view);
        }

        public void CheckUser(string username, string password)
        {
            model.CheckUser(username, password);
        }

    }
}
