namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers => new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("72C2C4B1-EC58-41E5-A123-F582234B7F7B")), "mehmet", "mehmet@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("F227D7B2-883D-47CE-AB9E-EB113C10C4E1")), "john", "john@gmail.com")
        };

        public static IEnumerable<Product> Products => new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("1F1F3CCA-B2B7-4422-A34C-A4AFD687A867")), "IPhone X", 500),
            Product.Create(ProductId.Of(new Guid("9C8328DA-7B3D-411E-B9ED-A36050E1085C")), "Samsung 10", 400),
            Product.Create(ProductId.Of(new Guid("C3E11456-1D19-4BB1-A702-B50302F90147")), "Huawei Plus", 650),
            Product.Create(ProductId.Of(new Guid("932D5397-7479-4C6C-8CB7-EA7DB8DC4319")), "Xiaomi", 450)
        };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4", "Turkey", "Istanbul", "38050");
                var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

                var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
                var payment2 = Payment.Of("john", "8885555555554444", "06/30", "222", 2);

                var order1 = Order.Create(
                    OrderId.Of(new Guid("EC6AD33A-FEB6-4316-AF10-7DF297FA2F18")),
                    CustomerId.Of(new Guid("72C2C4B1-EC58-41E5-A123-F582234B7F7B")),
                    OrderName.Of("ORD_1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment1);
                order1.Add(ProductId.Of(new Guid("1F1F3CCA-B2B7-4422-A34C-A4AFD687A867")), 2, 500);
                order1.Add(ProductId.Of(new Guid("9C8328DA-7B3D-411E-B9ED-A36050E1085C")), 1, 400);

                var order2 = Order.Create(
                    OrderId.Of(new Guid("BB95AB78-2A24-4019-8BCF-08CACCBBE09C")),
                    CustomerId.Of(new Guid("F227D7B2-883D-47CE-AB9E-EB113C10C4E1")),
                    OrderName.Of("ORD_2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    payment1);
                order2.Add(ProductId.Of(new Guid("C3E11456-1D19-4BB1-A702-B50302F90147")), 2, 650);
                order2.Add(ProductId.Of(new Guid("932D5397-7479-4C6C-8CB7-EA7DB8DC4319")), 1, 450);

                return [order1, order2];
            }
        }
    }
}