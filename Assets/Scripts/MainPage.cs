using UnityEngine;
using UnityEngine.SceneManagement;
public class MainPage : MonoBehaviour
{
    [SerializeField] GameObject instructionsPanel;
    public static MainPage instance;
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
        instructionsPanel.SetActive(true);
    }




}
