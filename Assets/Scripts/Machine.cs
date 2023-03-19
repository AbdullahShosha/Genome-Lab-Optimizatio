using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Machine : Interactable
{
    public Sprite NextStepHelper, WrongStephelper;
    public Image helper;
    public bool GoToCenter;
    public string WorkingName, WorkingViewName;
    public Text MachineScreenTime, TriggerStayTime ,ErrorPanelText ,tempandcycle;
    public Animator Work;
    public static Animator CameraAnimator;
    CenterfugtunesControl Centerfugtunes;
    TubeController tube;
    string CurrentInteracted;

    private void Start()
    {
        CameraAnimator = GameObject.Find("mainCamera").GetComponent<Animator>();
        Interaction_Time = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        DragStep.Interactable_Status[ID] = true;
        GoToCenter = true;
        if (other.GetComponent<CenterfugtunesControl>())
        {
            Centerfugtunes = other.GetComponent<CenterfugtunesControl>();
            CurrentInteracted = "Centerfugtunes";
        }

        else if (other.GetComponent<TubeController>())
        { 
            tube = other.GetComponent<TubeController>();
            CurrentInteracted = "tube";
        }
    }

    //Camera Animation
    public void ResetCameraValues()
    {
        CameraAnimator.SetBool(WorkingName, false);
        CameraAnimator.SetBool(WorkingViewName, false);
        CameraAnimator.SetBool("Base", false);
    }


    public void Startcorontine()
    {
        ResetCameraValues();
        CameraAnimator.SetBool(WorkingViewName, true);
        TurnOn();
        StartCoroutine(SatrtWorking());

    }


    public IEnumerator SatrtWorking()
    {
        gameObject.GetComponent<AudioSource>().Play();
        while (ChangeValue.Timer > 0)
        {
            yield return new WaitForSeconds(2);
            ChangeValue.Timer--;
            MachineScreenTime.text = ChangeValue.Timer.ToString();
        }
        gameObject.GetComponent<AudioSource>().Stop();
        ResetCameraValues();
        CameraAnimator.SetBool("Base", true);
        ChangeValue.Temp = 0;
        ChangeValue.Speed = 0;
        if (CurrentInteracted == "Centerfugtunes")
        { 
            Centerfugtunes.gameObject.transform.position = Centerfugtunes.Readypos;
            if(Steps.Step == 21 || Steps.Step == 26)
            Centerfugtunes.gameObject.transform.GetChild(CenterfugtunesControl.indx- 1).gameObject.SetActive(false);
            Centerfugtunes.gameObject.transform.GetChild(CenterfugtunesControl.indx).gameObject.SetActive(true);
            CenterfugtunesControl.indx++;
        }
        else if (CurrentInteracted == "tube")
            tube.gameObject.transform.position = tube.Readypos;

        TurnOff();
        helper.sprite = NextStepHelper;
        Steps.NextStep();
        
    }


    public void TurnOff()
    {
        Work.SetBool("IsWorking", false);

    }
    public void TurnOn()
    {
        Work.SetBool("IsWorking", true);
    }
    private void OnTriggerExit(Collider other)
    {
        DragStep.Interactable_Status[ID] = false;
        Interaction_Time = 0;
    }
    public override void Interact()
    {
        Debug.Log(Name);
    }
}
