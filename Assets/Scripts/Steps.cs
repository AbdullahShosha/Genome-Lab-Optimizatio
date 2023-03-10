using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Steps : MonoBehaviour
{
    public static Text steptext, instructiontext;
    
    public static GameObject WrongStepPanel;
    public GameObject WrongStepPanel1;
    static string[] instructions = new string[40];
    
    public static Transform arrowPossitions;
    public static int Step = 15;
    // Start is called before the first frame update
    void Start()
    {
        instructions[0] = "take 200 Microliters of blood form the buffer";
        instructions[1] = "take 20 Microliters of k.protein from the buffer";
        instructions[2] = "take 400 Microliters from Lysis Solution buffer";
        instructions[3] = "put the sample in the Votrex for 1m";
        instructions[4] = "place the sample in the thermomixer for 10m";
        instructions[5] = "take 200 Microliters of Ithanol 96-100 from the buffer";
        instructions[6] = "place the sample in the centerifuge and set it to 6000 cycles per minute for 1m";
        instructions[7] = "take 500 Microliters from Wash buffer1";
        instructions[8] = "place the sample in the centerifuge and set it to 14000 cycles per minute for 3m";
        instructions[9] = "take 200 Microliters from Elution buffer";
        instructions[10] = "place the sample in the centerifuge and set it to 8000 cycles per minute for 3m";
        instructions[11] = "take 500 Microliters from Wash buffer2";
        instructions[12] = "place the sample in the centerifuge and set it to 14000 cycles per minute for 3m";
        instructions[13] = "put the sample in the freezer at a teperature of 20 degrees";
        
        instructions[14] = "take 1000 Microliters of blood from the buffer to the Falcon Tube";
        instructions[15] = "add 12000 Microliters from Lysis Solution to falcon Tube ";
        instructions[16] = "place the sample in the centerifuge and set it to 3500 cycles per minute for 20m ";
        instructions[17] = "Take the liquid from the tube and leave the ball";
        instructions[18] = "put liquid in the basin";
        instructions[19] = "add 1000 Microliters from Lysis Solution buffer to falcon Tube";
        instructions[20] = "put the ball in a small smple Centerfugtunes";
        instructions[21] = "place the sample in the small centerifuge and set it to 8000 cycles per minute for 2m";
        instructions[22] = "add 500 Microliters from Trizol bottle to the solution ,you can Save the Sample in the freezer at a teperature of -8 degrees and Stop here but We Will Continue";
        instructions[23] = "add 200 Microliters from Chloroform bottle to the solution and leave the solution in room teperature for 2 to 3 minuites";
        instructions[24] = "place the sample in the small centerifuge and set it to 10,000 cycles per minute for 20m at a teperature of 4 degrees";
        instructions[25] = "Take the RNA from the Sample";
        instructions[26] = "Put it in another Small Tube";
        instructions[27] = "add 500 Microliters from IsoPropanol bottle to the solution and leave the solution in room teperature for 10 minuites";
        instructions[28] = "place the sample in the small centerifuge and set it to 12,000 cycles per minute for 10m";
        instructions[29] = "add 1000 Microliters from Ithanol Buffer to the solution";
        instructions[30] = "place the sample in the centerifuge and set it to 7500 cycles per minute for 5m";
        instructions[31] = "take from 20:25 Microliters from Elution buffer";

        steptext = GameObject.FindGameObjectWithTag("Step").GetComponent<Text>();
        instructiontext = GameObject.FindGameObjectWithTag("StepText").GetComponent<Text>();
        WrongStepPanel = WrongStepPanel1;
        if (Step < 15)
        steptext.text = "Step " + (Step).ToString() + " :";
        else
        steptext.text = "Step " + (Step-14).ToString() + " :";
        instructiontext.text = instructions[Step-1];
 
    }


    public static void NextStep()
    {
        if (Step == 14 || Step == 32)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Step++;
        if (Step < 15)
            steptext.text = "Step " + (Step).ToString() + " :";
        else
            steptext.text = "Step " + (Step - 14).ToString() + " :";
        instructiontext.text = instructions[Step-1];
        Debug.Log(Step);
    }
    public void okWrongStep()
    {
        WrongStepPanel.SetActive(false);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
    public void ChangeScene(int indx)
    {
        SceneManager.LoadScene(indx);
    }
}
