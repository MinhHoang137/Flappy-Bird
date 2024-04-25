using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public float spawnRate = 1f;
    private float currentCD = 0;
    public float decreaseRate;
    private float height = -1.5f;
    
    private void Spawn()
    {
        //Debug.Log("Spawn");
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(-height, height);
    }
    private void Update()
    {
        if (currentCD > 0)
        {
            currentCD -= Time.deltaTime;
            if (currentCD < 0) { currentCD = 0; }
        }
        if (currentCD == 0) {
            Spawn();
            currentCD = spawnRate;
        }
        spawnRate *= Mathf.Exp(-decreaseRate * Time.deltaTime);
    }
}
