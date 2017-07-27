using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{


    public class MailBox
    {
        public event EventHandler<Plic> MailReceived;

        public void Generate()
        {
            for(int i=0; i < 100; i++)
            {
                Plic plic = new Plic();
                plic.Id = i;
                if (i < 80)
                {
                    plic.Numar = i;
                    plic.Strada = String.Format("Strada {0}", i);
                }
                else
                {
                    plic.Strada = String.Format("Strada {0}", i);
                }

                if (null != MailReceived)
                {
                    MailReceived(this, plic);
                }
            }
        }


        //incercare metoda extinsa ? nu stiu ?
        //public void MailReceiveExtension(this MailSorter badBoySort, Plic plic)
        //{
        //    badBoySort.MailReceived(plic);
        //}

    }
}
