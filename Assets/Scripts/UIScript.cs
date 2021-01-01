using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject SelectSound;
    private int SwitchSpecial;
    public void ToggleTerraform() {
        if (Logic.isTerraform) {
            Select();
            StatusScript.statusMessage = "Tool: None";
            Logic.isTerraform = false;
        } else {
            Select();
            DisableAll();
            Logic.isTerraform = true;
            StatusScript.statusMessage = "Tool: Terraform";
        }
    }
    public void ToggleRoad() {
        if (Logic.isBuildRoad) {
            Select();
            StatusScript.statusMessage = "Tool: None";
            Logic.isBuildRoad = false;
        } else {
            Select();
            DisableAll();
            Logic.isBuildRoad = true;
            StatusScript.statusMessage = "Tool: Road";
        }
    }
    public void SwitchSpecialButton() {
        SwitchSpecial++;
        Select();
        DisableAll();
        switch (SwitchSpecial){
            case 1:
            Logic.isBuildPump = true;
            StatusScript.statusMessage = "Tool: Water Pump";
            break;

            case 2:
            Logic.isBuildTurbine = true;
            StatusScript.statusMessage = "Tool: Power Turbine";
            break;
            
            case 3:
            Logic.isBuildTower = true;
            StatusScript.statusMessage = "Tool: Water Tower";
            break;
            
            case 4:
            Logic.isBuildPlant = true;
            StatusScript.statusMessage = "Tool: Power Plant";
            break;
            
            default:
            StatusScript.statusMessage = "Tool: None";
            SwitchSpecial = 0;
            break;
        }
    }
    public void ToggleDestroy() {
        if (Logic.isDestroy) {
            Select();
            StatusScript.statusMessage = "Tool: None";
            Logic.isDestroy = false;
        } else {
            Select();
            DisableAll();
            Logic.isDestroy = true;
            StatusScript.statusMessage = "Tool: Destroy";
        }
    }
    public void ToggleResidential() {
        if (Logic.isBuildResidential) {
            Select();
            StatusScript.statusMessage = "Tool: None";
            Logic.isBuildResidential = false;
        } else {
            Select();
            DisableAll();
            Logic.isBuildResidential = true;
            StatusScript.statusMessage = "Tool: Residential";
        }
    }
    public void ToggleCommercial() {
        if (Logic.isBuildCommercial) {
            Select();
            StatusScript.statusMessage = "Tool: None";
            Logic.isBuildCommercial = false;
        } else {
            Select();
            DisableAll();
            Logic.isBuildCommercial = true;
            StatusScript.statusMessage = "Tool: Commercial";
        }
    }
    public void ToggleBuildIndustrial() {
        if (Logic.isBuildIndustrial) {
            Select();
            StatusScript.statusMessage = "Tool: None";
            Logic.isBuildIndustrial = false;
        } else {
            Select();
            DisableAll();
            Logic.isBuildIndustrial = true;
            StatusScript.statusMessage = "Tool: Industrial";
        }
    }
    public void ExitButton() {
        if (Logic.gameExit == 1) {
            Select();
            SceneManager.LoadScene(0);
        }
        if (Logic.gameExit == 0){
            Select();
            Logic.gameExit++;
            StatusScript.playerMessage = "Are you sure you want to exit? \nPress again to confirm.";
        }
    }
    void DisableAll() {
        Logic.isTerraform = false;  
        Logic.isBuildRoad = false;
        Logic.isDestroy = false;
        Logic.isBuildResidential = false;
        Logic.isBuildCommercial = false;
        Logic.isBuildIndustrial = false;
        Logic.isBuildPump = false;
        Logic.isBuildTurbine = false;
        Logic.isBuildTower = false;
        Logic.isBuildPlant = false;
    }
    public void GUIEnter() {
        Logic.isOnGUI = true;
    }
    public void GUIExit() {
        Logic.isOnGUI = false;
    }
    public void Select() {
        Object.Instantiate(SelectSound, new Vector3(0,0,0), Quaternion.identity); 
    }
    public void ToggleLoad() {
        Logic.doLoad = true;
    }
    public void ToggleSave() {
        Logic.doSave = true;
    }
}
