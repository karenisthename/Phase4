using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

namespace Phase4
{
    public class Company
    {
        string _companyName;
        int _busID;
        int _centreID;
        int _regNo;
        string _postcode;
        int _telephone;
        string _email;
        Address _address;
        CompanyServiceList _services;
        EngineerCollection _engineers;

        public string companyName
        {
            get { return _companyName; }
            set { _companyName = value; }    
        }
        
        public int businessID
        {
            get { return _busID; }
            set { _busID = value; }
        }

        public int centreID
        {
            get { return _centreID; }
            set { _centreID = value; }
        }

        public int registrationNo
        {
            get { return _regNo; }
            set { _regNo = value; }
        }

        public string postCode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

        public int telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
        
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Address companyAddress
        {
            get { return _address; }
            set { _address = value; }
        }

        public CompanyServiceList Services
        {
            get { return _services; }
        }
        
        public EngineerCollection Engineers
        {
            get { return _engineers; }
        }
        public Company(string compName, int busID, int cntreID, int regNo, string pstCde, int phone, string email, Address add, CompanyServiceList services, EngineerCollection engineers)
        {
            _companyName = compName;
            _busID = busID;
            _centreID = cntreID;
            _regNo = regNo;
            _postcode = pstCde;
            _telephone = phone;
            _email = email;
            _address = add;
            _services = services;
            _engineers = engineers;
        }
    }

    public class CompanyCollection : Collection<Company>
    {
        public Company this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public Company Add(Company newCompany)
        {
            this.Items.Add(newCompany);
            return (Company)this.Items[this.Items.Count - 1];
        }
    }

    public sealed class CompanyDataCollection
    {
        static CompanyCollection _newCompanyCollection = new CompanyCollection();
        public static CompanyCollection CompanyList
        {
            get { return _newCompanyCollection; }
        }
    }

}
