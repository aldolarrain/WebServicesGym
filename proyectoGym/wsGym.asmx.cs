using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace proyectoGym
{
    /// <summary>
    /// Summary description for wsGym
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsGym : System.Web.Services.WebService
    {

        //metodos de busqueda

        [WebMethod]
        public DataSet buscarPaquetes(string paquetes)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select * from paquetes";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet buscarCliente(string paquetes)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select * from cliente";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet buscarDetalleInscripcion(string paquetes)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select * from detalleInscripcion";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }


        [WebMethod]
        public DataSet buscarClientePorNombre(string nombre)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select * from cliente where nombre like concat('%" + nombre + "%')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet buscarTipoInscripcionPorNombre(string nombre)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select * from tipoInscripcion where nombre like concat('%" + nombre + "%')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet buscarAdministradorPorNombre(string nombre)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select * from administrador where nombre like concat('%" + nombre + "%')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet buscarEntrenadorPorNombre(string nombre)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select * from entrenador where nombre like concat('%" + nombre + "%')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }
        [WebMethod]
        public DataSet buscarHorario(string hora)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select * from horario where horaDeInicio or horaDeFinalizacion like concat('%" + hora + "%')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet buscarDisciplinaPorNombre(string nombre)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select * from disciplina where nombre like concat('%" + nombre + "%')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet buscarNotaInscripcionPorNombre(int nombre)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select * from notaInscripcion where id_inscripcion like concat('%" + nombre + "%')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        //metodos de guardado

        [WebMethod]
        public DataSet guardarPaquetes(string nombre, string descripcion, int cupos, int id_disciplina)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "insert into paquetes(nombre, descripcion, cupos, id_disciplina) values('" + nombre + "','" + descripcion + "','" + cupos + "','" + id_disciplina + "')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet guardarDetalleInscripcion(int cantidad, int id_cliente, int precio, int id_paquete)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "insert into detalleInscripcion(cantidad, id_cliente, precio, id_paquete) values('" + cantidad + "','" + id_cliente + "','" + precio + "','" + id_paquete + "')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet guardarCliente(string nombre, string apellido)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "insert into cliente(nombre, apellido) values('" + nombre + "','"+apellido+"')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }


        [WebMethod]
        public DataSet guardarTipoInscripcion(string nombre, int costo, string periodo, int frecuencia)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "insert into tipoInscripcion(nombre, costo, periodo, frecuencia) values('" + nombre + "','" + costo + "','" + periodo + "','" + frecuencia + "')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet guardarNotaInscripcion(int idCli, int idTipoIns, string fecha)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "insert into notaInscripcion(id_cliente, id_tipoInscripcion, fechaDeInscripcion) values('" + idCli + "','" + idTipoIns + "','" + fecha + "')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }


        [WebMethod]
        public DataSet guardarAdministrador(string nombre, string apellido,string contrasena)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "insert into administrador(nombre, apellido, contrasena) values('" + nombre + "','" + apellido + "','" + contrasena + "')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet guardarEntrenador(string nombre, string apellido)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "insert into entrenador(nombre, apellido) values('" + nombre + "','" + apellido + "')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet guardarHorario(string horaE, string horaS)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "insert into horario(horaDeInicio, horaDeFinalizacion) values('" + horaE + "','" + horaS + "')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet guardarDisciplina(string nombre, string descripcion, int idE, int idH)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "insert into disciplina(nombre, descripcion, id_entrenador, id_horario) values('" + nombre + "','" + descripcion + "', '" + idE + "', '" + idH + "')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet buscarVentaPorFecha(string fecha1, string fecha2)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select id_venta, empresa, date_format(fecha, '%Y-%m-%d') as fecha from cliente, venta where venta.id_cliente=cliente.id_cliente and fecha between ('" + fecha1 + "') and ('" + fecha2 + "');";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        //CONSULTAS WEBSERVICE

        [WebMethod]
        public DataSet buscarDisciplinaPorPaquete(string nombre)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select id_paquete as Id_paquete, nombreP as Nombre, cupos as Cupos, horaDeInicio as Inicio, horaDeFinalizacion as Final from disciplina, horario, paquetes where paquetes.id_disciplina = disciplina.id_disciplina and disciplina.id_horario = horario.id_horario and nombre like concat('%" + nombre + "%')";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }

        [WebMethod]
        public DataSet buscarInscripcionPorFecha(string fecha1, string fecha2)
        {
            clsConexion con = new clsConexion();
            string s;
            s = "select id_inscripcion, date_format(fechaDeInscripcion, '%Y-%m-%d') as fecha from cliente, notaInscripcion where notaInscripcion.id_cliente=cliente.id_cliente and fechaDeInscripcion between ('" + fecha1 + "') and ('" + fecha2 + "');";
            DataSet ds = new DataSet();
            con.ejecutarSQL(s, "tc", ds);
            return ds;
        }
    }
}
