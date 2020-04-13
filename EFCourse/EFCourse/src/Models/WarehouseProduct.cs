﻿namespace Models
{
    public class WarehouseProduct
    {
        public int WarehouseProductId { get; set; }
        public int WareHouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
