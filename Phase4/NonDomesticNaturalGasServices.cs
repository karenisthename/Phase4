using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Phase4
{
    public class NonDomesticNaturalGasServices
    {
        public string _nonDomNatGas;

        public string NonDomNatGas
        {
            get { return _nonDomNatGas; }
        }

        public NonDomesticNaturalGasServices(string nonDomNatGas)
        {
            _nonDomNatGas = nonDomNatGas;
        }

        public NonDomesticNaturalGasServices()
        {
        }
    }

    public class NonDomesticNaturalGasServicesList : Collection<NonDomesticNaturalGasServices>
    {
        public NonDomesticNaturalGasServices this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public NonDomesticNaturalGasServices Add(NonDomesticNaturalGasServices nonDomNatGas)
        {
            this.Items.Add(nonDomNatGas);
            return (NonDomesticNaturalGasServices)this.Items[this.Items.Count - 1];
        }
    }
}
