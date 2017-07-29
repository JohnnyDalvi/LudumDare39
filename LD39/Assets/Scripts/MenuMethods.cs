﻿using UnityEngine;
using UnityEngine.UI;

public class MenuMethods : MonoBehaviour
{
    GUIOverallOptions _guiOverallOptions;
    public GameObject optionsWindow;
    public Slider volumeSlider;
    public Slider musicSlider;
    AudioSource source;
    int Timer;
    void Adressingvalue()
    {
        volumeSlider.value = AudioController.instance.currentMasterVol;
        musicSlider.value = AudioController.instance.currentMusic;
    }

    void Update()
    {
        Timer += 1;
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
        Adressingvalue();
    }

    public void StartGame()
    {
        LevelManager.instance.LoadLevel("Game");
    }

    public void QuitApplication()
    {
        LevelManager.instance.QuitRequest();
    }

    public void PlayButtonSound()
    {
        AudioController.PlayButtonSound(source);
    }

    public void RestartLevel()
    {
        LevelManager.instance.ReloadLevel();
    }

    public void changeVolumes()
    {
        if (Timer >= 10)
        {
            AudioController.instance.ChangeMusicVolume(musicSlider.value);
            AudioController.instance.ChangeMasterVolume(volumeSlider.value);
        }
        else
        {
            Adressingvalue();
        }
    }

    public void BackToMenu()
    {
        LevelManager.instance.LoadLevel("Start");
    }

    public void OpenOptions()
    {
        if (!Master.isPaused)
            Master.PauseGame();
        else
            Master.UnPauseGame();
        Timer = 0;
        optionsWindow.SetActive(!optionsWindow.activeInHierarchy);
        AudioController.instance.SaveSoundConfigs();
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
