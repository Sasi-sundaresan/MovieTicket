using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.models
{
    public class MovieTicket
    {
        public int TicketID { get; set; }  
        public string CustomerName{get; set;}
        public string MovieName{get; set;}
        public string ShowTime{get; set;}
        public string SeatNumber{get; set;}
        public decimal Price{get; set;}
        public int TicketQuantity{get; set;}
        public decimal TotalAmount => Price * TicketQuantity;

        public MovieTicket() { }
        public MovieTicket(string customerName,string movieName,string showTime,string seatNumber,decimal price,int ticketQuantity)
        {
            CustomerName=customerName;
            MovieName=movieName;
            ShowTime=showTime;
            SeatNumber=seatNumber;
            Price=price;
            TicketQuantity=ticketQuantity;
      

        }

    }
}