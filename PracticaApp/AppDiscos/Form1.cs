using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDiscos
{
    public partial class Form1 : Form
    {
        private List<Discos> listaDiscos;//Atributo
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConexionBD_Discos conexion = new ConexionBD_Discos();//conexionDb se guarda en conexion
            listaDiscos = conexion.ListaConex();
            dgvDiscos.DataSource = listaDiscos;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;//nose ve columna direccion foto
            CargarImagen(listaDiscos[0].UrlImagenTapa);// carga imagen en picturebox a traves de la funcion

        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)// al cliquear cambia la imagen correspondiente
        {
            Discos seleccionado = (Discos)dgvDiscos.CurrentRow.DataBoundItem;
            CargarImagen(seleccionado.UrlImagenTapa);
        }



        private void CargarImagen( string imagen)
        {
            try
            {
                pictureBoxDiscos.Load(imagen);
            }
            catch (Exception)
            {

                pictureBoxDiscos.Load("https://media.istockphoto.com/id/1222357475/vector/image-preview-icon-picture-placeholder-for-website-or-ui-ux-design-vector-illustration.jpg?s=612x612&w=0&k=20&c=KuCo-dRBYV7nz2gbk4J9w1WtTAgpTdznHu55W9FjimE=");
            }
        }

        
    }
}
