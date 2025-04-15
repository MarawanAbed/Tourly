using System.ComponentModel.DataAnnotations;

public class PaymentCallbackDto
{
    [Required]
    public string Message { get; set; }

    [Required]
    public long TransactionId { get; set; }

    [Required]
    public CallbackOrderObj Obj { get; set; }
}

public class CallbackOrderObj
{
    public CallbackOrder Order { get; set; }
}

public class CallbackOrder
{
    [Required]
    public string MerchantOrderId { get; set; }
}
