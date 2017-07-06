using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class MailSorter
    {
        public event EventHandler<int> PlicWithoutAddress;
        public event EventHandler<int> PlicWithAddress;
        List<Plic> mailWithoutAddress = new List<Plic>();
        List<Plic> mailWithAddress = new List<Plic>();

        public void MailReceived(Plic plic)
        {
            
            if (plic.Numar.HasValue && plic.Strada != null)
            {
                mailWithAddress.Add(plic);

                if (null != PlicWithAddress)
                    PlicWithAddress(this, plic.Id);
            }
            else
            {
                mailWithoutAddress.Add(plic);

                if (null != PlicWithoutAddress)
                    PlicWithoutAddress(this, plic.Id);
            }
        }
    }
}
