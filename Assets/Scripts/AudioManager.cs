using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sound Column")]
    [SerializeField] private AudioSource musicSource; 
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Sources")]
    public AudioClip backgroundMusic;
    public AudioClip buttonClickSound;
    public AudioClip winSound;
    public AudioClip gameOverSound;
    public AudioClip crash;
    public AudioClip train_warning;
    public AudioClip honk;
    public AudioClip train_passing;
    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Começa a tocar a música ambiente logo que o jogo arranca
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true; // Garante que a música repete
            musicSource.Play();

        }
    }

    // Função que qualquer outro script ou botão pode chamar para tocar um som
    public void PlaySFX(AudioClip somQueQueroTocar)
    {
        sfxSource.PlayOneShot(somQueQueroTocar);
    }

    public void ChangeVolume(float slideValue)
    {
        AudioListener.volume = slideValue;
    }
}
