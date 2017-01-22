using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public float time = 5f;
    // Use this for initialization
    void Start()
    {

    }

    void OnEnable()
    {
        EventManager.StartListening("PlayerDied", OnPlayerDeath);
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        EventManager.StopListening("PlayerDied", OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
		var image =GetComponent<Image>();
		CommonCoroutines.ImageAlphaToValue(image, time, 1.0f);
		SceneManager.LoadScene(0); 
    }
}
