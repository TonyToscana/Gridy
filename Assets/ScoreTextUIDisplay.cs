using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextUIDisplay : MonoBehaviour
{
    [SerializeField] public Text text;
    [SerializeField] public GameObject panel;

    [HideInInspector] public bool showData = true;

    // Start is called before the first frame update
    void Start()
    {
        ShowData(); 
    }

    private void ShowData()
    {
        try
        {
            this.text.text = this.GetScoresFromWeb();
        }
        catch (Exception e)
        {
            this.text.text = "No Connection with the server.";
        }

        showData = false;
    }

    private string GetScoresFromWeb()
    {
        IData data = new WebData(new Data());
        string web = data.Load("name");
        ScoreData[] response = JsonHelper.FromJson<ScoreData>(web);
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < response.Length; i++)
        {
            result.Append(response[i].name).Append("\t").Append(response[i].points).Append("\t").Append(response[i].time).Append("\n");
        }

        return result.ToString();
    }

    public void OnCloseScoreBtnClick()
    {
        panel.SetActive(false);
        showData = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (showData == true)
        {
            ShowData();
        }
    }
}
