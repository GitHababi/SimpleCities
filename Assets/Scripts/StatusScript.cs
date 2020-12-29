using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{
    public static string statusMessage;

    public GameObject Status;
    private Text text;
    void Start() {
        StatusScript.statusMessage = "Selected: None";
    }
    void Update()
    {
        text = Status.GetComponent<Text>();
        text.text = statusMessage;
    }
}
