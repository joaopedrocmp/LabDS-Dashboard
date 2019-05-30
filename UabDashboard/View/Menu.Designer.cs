namespace UabDashboard.View
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.graph = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_topicoNome = new System.Windows.Forms.Label();
            this.lbl_ucNome = new System.Windows.Forms.Label();
            this.lbl_nomeTarefa = new System.Windows.Forms.Label();
            this.txb_conclusao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_uc_name = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_detalhesTarefa = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(16, 62);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(513, 739);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseClick);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // graph
            // 
            this.graph.Location = new System.Drawing.Point(563, 62);
            this.graph.Margin = new System.Windows.Forms.Padding(5);
            this.graph.Name = "graph";
            this.graph.ScrollGrace = 0D;
            this.graph.ScrollMaxX = 0D;
            this.graph.ScrollMaxY = 0D;
            this.graph.ScrollMaxY2 = 0D;
            this.graph.ScrollMinX = 0D;
            this.graph.ScrollMinY = 0D;
            this.graph.ScrollMinY2 = 0D;
            this.graph.Size = new System.Drawing.Size(883, 290);
            this.graph.TabIndex = 1;
            this.graph.UseExtendedPrintDialog = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lbl_detalhesTarefa);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbl_topicoNome);
            this.panel1.Controls.Add(this.lbl_ucNome);
            this.panel1.Controls.Add(this.lbl_nomeTarefa);
            this.panel1.Controls.Add(this.txb_conclusao);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_uc_name);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(564, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 410);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(405, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Detalhes";
            // 
            // lbl_topicoNome
            // 
            this.lbl_topicoNome.AutoSize = true;
            this.lbl_topicoNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_topicoNome.Location = new System.Drawing.Point(146, 119);
            this.lbl_topicoNome.Name = "lbl_topicoNome";
            this.lbl_topicoNome.Size = new System.Drawing.Size(0, 25);
            this.lbl_topicoNome.TabIndex = 11;
            // 
            // lbl_ucNome
            // 
            this.lbl_ucNome.AutoSize = true;
            this.lbl_ucNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ucNome.Location = new System.Drawing.Point(118, 74);
            this.lbl_ucNome.Name = "lbl_ucNome";
            this.lbl_ucNome.Size = new System.Drawing.Size(0, 25);
            this.lbl_ucNome.TabIndex = 10;
            // 
            // lbl_nomeTarefa
            // 
            this.lbl_nomeTarefa.AutoSize = true;
            this.lbl_nomeTarefa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nomeTarefa.Location = new System.Drawing.Point(146, 176);
            this.lbl_nomeTarefa.Name = "lbl_nomeTarefa";
            this.lbl_nomeTarefa.Size = new System.Drawing.Size(0, 25);
            this.lbl_nomeTarefa.TabIndex = 7;
            // 
            // txb_conclusao
            // 
            this.txb_conclusao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_conclusao.Location = new System.Drawing.Point(220, 351);
            this.txb_conclusao.Name = "txb_conclusao";
            this.txb_conclusao.Size = new System.Drawing.Size(76, 30);
            this.txb_conclusao.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Conclusão (%):";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Detalhes da Tarefa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tarefa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tópico";
            // 
            // lbl_uc_name
            // 
            this.lbl_uc_name.AutoSize = true;
            this.lbl_uc_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_uc_name.Location = new System.Drawing.Point(65, 74);
            this.lbl_uc_name.Name = "lbl_uc_name";
            this.lbl_uc_name.Size = new System.Drawing.Size(47, 25);
            this.lbl_uc_name.TabIndex = 1;
            this.lbl_uc_name.Text = "UC:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(724, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbl_detalhesTarefa
            // 
            this.lbl_detalhesTarefa.AutoSize = true;
            this.lbl_detalhesTarefa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_detalhesTarefa.Location = new System.Drawing.Point(79, 271);
            this.lbl_detalhesTarefa.Name = "lbl_detalhesTarefa";
            this.lbl_detalhesTarefa.Size = new System.Drawing.Size(0, 25);
            this.lbl_detalhesTarefa.TabIndex = 13;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 838);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.treeView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.Shown += new System.EventHandler(this.Menu_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        public ZedGraph.ZedGraphControl graph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_uc_name;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txb_conclusao;
        public System.Windows.Forms.Label lbl_nomeTarefa;
        public System.Windows.Forms.Label lbl_ucNome;
        public System.Windows.Forms.Label lbl_topicoNome;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lbl_detalhesTarefa;
    }
}