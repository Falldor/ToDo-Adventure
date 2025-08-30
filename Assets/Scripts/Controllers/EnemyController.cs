using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _posTela;


    void Awake() => instance = this;

    void Start()
    {
        CreateEnemy();
    }

    public void CreateEnemy()
    {
        GameObject inimigo = Instantiate(_enemyPrefab, transform);
        StartCoroutine(inimigo.GetComponent<Enemy>().MoveToPosition(_posTela.position.x));
    }
}
