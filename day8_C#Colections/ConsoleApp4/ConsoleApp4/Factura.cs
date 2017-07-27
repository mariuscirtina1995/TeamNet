using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Factura
    {
        //field
        private int valoare;
        //property
        public int Valoare
        {
            get
            {
                return valoare;
            }

            set
            {   
                valoare = value;
                //FacuraChanged(this, this); //1
                if(null != FacuraChanged)
                    FacuraChanged(this, this.valoare); //2

                if(null != FacturaReallyChanged)
                    FacturaReallyChanged(this.valoare, this.valoare * 2, this.valoare * 3);
            }

        }
        //Event
        //public event EventHandler<Factura> FacuraChanged; //1
        public event EventHandler<int> FacuraChanged; //2
        public event ForShowingInt FacturaReallyChanged; //event for delegate in Program cs namespace

        public int? Sold { get; set; }

    }
}
