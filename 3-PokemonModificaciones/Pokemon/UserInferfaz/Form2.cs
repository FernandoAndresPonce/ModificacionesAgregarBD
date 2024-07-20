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
using BussinesLogic;

namespace UserInferfaz
{
    public partial class frmAltaPokemon : Form
    {
        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            ElementoBusi elementoLista = new ElementoBusi();

            cmbTipo.DataSource = elementoLista.ListarE();
            cmbDebilidad.DataSource = elementoLista.ListarE();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            PokemonBusiness addPokemon = new PokemonBusiness();
            Pokemon Pokemon = new Pokemon();

            try
            {
                Pokemon.Numero = int.Parse(txtNumero.Text);
                Pokemon.Nombre = txtNombre.Text;
                Pokemon.Descripcion = txtDescripcion.Text;
                Pokemon.UrlImagen = txtUrlImagen.Text;

                
                Pokemon.Tipo = (Elemento )cmbTipo.SelectedItem;
                Pokemon.Debilidad = (Elemento)cmbDebilidad.SelectedItem;

                addPokemon.agregar(Pokemon);
                MessageBox.Show("Agregado Exitosamente");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               
            }
            finally
            {
                Close();
            }
           

            
            
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagenAP(txtUrlImagen.Text);
        }

        public void cargarImagenAP( string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception ex)
            {
                pictureBox1.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkq9bHJ3gt0lMcFAlhsCbumDb0fYgvpP0HNQ&s");


            }

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
