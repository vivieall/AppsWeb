using BetterConsoleTables;
using Common;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistence.Database;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(Parameter.ConnectionString);

            var context = new ApplicationDbContext(optionsBuilder.Options);

            var clientService = new ClientService(context);
            var productService = new ProductService(context);
            var warehouseService = new WarehouseService(context);

            using (context) 
            {
                //PrintProductsByPagingTable(productService);
                //PrintWarehousesAndProductsComplex(warehouseService);
                //PrintClientTable(clientService, 3);
                //PrintProductsTable(productService);
                //ProductsExistsByName(productService, "Guitarra eléctrica Fender Squier");
                PrintClientsTable(clientService);
            }

            Console.Read();
        }

        static void PrintProductsByPagingTable(ProductService productService)
        {
            var page = 0;

            do
            {
                var table = new Table("ProductId", "Name", "Price");
                var products = productService.GetPaged(page, 10);

                if (!products.Any()) 
                {
                    Console.WriteLine("No hay más registros que visualizar ...");
                    break;
                }

                foreach (var product in products)
                {
                    table.AddRow(product.ProductId, product.Name, product.Price);
                }

                Console.Write(table.ToString());
                Console.WriteLine("Presione enter para seguir buscando");
                Console.ReadLine();

                Console.Clear();

                page++;
            } while (true);
        }

        static void ProductsExistsByName(ProductService productService, string name) 
        {
            var exists = productService.ExistsByName(name);

            Console.WriteLine(exists ? "Product exists" : "Product not exists");
        }

        static void PrintProductsTable(ProductService productService)
        {
            var products = productService.GetAll(true);

            var table = new Table("ProductId", "Name", "Price");

            foreach (var product in products)
            {
                table.AddRow(product.ProductId, product.Name, product.Price);
            }

            Console.Write(table.ToString());
        }

        static void PrintWarehousesAndProductsComplex(WarehouseService warehouseService)
        {
            var warehouses = warehouseService.GetAllWithProducts();
            var table = new Table("Warehouse", "Product", "Price");

            foreach (var warehouse in warehouses)
            {
                table.AddRow(warehouse.WarehouseName, warehouse.ProductName, warehouse.ProductPrice);
            }

            Console.Write(table.ToString());
        }

        static void PrintWarehousesAndProducts(WarehouseService warehouseService)
        {
            var warehouses = warehouseService.GetAll();
            var table = new Table("Warehouse", "Product", "Price");

            foreach (var warehouse in warehouses)
            {
                table.AddRow(warehouse.Name);

                foreach (var warehouseProduct in warehouse.Products) 
                {
                    table.AddRow("", warehouseProduct.Product.Name, warehouseProduct.Product.Price);
                }
            }

            Console.Write(table.ToString());
        }

        static void PrintClientsTable(ClientService clientService) 
        {
            var clients = clientService.GetAll();

            var table = new Table("ClientId", "ClientNumber", "Name", "Country");

            foreach (var client in clients) 
            {
                table.AddRow(client.ClientId, client.ClientNumber, client.Name, client.Country?.Name ?? "-");
            }

            Console.Write(table.ToString());
        }

        static void PrintClientTable(ClientService clientService, int id)
        {
            var client = clientService.Get(id);

            var table = new Table("ClientId", "ClientNumber", "Name", "Country");

            if (client != null) 
            {
                table.AddRow(client.ClientId, client.ClientNumber, client.Name, client.Country?.Name ?? "-");
                Console.Write(table.ToString());
            }
        }

        static void PrintClientTable(ClientService clientService)
        {
            var client = clientService.GetFirstClient();

            var table = new Table("ClientId", "ClientNumber", "Name", "Country");

            if (client != null)
            {
                table.AddRow(client.ClientId, client.ClientNumber, client.Name, client.Country?.Name ?? "-");
                Console.Write(table.ToString());
            }
        }
    }
}
