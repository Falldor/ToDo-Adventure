using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dia : MonoBehaviour
{
    private TextMeshProUGUI _diaTexto;

    private void Awake()
    {
        _diaTexto = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetDiaAtivo(bool ativo)
    {
        _diaTexto.gameObject.SetActive(ativo);
    }

    public string GetDiaTexto()
    {
        return int.Parse(_diaTexto.text).ToString("00");
    }

    public void AtualizarDiaTexto(string dia)
    {
        _diaTexto.text = dia;
    }

    public void getDate()
    {
        transform.GetComponentInParent<GeradorCalendario>().selectDia(gameObject);
    }

    public string submit()
    {
        return _diaTexto.text;
    }
}