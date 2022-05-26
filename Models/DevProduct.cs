﻿using System;
using System.Collections.Generic;

    public partial class DevProduct
    {
        public DevProduct()
        {
            DevTransactions = new HashSet<DevTransaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int QuantityInStock { get; set; }
        public double Price { get; set; }

        public virtual ICollection<DevTransaction> DevTransactions { get; set; }
    }

    

