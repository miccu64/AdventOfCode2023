namespace Day15.Models.Part2;

public class Step
{
    public string Label { get; }
    public int FocalLength { get; }
    public OperationType Operation { get; }
    public int BoxId { get; }

    public Step(string stepText)
    {
        if (stepText.Contains('-'))
        {
            Operation = OperationType.Dash;
            Label = stepText[..^1];
        }
        else
        {
            string[] splitOperation = stepText.Split('=');
            Operation = OperationType.EqualsSign;
            Label = splitOperation[0];
            FocalLength = int.Parse(splitOperation[1]);
        }

        BoxId = (int)new Hasher().Hash(Label);
    }
}