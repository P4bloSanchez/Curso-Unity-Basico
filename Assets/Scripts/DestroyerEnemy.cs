using UnityEngine;

public class DestroyerEnemy : MonoBehaviour
{
    private Vector2 _bordes;

    private float _enemytWidth;
    private float _enemyHeight;
    private Collider2D _colisionador;

    private float margen = 0.3f;

    // Update is called once per frame
    void Update()
    {
        Vector2 posicion = Camera.main.WorldToViewportPoint(transform.position);

        if(posicion.y > 1 + margen || posicion.x > 1 + margen||
            posicion.y < 0 - margen || posicion.x < 0 - margen){
                Destroy(gameObject);
            }
    }
}
