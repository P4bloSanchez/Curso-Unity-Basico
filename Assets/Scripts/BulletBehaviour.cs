using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        transform.position += Vector3.up * _bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy") && !_collider.tag.Equals("Enemy"))
        {
            EnemyHealth health = collision.GetComponent<EnemyHealth>();
            if (health != null)
            {
                Debug.Log("Llamando al m�todo");
                health.TakeDamage();
            }

            Destroy(this.gameObject);
        }

        if(collision.tag.Equals("Player") && !_collider.tag.Equals("Player")){
            LifePlayer saludDelJugador = collision.GetComponent<LifePlayer>();

            if (saludDelJugador != null){
                saludDelJugador.RecibirDanio();
            }
        }
    }
}