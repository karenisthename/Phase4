using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Phase4
{
    public class DomesticNaturalGasServices
    {
        public string _domNatGas;

        public string DomNatGas
        {
            get { return _domNatGas; }
        }

        public DomesticNaturalGasServices(string domNatGas)
        {
            _domNatGas = domNatGas;
        }

        public DomesticNaturalGasServices()
        {
        }
    }

    public class DomesticNaturalGasServicesList : Collection<DomesticNaturalGasServices>
    {
        public DomesticNaturalGasServices this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public DomesticNaturalGasServices Add(DomesticNaturalGasServices domNatGas)
        {
            this.Items.Add(domNatGas);
            return (DomesticNaturalGasServices)this.Items[this.Items.Count - 1];
        }
    }

}
