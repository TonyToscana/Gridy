using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class WebData : DataDecorator
{
    public WebData(IData temp) : base(temp)
    {
    }

    public override string Load(string name)
    {
        HttpClient client = new HttpClient();
        
        var t = Task.Run(() => GetAsync(new Uri(ServerConfiguration.ScoreUrl + "/" + name)));
        t.Wait();
        
        return t.Result;
    }

    private async Task<string> GetAsync(Uri uri)
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage content = await client.GetAsync(uri);

        return await content.Content.ReadAsStringAsync();
    }

    public override string Save(string name, string value)
    {
        base.Save(name, value);

        var result = Task.Run(() => PostAsync(new Uri(ServerConfiguration.BaseUrl), name, value));

        return result.Result;
    }

    private static async Task<string> PostAsync(Uri uri, string name, string value)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = uri;

            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>(name, value)
            });
            var result = await client.PostAsync(ServerConfiguration.ScorePath, content);

            return await result.Content.ReadAsStringAsync();
        }
    }
}
