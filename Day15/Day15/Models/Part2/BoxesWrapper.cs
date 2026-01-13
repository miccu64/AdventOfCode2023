namespace Day15.Models.Part2;

public class BoxesWrapper
{
    public BoxesWrapper()
    {
        List<Box> boxes = [];

        const int boxesCount = 256;
        for (int i = 0; i < boxesCount; i++)
            boxes.Add(new Box(i));

        Boxes = boxes;
    }

    public IReadOnlyList<Box> Boxes { get; }

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

        return Boxes.Sum(box => (long)box.Lenses.Index()
            .Sum(x => (box.Index + 1) * (x.Index + 1) * x.Item.FocalLength)
        );
    }

    private void DashOperation(Step step)
    {
        Box box = Boxes[step.BoxId];
        Lens? lensWithSameLabel = box.Lenses.SingleOrDefault(l => l.Label == step.Label);
        if (lensWithSameLabel == null)
            return;

        if (!box.Lenses.Remove(lensWithSameLabel))
            throw new InvalidOperationException("Found label, but couldn't remove it");
    }

    private void EqualsOperation(Step step)
    {
        Box box = Boxes[step.BoxId];
        int? indexOfLensWithSameLabel = box.Lenses.Index()
            .Where(x => x.Item.Label == step.Label)
            .Select(x => (int?)x.Index)
            .SingleOrDefault();

        Lens lensToAdd = new(step.Label, step.FocalLength);

        if (indexOfLensWithSameLabel != null)
            box.Lenses[indexOfLensWithSameLabel.Value] = lensToAdd;
        else
            box.Lenses = box.Lenses.Prepend(lensToAdd).ToList();
    }
}