using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterRefrence;
    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;
    private int randomIndex;
    private int randomSide;

    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        if (monsterRefrence == null || monsterRefrence.Length == 0)
        {
            Debug.LogError("monsterRefrence array is not assigned or empty!");
            yield break;
        }

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterRefrence.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterRefrence[randomIndex]);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
