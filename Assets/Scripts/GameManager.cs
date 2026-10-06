using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool levelPaused = true;
    private int nivelAtual;
    private LevelManager levelManager;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject definitionsPanel;
    [SerializeField] TMPro.TextMeshProUGUI winTimeText;
    [SerializeField] TMPro.TextMeshProUGUI loseTimeText;
    [SerializeField] TMPro.TextMeshProUGUI carsPassed;



    void Awake()
    {

        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
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
        levelManager = GetComponent<LevelManager>();
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
        AudioManager.instance.PlaySFX(AudioManager.instance.gameOverSound);
        Time.timeScale = 0f;
        loseTimeText.text = "Time: " + levelManager.getFinalTime();
        carsPassed.text = "Cars Passed: " + levelManager.getCarsSucceded();
        gameOverPanel.SetActive(true);
    }

    public void LevelCompleted()
    {
        Debug.Log("LEVEL COMPLETED");
        AudioManager.instance.PlaySFX(AudioManager.instance.winSound);
        Time.timeScale = 0f;
        winPanel.SetActive(true);
        winTimeText.text = "Time: " + levelManager.getFinalTime();
        //SceneManager.LoadScene(nivelAtual + 1);

    }

    public void PauseGame()
    {
        levelPaused = !levelPaused;
        if (levelPaused)
        {
            Time.timeScale = 0f;
            definitionsPanel.SetActive(true);
        }
        else
        {
           Time.timeScale = 1f;
            definitionsPanel.SetActive(false);
        }
        

 
    }

    public void ResumeGame()
    {
        levelPaused = false;
        Time.timeScale = 1f;
        definitionsPanel.SetActive(false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(nivelAtual);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(nivelAtual+1);
    }


}
