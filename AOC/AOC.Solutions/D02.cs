namespace AOC.Solutions;

public class D02 : DayBase
{
    protected override int Day => 2;
    
    public override long Solve_1()
    {
        var lines = GetInputLines().Select(x => x.Split(" "));
        
        var total = 0;
        
        foreach (var line in lines)
        {
            var elementA = line[0].First() - 64;
            var elementB = line[1].First() - 87;
            
            var score = (elementA - elementB) switch
            {
                -1 => 6, -2 => 0, +0 => 3, +1 => 0, +2 => 6,
            };

            total += score + elementB;
        }

        return total;
    }

    public override long Solve_2()
    {
        var lines = GetInputLines().Select(x => x.Split(" "));
        
        var total = 0;
        
        foreach (var line in lines)
        {
            var elementA = line[0].First() - 65;
            
            var elementB = (line[1].First() - 88) switch
            {
                0 => (elementA + 2) % 3 , 
                1 => elementA, 
                2 => (elementA + 1) % 3,
            };

            var score = (elementA - elementB) switch
            {
                -1 => 6, -2 => 0, +0 => 3, +1 => 0, +2 => 6,
            };

            total += score + elementB + 1;
        }

        return total;
    }
    
    
}