using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantarItem : MonoBehaviour
{
    public PlantaObjeto planta;
    public Text NomeTXT;
    public Text precoTXT;
    public Image icone;
    FarmMenager FM;

    public Image btimagem;
    public Text BtTexto;

    // Start is called before the first frame update
    void Start()
    {
        FM = FindObjectOfType<FarmMenager>();

        NomeTXT.text = planta.Nome;
        precoTXT.text = "$"+ planta.preco;
        icone.sprite = planta.icon;
    }
    public void ComprarPlanta()
    {
        FM.selecionarPlanta(this);
    }

}
