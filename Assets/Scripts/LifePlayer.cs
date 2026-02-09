using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] private float _life;
    [SerializeField] private float _takedDamage;

    [SerializeField] private LifeSlider1 _lifeLine;

    private float _actuallyHealth;

    //Render del jugador
    private SpriteRenderer _spriteRenderer;

    //Invocar tabla de puntaje
    [SerializeField] private ScoreLabel _score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _actuallyHealth = _life;
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _lifeLine.setMaxLife(_life);

        //Modicar la barra de vida al inicio
    }

    // Update is called once per frame
    void Update()
    {   
    }

    //Recibir danio
    public void RecibirDanio(){
        Debug.Log("Haz recibido daño");

        _actuallyHealth -= _takedDamage;
        _lifeLine.setLife(_actuallyHealth);
        _score.MinusScore(10);

        StartCoroutine(DamageFlash());

        if(_actuallyHealth <= 0){
            _actuallyHealth = 0;
            Debug.Log("Haz muerto");

            //LifeSlider.setVida(_saludActual);
            Destroy(gameObject);

            SceneManager.LoadScene("Menu");
        }
    }

    //Cambiar color del jugador cuando recibe daño y algo más
    private IEnumerator DamageFlash()
    {
        Color originalColor = _spriteRenderer.color;
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _spriteRenderer.color = originalColor;
    }
}
