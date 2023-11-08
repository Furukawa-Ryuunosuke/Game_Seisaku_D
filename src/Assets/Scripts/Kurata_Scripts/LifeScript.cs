using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[3];
    private int lifePoint = 3;

    public EnemyLight enemyLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLight.lightEnter)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
        }
    }
}
