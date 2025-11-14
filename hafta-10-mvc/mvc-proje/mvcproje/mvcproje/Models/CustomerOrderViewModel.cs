namespace mvcproje.Models
{
    public class CustomerOrderViewModel
    {
        public Customer Customer { get; set; }         // Tek bir müşteri bilgisi
        public List<Order> Orders { get; set; }        // O müşteriye ait siparişlerin listesi
    }
}
