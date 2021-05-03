using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Phase4
{
    public class NonDomesticLPGServices
    {
        public string _nonDomLPG;

        public string NonDomLPG
        {
            get { return _nonDomLPG; }
        }

        public NonDomesticLPGServices(string nonDomLPG)
        {
            _nonDomLPG = nonDomLPG;
        }

        public NonDomesticLPGServices()
        {
        }
    }

    public class NonDomesticLPGServicesList : Collection<NonDomesticLPGServices>
    {
        public NonDomesticLPGServices this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public NonDomesticLPGServices Add(NonDomesticLPGServices nonDomLPG)
        {
            this.Items.Add(nonDomLPG);
            return (NonDomesticLPGServices)this.Items[this.Items.Count - 1];
        }
    }
}
