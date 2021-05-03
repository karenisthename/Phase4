using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase4
{
    public class ServicesCategory
    {
        CompanyServices _DomesticNaturalGasServices;
        CompanyServices _DomesticLPGServices;
        CompanyServices _NonDomesticNaturalGasServices;
        CompanyServices _NonDomesticLPGServices;

        public CompanyServices DomesticNaturalGasServices
        {
            get { return _DomesticNaturalGasServices; }
        }

        public CompanyServices DomesticLPGServices
        {
            get { return _DomesticLPGServices; }
        }

        public CompanyServices NonDomesticNaturalGasServices
        {
            get { return _NonDomesticNaturalGasServices; }
        }

        public CompanyServices NonDomesticLPGServices
        {
            get { return _NonDomesticLPGServices; }
        }

        public ServicesCategory(CompanyServices services, string _serviceCategory)
        {
            if (_serviceCategory == "Domestic	Nat. Gas	LPG")
            {

            } else if(_serviceCategory == "Non Domestic	Nat. Gas	LPG")
            {
                
            }
            else if (_serviceCategory == "Domestic	Nat. Gas	LPG")
            {

            }

        }
    }
}
