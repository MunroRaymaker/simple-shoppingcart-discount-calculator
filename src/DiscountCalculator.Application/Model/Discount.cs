namespace DiscountCalculator.Application.Model
{
    public class Discount
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DiscountType DiscountType { get; set; }
    }

    public enum DiscountType
    {
        FixedPriceForNDiscount,

        FixedPriceForTwoSkusDiscount,

        Percentage
    }
}
