﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoAPI.Helpers
{
    public class RDSConnectionString
    {
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }

    }
}
