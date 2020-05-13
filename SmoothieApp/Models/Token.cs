﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieApp.Models
{
    public class Token
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string access_token { get; set; }
        public string error_description { get; set; }
        public DateTime expire_date { get; set; }

        public Token()
        {
        }
    }
}
