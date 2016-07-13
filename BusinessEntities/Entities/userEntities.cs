using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    using System;
    using System.Collections.Generic;

    public class userEntities
    {
        public userEntities()
        {
            this.Tokens = new HashSet<TokenEntities>();
        }

        public int ID { get; set; }
        public int IDV { get; set; }
        public string IDVMAIL { get; set; }
        public string IDVMAILPASSWORD { get; set; }
        public Nullable<int> IDVROLE { get; set; }

        public virtual personEntities person { get; set; }
        public virtual ICollection<TokenEntities> Tokens { get; set; }
    }
}
