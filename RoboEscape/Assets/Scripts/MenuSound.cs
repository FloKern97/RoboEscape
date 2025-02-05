using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Class for controlling the sound of the menu.
///
/// @author Florian Kern (cgt104661)
/// </summary>
public class MenuSound : MonoBehaviour
{
    /** Audiomixer for the music */
    [SerializeField] private AudioMixer audioMixerMusic;
    
    /** Audiomixer for the special effects */
    [SerializeField] private AudioMixer audioMixerSFX;
    
    /** Slider for changing the volume of the music */
    [SerializeField] private Slider audioSliderMusic;
    
    /** Text that indicates the current volume of the music corresponding to the slider of the music volume */
    [SerializeField] private TMP_Text audioTextMusic;
    
    /** Slider for changing the volume of the SFX */
    [SerializeField] private Slider audioSliderSFX;
    
    /** Text that indicates the current volume of the SFX corresponding to the slider of the SFX */
    [SerializeField] private TMP_Text audioTextSFX;
    
    
    
    /// <summary>
    /// Method is called before the first frame update.
    ///
    /// Sets the slider values for the music and SFX and sets the volume of the music.
    /// </summary>
    void Start()
    {
        // using the values of the PlayerPrefs to set the value for the slider of the music or setting default value
        audioSliderMusic.SetValueWithoutNotify(PlayerPrefs.GetFloat("masterVolume", 0.3f));
        audioTextMusic.text = (audioSliderMusic.value * 100.0f).ToString("0") + "%";
        
        // using the values of the PlayerPrefs to set the value of the slider for the SFX or setting default value
        audioSliderSFX.SetValueWithoutNotify(PlayerPrefs.GetFloat("masterSFX", 0.3f));
        audioTextSFX.text = (audioSliderSFX.value * 100.0f).ToString("0") + "%";
        audioMixerMusic.SetFloat("volume", Mathf.Log10(PlayerPrefs.GetFloat("masterVolume", 0.3f)) * 20);

    }
    
    
    /// <summary>
    /// Gets called when the slider value for the volume of the music gets changed.
    /// Sets the volume for the music.
    /// </summary>
    /// <param name="volume"> The volume for the music. </param>
    public void SetMusicVolume(float volume)
    {
        audioTextMusic.text = (volume * 100.0f).ToString("0") + "%";
        
        // Audiomixer volume changes logarithmically, slider values change linearly
        audioMixerMusic.SetFloat("volume",Mathf.Log10(volume) * 20);
        
        // Setting the playerprefs with the chosen volume
        PlayerPrefs.SetFloat("masterVolume", volume);
        // Saving playerprefs
        PlayerPrefs.Save();
    }
    
    
    
    /// <summary>
    /// Gets called when the slider value for the volume of the special effects gets changed.
    /// Sets the volume for the special effects.
    /// </summary>
    /// <param name="volume"> The volume for the special effects. </param>
    public void SetSFXVolume(float volume)
    {
        audioTextSFX.text = (volume * 100.0f).ToString("0") + "%";
        
        // Audiomixer volume changes logarithmically, slider values change linearly
        audioMixerSFX.SetFloat("volume", Mathf.Log10(volume) * 20);
        
        // Setting the player prefs for the special effects with the chosen volume
        PlayerPrefs.SetFloat("masterSFX", volume);
        // Saving playerprefs
        PlayerPrefs.Save();
    }

}
