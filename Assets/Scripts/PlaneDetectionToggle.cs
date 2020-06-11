using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]

public class PlaneDetectionToggle : MonoBehaviour
{
    private ARPlaneManager planeManager;
    [SerializeField]
    private Text toggleButtonText;

    private void Awake()
    {
        planeManager = GetComponent < ARPlaneManager>();
        planeManager.enabled = false;
        toggleButtonText.text = "Enable";
    }

    public void TogglePlaneDetection()
    {
        // disabling manager prevents planes from being updated in size and location
        // so invisible planes will not change
        planeManager.enabled = !planeManager.enabled;
        string toggleButtonMsg = "";
        // if planes are being displayed
        if (planeManager.enabled)
        {
            toggleButtonMsg = "Disable";
            SetAllPlanesActive(true);
        } else // planes not being displayed
        {
            toggleButtonMsg = "Enable";
            SetAllPlanesActive(false);
        }

        toggleButtonText.text = toggleButtonMsg;
    }

    private void SetAllPlanesActive(bool value)
    {
        foreach(var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
