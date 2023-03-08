using UnityEngine;
using UnityEngine.SceneManagement;

public class UIandSceneManagement : MonoBehaviour
{
    public static void ExitApplication()
    {
        Application.Quit();
    }
    public static void ChangeScene(int indx)
    {
        SceneManager.LoadScene(indx);
    }
}
