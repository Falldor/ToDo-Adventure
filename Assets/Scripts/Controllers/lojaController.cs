using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class lojaController : MonoBehaviour
{
    public static lojaController Instance;
    [SerializeField] private TextMeshProUGUI _textGold;

    void Awake() => Instance = this;
    void Start()
    {
        if (PlayerPrefs.HasKey("Gold"))
        {
          // _textGold.text = $"Gold: {PlayerPrefs.GetInt("Gold")}";
        }
        else { _textGold.text = "Gold: 0"; }

    }

    public void openView(Button button)
    {
        ViewController.Instance.OpenView(nomesPrefabs.ViewLoja, button);
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
        if (GetDinheiro() + valor >= 0)
        {
            _textGold.text = "Gold: " + (int.Parse(_textGold.text.Split(":")[1]) + valor);
        }
        
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Gold", GetDinheiro());
    }

}
