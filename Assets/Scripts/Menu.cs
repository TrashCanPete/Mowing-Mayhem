﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public DontDestroyOnLoad dontDestroy;
    public GameObject crunchCamera;
    public Canvas renderCanvas;
    public GameObject highScoresGroup;
    public GameObject titleGroup;


    private void Start()
    {
        //dontDestroy = FindObjectOfType<DontDestroyOnLoad>().GetComponent<DontDestroyOnLoad>();
        crunchCamera = GameObject.FindGameObjectWithTag("CrunchCamera");
        renderCanvas = GetComponent<Canvas>();
        StartCoroutine(SwitchScoresGroupOn());
        
    }

    private void Update()
    {
        if (SceneManager.GetSceneByName("Menu Scene").isLoaded && (Input.anyKey))
        {
            LoadScene(1);
        }
    }
    public void LoadScene(int _Level)
    {
        //dontDestroy.setActiveCanvas = false;
        SceneManager.LoadScene(_Level);
        
    }
    public void SelectCharacter()
    {
        if(CharacterSelectCam.characterIndex == 0)
        {
            //default
            Debug.Log("Default");
        }
        if (CharacterSelectCam.characterIndex == 1)
        {
            //punk
            Debug.Log("Punk");
        }
        if (CharacterSelectCam.characterIndex == 2)
        {
            //other
            Debug.Log("Other");
        }
        Invoke("changeGameScene", 2);
    }
    public void changeGameScene()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadMainMenu()
    {
        //dontDestroy.setActiveCanvas = true;
        SceneManager.LoadScene(0);
    }
    public void ExitScene()
    {
        Application.Quit();
    }

    public IEnumerator SwitchScoresGroupOn()
    {
        yield return new WaitForSeconds(5f);
        titleGroup.SetActive(false);
        highScoresGroup.SetActive(true);
        StartCoroutine(SwitchOffScoresGroup());
    }
    
    void SetScoresActive()
    {
        highScoresGroup.SetActive(true);
        StartCoroutine(SwitchOffScoresGroup());
    }

    public IEnumerator SwitchOffScoresGroup()
    {
        yield return new WaitForSeconds(9.5f);
        highScoresGroup.SetActive(false);
        StartCoroutine(SwitchScoresGroupOn());
    }

}
