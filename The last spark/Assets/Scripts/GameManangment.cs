﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManangment : MonoBehaviour
{

    public List<GameObject> GameUI;
    public GameObject gameOverUI;
    public GameObject sliderUI;
    public Image sliderFill;
    public GameObject sliderText;

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        SetUI(false);
    }

    private void SetUI(bool state)
    {
        foreach (GameObject go in GameUI)
        {
            go.SetActive(state);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SetUI(false);
            sliderUI.SetActive(true);
            sliderText.SetActive(false);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerable ReloadScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        while (!async.isDone)
        {
            sliderFill.fillAmount = Mathf.Clamp01(async.progress / 0.9f);
            yield return null;
        }
        //yield return new WaitForSeconds(0.2f);
        
    }
}
