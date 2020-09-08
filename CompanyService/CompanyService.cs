using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyService
{
    public class CompanyService : ICompanyConfidentialService, ICompanyPublicService
    {
        public string GetConfidentialInformation()
        {
            return "Confidential Information";
        }

        public string GetPublicInformation()
        {
            return "Public Information";
        }
    }
}
