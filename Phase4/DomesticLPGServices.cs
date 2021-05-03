using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Phase4
{
    public class DomesticLPGServices
    {
        public string _domLPG;

        public string DomLPG
        {
            get { return _domLPG; }
        }

        public DomesticLPGServices(string domLPG)
        {
            _domLPG = domLPG;
        }

        public DomesticLPGServices()
        {
        }
    }
    public class DomesticLPGServicesList : Collection<DomesticLPGServices>
    {
        public DomesticLPGServices this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public DomesticLPGServices Add(DomesticLPGServices domNatGas)
        {
            this.Items.Add(domNatGas);
            return (DomesticLPGServices)this.Items[this.Items.Count - 1];
        }
    }
}
