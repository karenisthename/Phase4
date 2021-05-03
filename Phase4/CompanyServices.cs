using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Phase4
{
    public class CompanyServices
    {
        string _companyService;
        DomesticNaturalGasServicesList _domNatGaslist;
        DomesticLPGServicesList _domLPGList;
        NonDomesticNaturalGasServicesList _nonDomNatGaslist;
        NonDomesticLPGServicesList _nonDomLPGlist;
        CompanyServiceList compservicelist;

        public string CompanyService
        {
            get { return _companyService; }
        }

        public DomesticNaturalGasServicesList DomNatGaslist
        {
            get { return _domNatGaslist; }    
        }
        public DomesticLPGServicesList DomLPGList
        {
            get { return _domLPGList; }
        }

        public NonDomesticNaturalGasServicesList NonDomNatGasList
        {
            get { return _nonDomNatGaslist; }
        }

        public NonDomesticLPGServicesList NonDomLPG
        {
            get { return _nonDomLPGlist; }
        }

        public CompanyServices(string companyService, 
                                DomesticNaturalGasServicesList domNatGas = null, 
                                DomesticLPGServicesList domLPG = null , 
                                NonDomesticNaturalGasServicesList nonDomNatGas = null,
                                NonDomesticLPGServicesList nonDomLPG = null)
        {
             _companyService = companyService;
            _domNatGaslist = domNatGas;
            _domLPGList = domLPG;
            _nonDomNatGaslist = nonDomNatGas;
            _nonDomLPGlist = nonDomLPG;
        }
        public CompanyServices(string companyService,
                        NonDomesticNaturalGasServicesList nonDomNatGas = null,
                        NonDomesticLPGServicesList nonDomLPG = null)
        {
            _nonDomNatGaslist = nonDomNatGas;
            _nonDomLPGlist = nonDomLPG;
        }

    }

    public class CompanyServiceList : Collection<CompanyServices>
    {
        public CompanyServices this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public CompanyServices Add(CompanyServices compServices)
        {
            this.Items.Add(compServices);
            return (CompanyServices)this.Items[this.Items.Count - 1];
        }
    }

}
