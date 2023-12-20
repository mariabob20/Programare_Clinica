using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Programare_Clinica.Models
{
    public class ListProgramare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(ServiciuList))]
        public int ServiciuListID { get; set; }
        public int ProgramareID { get; set; }
    }
}
