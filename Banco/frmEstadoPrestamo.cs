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
    public partial class frmEstadoPrestamo : Form {
        public string dniUser { get; set; }
        private controladoraBanco control;
        public frmEstadoPrestamo() {
            InitializeComponent();
            control = new controladoraBanco();
        }

        private void frmEstadoPrestamo_Load(object sender, EventArgs e) {
            if (control.getUser(dniUser).listaPrestamos != null) {
                ListViewItem item;
                foreach (ePrestamo aux in control.getUser(dniUser).listaPrestamos) {
                    item = listView1.Items.Add(aux.nroDeCuenta);
                    item.SubItems.Add(aux.montoSolicitado.ToString());
                    item.SubItems.Add(aux.cuotasxPagar.ToString());
                    item.SubItems.Add(aux.fechaDeSolicitud);
                }
            }
        }
    }
}
