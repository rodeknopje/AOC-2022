using System.Text.RegularExpressions;

namespace AOC.Solutions;

public class D05 : DayBase
{
    protected override int Day => 5;

    public override long Solve_1()
    {
        var tempStacks = InitializeStacks();
        
        foreach (var stack in tempStacks)
        {
            stack.Reverse();
        }

        var stacks = tempStacks.Select(x => new Stack<char>(x)).ToList();


        var lines = GetInputLines();

        foreach (var line in lines)
        {
            if (line.Contains("move") == false)
            {
                continue;
            }

            var data = GetTransferData(line);
            
            for (var i = 0; i < data.amount; i++)
            {
                stacks[data.to].Push(stacks[data.from].Pop());
            }
        }

        var message = string.Empty;

        foreach (var stack in stacks)
        {
            message += stack.Pop();
        }

        Console.WriteLine(message);

        return 1;
    }
    
    public override long Solve_2()
    {
        var stacks = InitializeStacks();
        
        var lines = GetInputLines();

        foreach (var line in lines)
        {
            if (!line.Contains("move"))
            {
                continue;
            }
            
            var data = GetTransferData(line);
            var range = stacks[data.from].Take(data.amount).ToList();
            stacks[data.from].RemoveRange(0, data.amount);
            stacks[data.to].InsertRange(0, range);
        }

        var message = string.Empty;

        foreach (var stack in stacks)
        {
            message += stack.First();
        }

        Console.WriteLine(message);

        return 0;
    }

    private static (int amount, int from, int to) GetTransferData(string line)
    {
        var nums =  line
            .Split(" ")
            .Where((_,index) => index % 2 == 1)
            .Select(x => Convert.ToInt32(x)).ToList();

        return (nums[0], --nums[1], --nums[2]);
    }
    
    private List<List<char>> InitializeStacks()
    {
        var stacks = new List<List<char>>();

        var lines = GetInputLines();

        for (var i = 0; i < 9; i++)
        {
            stacks.Add(new List<char>());
        }

        foreach (var line in lines)
        {
            if (line.Contains("[") == false)
            {
                break;
            }
            for (var index = 0; index < line.Length; index++)
            {
                var character = line[index];

                if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(character) == false)
                {
                    continue;
                }

                var stackIndex = (index - 1) / 4;
                
                stacks[stackIndex].Add(character);
            }
        }

        return stacks;
    }
}