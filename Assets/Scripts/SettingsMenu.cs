using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;

    [SerializeField]
    private TMP_Dropdown dropdownResolutions;

    private static SettingsMenu instance = null;

    private void Awake()
    {
        ResolutionsList();

        if (instance is null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log(instance);
        }
        else
        {
            Destroy(this);
        }

    }

    private void ResolutionsList()
    {
        resolutions = Screen.resolutions;

        dropdownResolutions.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        dropdownResolutions.AddOptions(options);
        dropdownResolutions.value = currentResolutionIndex;
        dropdownResolutions.RefreshShownValue();
    }

    public void SetResolutions(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
