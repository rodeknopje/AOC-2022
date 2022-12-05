namespace AOC.Solutions;

public class D01 : DayBase
{
    protected override int Day => 1;
    
    public override long Solve_1()
    {
        return GetInputRaw().Split("\n\n").Select(x => x.Split("\n").Select(s => Convert.ToInt64(s)).Sum()).Max();
    }
    
    public override long Solve_2()
    {
        return GetInputRaw().Split("\n\n").Select(x => x.Split("\n").Select(s => Convert.ToInt64(s)).Sum()).Order().TakeLast(3).Sum();
    }
}

