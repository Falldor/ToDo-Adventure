using System;
using System.Globalization;
using UnityEngine;
using TMPro;

public class GeradorCalendario : MonoBehaviour
{
    private DateTime _dataCalendarioExibido;

    [SerializeField] private Dia[] _dias;

    [SerializeField] private TextMeshProUGUI[] _semanasText;

    [SerializeField] private TextMeshProUGUI _mesAnoTexto;

    [SerializeField] private GameObject _diaSelect;

    private DateTimeFormatInfo _traducao;


    public void Awake()
    {
         _traducao = CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat;
    }

    private void Start()
    {
        InicializaCalendario();
    }

    private void InicializaCalendario()
    {
        //Pega o dia de hoje para inicializar o calendário
        _dataCalendarioExibido = DateTime.Today;

        //Define o idioma em que o calendário será exibido
       

        GerarSemanas();

        SetTextoMesAno();

        GerarDias();
    }

    private void GerarSemanas()
    {
        for (int i = 0; i < _semanasText.Length; i++)
        {
            //Você pode dar cast do tipo de um enum seguindo do número do índice dele para retornar o elemento correspodente
            _semanasText[i].text = _traducao.GetDayName((DayOfWeek)i)[0].ToString().ToUpper();
        }
    }

    private void SetTextoMesAno()
    {
        //Atualiza o texto que mostra o mês e o ano
        _mesAnoTexto.text = string.Format("{0} {1}",_dataCalendarioExibido.Month, _dataCalendarioExibido.Year.ToString());
    }
    private void GerarDias()
    {
        //Pega o primeiro dia do mês
        DateTime primeiroDia = new DateTime(_dataCalendarioExibido.Year, _dataCalendarioExibido.Month, 1);

        //Desativa todos os dias antes de ativar os certos
        ReiniciarDias();

        //DayOfWeek é um enum. Você pode pegar o índice de um enum se você der cast de int nele. Nesse caso os índices vão de domingo a sábado, sendo domingo 0 e sábado 6
        for (int i = (int)primeiroDia.DayOfWeek, dia = 1; dia <= DateTime.DaysInMonth(_dataCalendarioExibido.Year, _dataCalendarioExibido.Month); i++, dia++)
        {
            if (_dataCalendarioExibido.Month == DateTime.Now.Month && _diaSelect == null)
            {
                if (dia == DateTime.Now.Day) { _dias[i].getDate(); }
                else { _dias[i].GetComponent<TextMeshProUGUI>().color = Color.white; }
            }
            //Ativa o dia            
            _dias[i].SetDiaAtivo(true);

            //Define o dia
            _dias[i].AtualizarDiaTexto(dia.ToString());
        }
    }

    public void AlteraMes(int sentido)
    {
        if (_dataCalendarioExibido.AddMonths(sentido).Month >= DateTime.Now.Month)
        {
            _dataCalendarioExibido = _dataCalendarioExibido.AddMonths(sentido);
        }

        if(_diaSelect != null){DeselectDay();}
        GerarDias();
        SetTextoMesAno();
    }

    public void AlteraAno(int sentido)
    {
        //Atualiza o ano de acordo com o sentido
        _dataCalendarioExibido = _dataCalendarioExibido.AddYears(sentido);

        
        if(_diaSelect != null){DeselectDay();}
        GerarDias();
        SetTextoMesAno();
    }

    private void ReiniciarDias()
    {
        //Desativa todos os dias
        for (int i = 0; i < _dias.Length; i++)
        {
            _dias[i].SetDiaAtivo(false);
        }
    }

    public string[] submit()
    {
        string[] data = new string[3]{int.Parse(_diaSelect.GetComponent<TextMeshProUGUI>().text).ToString("00"),
            _mesAnoTexto.text.Split(" ")[0],
            _mesAnoTexto.text.Split(" ")[1]};

        return data;
    }

    public void selectDia(GameObject dia)
    {
        if (_diaSelect == null)
        {
            _diaSelect = dia;
        }
        else
        {
            _diaSelect.GetComponent<TextMeshProUGUI>().color = Color.white;
            _diaSelect = dia;
        }
        _diaSelect.GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void DeselectDay()
    {
        _diaSelect.GetComponent<TextMeshProUGUI>().color = Color.white;
        _diaSelect = null;
    }

    public void SetInformations(DateTime data)
    {

        AlteraMes(data.Month - _dataCalendarioExibido.Month);
        AlteraAno(data.Year - _dataCalendarioExibido.Year);
        foreach (Dia dia in _dias)
        {
            if (dia.GetDiaTexto() == data.Day.ToString("00"))
            {
                dia.getDate();
            }
        }
    }
}