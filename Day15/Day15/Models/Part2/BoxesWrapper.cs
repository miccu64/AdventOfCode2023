namespace Day15.Models.Part2;

public class BoxesWrapper
{
    public IReadOnlyList<Box> Boxes { get; }

    public BoxesWrapper()
    {
        List<Box> boxes = [];
        
        const int boxesCount = 256;
        for (int i = 0; i < boxesCount; i++)
            boxes.Add(new Box());

        Boxes = boxes;
    }

    public void Process(string text)
    {
        string[] splitText =  text.Split(',');

        foreach (string operation in splitText)
        {
            
        }
    }

    private (OperationType operationType, string[] splitOperation) GetOperation(string operation)
    {
        string[] splitOperation = operation.Split('-');
        if (splitOperation.Length == 2)
        {
            return (OperationType.Dash, splitOperation);
        }
        else
        {
            splitOperation = operation.Split('=');
            return (OperationType.EqualsSign, splitOperation);
        }
    }
}