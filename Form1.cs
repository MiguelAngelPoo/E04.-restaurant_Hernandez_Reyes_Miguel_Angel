using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comanda
{
    public partial class frmComanda : Form
    {//se llama al menu que esta en la clase base de datos
         BaseDatos menus;
        public frmComanda()
        {//el form
            InitializeComponent();
            this.Text = "San Jorge Restaurant";
            this.BackColor = Color.BurlyWood;
            menus = new BaseDatos();
            menuActivo();
        }

        public void menuActivo()
        {//metodo de menu
            cboMenu.DataSource = menus.listamenu;
            cboMenu.DisplayMember = "Nombre";
            cboMenu.ValueMember = "Id";
        }

        private void cboMenu_SelectedIndexChanged(object sender, EventArgs e)
        {//combo comboBoxMenu
            switch (cboMenu.SelectedIndex)
            {
                case 1: lstSeleccion.DataSource = menus.ListAperitivos;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;
                case 2: lstSeleccion.DataSource = menus.Ensalada;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;
                case 3: lstSeleccion.DataSource = menus.ListCarnes;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;
                case 4: lstSeleccion.DataSource = menus.ListPescado;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;
                case 5: lstSeleccion.DataSource = menus.ListPollo;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;
                case 6: lstSeleccion.DataSource = menus.ListPasta;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;
                case 7: lstSeleccion.DataSource = menus.ListSandwich;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;
                case 8: lstSeleccion.DataSource = menus.ListPaninis;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;
                case 9: lstSeleccion.DataSource = menus.ListPostre;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;
                case 10: lstSeleccion.DataSource = menus.ListBebida;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;

                default: 
                    lstSeleccion.DataSource = menus.Vacio;
                    lstSeleccion.DisplayMember = "Nombre";
                    lstSeleccion.ValueMember = "Id";
                    break;
            }

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AgregarMenu();
        }
        public void AgregarMenu()
        {
            var valor = lstSeleccion.SelectedIndex;
            if (valor != 0)
            {
                var datos = Convert.ToDecimal(cboCantidad.Text) * Convert.ToDecimal(txtPrecio.Text);
                var total = Convert.ToString(datos);
                dbgrdMostrar.Rows.Add(lstSeleccion.Text, cboCantidad.Text, txtPrecio.Text, total);


            }

        }
        //metodo para limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarAgregar();
        }

        public  void Limpiar()
        {//metodo para limpiar
            txtPrecio.Text = "";
            cboCantidad.Text = "0";
            cboMenu.Text = "None";
            txtTotal.Text = "";
            dbgrdMostrar.Rows.Clear();
        }

        public void LimpiarAgregar()
        {
            txtPrecio.Text = "";
            cboCantidad.Text = "0";
            cboMenu.Text = "None";
            txtTotal.Text = "";
        }

        private void buttonCobrar_Click(object sender, EventArgs e)
        {
            cobrar();
        }

        public void cobrar()
        {
            decimal suma = 0;
            foreach (DataGridViewRow Celda in dbgrdMostrar.Rows)

                suma += Convert.ToDecimal(Celda.Cells["Total"].Value);


            txtTotal.Text = Convert.ToString(suma);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarMenu();
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarAgregar();
        }

        private void cobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cobrar();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Proyecto POO Mayo 2019", "Acerca de..");
        }

        private void frmComanda_Load(object sender, EventArgs e)
        {

        }
    }

}