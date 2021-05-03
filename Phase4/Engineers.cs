using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Phase4
{
    public class Engineers
    {
        string _firstName;
        string _lastName;
        EngineerServiceList _engineerServices;

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public EngineerServiceList EngrSvcs
        {
            get { return _engineerServices; }
        }
        
        
        public Engineers(string firstName, string lastName, EngineerServiceList _EngSvcs)
        {
            _firstName = firstName;
            _lastName = lastName;
            _engineerServices = _EngSvcs;
        }

        public Engineers() { }
    }

    public class EngineerCollection : Collection<Engineers>
    {
        public Engineers this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public Engineers Add(Engineers newEngineer)
        {
            this.Items.Add(newEngineer);
            return (Engineers)this.Items[this.Items.Count - 1];
        }
    }
}
