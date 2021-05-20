using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DATOS
{
    public class clsConexion
    {
        private String servidor;
        private String basedatos;
        private String usuario;
        private String contrasena;
        private MySqlCommand cmdSP;

        public clsConexion()
        { //constructor
            this.servidor = "localhost";
            this.usuario = "root";
            this.contrasena = "";
            this.basedatos = "bdgym";
            this.cmdSP = new MySqlCommand();
        }

        public MySqlConnection conectar()
        {
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Data Source =" + this.servidor + "; User ID=" + this.usuario + "; Password=" + this.contrasena + "; Initial Catalog= " + this.basedatos;
            cnx.Open();
            return cnx;
        }

        public void desconectar()
        {
            MySqlConnection cnx = this.conectar();
            cnx.Close();
        }

        public void PrepararSP(String sp)
        {
            //procedimiento almacenado
            cmdSP.Connection = conectar();
            cmdSP.CommandType = CommandType.StoredProcedure;
            cmdSP.CommandText = sp;
        }

        public void AddParametro(String param, String valor)
        {
            MySqlParameter par = new MySqlParameter();
            par.ParameterName = param;
            par.Value = valor;
            cmdSP.Parameters.Add(par);
        }

        public void ejecutarSP()
        {
            MySqlDataReader spResult;
            cmdSP.Prepare();
            spResult = cmdSP.ExecuteReader();
        }

        public void ejecutarSQL(String s, String nTable, DataSet ds)
        {
            MySqlDataAdapter MysqlAdapter;
            MysqlAdapter = new MySqlDataAdapter(s, conectar());
            MysqlAdapter.Fill(ds, nTable);
            desconectar();
        }

    }
}