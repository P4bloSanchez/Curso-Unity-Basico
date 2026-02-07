using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    /*Quería usar este codigo en base al border manager pero creo que no me funciono tan bien*/ 
    
    private Vector2 _bordes;

    private float _bulletWidth;
    private float _bulletHeight;
    private Collider2D _colisionador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 screenValues = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        _bordes = Camera.main.ScreenToWorldPoint(screenValues);

        _colisionador = GetComponent<Collider2D>();
        _bulletWidth = _colisionador.bounds.extents.x;
        _bulletHeight = _colisionador.bounds.extents.y;
    }

    //La bala va desaparecer
    void LateUpdate()
    {
        /*
        Vector2 posicion = Camera.main.WorldToViewportPoint(transform.position);

        if(posicion.y > 1 || posicion.x > 1 ||
            posicion.y < 0 || posicion.x < 0){
                Destroy(gameObject);
            }
        */

        Vector3 posicion = transform.position;

        if ( posicion.x > _bordes.x || posicion.x < - _bordes.x || 
        posicion.y > _bordes.y || posicion.y < -_bordes.y ){
            Destroy(gameObject);
        }
    }
}
