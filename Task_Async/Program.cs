using System.Diagnostics;
using System.Net;

string s;

List<string> urlList = new List<string>()
{
    "https://medium.com/@dorlugasigal/c-10-priorityqueue-is-here-5067e2628470",
    "https://medium.com/@nicolas-rfontes/c-performance-linq-x-for-635db3bbdc06",
    "https://medium.com/projectwt/solid-principles-in-c-net-6-0-using-batman-as-example-87d59f9616dd",
    "https://medium.com/projectwt/simple-dependency-injection-in-net-6-0-web-api-24164e56f8f8",
    "https://medium.com/projectwt/nlog-with-ilogger-in-net-6-0-web-api-fb7072d8ac6c",
    "https://medium.com/@scottoffen/effortlessly-renew-api-tokens-in-asp-net-6-0-84a67241a5f"

};

using (WebClient client=new WebClient() )
{
    Stopwatch sw = Stopwatch.StartNew();
    sw.Restart();
    foreach (var item in urlList)
    {
        sw.Start();
        s = client.DownloadString(item);
        sw.Stop();
        Console.WriteLine(s.Length+" "+sw.Elapsed);
    }
}

Console.WriteLine("******************************************* With Async *************************************");

HttpClient httpClient = new HttpClient();
foreach (var item in urlList)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    stopwatch.Restart();
   using(HttpResponseMessage httpResponse=await httpClient.GetAsync(item))
    {
        using(HttpContent content=httpResponse.Content)
            
        {
            stopwatch.Start();
            string pagecontent = await content.ReadAsStringAsync();
            stopwatch.Stop();
            Console.WriteLine(pagecontent.Length+ " " + stopwatch.Elapsed);
        }
    }

}
