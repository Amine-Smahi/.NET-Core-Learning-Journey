namespace WebApp.Models
{
    public class TransferViewModel
    {
        public string TransferNotes { get; set; }
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
