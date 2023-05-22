using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainController : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] Toggle muteToggle;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TMP_Text bgmVolText;
    [SerializeField] TMP_Text sfxVolText;
    // [SerializeField] private GameObject confirmationPrompt = null;

    private void OnEnable()
    {
        muteToggle.isOn = audioManager.IsMute;
        bgmSlider.value = audioManager.BgmVolume;
        sfxSlider.value = audioManager.SfxVolume;
        SetBgmVolText(bgmSlider.value);
        SetSfxVolText(bgmSlider.value);
    }

    public void SetBgmVolText(float bgmVolume)
    {
        bgmVolText.text = Mathf.RoundToInt(bgmVolume * 100).ToString();
    }
    public void SetSfxVolText(float sfxVolume)
    {
        sfxVolText.text = Mathf.RoundToInt(sfxVolume * 100).ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
