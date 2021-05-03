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
    public partial class frmSolicitud : Form {
        private controladoraBanco control;
        public string dniUsuario { get; set; }
        public frmSolicitud() {
            InitializeComponent();
            control = new controladoraBanco();
        }
        public void listar() {
            eUsuario userTemp = controladoraBanco.listaUsuarios.Find(delegate(eUsuario user) { return user.DNI == dniUsuario; });
            listView1.Items.Clear();
            if (userTemp != null) {
                if (userTemp.solicitudes != null) {
                    ListViewItem item;
                    foreach (eSolicitudes solT in userTemp.solicitudes) {
                        item = listView1.Items.Add(solT.idSolicitud.ToString());
                        item.SubItems.Add(solT.prestamoDatos.nroDeCuenta);
                        item.SubItems.Add(solT.prestamoDatos.montoSolicitado.ToString());
                        item.SubItems.Add(solT.prestamoDatos.fechaDeSolicitud);
                        item.SubItems.Add(solT.prestamoDatos.cuotasxPagar.ToString());
                        item.SubItems.Add(solT.resultado);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            frmSolicitarPrestamo x = new frmSolicitarPrestamo();
            x.dniUser = dniUsuario;
            x.Show();
        }
        private void button2_Click(object sender, EventArgs e) {
            Close();
        }

        public void frmSolicitud_Load(object sender, EventArgs e) {
             listar();
        }
        private void button3_Click(object sender, EventArgs e) {
            listar();
        }
    }
}
