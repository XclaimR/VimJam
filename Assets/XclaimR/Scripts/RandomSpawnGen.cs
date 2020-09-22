using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnGen : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> spawnPoints;
    List<int> usedSpawnPoints = new List<int>();
    List<int> usedspawnThis = new List<int>();
    public int sizeOfList;
    public GameObject[] spawnThis;
    public GameObject collectible;

    void Start()
    {
        Invoke("Generate", 0);
    }

    // Update is called once per frame
    void Generate()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnThis = GameObject.FindGameObjectsWithTag("Collectible");
        foreach (GameObject BP in go)
            Addtarget(BP.transform);
        sizeOfList = spawnPoints.Count;
        //Debug.Log("Spawn Location Count : " + sizeOfList);
        Invoke("Spawn", 0);
    }

    public void Addtarget(Transform BP)
    {
        spawnPoints.Add(BP);
        
    }

    void Spawn()
    {
        for (int i = 0; i < spawnThis.Length; i++)
        {
            int randIndex = Random.Range(0, sizeOfList);
            while (usedSpawnPoints.Contains(randIndex))
            {
                randIndex = Random.Range(0, sizeOfList);
            }
            //Debug.Log("Randindex Value : " + randIndex);
            usedSpawnPoints.Add(randIndex);
            Transform sp = spawnPoints[randIndex];
            int st = Random.Range(0, spawnThis.Length);
            while (usedspawnThis.Contains(st))
            {
                st = Random.Range(0, spawnThis.Length);
            }
            usedspawnThis.Add(st);
            Instantiate(spawnThis[st], sp.position, Quaternion.identity);
            //spawnPoints.RemoveAt(randIndex);
            Destroy(spawnThis[st]);

        }
    }
}
