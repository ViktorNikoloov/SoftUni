namespace _03.Telephony.Models.Contracts
{
    public interface IBrowseable
    {
        public int MyProperty { get; set; }

        public string Browse(string url);
    }
}
