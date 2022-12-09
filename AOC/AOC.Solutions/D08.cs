using System.Threading.Channels;

namespace AOC.Solutions;

public class D08 : DayBase
{
    protected override int Day => 8;

    private readonly int[,] _input;
    
    long visibleTrees;
    long maxSceneScore;

    public D08()
    {
        _input = GetInputIntMap();
        
        var h = _input.GetLength(0);
        var w = _input.GetLength(1);

        for (var y = 0; y < h; y++)
        for (var x = 0; x < w; x++)
        {
            var result = IsVisible(_input[y, x], y, x, w, h);

            visibleTrees += result.visible ? 1 : 0;
            maxSceneScore = Math.Max(maxSceneScore, result.score);
        }
    }

    public override long Solve_1() => visibleTrees;
    
    public override long Solve_2() => maxSceneScore;
    
    private (bool visible, long score) IsVisible(int t, int y, int x, int w, int h)
    {
        var scores = new long[4];

        var visible = false;
        
        // left
        for (var l = x-1; l >= -1; l--)
        {
            if (l < 0)
            {
                visible = true;
                break;
            }

            scores[0]++;

            if (_input[y, l] >= t)
            {
                break;
            }
        }
        // right
        for (var r = x + 1; r <= w; r++)
        {
            if (r == w)
            {
                visible = true;
                break;
            }

            scores[1]++;;

            if (_input[y, r] >= t)
            {
                break;
            }
        }
        // up
        for (var u = y-1; u >= -1; u--)
        {
            if (u == -1)
            {
                visible = true;
                break;
            }
            
            scores[2]++;
            
            if (_input[u, x] >= t)
            {
                break;
            }
        }
        // down
        for (var d = y + 1; d <= h; d++)
        {
            if (d == h)
            {
                visible = true;
                break;
            }

            scores[3]++;
            
            if (_input[d, x] >= t)
            {
                break;
            }
        }
        
        return (visible, scores.Aggregate((a, b) => a * b));
    }
}