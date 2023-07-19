using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Noma Plant", menuName = "Planta")]
public class PlantaObjeto : ScriptableObject
{
    public string Nome;
    public Sprite[] PlantStages;
    public float timeBtw;
    public int preco;
    public int PrecoVenda;
    public Sprite icon;
}
