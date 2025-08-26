using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class lojaController : MonoBehaviour
{
    public static lojaController Instance;
    [SerializeField] private TextMeshProUGUI _textGold;
    [SerializeField] private GameObject _lojaViewPrefab;
    [SerializeField] private GameObject ponto;

    void Awake() => Instance = this;
    void Start()
    {
        _textGold.text = "Gold: 3";
        _lojaViewPrefab = Instantiate(_lojaViewPrefab, transform);
        _lojaViewPrefab.SetActive(false);
    }

    public void openView()
    {
        _lojaViewPrefab.transform.position = ponto.transform.position;
        _lojaViewPrefab.gameObject.SetActive(true);
    }

    void OnApplicationQuit()
    {
        _lojaViewPrefab = _lojaViewPrefab.gameObject;
    }

    public int GetDinheiro()
    {
        return int.Parse(_textGold.text.Split(":")[1]);
    }

    public void SetDinheiro(string valor)
    {
        _textGold.text = "Gold: " + valor;
    }

    public void AddDinheiro(int valor)
    {
        _textGold.text = "Gold: " + (int.Parse(_textGold.text.Split(":")[1]) + valor); 
    }

}
