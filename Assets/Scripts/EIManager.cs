using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class EIManager : MonoBehaviour
{
    //has
    //get : bir veriyi getirir
    //set : bir veriyi yerle?tirir
    public Image whiteeffectimage;
    private int effectcontrol = 0;
    private bool radialshine;

    public Image FillRateImage;
    public GameObject Player;
    public GameObject FinishLine;

    public Animator LayoutAnimator;
    public TextMeshProUGUI coin_text;

    //Butonlar
    public GameObject settings_open;
    public GameObject settings_close;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibration_On;
    public GameObject vibration_Off;
    public GameObject iap;
    public GameObject information;
    public GameObject Layout_Background;

    public GameObject intro_Hand;
    public GameObject toptopmove_Text;
    public GameObject noAds;
    public GameObject shop_Button; 

    public GameObject RestartScreen;

    //Oyun Sonu
    public GameObject finishScreen;
    public GameObject blackBackGround;
    public GameObject complate;
    public GameObject radial_shine;
    public GameObject coin;
    public GameObject rewarded;
    public GameObject nothanks;

    public GameObject achievedCoin;
    public GameObject nextLevel;
    public TextMeshProUGUI achievedText;


    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if(PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);

        }
        CoinTextUpdate();
    }

    public void Update()
    {
        if (radialshine == true)
        {
            radial_shine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 30f * Time.deltaTime));
        }

        FillRateImage.fillAmount = (Player.transform.position.z*100) / (FinishLine.transform.position.z)/100;
    }


    public void FirstTouch()
    {
        intro_Hand.SetActive(false);
        noAds.SetActive(false);
        shop_Button.SetActive(false);
        noAds.SetActive(false);
        settings_open.SetActive(false);
        settings_close.SetActive(false);
        sound_On.SetActive(false);
        sound_Off.SetActive(false);
        vibration_On.SetActive(false);
        vibration_Off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
        Layout_Background.SetActive(false);

    }

    public void CoinTextUpdate()
    {
        coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }

    public void RestartButtonActive()
    {
        RestartScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        Variables.firsttouch = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void NextScene()
    {
        Time.timeScale = 1f;
        Variables.firsttouch = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.4f;
        radialshine = true;
        finishScreen.SetActive(true);
        blackBackGround.SetActive(true);
        yield return new WaitForSecondsRealtime(0.6f);
        complate.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        radial_shine.SetActive(true);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(0.4f);
        rewarded.SetActive(true);
        yield return new WaitForSecondsRealtime(0.4f);
        nothanks.SetActive(true);

    }

    public IEnumerator AfterRewardButton()
    {
        achievedCoin.SetActive(true);
        achievedText.gameObject.SetActive(true);
        rewarded.SetActive(false);
        nothanks.SetActive(false);
        for (int i = 0; i < 401; i += 4)
        {
            achievedText.text = "+" + i.ToString();
            yield return new WaitForSecondsRealtime(0.0001f);
        }
        yield return new WaitForSecondsRealtime(1f);
        nextLevel.SetActive(true);

       
        


    }

    public void Privacy_Policy()
    {
        Application.OpenURL("https://www.tosugames.com/privacy-policy/"); 
        
    }

    public void TermOfUse()
    {
        Application.OpenURL("https://www.tosugames.com/sample-page/");
    }

    //Buton fonksiyonlari


    public void Settings_Open()
    {
        settings_open.SetActive(false);
        settings_close.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_in");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_On.SetActive(true);
            sound_Off.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }
        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibration_On.SetActive(true);
            vibration_Off.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibration_On.SetActive(false);
            vibration_Off.SetActive(true);
        }
    }

    public void Settings_Close()
    {
        settings_open.SetActive(true);
        settings_close.SetActive(false);
        LayoutAnimator.SetTrigger("Slide_out");
        AudioListener.volume = 1;
    }

    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound",2);
    }

    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_On()
    {
        vibration_On.SetActive(false);
        vibration_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }    
    
     public void Vibration_Off()
    {
        vibration_On.SetActive(true);
        vibration_Off.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }

    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.005f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b , 1))
            {
                effectcontrol = 1;
            }
        }

        while (effectcontrol == 1)
        {
            yield return new WaitForSeconds(0.005f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
            {
                effectcontrol = 2;
            }
        }

        if(effectcontrol == 2)
        {
            Debug.Log("tamamd?r");
        }
        
    }
}
