using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Common
{
    public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
    {
        public TrustAllCertificatePolicy()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public bool CheckValidationResult(ServicePoint sp, System.Security.Cryptography.X509Certificates.X509Certificate cert, WebRequest req, int problem)
        {

            return true;

        }
    }
}
