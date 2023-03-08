using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public static int ChoosenExperment = 1;
    public Text  HoverdEpermentNameText, HoverdDetailsText;

    public void PlayLab ()
    {
        SceneManager.LoadScene(ChoosenExperment);
    }
    public void ONHoverButton()
    {
        HoverdEpermentNameText.text = "Hover DNA Extraction";
        HoverdDetailsText.text = "Hover here u can write some Details about the experment";
    }
    public void ONExitButton()
    {
        HoverdEpermentNameText.text = "Choosen DNA Extraction";
        HoverdDetailsText.text = "Choosen here u can write some Details about the experment";
    }
    public void NextSceneindx(int indx)
    {
        if (indx == 1)
            Steps.Step = 1;
        else if (indx == 2)
            Steps.Step = 15;
        ChoosenExperment = indx;
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
}
