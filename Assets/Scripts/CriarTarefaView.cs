using UnityEngine;
using UnityEngine.UIElements;

public class CriarTarefaView : MonoBehaviour
{
    [SerializeField] private GameObject _CriarTarefaPrefab;
    [SerializeField] private Transform _ponto;
    void Start()
    {
        _CriarTarefaPrefab = Instantiate(_CriarTarefaPrefab, transform);
        _CriarTarefaPrefab.SetActive(false);
    }

    public void openView()
    {
        _CriarTarefaPrefab.transform.position = _ponto.position;
        _CriarTarefaPrefab.SetActive(true);
    }
}
