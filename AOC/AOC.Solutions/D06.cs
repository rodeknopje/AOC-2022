namespace AOC.Solutions;

public class D06 : DayBase
{
    protected override int Day => 6;
    public override long Solve_1() => GetFirstUniqueString(4);
    public override long Solve_2() => GetFirstUniqueString(14);
    
    private int GetFirstUniqueString(int length)
    {
        var input = GetInputRaw();
        
        for (var i = length; i < input.Length; i++)
        {
            var part = input.Substring(i - length,length);
            
            if (part.Distinct().Count() == length)
            {
                return i;
            }
        }

        return 0;
    }
}