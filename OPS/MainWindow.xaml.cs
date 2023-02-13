using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace OPS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conexionSql;

        public MainWindow()
        {
            InitializeComponent();

            string Conexion = ConfigurationManager.ConnectionStrings["OPS.Properties.Settings.OSPConnectionString"].ConnectionString;

            conexionSql = new SqlConnection(Conexion);
            ConsultarUsuarios();



        }

        private void ConsultarUsuarios()
        {
            string consulta = "Select * from Usuario order by Nombre";  
            
            //adaptar las tablas fisicas datable
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, conexionSql);


            using (sqlDataAdapter)
            {
                DataTable tabla = new DataTable();
                sqlDataAdapter.Fill(tabla);
                dataGrid1.ItemsSource = tabla.DefaultView;
            }

        }
        
    }
}
