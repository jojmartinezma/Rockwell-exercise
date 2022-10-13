
using Find_clicks;


string word = "ant";



var clickFunction = new Clicks();

Console.WriteLine(word + "--" + clickFunction.ClicksCount(word));

word = "jose"; // 15
Console.WriteLine(word + "--" + clickFunction.ClicksCount(word));

word = "rockwell **"; // 28
Console.WriteLine(word + "--" + clickFunction.ClicksCount(word));