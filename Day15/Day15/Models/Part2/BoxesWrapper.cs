namespace Day15.Models.Part2;

public class BoxesWrapper
{
    private readonly IReadOnlyList<Box> _boxes;
    
    public BoxesWrapper()
    {
        const int boxesCount = 256;
        _boxes = Enumerable.Range(0, boxesCount)
            .Select(x => new Box(x))
            .ToList();
    }

    public long Process(string text)
    {
        string[] splitText = text.Split(',');

        foreach (string operation in splitText)
        {
            Step step = new(operation);

            switch (step.Operation)
            {
                case OperationType.Dash:
                    DashOperation(step);
                    break;
                case OperationType.EqualsSign:
                    EqualsOperation(step);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        return _boxes.Sum(box => (long)box.Lenses.Index()
            .Sum(x => (box.Index + 1) * (x.Index + 1) * x.Item.FocalLength)
        );
    }

    private void DashOperation(Step step)
    {
        Box box = _boxes[step.BoxId];
        Lens? lensWithSameLabel = box.Lenses.SingleOrDefault(l => l.Label == step.Label);
        if (lensWithSameLabel == null)
            return;

        if (!box.Lenses.Remove(lensWithSameLabel))
            throw new InvalidOperationException("Found label, but couldn't remove it");
    }

    private void EqualsOperation(Step step)
    {
        Box box = _boxes[step.BoxId];
        Lens lensToAdd = new(step.Label, step.FocalLength);
        
        int? indexOfLensWithSameLabel = box.Lenses.Index()
            .Where(x => x.Item.Label == step.Label)
            .Select(x => (int?)x.Index)
            .SingleOrDefault();

        if (indexOfLensWithSameLabel != null)
            box.Lenses[indexOfLensWithSameLabel.Value] = lensToAdd;
        else
            box.Lenses.Add(lensToAdd);
    }
}