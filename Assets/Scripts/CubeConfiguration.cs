﻿using System;
using UnityEngine;

public class CubeConfiguration : MonoBehaviour
{
    public static CubeConfiguration Instance { get; private set; }

    [NonSerialized] public int cubesOnTheMap;

    [NonSerialized] public Color[] colors;

    [SerializeField] private GameObject warmHole = null;
    [SerializeField] private GameObject coldHole = null;

    //for reward
    [NonSerialized] public int warmCubes;
    [NonSerialized] public int coldCubes;

    private void Awake()
    {
        Instance = this;

        colors = ColorExtensions.LoadMassive();
    }

    string[] a = new string[] { "Hole" };

    private void Start()
    {
        //fuck your "Find" 
        GameObject[] warmColorBlocks = GameObject.FindGameObjectsWithTag("WarmColor");
        GameObject[] coldColorBlocks = GameObject.FindGameObjectsWithTag("ColdColor");

        warmCubes = warmColorBlocks.Length;
        coldCubes = coldColorBlocks.Length;

        warmHole.GetComponent<Renderer>().material.color = colors[0];
        coldHole.GetComponent<Renderer>().material.color = colors[1];

       
        foreach (GameObject block in warmColorBlocks)
        {
            if (block.name == "AssDestroyer" ||
                block.name == "HoleOne" ||
                block.name == "HoleTwo") { continue; }

            block.GetComponent<Renderer>().material.color = colors[0];
        }
        foreach (GameObject block in coldColorBlocks)
        {
            if (block.name == "AssDestroyer" ||
                block.name == "HoleOne" ||
                block.name == "HoleTwo") { continue; }

            block.GetComponent<Renderer>().material.color = colors[1];
        }

        cubesOnTheMap += warmColorBlocks.Length;
        cubesOnTheMap += coldColorBlocks.Length;
        cubesOnTheMap -= 4; //Потому что эти теги из за одногодибилка висят по 2 раза на каждой дыре
        //Debug.Log(cubesOnTheMap);
    }
}
