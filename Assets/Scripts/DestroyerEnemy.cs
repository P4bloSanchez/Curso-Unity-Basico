using UnityEngine;

public class DestroyerEnemy : MonoBehaviour
{
    private float marge = 0.3f;

    // Update is called once per frame
    void LateUpdate()
    {
        DestroyTheEnemy();
    }

    private void DestroyTheEnemy(){
        Vector2 posicion = Camera.main.WorldToViewportPoint(transform.position);

        if(posicion.y > 1 + marge || posicion.x > 1 + marge||
            posicion.y < 0 - marge || posicion.x < 0 - marge){
                Destroy(gameObject);
            }
    
    }
}
