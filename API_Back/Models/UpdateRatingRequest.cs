﻿namespace API_Back.Models
{
    public class UpdateRatingRequest
    {
        public UpdateRatingRequest() { }


        public int IdProduct { get; set; }
        public int rating { get; set; }
        public int Id { get; set; }
    }
}
