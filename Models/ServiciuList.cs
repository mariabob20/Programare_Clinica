﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Programare_Clinica.Models
{
    public class ServiciuList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250), Unique]
        public string Descriere { get; set; }

        public DateTime Date { get; set; }

       // [ForeignKey(typeof(Serviciu))]
       // public int ServiciuID { get; set; }  adauga la lab 10
    }
}
