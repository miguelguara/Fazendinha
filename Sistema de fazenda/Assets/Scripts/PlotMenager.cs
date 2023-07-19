using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotMenager : MonoBehaviour
{
    bool IsPlanted = false;
    BoxCollider2D plantCollider;

    public SpriteRenderer Plant;
    SpriteRenderer terra;

    int plantStage = 0;
    float timer;

    PlantaObjeto PSelected;
    FarmMenager fm;

    public Color podeCor = Color.green;
    public Color NaoPodeCor = Color.red;

    void Start()
    {
        Plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<FarmMenager>();
        terra = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlanted)
        {
            timer-= Time.deltaTime;
            if (timer < 0 && plantStage < PSelected.PlantStages.Length -1)
            {
                timer = PSelected.timeBtw;
                plantStage++;
                UpdatePlanta();
            }
        }

    }

    private void OnMouseDown()
    {
        if (IsPlanted && plantStage == PSelected.PlantStages.Length - 1 && !fm.isPlanting)
        {
            Harvest();
        }
        else if (!IsPlanted && fm.isPlanting && fm.PlantaSelecionada.planta.preco <= fm.dinheiro)
        {
            plantar(fm.PlantaSelecionada.planta);
        }
    }
    private void OnMouseOver()
    {
        if (fm.isPlanting)
        {
            if(IsPlanted || fm.PlantaSelecionada.planta.preco > fm.dinheiro)
            {
                terra.color = NaoPodeCor;
            }
            else
            {
                terra.color = podeCor;
            }
        }
    }
    private void OnMouseExit()
    {
        terra.color = Color.white;
    }

    void Harvest()
    {
        IsPlanted = false;
        Plant.gameObject.SetActive(false);
        fm.transacao(PSelected.PrecoVenda);
    }

    void plantar(PlantaObjeto novaPlanta)
    {   
        PSelected = novaPlanta;
        IsPlanted = true;
        plantStage = 0;
        UpdatePlanta();
        fm.transacao(-PSelected.preco);
        timer = PSelected.timeBtw;
        Plant.gameObject.SetActive(true);
    }
    void UpdatePlanta()
    {
        Plant.sprite = PSelected.PlantStages[plantStage];
        plantCollider.size = Plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, Plant.bounds.size.y/2);
    }
}
