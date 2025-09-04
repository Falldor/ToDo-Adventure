using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textNivel;
    [SerializeField] private TextMeshProUGUI _textDano;
    [SerializeField] private TextMeshProUGUI _textCusto;

    [SerializeField] private Player player;

    void Start()
    {
        _textCusto.text = "por: 10";
        _textDano.text = "1 -> 2";
        player = FindAnyObjectByType<Player>();
    }
    public void levelUp()
    {
        int dinherio = lojaController.Instance.GetDinheiro();
        int custo = int.Parse(_textCusto.text.Split(':')[1]);
        string[] dano = _textDano.text.Split("->");
        float novoDano = float.Parse(dano[1]) * 2;
        if (dinherio >= custo)
        {
            _textNivel.text = "Lv." + (int.Parse(_textNivel.text.Split(".")[1]) + 1);
            _textDano.text = dano[1] + " -> " + novoDano;
            lojaController.Instance.SetDinheiro((dinherio - custo).ToString());
            _textCusto.text = "por: " + custo * 2;
        }

        player.SetDano((int)novoDano);
    }

    public void closeView()
    {
        ViewController.Instance.CloseView();
    }


}
