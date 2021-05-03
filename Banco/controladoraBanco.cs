using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Banco {
    public class controladoraBanco {
        public static List<eUsuario> listaUsuarios { get; set; }
        public List<eSolicitudes> listaSolicitudes;
        public controladoraBanco() {
            if (listaUsuarios == null) {
                listaUsuarios = new List<eUsuario>(); } 
            else if (listaSolicitudes == null) {
                listaSolicitudes = new List<eSolicitudes>();
            }
        }
        public eUsuario getUser(string dniUser) {
            return listaUsuarios.Find(delegate (eUsuario user) { return user.DNI == dniUser; });
        }
        public string abrirCuenta(string dniUsuario, string tipoTarjeta,decimal n) {
            string result = "";
            eUsuario user = listaUsuarios.Find(delegate (eUsuario value) { return value.DNI == dniUsuario; });
            eTarjeta auxT = new eTarjeta {
                tipoTarjeta = tipoTarjeta,
                estado = "ACTIVO",
                saldoTarjeta = n,
                nroCuenta = generarNroCuenta(),
                nroTarjeta = generarNroTarjeta()
            };
            user.tarjetas.Add(auxT);
            return "Operacion Realizada con Exito";
        }
        public bool existeUsuario(string dniUsuario) {
            if (listaUsuarios.Exists(delegate (eUsuario value) { return value.DNI == dniUsuario; }))
                return true;
            else
                return false;
        }
        public bool registrarseEnBanco(eUsuario n) {
            if (!listaUsuarios.Exists(delegate(eUsuario user) { return user.DNI == n.DNI; })) {
                n.contraseña = generarContraseña();
                n.tarjetas = new List<eTarjeta>();
                listaUsuarios.Add(n);
                return true;
            }else {
                return false; 
            }
        }
        public string generador(int j) {
            string clave = "";
            Random x = new Random((int)DateTime.Now.Ticks * j);
            int i = 0;
            while (i < j) {
                int step = x.Next(0, 9);
                clave += step;
                i++;
            }
            return clave;
        }
        public string generarContraseña() {
            return generador(6);
        }
        public string generarNroTarjeta() {
            return generador(16);
        }
        public string generarNroCuenta() {
            return generador(14);
        }
        public void solicitarPrestamo(ePrestamo prestamo) {
            int idSoli = 0;
                foreach (eUsuario users in listaUsuarios) {
                    if (users.solicitudes != null) {
                        idSoli += users.solicitudes.Count();

                    }
                }
            eSolicitudes solicitud = new eSolicitudes {
                idSolicitud = idSoli + 1,
                prestamoDatos = prestamo,
                resultado = "EN PROCESO"
            };
            eUsuario userT = listaUsuarios.Find(delegate (eUsuario value) { return value.DNI == prestamo.DNIcliente; });
            if (userT.solicitudes == null) {
                userT.solicitudes = new List<eSolicitudes>();
            }
            userT.solicitudes.Add(solicitud);
        }
        public void evaluarSolicitud(int idSolicitud, bool resp) {
            if (resp) {
                eSolicitudes solicitudT = listaSolicitudes.Find(delegate (eSolicitudes value) { return value.idSolicitud == idSolicitud; });
                eUsuario userT = listaUsuarios.Find(delegate(eUsuario value) {return value.DNI == solicitudT.prestamoDatos.DNIcliente; });
                userT.listaPrestamos.Add(solicitudT.prestamoDatos);
                foreach (eSolicitudes x in userT.solicitudes) {
                    if (x.idSolicitud == idSolicitud) {
                        x.resultado = "APROBADO";
                        break;
                    }
                }
            } else if (!resp) {
                eSolicitudes solicitudT = listaSolicitudes.Find(delegate (eSolicitudes value) { return value.idSolicitud == idSolicitud; });
                eUsuario userT = listaUsuarios.Find(delegate (eUsuario value) { return value.DNI == solicitudT.prestamoDatos.DNIcliente; });
                foreach (eSolicitudes x in userT.solicitudes) {
                    if (x.idSolicitud == idSolicitud) {
                        x.resultado = "DESAPROBADO";
                        break;
                    }
                }
            }
        }
    }
}
