﻿using Microsoft.VisualBasic.Devices;

namespace sistemas_distribuidos_A3
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
            btnListar = new Button();
            label1 = new Label();
            txtNomeMoeda2 = new TextBox();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
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
            btnSalvar.Click += btnSalvar_Click;
            // 
            // richTextBoxMoedas
            // 
            richTextBoxMoedas.Location = new Point(12, 70);
            richTextBoxMoedas.Name = "richTextBoxMoedas";
            richTextBoxMoedas.Size = new Size(466, 257);
            richTextBoxMoedas.TabIndex = 6;
            richTextBoxMoedas.Text = "";
            // 
            // btnListar
            // 
            btnListar.Location = new Point(298, 41);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(180, 23);
            btnListar.TabIndex = 7;
            btnListar.Text = "Exibir Moedas Salvas";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 341);
            label1.Name = "label1";
            label1.Size = new Size(309, 15);
            label1.TabIndex = 8;
            label1.Text = "Digite o nome da moeda que deseja modificar ou excluir:";
            // 
            // txtNomeMoeda2
            // 
            txtNomeMoeda2.Location = new Point(327, 338);
            txtNomeMoeda2.Name = "txtNomeMoeda2";
            txtNomeMoeda2.Size = new Size(151, 23);
            txtNomeMoeda2.TabIndex = 9;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(403, 367);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 11;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(327, 367);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 14;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            btnExcluir.Location = new Point(405, 367);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 11;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnEditar);
            Controls.Add(btnExcluir);
            Controls.Add(txtNomeMoeda2);
            ClientSize = new Size(490, 394);
            Controls.Add(btnExcluir);
            Controls.Add(label1);
            Controls.Add(btnListar);
            Controls.Add(richTextBoxMoedas);
            Controls.Add(btnSalvar);
            Controls.Add(btnBuscar);
            Controls.Add(txtNomeMoeda);
            Controls.Add(labelMoeda);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button btnListar;
        private Label label1;
        private TextBox txtNomeMoeda2;
        private Button btnExcluir;
        private Button btnEditar;
        private TextBox textBox1;
        private Button button2;
        private Button btnDelete;
    }
}
