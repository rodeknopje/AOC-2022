namespace AOC.Solutions;

using System.Text.RegularExpressions;

public class D07 : DayBase
{
    protected override int Day => 7;

    private readonly List<string> _lines;

    private long _totalA;
    private long _totalB;

    private readonly List<long> _dirSizes = new();

    public D07()
    {
        _lines = GetInputLines();

        TraverseDirectories();
    }

    public override long Solve_1()
    {
        return _totalA;
    }

    public override long Solve_2()
    {
        var need = 30000000 - (70000000 - _totalB);

        var smallest = _dirSizes.Where(x => x >= need).Min();

        return smallest;
    }
    
    private long TraverseDirectories()
    {
        long currentSize = 0;

        while (_lines.Any())
        {
            var line = _lines.First();

            _lines.RemoveAt(0);

            if (new Regex("\\d").IsMatch(line))
            {
                currentSize += Convert.ToInt64(line.Split(" ").First());

                _totalB += Convert.ToInt64(line.Split(" ").First());

                if (_lines.Any() == false && currentSize <= 100000)
                {
                    _totalA += currentSize;
                }
            }
            // if its a cd
            else if (line.Contains("cd .."))
            {
                _dirSizes.Add(currentSize);

                if (currentSize <= 100000)
                {
                    _totalA += currentSize;
                }

                return currentSize;
            }
            else if (line.Contains("cd"))
            {
                currentSize += TraverseDirectories();
            }
        }

        return currentSize;
    }
}