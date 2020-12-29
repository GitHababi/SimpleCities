using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public void ToggleTerraform() {
        
        if (Logic.isTerraform) {
            StatusScript.statusMessage = "Selected: None";
            Logic.isTerraform = false;
        } else {
            DisableAll();
            Logic.isTerraform = true;
            StatusScript.statusMessage = "Selected: Terraform";
        }
    }
    public void ToggleBuildRoad() {
        
        if (Logic.isBuildRoad) {
            StatusScript.statusMessage = "Selected: None";
            Logic.isBuildRoad = false;
        } else {
            DisableAll();
            Logic.isBuildRoad = true;
            StatusScript.statusMessage = "Selected: Road";
        }
    }
    public void ToggleDestroy() {
        
        if (Logic.isDestroy) {
            StatusScript.statusMessage = "Selected: None";
            Logic.isDestroy = false;
        } else {
            DisableAll();
            Logic.isDestroy = true;
            StatusScript.statusMessage = "Selected: Destroy";
        }
    }
    void DisableAll() {
        Logic.isTerraform = false;
        Logic.isBuildRoad = false;
        Logic.isDestroy = false;
    }
}
