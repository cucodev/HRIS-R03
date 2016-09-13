using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CrudEntities
{
    public class UserEntities
    {
        public int ID { get; set; }
        public int IDV { get; set; }
        public string IDVMAIL { get; set; }
        public string IDVMAILPASSWORD { get; set; }
        public Nullable<int> IDVROLE { get; set; }
        public virtual person person { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
