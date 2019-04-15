using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UabDashboard
{
    public delegate void ViewHandler<IView>(IView sender, ViewEventArgs e);

    public class ViewEventArgs : EventArgs
    {
    }

    public interface IView
    {
        event ViewHandler<IView> Changed;
        void SetController(IController cont);
    }

}
