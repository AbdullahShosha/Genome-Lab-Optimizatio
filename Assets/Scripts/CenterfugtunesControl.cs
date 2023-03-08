using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterfugtunesControl : MonoBehaviour
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

    //public delegate void test();
    private void Start()
    {
        Readypos = transform.position;
    }

    /*private void Update()
    {
        //test a = Update;
        //a();
        
        if (MachineDone)
        {
            gameObject.transform.position = Ready.position;
            MachineDone = false; 
        }
    }*/
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

            if (other.CompareTag("pipepitte"))
                
            {
                if (Pipepitte.InsidePip != "empty")
                {
                    if ((Steps.Step == 1 && Pipepitte.InsidePip == "Blood" && Pipepitte.Size == 200) ||
                        (Steps.Step == 2 && Pipepitte.InsidePip == "KProtein" && Pipepitte.Size == 20) ||
                        (Steps.Step == 3 && Pipepitte.InsidePip == "LysisSolution" && Pipepitte.Size == 400) ||
                        (Pipepitte.InsidePip == "Ithanol" && ((Steps.Step == 6 && Pipepitte.Size == 200) || (Steps.Step == 30 && Pipepitte.Size == 1000))) ||
                        (Steps.Step == 8 && Pipepitte.InsidePip == "WashBuffer1" && Pipepitte.Size == 500) ||
                        (Pipepitte.InsidePip == "ElutionBuffer" && ((Steps.Step == 10 && Pipepitte.Size == 200) || (Steps.Step == 32 && Pipepitte.Size >= 20 && Pipepitte.Size <=25))) ||
                        (Steps.Step == 12 && Pipepitte.InsidePip == "WashBuffer2" && Pipepitte.Size == 500) ||
                        (Steps.Step == 23 && Pipepitte.InsidePip == "Trizol" && Pipepitte.Size == 500) ||
                        (Steps.Step == 24 && Pipepitte.InsidePip == "Chloroform" && Pipepitte.Size == 200) ||
                        (Steps.Step == 28 && Pipepitte.InsidePip == "IsoPropanol" && Pipepitte.Size == 500))
                    {
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
                        Pipepitte.InsidePip = "empty";
                        Pipepitte.Size = 0;
                    }
                    else if(Pipepitte.InsidePip == "RNA" && Steps.Step == 27 && NumberOfElements == 0)
                    {
                        transform.GetChild(indx - 1).gameObject.SetActive(false);
                        transform.GetChild(indx).gameObject.SetActive(true);
                        indx++;
                        Pipepitte.InsidePip = "empty";
                        Pipepitte.Size = 0;
                        Steps.NextStep();
                    }
                    else
                    {
                        machine.ErrorPanelText.text = "Wrong Step";
                        Steps.WrongStepPanel.SetActive(true);
                        helper.sprite = WrongStephelper;
                    }
                    other.transform.position = Pipepitte.Reset;
                }
                else
                {
                    if (Steps.Step == 26)
                    {
                        Pipepitte.InsidePip = "RNA";
                            Pipepitte.Size = 1;
                        transform.GetChild(indx - 1).gameObject.SetActive(false);
                        transform.GetChild(indx).gameObject.SetActive(true);
                        indx++;
                        Steps.NextStep();
                    }
                    else
                    {
                        //machine.ErrorPanelText.text = "Wrong Step";
                        Steps.WrongStepPanel.SetActive(true);
                        helper.sprite = WrongStephelper;
                    }
                    other.transform.position = Pipepitte.Reset;
                }
            }
            else if (other.CompareTag("Votrex"))
            {
                if (Steps.Step == 4 && Votrex.Vortexon)
                    Steps.NextStep();
                else
                    Steps.WrongStepPanel.SetActive(false);

                MachineDone = true;
                gameObject.transform.position = Readypos;
            }
            else if (other.CompareTag("Machine"))
            {
                //if (NumberOfElements > 0)
                //{
                    machine.ResetCameraValues();
                    if (machine.GoToCenter)
                    {
                        if ((machine.WorkingName == "Thermo" && Steps.Step == 5) ||
                        (machine.WorkingName == "Center" &&
                        (Steps.Step == 7 || Steps.Step == 9 || Steps.Step == 11 || Steps.Step == 13 || Steps.Step == 31))||
                        (machine.WorkingName == "Center2" && (Steps.Step == 22 || Steps.Step == 25 || Steps.Step == 29))
                        )
                        {
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

                /*}
                else
                {
                    MachineDone = true;
                    gameObject.transform.position = Ready.position;
                    Steps.WrongStepPanel.SetActive(true);
                    helper.sprite = WrongStephelper;
                    machine.ErrorPanelText.text = "Empty Sample";
                }*/
            }

        }
        else
        {
            if(other.CompareTag("pipepitte"))
                PipepitteAnimator.SetBool("Soaking", true);
            time += Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        time = 0;
    }
}