using System;
using TMPro;
using UnityEngine;

public class notificacao : MonoBehaviour
{
    [SerializeField] private GameObject objetoPai;
    [SerializeField] private TMP_InputField _diasInput;
    [SerializeField] private TMP_InputField _horasInput;
    [SerializeField] private TMP_InputField _minutosInput;


    void Start()
    {
        objetoPai.SetActive(false);
        _diasInput.text = "00";
        _horasInput.text = "00";
        _minutosInput.text = "00";
    }

    void OnDisable()
    {
        _diasInput.text = "00";
        _horasInput.text = "00";
        _minutosInput.text = "00";
    }

    public void AltDias(int valor)
    {
        if (int.Parse(_diasInput.text) < 31 && valor > 0)
        {
            _diasInput.text = (int.Parse(_diasInput.text) + 1).ToString("00");
        }
        else if (int.Parse(_diasInput.text) > 0 && valor < 0)
        {
            _diasInput.text = (int.Parse(_diasInput.text) - 1).ToString("00");
        }
    }
    public void AltHoras(int valor)
    {
        if (int.Parse(_horasInput.text) < 24 && valor > 0)
        {
            _horasInput.text = (int.Parse(_horasInput.text) + 1).ToString("00");
        }
        else if (int.Parse(_horasInput.text) > 0 && valor < 0)
        {
            _horasInput.text = (int.Parse(_horasInput.text) - 1).ToString("00");
        }
    }

    public void AltMinutos(int valor)
    {
        if (int.Parse(_minutosInput.text) < 60 && valor > 0)
        {
            _minutosInput.text = (int.Parse(_minutosInput.text) + 1).ToString("00");
        }
        else if (int.Parse(_minutosInput.text) > 0 && valor < 0)
        {
            _minutosInput.text = (int.Parse(_minutosInput.text) - 1).ToString("00");
        }
    }

    public int[] submit()
    {
        int[] horario = new int[3] { int.Parse(_diasInput.text), int.Parse(_horasInput.text), int.Parse(_minutosInput.text) };
        return horario;
    }

    public void SetInformations(int[] horario)
    {
        _diasInput.text = horario[0].ToString("00");
        _horasInput.text = horario[1].ToString("00");
        _minutosInput.text = horario[2].ToString("00");
    }
}
