using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject SelectSound;
    public void ToggleTerraform() {
        if (Logic.isTerraform) {
            Select();
            StatusScript.statusMessage = "Selected: None";
            Logic.isTerraform = false;
        } else {
            Select();
            DisableAll();
            Logic.isTerraform = true;
            StatusScript.statusMessage = "Selected: Terraform";
        }
    }
    public void ToggleBuildRoad() {
        if (Logic.isBuildRoad) {
            Select();
            StatusScript.statusMessage = "Selected: None";
            Logic.isBuildRoad = false;
        } else {
            Select();
            DisableAll();
            Logic.isBuildRoad = true;
            StatusScript.statusMessage = "Selected: Road";
        }
    }
    public void ToggleDestroy() {
        if (Logic.isDestroy) {
            Select();
            StatusScript.statusMessage = "Selected: None";
            Logic.isDestroy = false;
        } else {
            Select();
            DisableAll();
            Logic.isDestroy = true;
            StatusScript.statusMessage = "Selected: Destroy";
        }
    }
    public void ToggleResidential() {
        if (Logic.isBuildResidential) {
            Select();
            StatusScript.statusMessage = "Selected: None";
            Logic.isBuildResidential = false;
        } else {
            Select();
            DisableAll();
            Logic.isBuildResidential = true;
            StatusScript.statusMessage = "Selected: Residential";
        }
    }
    public void ToggleCommercial() {
        if (Logic.isBuildCommercial) {
            Select();
            StatusScript.statusMessage = "Selected: None";
            Logic.isBuildCommercial = false;
        } else {
            Select();
            DisableAll();
            Logic.isBuildCommercial = true;
            StatusScript.statusMessage = "Selected: Commercial";
        }
    }
    void DisableAll() {
        Logic.isTerraform = false;
        Logic.isBuildRoad = false;
        Logic.isDestroy = false;
        Logic.isBuildResidential = false;
        Logic.isBuildCommercial = false;
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
