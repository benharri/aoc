using MoreLinq;

namespace Solutions._2024;

/// <summary>
/// <a href="https://adventofcode.com/2024/day/5">Day 5</a>
/// </summary>
public sealed class Day05() : Day(2024, 5, "Print Queue")
{
    private IEnumerable<Update> _updates = [];
    private IEnumerable<PageOrderingRule> _orderRules = [];

    public class Page
    {
        public readonly int Number;

        public Page(string s)
        {
            Number = int.Parse(s);
        }
    }
    
    public class PageOrderingRule
    {
        public readonly Page Target;
        public readonly Page Before;

        public PageOrderingRule(string s)
        {
            var split = s.Split('|');
            Target = new(split[0]);
            Before = new(split[1]);
        }

        public static IEnumerable<PageOrderingRule> FromList(IEnumerable<string> list)
        {
            return list.Select(s => new PageOrderingRule(s));
        }
    }

    public class Update
    {
        public readonly List<Page> Pages = []; 
        public Update(string s)
        {
            Pages.AddRange(s.Split(',').Select(i => new Page(i)));
        }

        public Page MiddlePage => Pages[Pages.Count / 2]; 

        public static IEnumerable<Update> FromList(IEnumerable<string> last)
        {
            return last.Select(s => new Update(s));
        }

        public bool IsValid(IEnumerable<PageOrderingRule> orderRules)
        {
            foreach (var page in Pages)
            {
                
            }
            foreach (var rule in orderRules)
            {
                
            }

            return true;
        }
    }
    
    public override void ProcessInput()
    {
        var s = Input.Split("").ToList();
        _orderRules = PageOrderingRule.FromList(s[0]);
        _updates = Update.FromList(s[1]);
    }

    public override object Part1()
    {
        return _updates.Where(u => u.IsValid(_orderRules)).Sum(u => u.MiddlePage.Number);
    }

    public override object Part2() => "";
}
