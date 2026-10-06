using UnityEngine;
using UnityEngine.SceneManagement;
public class MainPage : MonoBehaviour
{
    [SerializeField] GameObject instructionsPanel;
    public static MainPage instance;
    bool instructions_ON = false;
    void Awake()
    {

        instructionsPanel.SetActive(false);
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        instructions_ON = !instructions_ON;
            if (instructions_ON)
        {
            instructionsPanel.SetActive(true);

        }
        else
        {
            instructionsPanel.SetActive(false);

        }
    }




}
