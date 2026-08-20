using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections; // 1. Obrigatório adicionar isto lá em cima para as Coroutines!

public class WarningLight : MonoBehaviour
{
    private Light2D warningLight;
    public float interval = 0.5f;
    public int limit = 5;

    void Start()
    {
        warningLight = GetComponent<Light2D>();
        warningLight.enabled = false;
    }

    public void Light()
    {
        Debug.Log("IM SHINNING!");

        StartCoroutine(Coroutine_shine());
    }

    // A Coroutine mágica que permite pausar o tempo!
    private IEnumerator Coroutine_shine()
    {
        int countingLightTimes = 0;

        while (countingLightTimes < limit)
        {
            warningLight.enabled = true; // Acende
            yield return new WaitForSeconds(interval); // O JOGO CONTINUA, MAS ESTE SCRIPT ESPERA AQUI

            warningLight.enabled = false; // Apaga
            yield return new WaitForSeconds(interval); // ESPERA AQUI NOVAMENTE

            countingLightTimes++; // Completou uma piscadela!
        }
    }
}