using System;
using System.Collections.Generic;


    public partial class DevTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }

        public virtual DevCustomer Customer { get; set; } = null!;
        public virtual DevProduct Product { get; set; } = null!;
    }

