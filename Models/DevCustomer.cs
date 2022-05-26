using System;
using System.Collections.Generic;


    public partial class DevCustomer
    {
        public DevCustomer()
        {
            DevTransactions = new HashSet<DevTransaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public virtual ICollection<DevTransaction> DevTransactions { get; set; }
    }

