﻿namespace NetCafeUCN.DAL.Model
{
    public class BookingLine
    {
        public int ?Quantity { get; set; }
        public int Stationid { get; set; }
        public int ?Consumableid { get; set; }

        public BookingLine()
        {
        }
    }
}