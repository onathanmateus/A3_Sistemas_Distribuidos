﻿namespace sistemas_distribuidos_A3
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelMoeda = new Label();
            txtNomeMoeda = new TextBox();
            btnBuscar = new Button();
            btnSalvar = new Button();
            richTextBoxMoedas = new RichTextBox();
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // labelMoeda
            // 
            labelMoeda.AutoSize = true;
            labelMoeda.Location = new Point(12, 15);
            labelMoeda.Name = "labelMoeda";
            labelMoeda.Size = new Size(151, 15);
            labelMoeda.TabIndex = 0;
            labelMoeda.Text = "Qual moeda deseja buscar?";
            // 
            // txtNomeMoeda
            // 
            txtNomeMoeda.Location = new Point(169, 12);
            txtNomeMoeda.Name = "txtNomeMoeda";
            txtNomeMoeda.Size = new Size(123, 23);
            txtNomeMoeda.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(298, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(87, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(391, 12);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(87, 23);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar Moeda";
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // richTextBoxMoedas
            // 
            richTextBoxMoedas.Location = new Point(12, 70);
            richTextBoxMoedas.Name = "richTextBoxMoedas";
            richTextBoxMoedas.Size = new Size(466, 257);
            richTextBoxMoedas.TabIndex = 6;
            richTextBoxMoedas.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(298, 41);
            button1.Name = "button1";
            button1.Size = new Size(180, 23);
            button1.TabIndex = 7;
            button1.Text = "Exibir Moedas Salvas";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 341);
            label1.Name = "label1";
            label1.Size = new Size(306, 15);
            label1.TabIndex = 8;
            label1.Text = "Digite o nome da moeda que deseja modificar ou excluir";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(324, 338);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(154, 23);
            textBox1.TabIndex = 9;
            // 
            // button2
            // 
            button2.Location = new Point(324, 367);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(405, 367);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 11;
            button3.Text = "Excluir";
            button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 394);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(richTextBoxMoedas);
            Controls.Add(btnSalvar);
            Controls.Add(btnBuscar);
            Controls.Add(txtNomeMoeda);
            Controls.Add(labelMoeda);
            Name = "MainForm";
            Text = "BuscaCoin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMoeda;
        private TextBox txtNomeMoeda;
        private Button btnBuscar;
        private Button btnSalvar;
        private RichTextBox richTextBoxMoedas;
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
    }
}
