using SDKCompac.Modelos;

namespace SDKCompac {
    public interface SDK {
        void iniciarSesion();
        void cerrarSesion();

        // Empresa
        Empresa[] obtenerEmpresas();
        void abrirEmpresa(string Directorio);
        void cerrarEmpresa();

        // Cliente/Proveedor
        ClienteProveedor[] obtenerClientesProveedores();
    }
}