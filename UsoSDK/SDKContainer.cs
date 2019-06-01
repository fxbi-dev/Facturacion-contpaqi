using SDKCompac;

namespace UsoSDK {
    public class SDKContainer {
        private static Comercial _sdk;
        public static Comercial Sdk => _sdk;

        public static void init() {
            _sdk = new Comercial();
        }
    }
}