﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Singleton
    public static GameManager Instance()
    {
        return FindObjectOfType<GameManager>();
    }
    #endregion

    public enum GameState { NotPlaying, Playing }
    public static GameState gameState = GameState.NotPlaying;

    [SerializeField]
    private float timeTilStart;

    private float score, scoreMultiplier;

    [Header("UI")]
    [SerializeField]
    private TextMesh timer;
    [SerializeField]
    private TextMesh scoreText, speedText;

    private void Start()
    {
        StartCoroutine(InitGame());
    }

    private void Update()
    {
        scoreText.text = "Score: " + (int)score + string.Format(" (x{0:0.00})", scoreMultiplier);
        speedText.text = string.Format("Speed: {0:0.0}%", Time.timeScale * 100);
    }

    private IEnumerator InitGame()
    {
        timer.gameObject.SetActive(false);
        scoreMultiplier = 1;

        yield return new WaitForSeconds(timeTilStart - 3);

        timer.gameObject.SetActive(true);
        timer.text = "3";
        yield return new WaitForSeconds(1);

        timer.text = "2";
        yield return new WaitForSeconds(1);

        timer.text = "1";
        yield return new WaitForSeconds(1);
        
        timer.text = "0";
        gameState = GameState.Playing;
        yield return new WaitForSeconds(1);

        timer.gameObject.SetActive(false);
    }

    public void AddToMultiplier(float toAdd)
    {
        scoreMultiplier += toAdd;
    }

    public void AddPoints(float toAdd)
    {
        score += toAdd;
    }
}
