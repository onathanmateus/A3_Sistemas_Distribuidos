namespace sistemas_distribuidos_A3
{
    partial class FormEditar
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
            label1 = new Label();
            btnSalvarAlteracao = new Button();
            txtNomeAtual = new TextBox();
            label2 = new Label();
            txtNovoNome = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome atual da moeda:";
            // 
            // btnSalvarAlteracao
            // 
            btnSalvarAlteracao.Location = new Point(83, 85);
            btnSalvarAlteracao.Name = "btnSalvarAlteracao";
            btnSalvarAlteracao.Size = new Size(119, 23);
            btnSalvarAlteracao.TabIndex = 1;
            btnSalvarAlteracao.Text = "Salvar Alterações";
            btnSalvarAlteracao.UseVisualStyleBackColor = true;
            // 
            // txtNomeAtual
            // 
            txtNomeAtual.Enabled = false;
            txtNomeAtual.Location = new Point(150, 6);
            txtNomeAtual.Name = "txtNomeAtual";
            txtNomeAtual.ReadOnly = true;
            txtNomeAtual.Size = new Size(119, 23);
            txtNomeAtual.TabIndex = 2;
            txtNomeAtual.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 43);
            label2.Name = "label2";
            label2.Size = new Size(132, 15);
            label2.TabIndex = 3;
            label2.Text = "Novo nome da  moeda:";
            // 
            // txtNovoNome
            // 
            txtNovoNome.Location = new Point(150, 40);
            txtNovoNome.Name = "txtNovoNome";
            txtNovoNome.Size = new Size(119, 23);
            txtNovoNome.TabIndex = 4;
            // 
            // FormEditar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 120);
            Controls.Add(txtNovoNome);
            Controls.Add(label2);
            Controls.Add(txtNomeAtual);
            Controls.Add(btnSalvarAlteracao);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEditar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Renomear";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSalvarAlteracao;
        private TextBox txtNomeAtual;
        private Label label2;
        private TextBox txtNovoNome;
    }
}