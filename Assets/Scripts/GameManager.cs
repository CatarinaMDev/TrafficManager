using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool levelPaused = true;
    private int nivelAtual;


    void Awake()
    {
        // Regra de segurança: Se já existir um GameManager na cena, destrói o novo para não haver dois "chefes" ao mesmo tempo.
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            // Se não existir, EU assumo o cargo de chefe! (this = este script)
            instance = this;
        }
    }
    void Start()
    {
        nivelAtual = SceneManager.GetActiveScene().buildIndex;
        PauseGame();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();        
         }


    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }

    public void LevelCompleted()
    {
        Debug.Log("LEVEL COMPLETED");
        //PauseGame();
        //SceneManager.LoadScene(nivelAtual + 1);

    }

    void PauseGame()
    {
        levelPaused = !levelPaused;
        if (levelPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
           Time.timeScale = 1f;
        }

 
    }

    void RestartGame()
    {
        SceneManager.LoadScene(nivelAtual);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(nivelAtual);
    }

    void BackToMainMenu()
    {

    }

}
