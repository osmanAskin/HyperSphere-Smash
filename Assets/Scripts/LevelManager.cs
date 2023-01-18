using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI loadingtxt;

    void Start()
    {
        if (PlayerPrefs.HasKey("LevelIndex") == false)
        {
            PlayerPrefs.SetInt("LevelIndex", 1);
        }
        StartCoroutine("LoadingBar");
        LevelContol();
    }

    public void LevelContol()
    {
        int level = PlayerPrefs.GetInt("LevelIndex");
        SceneManager.LoadScene(level);
    }
    public IEnumerator LoadingBar()
    {
        while (true)
        {
            loadingtxt.text = "Loading".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            loadingtxt.text = "Loading.".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            loadingtxt.text = "Loading..".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            loadingtxt.text = "Loading...".ToString();


        }
    }
    
}
