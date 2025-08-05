﻿using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Models
{
    public class Stock
    {
        public DateTime Date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public float AdjClose { get; set; }
        public int Volume { get; set; }
    }
}
