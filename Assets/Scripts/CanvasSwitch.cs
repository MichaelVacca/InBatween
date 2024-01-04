using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    public GameObject canvasToShow;
    public GameObject canvasToHide;

    public void SwitchCanvas()
    {
        canvasToShow.SetActive(true);
        canvasToHide.SetActive(false);
    }
}
