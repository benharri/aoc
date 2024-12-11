using Solutions._2024;

namespace Tests;

[TestClass]
public class DojoTests
{
    private const string RawOrderingRule = "47|53";
    private const string RawUpdate = "75,47,61,53,29";
    private static readonly int[] ExpectedPageNumbers = [75, 47, 61, 53, 29];

    [TestMethod]
    public void TestDojoInput()
    {
        var day5 = new Day05();
        
    }

    [TestMethod]
    public void TestParsePageOrderingRule()
    {
        var orderRule = new Day05.PageOrderingRule(RawOrderingRule);
        Assert.AreEqual(47, orderRule.Target.Number);
        Assert.AreEqual(53, orderRule.Before.Number);
    }

    [TestMethod]
    public void TestParseUpdate()
    {
        var update = new Day05.Update(RawUpdate);
        CollectionAssert.AreEqual(ExpectedPageNumbers, update.Pages.Select(p => p.Number).ToList());
        Assert.AreEqual(61, update.MiddlePage.Number);
    }

    [TestMethod]
    public void TestDetectValidUpdate()
    {
        var orderRule = new Day05.PageOrderingRule(RawOrderingRule);
        var update = new Day05.Update(RawUpdate);
        
        Assert.IsTrue(update.IsValid([orderRule]));
    }
}
