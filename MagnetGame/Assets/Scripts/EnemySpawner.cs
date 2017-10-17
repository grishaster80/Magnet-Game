using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy;
	public float DelayTime;
	private float StartingDelayTime;
	private float PlatformSize;
	private float PlatformRandomScale;
	public GameObject Coin;
	private float CoinChance;
	private bool SpawningCoin;


	// Use this for initialization
	void Start () {
		DelayTime = Random.Range(0.25f,0.55f);
		Debug.Log (DelayTime);
		CoinChance = 5f;
		SpawningCoin = false;
	}
	
	// Update is called once per frame
	void Update () {
		DelayTime -= Time.deltaTime;
		if (DelayTime <= 0) {
			PlatformRandomScale = Random.Range (0.5f, 1f);
			Enemy.transform.localScale = new Vector3 (PlatformRandomScale, Enemy.transform.localScale.y, Enemy.transform.localScale.z);
			Vector3 EnemyPosition = new Vector3 (Random.Range((-1.8f+PlatformRandomScale/2),(1.8f-PlatformRandomScale/2)), transform.position.y, transform.position.z);
			Instantiate (Enemy, EnemyPosition, transform.rotation);
			DelayTime = Random.Range(0.25f,0.55f);
			if ((int)Random.Range (0, CoinChance) == 1) {
				SpawningCoin = true;
			} else {
				SpawningCoin = false;
			}
			if (SpawningCoin) {
				Vector3 CoinSpawningPosition = new Vector3 (Random.Range (-1.8f + Coin.transform.localScale.x, 1.8f - Coin.transform.localScale.x), transform.position.y + 1f, transform.position.z);
				Instantiate (Coin, CoinSpawningPosition, transform.rotation);
			}
		}
	}
}
