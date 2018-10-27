using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTileRandomizer : MonoBehaviour {

    public bool spawnNextTile;
    public int maxTileVisible;
    public PlayerTile[] tilePool; //Tipos de tille
    private int currentTileVisible;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnNextTile)
        {
            if (currentTileVisible < maxTileVisible) //Si hay menos tiles de los necesarios crea otro2
            {
                SpawnTile(); //Crea la instancia del tile
            }
        }
	}

    void SpawnTile()
    {
        PlayerTile tile = tilePool[maxTileVisible];
        PlayerTile instance = Instantiate<PlayerTile>(tile);
        instance.transform.position = transform.position;
        instance.tileTipe = Random.Range(0,4);
    }
}
