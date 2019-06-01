using SDKCompac.Modelos;

namespace SDKCompac {
    public interface SDK {
        void iniciarSesion();
        void cerrarSesion();

        // Empresa
        Empresa[] obtenerEmpresas();
        void abrirEmpresa(Empresa empresa);
        void cerrarEmpresa();

        // Cliente/Proveedor
        ClienteProveedor[] ObtenerClientesProveedores();
    }
}