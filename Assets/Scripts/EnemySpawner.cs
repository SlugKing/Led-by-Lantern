using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public int enemyCount;
	private int maxEnemyCount;
	private int totalEnemyCount;
	public GameObject enemy_1;
	public GameObject enemy_2;
	private IEnumerator spawner;
	public GameObject player;
	public GameObject right_bound;
	public GameObject pgrave;
	
	// Use this for initialization
	void Start () {
		enemyCount = 0;
		totalEnemyCount = 15;
		maxEnemyCount = 7;
		spawner = SpawnChecker();
		StartCoroutine(spawner);
		PlayerPrefs.SetInt("Score", 0);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	IEnumerator SpawnChecker()
	{
		for(;;)
		{
			if (enemyCount < maxEnemyCount && totalEnemyCount > 0)
			{
				float z_shift = (Random.value*9.0f) - 4.5f;
				enemy_1.GetComponent<Enemy_Behavior>().player = player;
				enemy_1.GetComponent<LivingEntity>().es = GetComponent<EnemySpawner>();
				enemy_1.GetComponent<LivingEntity>().pgrave = pgrave;
				enemy_2.GetComponent<Enemy_Behavior>().player = player;
				enemy_2.GetComponent<LivingEntity>().es = GetComponent<EnemySpawner>();
				enemy_2.GetComponent<LivingEntity>().pgrave = pgrave;
				if (right_bound.transform.position.x <= transform.position.x+20.0f)
				{
					float etype = (Random.value*5.0f);
					if (etype < 1.0f)
					{
						Instantiate(enemy_2, new Vector3(transform.position.x-15.0f, 1.2f, 2.5f+z_shift), Quaternion.identity);
					}
					else
					{
						Instantiate(enemy_1,  new Vector3(transform.position.x-15.0f, 1.2f, 2.5f+z_shift), Quaternion.identity);
					}
				}
				else
				{
					float etype = (Random.value*5.0f);
					if (etype < 1.0f)
					{
						Instantiate(enemy_2, new Vector3(transform.position.x+15.0f, 1.2f, 2.5f+z_shift), Quaternion.identity);
					}
					else
					{
						Instantiate(enemy_1,  new Vector3(transform.position.x+15.0f, 1.2f, 2.5f+z_shift), Quaternion.identity);
					}
				}
				enemyCount += 1;
				totalEnemyCount -= 1;
			}
			int secWait = (int)(Random.value*5.0f + 3.0f);
			yield return new WaitForSeconds(secWait);
		}
	}
	
	public bool CanWin()
	{
		if (totalEnemyCount == 0 && enemyCount == 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
