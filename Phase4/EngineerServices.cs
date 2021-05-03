using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Phase4
{
    public class EngineerServices
    {
        string _engineerService;
        DomesticNaturalGasServicesList _domNatGaslist;
        DomesticLPGServicesList _domLPGList;
        NonDomesticNaturalGasServicesList _nonDomNatGaslist;
        NonDomesticLPGServicesList _nonDomLPGlist;
        CompanyServiceList compservicelist;

        public string EngineerService
        {
            get { return _engineerService; }
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

        public EngineerServices(string engineerService,
                                DomesticNaturalGasServicesList domNatGas = null,
                                DomesticLPGServicesList domLPG = null,
                                NonDomesticNaturalGasServicesList nonDomNatGas = null,
                                NonDomesticLPGServicesList nonDomLPG = null)
        {
            _engineerService = engineerService;
            _domNatGaslist = domNatGas;
            _domLPGList = domLPG;
            _nonDomNatGaslist = nonDomNatGas;
            _nonDomLPGlist = nonDomLPG;
        }
        public EngineerServices(string companyService,
                        NonDomesticNaturalGasServicesList nonDomNatGas = null,
                        NonDomesticLPGServicesList nonDomLPG = null)
        {
            _nonDomNatGaslist = nonDomNatGas;
            _nonDomLPGlist = nonDomLPG;
        }
    }

    public class EngineerServiceList : Collection<EngineerServices>
    {
        public EngineerServices this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public EngineerServices Add(EngineerServices EngServices)
        {
            this.Items.Add(EngServices);
            return (EngineerServices)this.Items[this.Items.Count - 1];
        }
    }
}
