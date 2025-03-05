using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Service
    {
        public string TypeService { get; }
        public Service(string service)
        {
            this.TypeService = service;
        }
    }
}
