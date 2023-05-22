namespace BeerSender.Domain.Box;

public record Box_size(int Number_of_bottles)
{
    public static readonly int[] ValidSize = { 6, 12, 24 };
    public int Number_of_bottles { get; init; } = ValidSize.Contains(Number_of_bottles) 
        ?  Number_of_bottles 
        : throw new BoxException(Box_select_reason.Invalid_box_size.ToString());
}
