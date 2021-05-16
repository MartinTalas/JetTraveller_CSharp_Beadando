using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetTraveller_by_GKPLJP
{
    class Plane: PlaneInterface
    {
        private FROMTO ft;
        public Seat[,] seats = new Seat[12, 4];

        public FROMTO FT
        {
            get { return this.ft; }
        }

        public Plane(){ }

        public Plane(FROMTO f)
        {
            loadSeats();
            this.ft = f;
        }

        public void loadSeats()
        {
            /*
             4 oszlop és 12 sorban összesen 48 üléssel). A két 
            szélen az ablak melleti ülések találhatóak (24db), míg a gép közepén 8db nagy lábterű ülés 
            található, a többi folyosó menti ülés normál ülésnek minősül.
            */

            Seat[] temp = new Seat[4];
            int x = 0, counter = 0;
            for (int i = 1; i <= 48; i++)
            {
                seats[counter, x] = new Seat(i);
                x++;
                if (i % 4 == 0)
                {
                    if (counter > 3 && counter < 8)
                    {
                        seats[counter, 0].Type = SEAT_TYPE.WINDOW;
                        seats[counter, 1].Type = SEAT_TYPE.LARGE;
                        seats[counter, 2].Type = SEAT_TYPE.LARGE;
                        seats[counter, 3].Type = SEAT_TYPE.WINDOW;
                    }
                    else
                    {
                        seats[counter, 0].Type = SEAT_TYPE.WINDOW;
                        seats[counter, 1].Type = SEAT_TYPE.NORMAL;
                        seats[counter, 2].Type = SEAT_TYPE.NORMAL;
                        seats[counter, 3].Type = SEAT_TYPE.WINDOW;
                    }
                    //Console.WriteLine(seats[counter, 0].ID + " " + seats[counter, 1].ID + " " + seats[counter, 2].ID + " " + seats[counter, 3].ID);
                    //Console.WriteLine(seats[counter, 0].Type + " " + seats[counter, 1].Type + " " + seats[counter, 2].Type + " " + seats[counter, 3].Type);

                    counter++;
                    x = 0;
                }
            }
        }

        public string makeString()
        {
            string result = "";

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch(this.seats[i, j].Status)
                    {
                        case STATUS.FREE: 
                            
                            if(j == 3)
                            {
                                result += "0";
                            }
                            else
                            {
                                result += "0_";
                            }

                            break;
                        case STATUS.BOOKING:

                            if (j == 3)
                            {
                                result += "1";
                            }
                            else
                            {
                                result += "1_";
                            }

                            break;
                        case STATUS.BOOKED:

                            if (j == 3)
                            {
                                result += "2";
                            }
                            else
                            {
                                result += "2_";
                            }

                            break;
                        case STATUS.COVID:

                            if (j == 3)
                            {
                                result += "3";
                            }
                            else
                            {
                                result += "3_";
                            }

                            break;
                    }
                }

                if(i < 11)
                {
                    result += "+";
                }

            }
            Console.WriteLine(result);
            return result;
        }
    }
}
