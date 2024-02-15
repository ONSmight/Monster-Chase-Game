using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] monsters;
    [SerializeField]
    Transform leftpos, rightpos;
    int randomIndex, randomSide;
    GameObject spawenedMonster;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsters.Length);
            randomSide = Random.Range(0, 2);
            spawenedMonster = Instantiate(monsters[randomIndex]);
            //left
            if (randomSide == 0)
            {
                spawenedMonster.transform.position = leftpos.position;
                spawenedMonster.GetComponent<Monster>().speed = Random.Range(5, 8);
            }
            //right
            else
            {
                spawenedMonster.transform.position = rightpos.position;
                spawenedMonster.transform.localScale = new Vector3(-1, 1, 1);
                spawenedMonster.GetComponent<Monster>().speed = -Random.Range(5, 8);

            }
        }
       
    }
}
