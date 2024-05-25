using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisableObjects : MonoBehaviour
{
    public GameObject IndicationArrow;
    public GameObject Background;
    public GameObject Title;
    public Button StartGame;


    public void StartTheGame()
    {
        Background.SetActive(false);
        Title.SetActive(false);
        StartGame.gameObject.SetActive(false);
        StartCoroutine(EnableDisableSequence());
    }

    IEnumerator EnableDisableSequence()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 4; i++)
        {
            // Enable IndicationArrow for 1 second
            IndicationArrow.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            // Disable IndicationArrow for 1 second
            IndicationArrow.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        
    }
}