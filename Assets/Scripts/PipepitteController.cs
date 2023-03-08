using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PipepitteController : MonoBehaviour
{
    public int Size = 0 ;
    public string InsidePip;
    public Sprite NextStepHelper, WrongStephelper,putSample;
    public Image helper;
    public GameObject Panel;
    public InputField Field;
    public Text Ttext;
    public float time = 0;
    public Vector3 Reset;
    private bufferControl Currentbuffer;

    private void Start()
    {
        Reset = gameObject.transform.position;
        InsidePip  = "empty";
    }

    public void ONPanel()
    {
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Soaking", true);
        Size = 0;
        Panel.SetActive(true);
    }
    public void Set()
    {
        Size = int.Parse(Field.text);
        Field.Select();
        Field.text = "";
        Panel.SetActive(false);
        transform.position = Reset;
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Soaking", false);
        Steps.instructiontext.text = "add it to the sample";
        helper.sprite = putSample;
    }

    private void OnTriggerStay(Collider other)
    {

        Ttext.text = ((int)time).ToString();
        if (time >= 2.0f)
        {
            if ( other.CompareTag("Buffer"))
            {
                Currentbuffer = other.gameObject.GetComponent<bufferControl>();
                if (Currentbuffer.IsOpen)
                {
                    if (((((Steps.Step == 1) || (Steps.Step == 15)) && Currentbuffer.Name == "Blood") ||
                        (Steps.Step == 2 && Currentbuffer.Name == "KProtein") ||
                        ((Steps.Step == 3 || Steps.Step == 16 || Steps.Step == 20) && Currentbuffer.Name == "LysisSolution") ||
                        ((Steps.Step == 6 || Steps.Step == 30) && Currentbuffer.Name == "Ithanol") ||
                        (Steps.Step == 8 && Currentbuffer.Name == "WashBuffer1") ||
                        ((Steps.Step == 10 || Steps.Step == 32) && Currentbuffer.Name == "ElutionBuffer") ||
                        (Steps.Step == 12 && Currentbuffer.Name == "WashBuffer2")||
                        (Steps.Step == 23 && Currentbuffer.Name == "Trizol") ||
                        (Steps.Step == 24 && Currentbuffer.Name == "Chloroform") ||
                        (Steps.Step == 28 && Currentbuffer.Name == "IsoPropanol")))
                    {
                        InsidePip = Currentbuffer.Name;

                        if (Size == 0)
                            ONPanel();
                    }
                    else
                    {
                        Steps.WrongStepPanel.SetActive(true);
                        helper.sprite = WrongStephelper;
                        transform.position = Reset;
                    }
                }
                else
                {
                    Steps.WrongStepPanel.SetActive(true);
                    helper.sprite = WrongStephelper;
                    transform.position = Reset;
                }
            }
            else if (other.CompareTag("Tube")  && ((Steps.Step == 15 && InsidePip == "Blood" && Size == 1) ||
                    (Steps.Step == 16 && InsidePip == "LysisSolution" && Size == 12) || Steps.Step == 18))
            {
                gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Soaking", true);
                other.transform.GetChild(TubeController.indx).gameObject.SetActive(true);
                if (TubeController.indx > 0)
                    other.transform.GetChild(TubeController.indx - 1).gameObject.SetActive(false);
                TubeController.indx++;
                transform.position = Reset;
                Steps.NextStep();
                InsidePip = "empty";
                Size = 0;
            }
            else if (other.CompareTag("Basin") && Steps.Step == 19)
            {
                gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Soaking", true);
                transform.position = Reset;
                Steps.NextStep();
            }

        }
        else
            time += Time.deltaTime;

    }
    private void OnTriggerExit(Collider other)
    {
        time = 0;
        
    }
}
