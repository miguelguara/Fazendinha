using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmMenager : MonoBehaviour
{

    public PlantarItem PlantaSelecionada;
    public bool isPlanting = false;
    public int dinheiro = 100;
    public Text dinheiroTXT;
    public Color buyColor = Color.green;
    public Color blockColor = Color.red;
    void Start()
    {
        dinheiroTXT.text = "$ "+ dinheiro;
    }

    public void selecionarPlanta(PlantarItem novaPlanta)
    {
        if(PlantaSelecionada == novaPlanta)
        {
            PlantaSelecionada.btimagem.color = buyColor;
            PlantaSelecionada.BtTexto.text = "comprar";
            PlantaSelecionada = null;
            isPlanting= false;
        }
        else
        {
            if(PlantaSelecionada!=null)
            {
                PlantaSelecionada.btimagem.color = buyColor;
                PlantaSelecionada.BtTexto.text = "comprar";
            }
            PlantaSelecionada = novaPlanta;
            PlantaSelecionada.btimagem.color = blockColor;
            PlantaSelecionada.BtTexto.text = "cancelar";
            isPlanting = true;
        }
    }
    public void transacao(int valor)
    {
        dinheiro += valor;
        dinheiroTXT.text = "$"+dinheiro;
    }
}
