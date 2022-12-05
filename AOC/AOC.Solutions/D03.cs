namespace AOC.Solutions;

public class D03 : DayBase
{
    protected override int Day => 3;

    public override long Solve_1()
    {
        var lines = GetInputLines();

        var priority = 0;

        foreach (var line in lines)
        {
            var compartmentA = line.Take(line.Length / 2);
            var compartmentB = line.TakeLast(line.Length / 2);

            var error = compartmentA.Intersect(compartmentB).First();

            priority += error > 90 ? error - 96 : error - 38;
        }

        return priority;
    }

    public override long Solve_2()
    {
        var lines = GetInputLines();

        var priority = 0;

        for (var i = 0; i < lines.Count; i += 3)
        {
            var bags = new List<char>();
            
            bags.AddRange(lines[i + 0].Distinct().ToList());
            bags.AddRange(lines[i + 1].Distinct().ToList());
            bags.AddRange(lines[i + 2].Distinct().ToList());

            var common = bags.First(x => bags.Count(a => a == x) == 3);
            
            priority += common > 90 ? common - 96 : common - 38;
        }

        return priority;
    }
}