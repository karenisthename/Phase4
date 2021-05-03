using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Phase4
{
    public class Services
    {
        public string _service;

        public string Service
        {
            get { return _service; }
        }

        public Services(string service)
        {
            _service = service;
        }

        public Services()
        {
        }
    }

    public class ServiceCollection : Collection<Services>
    {
        public Services this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public Services Add(Services newService)
        {
            this.Items.Add(newService);
            return this.Items[this.Items.Count - 1];
        }
    }
}
