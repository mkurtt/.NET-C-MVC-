using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class ApplicationUser : BaseEntity
    {

        public ApplicationUser()
        {
            LastLogin = DateTime.UtcNow;
        }
        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public DateTime LastLogin { get; set; }

        public string PicturePath { get; set; }

        //public bool IsStaff { get; set; }

        public virtual ICollection<Role> Roles { get; set; }


        public virtual ICollection<Product> Products { get; set; }
        
    }
}
