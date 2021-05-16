using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetTraveller_by_GKPLJP
{
    class VisualSeat
    {
        private Seat seat;
        private Button button;

        public Button Btn
        {
            get { return this.button; }
        }

        public Seat VSeat
        {
            get { return this.seat; }
        }

        public VisualSeat() { }
        public VisualSeat(Seat param) 
        {
            this.seat = param;
            this.button = new Button();
            this.button.Size = new System.Drawing.Size(32, 32);
        }
    }
}
