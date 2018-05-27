using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using SDKCompac.Modelos;
using SDKCompac.Nativos;

namespace SDKCompac{
    public class Comercial : SDK {
        public string Ruta { get; }
        private const string SISTEMA = "CONTPAQ I COMERCIAL";
        public bool SesionIniciada { private set; get; }
        private int _error;

        #region Constructores
        public Comercial() {
            SesionIniciada = false;
            Ruta = @"C:\Program Files (x86)\Compac\COMERCIAL";
            Nativos.SDK.SetCurrentDirectory(Ruta);
        }

        public Comercial(string Ruta) {
            SesionIniciada = false;
            this.Ruta = Ruta;
            Nativos.SDK.SetCurrentDirectory(Ruta);
        }
        #endregion

        #region Manejo de errores
        private void comprobarSesion()
        {
            if (!SesionIniciada)
            {
                throw new SDKCompacException("La sesión no está iniciada");
            }
        }

        private void comprobarError()
        {
            if (_error != 0)
            {
                throw new SDKCompacException(Nativos.SDK.getError(_error));
            }
        }

        public static void comprobarError(int error)
        {
            if (error != 0)
            {
                throw new SDKCompacException(Nativos.SDK.getError(error));
            }
        }
        #endregion

        #region Sesion
        public void iniciarSesion() {
            _error = Nativos.SDK.fSetNombrePAQ(SISTEMA);
            if (_error != 0)
            {
                throw new SDKCompacException(Nativos.SDK.getError(_error));
            }
            SesionIniciada = true;
        }

        public void cerrarSesion() {
            comprobarSesion();
            cerrarEmpresa();
            Nativos.SDK.fTerminaSDK();
            SesionIniciada = false;
        }
        #endregion

        #region Empresa
        public Empresa[] obtenerEmpresas()
        {
            comprobarSesion();
            List<Empresa> empresas = new List<Empresa>();
            int idEmpresa = 0;
            StringBuilder nombreEmpresa = new StringBuilder();
            StringBuilder directorioEmpresa = new StringBuilder();
            Empresa empresa;
            _error = Nativos.SDK.fPosPrimerEmpresa(ref idEmpresa, nombreEmpresa, directorioEmpresa);
            comprobarError();
            empresa = new Empresa() {
                ID = idEmpresa,
                Nombre = nombreEmpresa.ToString(),
                Directorio = directorioEmpresa.ToString()
            };
            empresas.Add(empresa);
            while (true)
            {
                _error = Nativos.SDK.fPosSiguienteEmpresa(ref idEmpresa, nombreEmpresa, directorioEmpresa);
                if (_error == 0)
                {
                    empresa = new Empresa() {
                        ID = idEmpresa,
                        Nombre = nombreEmpresa.ToString(),
                        Directorio = directorioEmpresa.ToString()
                    };
                    empresas.Add(empresa);
                } else
                {
                    break;
                }
            }
            return empresas.ToArray();
        }

        public void abrirEmpresa(string Directorio)
        {
            comprobarSesion();
            cerrarEmpresa();
            _error = Nativos.SDK.fAbreEmpresa(Directorio);
            comprobarError();
        }

        public void cerrarEmpresa()
        {
            comprobarSesion();
            Nativos.SDK.fCierraEmpresa();
        }
        #endregion

        #region Cliente Proveedor
        public ClienteProveedor[] obtenerClientesProveedores() {
            comprobarSesion();
            
            List<ClienteProveedor> clientes = new List<ClienteProveedor>();
            int indice = -1;
            string[] campos = {
                ClienteProveedor.Campos.CodigoCliente,
                ClienteProveedor.Campos.RazonSocial,
                ClienteProveedor.Campos.CodigoValorClasificacionCliente1
            };
            _error = Nativos.SDK.fPosPrimerCteProv();
            comprobarError();
            
            while (_error == 0) {
                try {
                    ClienteProveedor cteProv = ClienteProveedor.Obtener(indice, campos);
                    clientes.Add(cteProv);
                    _error = Nativos.SDK.fPosSiguienteCteProv();
                    indice--;
                }
                catch {
                    break;
                }
            }
            clientes.Sort();
            return clientes.ToArray();
        }
        #endregion
    }
}