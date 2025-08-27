using System;
using TMPro;
using UnityEngine;

public class GeradorHorario : MonoBehaviour
{
    [SerializeField] private TMP_InputField _horasInput;
    [SerializeField] private TMP_InputField _minutosInput;

    void OnEnable()
    {
         _horasInput.text = (DateTime.Now.Hour + 1).ToString("00");
        _minutosInput.text = (DateTime.Now.Minute + 1).ToString("00");
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
            if (int.Parse(_minutosInput.text) + 1 == 60)
            {
                _minutosInput.text = "00";
                AltHoras(1);
            }
            else { _minutosInput.text = (int.Parse(_minutosInput.text) + 1).ToString("00"); }
        }
        else if (int.Parse(_minutosInput.text) > 0 && valor < 0)
        {
            if (int.Parse(_minutosInput.text) - 1 <=  0 && int.Parse(_horasInput.text) > 0)
            {
                _minutosInput.text = "59";
                AltHoras(-1);
            }
            else { _minutosInput.text = (int.Parse(_minutosInput.text) - 1).ToString("00"); }

        }
    }

    public int[] submit()
    {
        int[] horario = new int[2] { int.Parse(_horasInput.text), int.Parse(_minutosInput.text) };
        return horario;
    }

    public void SetInformations(DateTime horario)
    {
        _horasInput.text = horario.Hour.ToString("00");
        _minutosInput.text = horario.Minute.ToString("00");
    }
}
