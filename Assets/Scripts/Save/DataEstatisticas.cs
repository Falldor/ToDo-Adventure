using System;

[System.Serializable]
public class DataEstatistica : Data
{
    public int qtdTarefasCriadas;
    public int qtdTarefasDeletadas;

    public int qtdTarefasConcluidas;

    public DataEstatistica(int qtdCriadas, int qtdDeletadas, int qtdConcluidas)
    {
        qtdTarefasCriadas = qtdCriadas;
        qtdTarefasDeletadas = qtdDeletadas;
        qtdTarefasConcluidas = qtdDeletadas;
    }
}