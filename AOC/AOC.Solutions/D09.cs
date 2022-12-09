namespace AOC.Solutions;

public class D09 : DayBase
{
    protected override int Day => 9;


    public override long Solve_1() => Solve(2);
    public override long Solve_2()=> Solve(10);
    
    private long Solve(int tailLength)
    {
        var points = new (int x, int y)[tailLength];
        
        var visited = new List<(int x, int y)>();

        foreach (var line in GetInputLines())
        {
            var cmd = line.Split(" ");
            
            for (var i = 0; i < int.Parse(cmd.Last()); i++)
            {
                switch (cmd.First())
                {
                    case "U": points[0].y++; break;
                    case "D": points[0].y--; break;
                    case "R": points[0].x++; break;
                    case "L": points[0].x--; break;
                }

                for (var j = 1; j < points.Length; j++)
                {
                    if (Math.Abs(points[j - 1].x - points[j].x) > 1 ||
                        Math.Abs(points[j - 1].y - points[j].y) > 1 )
                    {
                        points[j].x += Math.Clamp(points[j - 1].x - points[j].x, -1, 1);
                        points[j].y += Math.Clamp(points[j - 1].y - points[j].y, -1, 1);
                    }
                }

                visited.Add(points.Last());
            }

        }
        
        return visited.Distinct().Count();
    }

   
}