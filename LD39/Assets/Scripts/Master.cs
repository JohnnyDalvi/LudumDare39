﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{
    #region EventInitializers

    public delegate void SceneLoaded();

    public static event SceneLoaded OnSceneLoaded;

    public delegate void Pause();

    public static event Pause OnPause;

    public delegate void Win();

    public static event Win OnWin;

    public delegate void Lose();

    public static event Lose OnLose;

    public delegate void UnPause();

    public static event UnPause OnUnPause;

    public delegate void Reset();

    public static event Reset OnReset;

    public delegate void HourChange(float hour, float insulation);

    public static event HourChange OnHourChange;

    #endregion


    static bool printEvents
    {
        get { return instance._printEvents; }
    }
    public bool _printEvents;

    public static float time
    {
        get { return Time.time; }
    }
    public static Master instance;
    public static bool isPaused
    {
        get
        {
            if (Time.timeScale == 0) return true;
            return false;
        }
    }

    void Awake()
    {
        SceneManager.sceneLoaded += loadScene;
        instance = this;
    }

    void loadScene(Scene scene, LoadSceneMode mode)
    {
        if (OnSceneLoaded != null)
            OnSceneLoaded();
        if (isPaused)
            UnPauseGame();
#if UNITY_EDITOR
        if (printEvents)
            print("OnSceneLoaded() Event on " + time.ToString("0.0s"));
#endif
    }

    public static void ChangeCurrentHour(float newHour, float insulation)
    {
        if (OnHourChange != null)
            OnHourChange(newHour, insulation);

#if UNITY_EDITOR
        if (printEvents)
            print(string.Format("OnHourChange({0}, {1}) Event on {2}", newHour, insulation, time.ToString("0.0s")));
#endif
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;

        if (OnPause != null)
            OnPause();
#if UNITY_EDITOR
        if (printEvents)
            print("OnPause() Event on " + time.ToString("0.0s"));
#endif
    }

    public static void UnPauseGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.01f;

        if (OnUnPause != null)
            OnUnPause();
#if UNITY_EDITOR
        if (printEvents)
            print("OnUnPause() Event on " + time.ToString("0.0s"));
#endif
    }

    public static void ResetGame()
    {
        if (isPaused)
            UnPauseGame();
        if (OnReset != null)
            OnReset();
#if UNITY_EDITOR
        if (printEvents)
            print("OnReset() Event on " + time.ToString("0.0s"));
#endif
    }

    public static void WinGame()
    {
        if (OnWin != null)
            OnWin();
#if UNITY_EDITOR
        if (printEvents)
            print("OnWin() Event on " + time.ToString("0.0s"));
#endif
    }

    public static void LoseGame()
    {
        if (OnLose != null)
            OnLose();
#if UNITY_EDITOR
        if (printEvents)
            print("OnLose() Event on " + time.ToString("0.0s"));
#endif
    }
}
