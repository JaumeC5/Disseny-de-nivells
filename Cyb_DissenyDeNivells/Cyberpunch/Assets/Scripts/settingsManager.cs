using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class settingsManager : MonoBehaviour
{

    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Slider musicVolumeSlider;

    public AudioSource musicSource;
    public Resolution[] resolutions;
    private gameSettings gameSettings;

    void Awake() {

		musicSource.volume = PlayerPrefs.GetFloat ("music");
		musicVolumeSlider.value = musicSource.volume;

    }

    void OnEnable()
    {
        gameSettings = new gameSettings();
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        //applyButton.onClick.AddListener(delegate{ OnApplyButtonClick(); });

        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions) {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));

        }
        //LoadSettings();
    }

    public void OnFullscreenToggle() {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    public void OnResolutionChange() {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }

    public void OnTextureQualityChange() {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;


    }

    public void OnMusicVolumeChange() {
        musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
		PlayerPrefs.SetFloat ("music", musicSource.volume);
    }

}
