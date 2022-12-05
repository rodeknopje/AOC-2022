namespace AOC.Solutions;

public class D04 : DayBase
{
    protected override int Day => 4;
    public override long Solve_1()
    {
        var lines = GetInputLines();
        var total = 0;
        
        foreach (var line in lines)
        {
            var nums = line.Split('-', ',').Select(x => Convert.ToInt32(x)).ToList();

            if ((nums[0] >= nums[2] && nums[1] <= nums[3]) || (nums[2] >= nums[0] && nums[3] <= nums[1])) {
                total++;
            }
        }

        return total;
    }

    public override long Solve_2()
    {
        var lines = GetInputLines();
        var total = 0;
        
        foreach (var line in lines)
        {
            var nums = line.Split('-', ',').Select(x => Convert.ToInt32(x)).ToList();

            if (
                (nums[0] >= nums[2] && nums[0] <= nums[3]) ||
                (nums[1] >= nums[2] && nums[1] <= nums[3]) ||
                (nums[2] >= nums[0] && nums[2] <= nums[1]) ||
                (nums[3] >= nums[0] && nums[3] <= nums[1]))
            {
                total++;
            }
        }

        return total;
    }
}