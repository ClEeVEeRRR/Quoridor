using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellMana : MonoBehaviour
{
    public Material [] material;

    Renderer rendR;

gameMana gm;
    private void Start()
    {
        gm = GameObject.Find("Grid").GetComponent<gameMana>();
    }

    void OnMouseEnter()
    {
        rendR = GetComponent<Renderer>();
        rendR.enabled = true;
        rendR.sharedMaterial = material [0];
    }

    void OnMouseExit()
    {
        rendR.sharedMaterial = material [1];
    }

}
