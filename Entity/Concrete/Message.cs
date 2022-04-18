﻿using System;


namespace EntityLayer.Concrete
{
    public class Message
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Detais { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

    }
}
