using UnityEngine;

public class DestroyerBullet1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Actualización del objeto
    void LateUpdate()
    {
        DestroyTheBullet();
    }

    // Destrucción de la bala
    void DestroyTheBullet(){
        Vector2 posicion = Camera.main.WorldToViewportPoint(transform.position);

        if(posicion.y > 1 || posicion.x > 1 ||
            posicion.y < 0 || posicion.x < 0){
                Destroy(gameObject);
            }
    }
}
