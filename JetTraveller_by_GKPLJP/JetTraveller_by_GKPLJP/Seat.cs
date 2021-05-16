using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetTraveller_by_GKPLJP
{
    enum SEAT_TYPE
    {
        NORMAL,
        WINDOW,
        LARGE
    }

    enum STATUS
    {
        FREE,
        BOOKING,
        BOOKED,
        COVID
    }

    class Seat
    {
        private int id;
        private double x, y;
        private SEAT_TYPE type;
        private STATUS status;

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        } 

        public SEAT_TYPE Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public STATUS Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public Seat() { }
        public Seat(int par) 
        {
            this.ID = par;
            this.Status = STATUS.FREE;
        }
    }
}
