using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour {

	//public Font uifont;
	public GameObject scoretext;
	public GameObject img;
	public Sprite[] skinbank = new Sprite[7];
	private GameObject[] scores = new GameObject[5];
	private GameObject[] names = new GameObject[5];
	private GameObject[] skins = new GameObject[5];
	public GameObject scorebox;
	// Use this for initialization
	void Start () {
		
		for (int i = scores.Length-1; i >= 0; i--)
		{
			if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HS"+i.ToString())) // score is worthy of a spot
			{
				if (i < scores.Length-1) // not last place, swap required
				{
					int prev = PlayerPrefs.GetInt("HS"+i.ToString());
					string prev_n = PlayerPrefs.GetString("HSs"+i.ToString());
					int prev_s = PlayerPrefs.GetInt("HSc"+i.ToString());
					PlayerPrefs.SetInt("HS"+i.ToString(), PlayerPrefs.GetInt("Score"));
					PlayerPrefs.SetString("HSs"+i.ToString(), PlayerPrefs.GetString("CurrPlayer"));
					PlayerPrefs.SetInt("HSc"+i.ToString(), PlayerPrefs.GetInt("CurrSkin"));
					PlayerPrefs.SetInt("HS"+(i+1).ToString(), prev);
					PlayerPrefs.SetString("HSs"+(i+1).ToString(), prev_n);
					PlayerPrefs.SetInt("HSc"+(i+1).ToString(), prev_s);
				}
				else
				{
					PlayerPrefs.SetInt("HS"+i.ToString(), PlayerPrefs.GetInt("Score"));
					PlayerPrefs.SetString("HSs"+i.ToString(), PlayerPrefs.GetString("CurrPlayer"));
					PlayerPrefs.SetInt("HSc"+i.ToString(), PlayerPrefs.GetInt("CurrSkin"));
				}
			}
		}
		PlayerPrefs.Save();
		// debug : run to clear scores
		/*
		for (int i = 0; i < scores.Length; i++)
		{
			PlayerPrefs.SetInt("HS"+i.ToString(), -1);
			PlayerPrefs.SetString("HSs"+i.ToString(), "");
		  PlayerPrefs.SetInt("HSc"+i.ToString(), 0);
		}
		*/
		
		for (int i = 0; i < scores.Length; i++)
		{
			scores[i] = Instantiate(scoretext, new Vector3(975, 465-(75*i), 0), Quaternion.identity);
			scores[i].transform.SetParent(scorebox.transform, false);
			if (PlayerPrefs.GetInt("HS"+i.ToString()) == -1)
			{
				scores[i].GetComponent<UnityEngine.UI.Text>().text = "";
			}
			else
			{
				scores[i].GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetInt("HS"+i.ToString()).ToString();
			}
		}
		for (int i = 0; i < names.Length; i++)
		{
			names[i] = Instantiate(scoretext, new Vector3(625, 465-(75*i), 0), Quaternion.identity);
			names[i].transform.SetParent(scorebox.transform, false);
			names[i].GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetString("HSs"+i.ToString());
		}
		for (int i = 0; i < skins.Length; i++)
		{
			if (PlayerPrefs.GetInt("HS"+i.ToString()) != -1)
			{
				skins[i] = Instantiate(img, new Vector3(275, 465-(75*i), 0), Quaternion.identity);
				skins[i].transform.SetParent(scorebox.transform, false);
				int skindex = PlayerPrefs.GetInt("HSc"+i.ToString());
				skins[i].GetComponent<UnityEngine.UI.Image>().sprite = skinbank[skindex];
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
