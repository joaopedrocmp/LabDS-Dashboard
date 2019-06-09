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
        static long idTarefaAtual = 0;
        static long idTopicoAtual = 0;
        static long idUcAtual = 0;


        [STAThread]
        static void Main()
        {
            loginView = new Form1();
            menuView = new View.Menu();
            loginModel = new LoginModel();
            menuModel = new MenuModel();

            studentData = new StudentData();

            // Eventos View Form1 (login)
            loginView.OnLoginAttempted += CheckLogin;

            menuView.OnLoadTree += LoadTreeData;

            // Eventos View Menu
            menuView.OnFormClosed += menuViewClose;

            menuView.OnLoadGraph += menuLoadGraph;

            menuView.OnNodeClick += menuNodeClick;

            menuView.OnSaveButtonClick += SaveButtonClick;

            //Eventos Model
            loginModel.OnLoginAttemptedResponse += CheckLoginResponse;

            menuModel.OnLoadTreeResponse += TreeLoad;

            menuModel.OnGetTarefaResponse += LoadTarefa;

            menuModel.OnGuardaDados += GuardaDadosResponse;


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
                popup = new Popup();
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
                popup = new Popup();
                popup.Show();
                popup.BringToFront();
                popup.textBox1.Text = "Ups, algo não está bem!" + Environment.NewLine;
                popup.textBox1.Text += "Erro: -";
                popup.textBox1.Text += ex.Message + Environment.NewLine;
                popup.textBox1.Text += "Em: -";
                popup.textBox1.Text = ex.StackTrace;
            }
        }

        static void menuLoadGraph(object sender, EventArgs e)
        {
            GraphPane myPane = menuView.graph.GraphPane;

            List<Color> colorList = new List<Color>();
            colorList = FillColorlist();

            myPane.Title.Text = "Uc Status";
            myPane.XAxis.Title.Text = "Uc";

            myPane.YAxis.Title.Text = "Completo";
            myPane.XAxis.IsVisible=false;
            // myPane.YAxis. = 100;

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
                // ponto de Debugg

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

        private static void menuNodeClick(object sender, EventArgs e)
        {
            try
            {
                if (menuView.treeView1.SelectedNode.Parent.Parent != null)
                {
                    menuModel.GetTarefa(username,menuView.treeView1.SelectedNode.Parent.Parent.Index, 
                                         menuView.treeView1.SelectedNode.Parent.Index, menuView.treeView1.SelectedNode.Index);
                }
            }
            catch (NullReferenceException ex)
            {
                menuView.lbl_nomeTarefa.Text = "";
                menuView.lbl_topicoNome.Text = "";
                menuView.lbl_ucNome.Text = "";               
            }
            catch(Exception ex)
            {
                popup = new Popup();
                popup.Show();
                popup.BringToFront();
                popup.textBox1.Text = "Ups, algo não está bem!" + Environment.NewLine;
                popup.textBox1.Text += "Erro: -";
                popup.textBox1.Text +=  ex.Message + Environment.NewLine;
                popup.textBox1.Text += "Em: -";
                popup.textBox1.Text = ex.StackTrace;
            }
        }

        static void LoadTarefa(object sender, GetTarefaResponseHandlerEventArgs e)
        {
            menuView.lbl_ucNome.Text = e.nomeUC;
            menuView.lbl_topicoNome.Text = e.nomeTopico;
            menuView.lbl_nomeTarefa.Text = e.tarefa.Nome;
            menuView.lbl_detalhesTarefa.Text = e.tarefa.Detalhes;
            menuView.txb_conclusao.Text = e.tarefa.Conclusao.ToString();
            idTarefaAtual = e.tarefa.Id;
            idTopicoAtual = e.idTopicoAtual;
            idUcAtual = e.idUcAtual;
        }

        private static void SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                foreach (var uc in studentData.ListaUcs)
                {
                    if (uc.Id == idUcAtual)
                    {
                        foreach (var topico in uc.ListaTopicos)
                        {
                            if (topico.Id == idTopicoAtual)
                            {
                                foreach (var tarefa in topico.ListaTarefas)
                                {
                                    if (tarefa.Id == idTarefaAtual)
                                    {
                                        tarefa.Conclusao = Convert.ToInt32(menuView.txb_conclusao.Text);
                                        menuModel.GuardaDados(studentData);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                popup = new Popup();
                popup.Show();
                popup.BringToFront();
                popup.textBox1.Text = "Ups, algo não está bem!" + Environment.NewLine;
                popup.textBox1.Text += "Erro: -";
                popup.textBox1.Text += ex.Message + Environment.NewLine;
                popup.textBox1.Text += "Em: -";
                popup.textBox1.Text = ex.StackTrace;
            }        
        }

        static void GuardaDadosResponse(object sender, GuardaDadosResponseHandlerEventArgs e)
        {
            if(e.validation)
            {
                popup = new Popup();
                menuView.Show();
                loginView.Hide();
                popup.textBox1.Text = "Alterações Guardadas";
                popup.Show();
                popup.BringToFront();
            }
            else
            {
                popup = new Popup();
                menuView.Show();
                loginView.Hide();
                popup.textBox1.Text = "Erro ao guardar alterações";
                popup.Show();
                popup.BringToFront();
            }
        }



    }
}
