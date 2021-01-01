using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{
    public static string statusMessage; //Selected item message box
    public GameObject Status;
    private Text text;


    public static string playerMessage; //Centered Text message box
    public GameObject Message;
    private Text messagetext;

    public static string residentialCount; //Residential Text message box
    public GameObject residentialDisplay;
    private Text residentialText;

    public static string commercialCount; //Commercial Text message box
    public GameObject commercialDisplay;
    private Text commercialText;

    public static string industrialCount; //Industrial Text message box
    public GameObject industrialDisplay;
    private Text industrialText;

    public static string timeMessage; //Industrial Text message box
    public GameObject timeDisplay;
    private Text timeText;

    public static string moneyMessage; //Cash Text message box
    public GameObject moneyDisplay;
    private Text moneyText;

    void Start() {
        StatusScript.playerMessage = "";
        StatusScript.statusMessage = "Tool: None";
    }
    void Update()
    {
        text = Status.GetComponent<Text>();
        text.text = statusMessage;

        messagetext = Message.GetComponent<Text>();
        messagetext.text = playerMessage;

        residentialText = residentialDisplay.GetComponent<Text>();
        residentialText.text = residentialCount;

        industrialText = industrialDisplay.GetComponent<Text>();
        industrialText.text = industrialCount;

        commercialText = commercialDisplay.GetComponent<Text>();
        commercialText.text = commercialCount;

        timeText = timeDisplay.GetComponent<Text>();
        timeText.text = timeMessage;



        moneyText = moneyDisplay.GetComponent<Text>();
        if (Logic.Cash < 0) {
            moneyText.color = new Color(1,0,0,1);
        }
        else {
            moneyText.color = new Color(0,1,0,1);
        }
        moneyText.text = moneyMessage;
    }
}
