using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnGen : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> spawnPoints;
    public int sizeOfList;
    public GameObject[] spawnThis;
    public GameObject collectible;

    void Start()
    {
        Debug.Log("Started");
        Invoke("Generate", 0);
    }

    // Update is called once per frame
    void Generate()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnThis = GameObject.FindGameObjectsWithTag("Collectible");
        foreach (GameObject BP in go)
            Addtarget(BP.transform);
        
    }

    public void Addtarget(Transform BP)
    {
        spawnPoints.Add(BP);
        sizeOfList = spawnPoints.Count;
        Debug.Log("Spawn Location Count : " + sizeOfList);
        Invoke("Spawn", 0);
    }

    void Spawn()
    {
        for (int i = 0; i < spawnThis.Length; i++)
        {
            int randIndex = Random.Range(0, sizeOfList);
            Debug.Log(randIndex);
            Transform sp = spawnPoints[randIndex];
            Instantiate(spawnThis[Random.Range(0,spawnThis.Length)], sp.position, Quaternion.identity);
            spawnPoints.RemoveAt(randIndex);
        }
    }
}
