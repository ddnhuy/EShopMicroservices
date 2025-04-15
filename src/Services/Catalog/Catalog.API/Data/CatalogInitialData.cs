using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync(cancellation))
            {
                return;
            }

            session.Store(GetPreconfiguredProducts());
            await session.SaveChangesAsync(cancellation);
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = new Guid("A4E16E86-933C-48D0-B19F-8E5C3513CB2C"),
                Name = "IPhone X",
                Description = "This phone is the company's biggrest change to its",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Category = ["Smart Phone"]
            },
            new Product()
            {
                Id = new Guid("02BE5B4A-02CB-45FB-BDF9-DA91D8EEA91E"),
                Name = "Samsung 10",
                Description = "This phone is the company's biggrest change to its",
                ImageFile = "product-2.png",
                Price = 840.00M,
                Category = ["Smart Phone"]
            },
            new Product()
            {
                Id = new Guid("7899A806-7ADB-42E1-BE15-A61928C51DD1"),
                Name = "Huawei Plus",
                Description = "This phone is the company's biggrest change to its",
                ImageFile = "product-3.png",
                Price = 650.00M,
                Category = ["Smart Phone"]
            },
            new Product()
            {
                Id = new Guid("CD443C6A-0457-4FB3-8591-51BB6C73A7BE"),
                Name = "Panasonic Lumix",
                Description = "This phone is the company's biggrest change to its",
                ImageFile = "product-4.png",
                Price = 800.00M,
                Category = ["Camera"]
            },
            new Product()
            {
                Id = new Guid("932FDABA-6332-4FB8-AE16-DC73118E93EF"),
                Name = "LG G7 ThinQ",
                Description = "This phone is the company's biggrest change to its",
                ImageFile = "product-5.png",
                Price = 450.00M,
                Category = ["Home Kitchen"]
            }
        };
    }
}
