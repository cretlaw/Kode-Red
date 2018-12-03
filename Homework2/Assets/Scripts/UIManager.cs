﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public int NumOfKills = 0;

    private SimpleHealthBar _killsBar;
    private Text _killsTxt;

    private Image _gameOverYWImg;
    private Text _gameOverText;
    private Image _crossHair;
    private FPSInput _fpsInput;
    private PlayerWeaponsController _playerWeaponsController;
    private PlayerController _playerController;
    private SceneController _sceneController;

    private AudioSource[] _allAudioSource;
    private bool _isMusicOn;
    private Button _musicButton;

    // Use this for initialization
    void Start ()
    {

        _isMusicOn = true;
       
        _musicButton = GameObject.Find("musicBtn").GetComponent<Button>();

        _killsBar = GameObject.Find("Kills").GetComponent<SimpleHealthBar>();
        _killsTxt = GameObject.Find("KillsTxt").GetComponent<Text>();
        _killsTxt.text = "Killed " + NumOfKills;
        _gameOverYWImg = GameObject.Find("GameOverYW").GetComponent<Image>();
        _gameOverText = GameObject.Find("YouWon").GetComponent<Text>();
        _crossHair = GameObject.Find("CrossHair").GetComponent<Image>();

        _fpsInput = GameObject.Find("Player").GetComponent<FPSInput>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        _playerWeaponsController = GameObject.Find("Weapons").GetComponent<PlayerWeaponsController>();
        _sceneController = gameObject.GetComponent<SceneController>();


    }

    void Update()
    {
        _allAudioSource = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        _killsBar.UpdateBar(NumOfKills, 15);

        if (NumOfKills >= 15)
        {
            _gameOverYWImg.enabled = true;
            _gameOverText.enabled = true;
            //Prevents the player from moving and shooting only moving camera
            _fpsInput.enabled = false;
            _playerWeaponsController.enabled = false;
            _playerController.StopEnemyShooting();
            _crossHair.enabled = false;

            if (Input.GetKeyDown(KeyCode.R))
                Application.LoadLevel(0);


        }
    }


    public void toggleMusic()
    {
        if (_isMusicOn)
        {
            foreach (var audioSrc in _allAudioSource)
            {
                if(audioSrc != null)
                    audioSrc.enabled = false;
            }
            _musicButton.GetComponent<Image>().color = Color.red;
            _musicButton.GetComponentInChildren<Text>().text = "off";
            _isMusicOn = !_isMusicOn;
        }
        else
        {
            foreach (var audioSrc in _allAudioSource)
            {
                if(audioSrc != null)
                    audioSrc.enabled = true;
            }
            _musicButton.GetComponent<Image>().color = Color.white;
            _musicButton.GetComponentInChildren<Text>().text = "on";
            _isMusicOn = !_isMusicOn;
        }
    }
    public void UpdateKillsBar()
    {
        ++NumOfKills;
        _killsTxt.text = "Killed " + NumOfKills;
    }
}
