using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleScript : MonoBehaviour
{
    public GameObject Quit;
    public GameObject Play;
    public GameObject Select;
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
        SelectSound();
        SceneManager.LoadScene(1);
    }
    public void QuitButton() {
        SelectSound();
        Application.Quit();
    }   
    public void HababisoftClick() {
        SelectSound();
        Application.OpenURL("https://githababi.github.io/");
    }
    void SelectSound() {
        Object.Instantiate(Select, new Vector3(0,0,0), Quaternion.identity);
    }
}
