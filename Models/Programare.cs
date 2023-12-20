using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Programare_Clinica.Models
{
    public class Programare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Descriere { get; set; }
        [OneToMany]
        public List<ListProgramare> ListProgramari { get; set; }
    }
}
