using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] private float _vida;
    [SerializeField] private float _danioRecibido;

    private float _saludActual;

    public SliderLive barraDeVida;

    //Render del jugador
    private SpriteRenderer _spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _saludActual = _vida;
        _spriteRenderer = GetComponent<SpriteRenderer>();

        //Barra de Vida
        barraDeVida.setMaxSalud(_vida);
        barraDeVida.setSalud(_vida);
    }

    // Update is called once per frame
    void Update()
    {   
    }

    //Recibir danio
    public void RecibirDanio(){
        Debug.Log("Haz recibido daño");

        _saludActual -= _danioRecibido;
        barraDeVida.setSalud(_saludActual);
        StartCoroutine(DamageFlash());

        if(_saludActual <= 0){
            _saludActual = 0;
            Debug.Log("Haz muerto");

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
