﻿using ErpDatabase.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class Client : IEntity
    {
        //public int ClientId { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        public int Id { get; set; }
    }
}
