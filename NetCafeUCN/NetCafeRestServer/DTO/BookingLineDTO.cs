﻿namespace NetCafeUCN.API.DTO
{
    public class BookingLineDTO
    {
        public int? Quantity { get; set; }
        public int StationId { get; set; }
        public int? ConsumableId { get; set; }

        public BookingLineDTO()
        {
        }
    }
}