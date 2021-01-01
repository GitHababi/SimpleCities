using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleScript : MonoBehaviour
{
    public GameObject Quit;
    public GameObject Play;
    private Text playtext;
    private Text quittext;
    
    void Update() {
        quittext = Quit.GetComponent<Text>();
        playtext = Play.GetComponent<Text>();
    }
    public void OnGUIEnterQuit() {
        quittext.color = new Color(0.9f, 0.9f, 0f, 1f);
    }
    public void OnGUIExitQuit() {
        quittext.color = new Color(1f, 1f, 1f, 1f);
    }
    public void OnGUIEnterPlay() {
        playtext.color = new Color(0.9f, 0.9f, 0f, 1f);
    }
    public void OnGUIExitPlay() {
        playtext.color = new Color(1f, 1f, 1f, 1f);
    }
    public void PlayButton() {
        SceneManager.LoadScene(1);
    }
    public void QuitButton() {
        Application.Quit();
    }   
    public void HababisoftClick() {
        Application.OpenURL("https://githababi.github.io/");
    }
}
