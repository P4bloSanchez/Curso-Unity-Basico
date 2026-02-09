using System;
using UnityEngine;
using TMPro;

public class ScoreLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text _contador;
    private int _score = 0;

    void Awake(){
        _contador = GetComponent<TMP_Text>();
        _score = 0;
        _contador.text = $"Score:\n{_score:D7}";
    }
/*
    private void OnEnable()
    {
        EnemyHealth.EnemigoMuerto += AddScore;
    }
    */

    public void SetScore(int score){
        this._score = score;
        UpdateScore();
    }

    public void AddScore(int count){
        this._score += count;
        UpdateScore();
    }

    public void MinusScore(int count){
        this._score -= count;
        UpdateScore();
    }

    private void UpdateScore(){
        _contador.text = $"Score:\n{_score:D7}";
    }
}
