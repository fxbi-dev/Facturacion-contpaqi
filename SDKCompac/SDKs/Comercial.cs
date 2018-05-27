using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using SDKCompac.Modelos;
using SDKCompac.Nativos;

namespace SDKCompac{
    public class Comercial : SDK{
        public string Ruta { private set; get; }
        private const string SISTEMA = "CONTPAQ I COMERCIAL";
        public bool SesionIniciada { private set; get; }

        private void comprobarSesion() {
            if (!SesionIniciada) {
                throw new SDKCompacException("La sesión no está iniciada");
            }
        }

        private void comprobarError() {
            if (_error != 0) {
                throw new SDKCompacException(SdkComercial.getError(_error));
            }
        }

        private int _error;

        public Comercial() {
            SesionIniciada = false;
            Ruta = @"C:\Program Files (x86)\Compac\COMERCIAL";
            SdkComercial.SetCurrentDirectory(Ruta);
        }

        public Comercial(string Ruta)
        {
            SesionIniciada = false;
            this.Ruta = Ruta;
            SdkComercial.SetCurrentDirectory(Ruta);
        }

        public void iniciarSesion() {
            _error = SdkComercial.fSetNombrePAQ(SISTEMA);
            if (_error != 0) {
                throw new SDKCompacException(SdkComercial.getError(_error));
            }
            SesionIniciada = true;
        }

        public void cerrarSesion() {
            comprobarSesion();
            cerrarEmpresa();
            SdkComercial.fTerminaSDK();
            SesionIniciada = false;
        }

        public Empresa[] obtenerEmpresas() {
            comprobarSesion();
            List<Empresa> empresas = new List<Empresa>();
            int idEmpresa = 0;
            StringBuilder nombreEmpresa = new StringBuilder();
            StringBuilder directorioEmpresa = new StringBuilder();
            Empresa empresa;
            _error = SdkComercial.fPosPrimerEmpresa(ref idEmpresa, nombreEmpresa, directorioEmpresa);
            comprobarError();
            empresa = new Empresa() {
                ID = idEmpresa,
                Nombre = nombreEmpresa.ToString(),
                Directorio = directorioEmpresa.ToString()
            };
            empresas.Add(empresa);
            while (true) {
                _error = SdkComercial.fPosSiguienteEmpresa(ref idEmpresa, nombreEmpresa, directorioEmpresa);
                if (_error == 0) {
                    empresa = new Empresa() {
                        ID = idEmpresa,
                        Nombre = nombreEmpresa.ToString(),
                        Directorio = directorioEmpresa.ToString()
                    };                    
                    empresas.Add(empresa);
                } else {
                    break;
                }
            }
            return empresas.ToArray();
        }

        public void abrirEmpresa(string Directorio) {
            comprobarSesion();
            cerrarEmpresa();
            _error = SdkComercial.fAbreEmpresa(Directorio);
            comprobarError();
        }

        public void cerrarEmpresa() {
            comprobarSesion();
            SdkComercial.fCierraEmpresa();
        }

        public string[] obtenerClientesProveedores() {
            comprobarSesion();
            List<string> clientes = new List<string>();
            _error = SdkComercial.fPosPrimerCteProv();
            comprobarError();
            StringBuilder razonSocial = new StringBuilder();
            _error = SdkComercial.fLeeDatoCteProv("cRazonSocial", razonSocial, Constantes.kLongNombre);
            comprobarError();
            clientes.Add(razonSocial.ToString());
            while (true) {
                _error = SdkComercial.fPosSiguienteCteProv();
                if (_error == 0) {
                    _error = SdkComercial.fLeeDatoCteProv("cRazonSocial", razonSocial, Constantes.kLongNombre);
                    comprobarError();
                    clientes.Add(razonSocial.ToString());
                } else {
                    break;
                }
            }

            return clientes.ToArray();
        }
    }
}