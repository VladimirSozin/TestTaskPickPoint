namespace OrderApi.Models
{
    public enum OrderStatuses
    {
        Registered = 1,
        ReceivedToStore = 2,
        GivenToCourier = 3,
        DeliveredToTerminal = 4,
        DeliveredToRecipient = 5,
        Canceled = 6
    }
}