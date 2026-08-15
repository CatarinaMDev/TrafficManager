using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool levelPaused;
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
        levelPaused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            LevelCompleted();
        }
    }

    void GameOver()
    {

    }

    void LevelCompleted()
    {
        SceneManager.LoadScene(nivelAtual + 1);
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

    }

    void RestartLevel()
    {

    }

    void BackToMainMenu()
    {

    }

}
