using UnityEngine;

public class AudioController : MonoBehaviour
{
    static AudioController _instance;
    public AudioClip buttonSound;
    AudioSource audioSource;
    PlayerPreferences playPrefs;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public static AudioController instance
    {
        get
        {
            if (_instance == null)
            {
                return FindObjectOfType<AudioController>();
            }
            return _instance;
        }
    }


    public static void PlayButtonSound(AudioSource source)
    {
        source.PlayOneShot(instance.buttonSound);
    }

    public float currentMasterVol
    {
        get { return _currentMasterVol; }
    }
    public float currentMusic
    {
        get { return _currentMusic; }
    }
    float _currentMasterVol;
    float _currentMusic;



    void Start()
    {

        Master.OnUnPause += SaveSoundConfigs;

        playPrefs = GetComponent<PlayerPreferences>();
        _currentMasterVol = playPrefs.SavedMASTERVOL;
        _currentMusic = playPrefs.SavedMUSIC;
        ChangeMasterVolume(currentMasterVol);
        ChangeMusicVolume(currentMusic);
    }

    public void ChangeMusicVolume(float volume)
    {
        _currentMusic = volume;
        audioSource.volume = volume;
    }

    public void ChangeMasterVolume(float volume)
    {
        _currentMasterVol = volume;
        AudioListener.volume = volume;
    }

    public void SaveSoundConfigs()
    {
        playPrefs.saveSoundsConfig(currentMusic, currentMasterVol);
    }
}
