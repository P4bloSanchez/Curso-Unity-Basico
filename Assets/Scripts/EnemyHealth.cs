using System.Collections;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _bulletDamage;
    private float _currentHealth;

    private SpriteRenderer _spriteRenderer;

    public ScoreLabel score;

    //Crear evento
    //public static event Action<int> EnemigoMuerto;

    void Awake(){
        InstanceScorePanel();
    }

    private void Start()
    {
        _currentHealth = _health;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        Debug.Log("Hacer da�o");

        _currentHealth -= _bulletDamage;

        StartCoroutine(DamageFlash());

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);

            //Destruido el objeto, sumarle puntos al jugador
        /*
            if(EnemigoMuerto != null){
                EnemigoMuerto.Invoke(100);
            }
        */

            if(score != null){
                score.AddScore(100);
            }
        }
    }

    private IEnumerator DamageFlash()
    {
        Color originalColor = _spriteRenderer.color;
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _spriteRenderer.color = originalColor;
    }

    //Buscar el panel de la puntuación para instanciarlo
    private void InstanceScorePanel(){
        score = FindFirstObjectByType<ScoreLabel>();
    }
}
