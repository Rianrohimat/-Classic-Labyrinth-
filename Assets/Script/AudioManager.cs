using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    static AudioSource bgmInstance;
    static AudioSource sfxInstance;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    public bool IsMute { get => bgm.mute; }
    public float BgmVolume { get => bgm.volume; }
    public float SfxVolume { get => sfx.volume; }


    private void Awake()
    {
        if (bgmInstance != null)
        {
            Destroy(bgm.gameObject);
            bgm = bgmInstance;
        }
        else
        {
            bgmInstance = bgm;
            bgm.transform.SetParent(null);
            DontDestroyOnLoad(bgm.gameObject);
        }

        if (sfxInstance != null)
        {
            Destroy(sfx.gameObject);
            sfx = sfxInstance;
        }
        else
        {
            sfxInstance = sfx;
            sfx.transform.SetParent(null);
            DontDestroyOnLoad(sfx.gameObject);
        }
    }
    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgm.isPlaying)
            bgm.Stop();

        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfx.isPlaying)
            sfx.Stop();

        sfx.clip = clip;
        sfx.Play();
    }

    public void SetMute(bool value)
    {
        bgm.mute = value;
        sfx.mute = value;
    }

    public void SetBgmVolume(float value)
    {
        bgm.volume = value;
        PlayerPrefs.SetFloat("bgmVolume", BgmVolume);
    }

    public void SetSfxVolume(float value)
    {
        sfx.volume = value;
        PlayerPrefs.SetFloat("sfxVolume", SfxVolume);

    }

    // public void LoadVolume()
    // {
    //     bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume");
    //     sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    //     StartCoroutine(ConfirmationBox());
    // }

    // public IEnumerator ConfirmationBox()
    // {
    //     confirmationPrompt.SetActive(true);
    //     yield return new WaitForSeconds(2);
    //     confirmationPrompt.SetActive(false);
    // }

}