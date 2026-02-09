using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnTime;

    //Enemigos que pueden estar en la pantalla
    [SerializeField] private int _maxEnemies;

    private BoxCollider2D _boxCollider;
    private float _spawnTimer;
    private int _actuallyEnemies = 0;

    //Numero de oleadas
    [SerializeField] private int oleadas;
    [SerializeField] private float _tiempoEntreOleadas;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _spawnTimer = _spawnTime;
        StartCoroutine(SendWaves());
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
    }

    private void SpawnEnemy()
    {
            Vector2 randomPosition = GetPosition();
            Instantiate(_enemy, randomPosition, Quaternion.identity);

            //Lanzar mas enemigos
            _actuallyEnemies += 1;
        
    }

    private Vector2 GetPosition()
    {
        Bounds bounds = _boxCollider.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomX, randomY);
    }

    private IEnumerator SendWaves()
    {
        for (int i = 0; i < oleadas; i++)
        {
            Debug.Log($"Oleada {i + 1} - Max Enemigos: {_maxEnemies}");

            _actuallyEnemies = 0;
            _maxEnemies += i;

            while (_actuallyEnemies < _maxEnemies)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(_spawnTime);
            }

            yield return new WaitForSeconds(_tiempoEntreOleadas);
        }

        Debug.Log("Todas las oleadas han terminado");
    }
}