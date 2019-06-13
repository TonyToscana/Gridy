using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerConfiguration 
{
    public static string BaseUrl => "http://127.0.0.1:9082/";
    public static string ScoreUrl => "http://127.0.0.1:9082/rest/score";
    public static string ScorePath => "/rest/score";
}
