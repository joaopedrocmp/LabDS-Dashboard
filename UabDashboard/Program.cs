using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UabDashboard.Classes;
using UabDashboard.View;
using ZedGraph;

namespace UabDashboard
{
    static class Program
    {
        static View.Form1 loginView;
        static LoginModel loginModel;
        static View.Menu menuView;
        static string username;
        static MenuModel menuModel;
        static Popup popup;
        static StudentData studentData;


        [STAThread]
        static void Main()
        {
            loginView = new Form1();
            menuView = new View.Menu();
            loginModel = new LoginModel();
            menuModel = new MenuModel();
            popup = new Popup();

            studentData = new StudentData();

            // Eventos View Form1 (login)
            loginView.OnLoginAttempted += CheckLogin;

            menuView.OnLoadTree += LoadTreeData;

            // Eventos View Menu
            menuView.OnFormClosed += menuViewClose;

            menuView.OnLoadGraph += menuLoadGraph;

            //Eventos Model
            loginModel.OnLoginAttemptedResponse += CheckLoginResponse;

            menuModel.OnLoadTreeResponse += TreeLoad;

            Application.Run(loginView);
        }



        // ********************************** //
        //          View Form1(Login)         //
        //************************************//
        static void CheckLogin(object sender, EventArgs e)
        {
            username = loginView.txbUsername.Text;
            loginModel.CheckUser(loginView.txbUsername.Text, loginView.txbPassword.Text);
            loginView.txbPassword.Text = string.Empty;
            loginView.txbUsername.Text = string.Empty;
        }

        static void menuViewClose( object sender,EventArgs e)
        {
            loginView.Close();
        }

        static void CheckLoginResponse(object sender, CheckUserResponseHandlerEventArgs e)
        {
           if(e.userValidation)
            {
                menuView.Show();
                loginView.Hide();
                popup.textBox1.Text = " Bem-vindo !";
                popup.Show();
                popup.BringToFront();
            }
            else
            {
                // acão para erro no login
            }
        }

        // ********************************** //
        //          View Menu                 //
        //************************************//

        static void LoadTreeData(object sender, EventArgs e)
        {
            menuModel.LoadTree(username);
        }

        static void TreeLoad(object sender, LoadTreeResponseHandlerEventArgs e)
        {
            int ucNodeCount = 0;
            int topicNodeCount;
            studentData = e.studentData;

            try
            {
                menuView.treeView1.CheckBoxes = true;
                foreach (var uc in e.studentData.ListaUcs)
                {
                    topicNodeCount = 0;

                    menuView.treeView1.Nodes.Add(uc.Id.ToString());

                    foreach (var topico in uc.ListaTopicos)
                    {
                        menuView.treeView1.Nodes[ucNodeCount].Nodes.Add(topico.Nome);

                        foreach (var tarefa in topico.ListaTarefas)
                        {
                            TreeNode nodeTarefa = new TreeNode();

                            if (tarefa.Conclusao==100)
                            {
                                nodeTarefa.Checked = true;
                                nodeTarefa.Text = tarefa.Nome;

                                menuView.treeView1.Nodes[ucNodeCount].Nodes[topicNodeCount].Nodes.Add(nodeTarefa);
                            }
                            else
                            {
                                nodeTarefa.Checked = false;
                                nodeTarefa.Text = tarefa.Nome;
                                menuView.treeView1.Nodes[ucNodeCount].Nodes[topicNodeCount].Nodes.Add(nodeTarefa);
                            }
                        }
                        topicNodeCount++;
                    }

                    ucNodeCount++;
                }
            }
            catch (Exception ex)
            {
                popup.Show();
                popup.BringToFront();
                popup.textBox1.Text = ex.Message;
            }
        }

        static void menuLoadGraph(object sender, EventArgs e)
        {
            GraphPane myPane = menuView.graph.GraphPane;

            List<Color> colorList = new List<Color>();
            colorList = FillColorlist();

            myPane.Title = "Uc Status";
            myPane.XAxis.Title = "Uc";

            myPane.YAxis.Title = "Completo";
            myPane.YAxis.Min = 0;
            myPane.YAxis.Max = 100;
            //myPane.XAxis.ScaleFormat.;// .MajorGrid.IsZeroLine = false;

            int i = 1;
            int colorNo = 0;
            double media = 0;

            foreach (var uc in studentData.ListaUcs)
            {
                PointPairList ucPairList = new PointPairList();
                List<int> listaTarefas = new List<int>();

                // Cria lista de tarefas
                foreach (var topico in uc.ListaTopicos)
                {
                    foreach ( var tarefa in topico.ListaTarefas)
                    {
                        listaTarefas.Add(tarefa.Conclusao);
                    }
                }
                int total = 0;

                //calcula média 
                foreach(var t in listaTarefas)
                {
                    total += t;
                }
                media = total / listaTarefas.Count;

                ucPairList.Add(new ZedGraph.PointPair { X = i, Y = media });
                //MessageBox.Show((total / listaTarefas.Count).ToString());  // Debugg

                BarItem ucBar = myPane.AddBar(uc.Id + " - " + uc.Nome, ucPairList, colorList[colorNo]);
                i+=1;
                colorNo++;
            }

            // atualiza gráfico
            menuView.graph.AxisChange();
        }

        private static List<Color> FillColorlist()
        {
            List<Color> colorList = new List<Color>();
            
            colorList.Add(Color.Red);
            colorList.Add(Color.Blue);
            colorList.Add(Color.Green);
            colorList.Add(Color.Yellow);
            colorList.Add(Color.Orange);

            return colorList;
        }
    }
}
