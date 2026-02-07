using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnTime;

    //Enemigos que pueden estar en la pantalla
    [SerializeField] private int _maxEnemies;

    private BoxCollider2D _boxCollider;
    private float _spawnTimer;
    private int _actuallyEnemies = 0;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _spawnTimer = _spawnTime;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;

        //Limitar los enemigos

        Debug.Log($"Enemies: {_actuallyEnemies} / Max: {_maxEnemies} | spawnTimer: {_spawnTimer:F2}");

            if (_spawnTimer <= 0 && _actuallyEnemies < _maxEnemies)
            {
                SpawnEnemy();
                _spawnTimer = _spawnTime;
            }


    }

    private void SpawnEnemy()
    {
        Vector2 randomPosition = GetPosition();
        Instantiate(_enemy, randomPosition, Quaternion.identity);

        //Lanzar mas enemigos
        _actuallyEnemies ++;
    }

    private Vector2 GetPosition()
    {
        Bounds bounds = _boxCollider.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomX, randomY);
    }
}