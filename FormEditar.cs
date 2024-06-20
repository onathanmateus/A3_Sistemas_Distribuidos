using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemas_distribuidos_A3
{
    public partial class FormEditar : Form
    {
        public FormEditar(String text)
        {
            InitializeComponent();

            txtNomeAtual.Text = text;
        }

    }
}
