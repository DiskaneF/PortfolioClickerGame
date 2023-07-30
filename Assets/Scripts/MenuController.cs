using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanelClick;
    public GameObject menuPanelAuto;

    void Start()
    {
        menuPanelClick.SetActive(!menuPanelClick.activeSelf);
        menuPanelAuto.SetActive(!menuPanelAuto.activeSelf);
    }

    public void ToggleMenuClick()
    {
        if (menuPanelClick.activeSelf)
        {
            menuPanelClick.SetActive(false);
        }
        else
        {
            menuPanelClick.SetActive(true);
            menuPanelAuto.SetActive(false);
        }
    }

    public void ToggleMenuAuto()
    {
        if (menuPanelAuto.activeSelf)
        {
            menuPanelAuto.SetActive(false);
        }
        else
        {
            menuPanelAuto.SetActive(true);
            menuPanelClick.SetActive(false);
        }
    }

}
