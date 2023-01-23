using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown graphicsDropdown;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Toggle fullscreenToggle;
    public GameObject checkMark;
    Resolution[] resolutions;


    void Start()
    {


        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currectResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currectResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);

        if (PlayerPrefs.GetInt("resIndex") == null)
        {

            resolutionDropdown.value = currectResolutionIndex;
            resolutionDropdown.RefreshShownValue();

        }

            Debug.Log(PlayerPrefs.GetFloat("vol"));
            Debug.Log(PlayerPrefs.GetFloat("sfx"));

    }
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("quality"));
        if (PlayerPrefs.GetFloat("vol") != null)
        {
            audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("vol"));
            musicSlider.value = PlayerPrefs.GetFloat("vol");
        }
        if (PlayerPrefs.GetFloat("sfx") != null)
        {
            audioMixer.SetFloat("SFX", PlayerPrefs.GetFloat("sfx"));
            sfxSlider.value = PlayerPrefs.GetFloat("sfx");

        }
        if (PlayerPrefs.GetInt("quality") != null)
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
            graphicsDropdown.value = (PlayerPrefs.GetInt("quality"));
            graphicsDropdown.RefreshShownValue();

        }
        if (PlayerPrefs.GetInt("fullscreen") != null)
        {
            Debug.Log(PlayerPrefs.GetInt("fullscreen"));
            int value = PlayerPrefs.GetInt("fullscreen");
            if (value == 1)
            {
                Screen.fullScreen = true;
                fullscreenToggle.isOn = true;
            }
            if (value == 0)
            {
                Screen.fullScreen = false;
                fullscreenToggle.isOn = false;
            }

        }
        if (PlayerPrefs.GetInt("resIndex") != null)
        {
            // Debug.Log(PlayerPrefs.GetInt("resIndex"));
            Resolution resolution = resolutions[PlayerPrefs.GetInt("resIndex")];
            int value = PlayerPrefs.GetInt("fullscreen");
            if (value == 1)
            {
                Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.ExclusiveFullScreen);
            }
            if (value == 0)
            {
                Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.Windowed);
            }
            resolutionDropdown.value = (PlayerPrefs.GetInt("resIndex"));
            resolutionDropdown.RefreshShownValue();
        }



    }

    

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("vol", volume);

    }
    public void SetSfx(float volume)
    {
        audioMixer.SetFloat("SFX", volume);
        PlayerPrefs.SetFloat("sfx", volume);

    }

    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(qualityIndex);
        PlayerPrefs.SetInt("quality", qualityIndex);
        graphicsDropdown.RefreshShownValue();

    }
    public void SetFullScreen(bool isFullscreen)
    {
        Debug.Log(isFullscreen);
        Screen.fullScreen = isFullscreen;

        int a;
        if (isFullscreen) { a = 1; PlayerPrefs.SetInt("fullscreen", a); }
        if (!isFullscreen) { a = 0; PlayerPrefs.SetInt("fullscreen", a); }

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resIndex", resolutionIndex);

    }

} 