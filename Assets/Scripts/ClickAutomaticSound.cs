using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ClickAutomaticSound : MonoBehaviour
{
    private Slider mySlider;

    void Start()
    {
        mySlider = GetComponent<Slider>();

        if (AudioManager.instance != null)
        {

            mySlider.value = AudioManager.instance.volumeGlobal;


            mySlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    void ChangeVolume(float valor)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ChangeVolume(valor);
        }
    }
}