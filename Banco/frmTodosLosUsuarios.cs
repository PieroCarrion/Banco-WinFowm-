using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco {
    public partial class frmTodosLosUsuarios : Form {

        public frmTodosLosUsuarios() {
            InitializeComponent();
        }

        private void frmTodosLosUsuarios_Load(object sender, EventArgs e) {
            if (controladoraBanco.listaUsuarios.Count() != 0) {
                ListViewItem item;
                foreach (eUsuario user in controladoraBanco.listaUsuarios) {
                    item = listView1.Items.Add(user.DNI);
                    item.SubItems.Add(user.nombre);
                    item.SubItems.Add(user.apPaterno);
                    item.SubItems.Add(user.apMaterno);
                    item.SubItems.Add(user.edad.ToString());
                    item.SubItems.Add(user.tarjetas.Count().ToString());
                }
            }else {
                MessageBox.Show("No hay usuarios");
                Close();
            }
        }
    }
}
