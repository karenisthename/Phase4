using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase4
{
    public class Address
    {
        string _address1;
        string _address2;
        string _address3;
        string _address4;

        public string address1
        {
            get { return _address1; }
            //set { _address1 = value; }
        }
        public string address2
       {
            get { return _address2; }
            //set { _address2 = value; }
        }
        public string address3
        {
            get { return _address3; }
            //set { _address3 = value; }
        }
        public string address4
        {
            get { return _address4; }
            //set { _address4 = value; }
        }

        public Address(string add1, string add2, string add3, string add4)
        {
            _address1 = add1;
            _address2 = add2;
            _address3 = add3;
            _address4 = add4;
        }
    }
}
