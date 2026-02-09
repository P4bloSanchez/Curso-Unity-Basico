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
        Vector2 location = Camera.main.WorldToViewportPoint(transform.position);

        if(location.y > 1 || location.x > 1 ||
            location.y < 0 || location.x < 0){
                Destroy(gameObject);
            }
    }
}
