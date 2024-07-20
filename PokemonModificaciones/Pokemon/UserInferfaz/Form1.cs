using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using BusinessLogic;

namespace UserInferfaz
{
    public partial class Form1 : Form
    {
        private List<Pokemon> listaPokemones;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cargar();

        }

        private void cargar()
        {
            PokemonBusiness pokeBusiness = new PokemonBusiness();
            listaPokemones = pokeBusiness.Listar();
            dataGridView1.DataSource = listaPokemones;
            dataGridView1.Columns["UrlImagen"].Visible = false;

            pictureBox1.Load(listaPokemones[0].UrlImagen);

        }

    

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccion = (Pokemon)dataGridView1.CurrentRow.DataBoundItem;

            cargarImagen(seleccion.UrlImagen);
        }
        
        private void cargarImagen(string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception ex)
            {
                pictureBox1.Load("https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg");
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon formularioAltaPokemon = new frmAltaPokemon();
            formularioAltaPokemon.ShowDialog();
            cargar();

            
            
        }
    }
}
