using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TubeController : Interactable
{
    public IDictionary<string, int> Inside = new Dictionary<string, int>();
    public int NumberOfElements = 0;
    public static int indx = 1;
    public Sprite NextStepHelper, WrongStephelper;
    public Image helper;
    public bool MachineDone;
    public float time = 0;
    public Text Ttext;
    public Vector3 Readypos;
    PipepitteController Pipepitte;
    Animator PipepitteAnimator;
    Machine machine;

    
    void Start()
    {
        Readypos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (MachineDone)
        {
            gameObject.transform.position = Readypos;
            MachineDone = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pipepitte"))
        {
            Pipepitte = other.GetComponent<PipepitteController>();
            PipepitteAnimator = other.transform.GetChild(0).GetComponent<Animator>();
        }
        if (other.CompareTag("Machine"))
            machine = other.GetComponent<Machine>();
    }
    private void OnTriggerStay(Collider other)
    {
        Ttext.text = ((int)time).ToString();
        if (time >= 2.0f)
        {
            if (other.CompareTag("pipepitte") &&
                Pipepitte.InsidePip != "empty")
            {
                if ((Steps.Step == 15 && Pipepitte.InsidePip == "Blood" && Pipepitte.Size == 1000) ||
                    (Pipepitte.InsidePip == "LysisSolution" && ((Steps.Step == 16 && Pipepitte.Size == 12000))||(Steps.Step == 20 && Pipepitte.Size == 1000)) ||
                    (Steps.Step == 3  && Pipepitte.InsidePip == "ElutionBuffer" && Pipepitte.Size == 20))
                {
                    transform.GetChild(indx).gameObject.SetActive(true);
                    if(indx >0)
                    transform.GetChild(indx-1).gameObject.SetActive(false);
                    indx++;
                    if (Inside.ContainsKey(Pipepitte.InsidePip))
                        Inside[Pipepitte.InsidePip] += Pipepitte.Size;
                    else
                    {
                        Inside.Add(Pipepitte.InsidePip, Pipepitte.Size);

                        NumberOfElements++;
                    }
                    PipepitteAnimator.SetBool("Soaking", false);
                    helper.sprite = NextStepHelper;
                    Steps.NextStep();
                    other.transform.position = Pipepitte.Reset;
                }
                Pipepitte.InsidePip = "empty";
                Pipepitte.Size = 0;
            }
            else if (other.CompareTag("Machine"))
            {
                if (NumberOfElements > 0)
                {
                    machine.ResetCameraValues();
                    if (machine.GoToCenter)
                    {
                        if ((machine.WorkingName == "Center2" && Steps.Step == 17) ||
                        (machine.WorkingName == "Center" &&
                        (Steps.Step == 17 || Steps.Step == 9 || Steps.Step == 11 || Steps.Step == 13)))
                        {
                            if (Steps.Step == 17)
                            {
                                transform.GetChild(indx).gameObject.SetActive(true);
                                if (indx > 0)
                                    transform.GetChild(indx - 1).gameObject.SetActive(false);
                                indx++;
                            }
                            Machine.CameraAnimator.SetBool(machine.WorkingName, true);
                            machine.GoToCenter = false;
                        }
                        else
                        {
                            machine.ErrorPanelText.text = "Wrong Step";
                            Steps.WrongStepPanel.SetActive(true);
                            helper.sprite = WrongStephelper;
                            MachineDone = true;
                            gameObject.transform.position = Readypos;
                        }
                    }

                }
                else
                {
                    MachineDone = true;
                    gameObject.transform.position = Readypos;
                    Steps.WrongStepPanel.SetActive(true);
                    helper.sprite = WrongStephelper;
                    machine.ErrorPanelText.text = "Empty Sample";
                }
            }
            else if (other.CompareTag("Centerfugtunes") && Steps.Step == 21)
            {
                transform.GetChild(TubeController.indx-1).gameObject.SetActive(false);
                other.transform.GetChild(CenterfugtunesControl.indx).gameObject.SetActive(true);
                CenterfugtunesControl.indx++;
                MachineDone = true;
                Steps.NextStep();
            }

        }


        else
        {
            if (other.CompareTag("pipepitte"))
                PipepitteAnimator.SetBool("Soaking", true);
            time += Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        time = 0;
        
    }
}
