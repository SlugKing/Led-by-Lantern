using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour {

	public int dir;
	public GameObject other_arrow;
	public int skindex = 0;
	public Material player_mat;
	public Material player_hud_mat;
	public Texture green, blue, red, yellow, white, brown, purple;
	// Use this for initialization
	void Start () {
		player_mat.SetTexture("_MainTex", green);
		player_hud_mat.SetTexture("_EmissionMap", green);
		player_hud_mat.SetTexture("_MainTex", green);
		PlayerPrefs.SetInt("CurrSkin", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Change()
	{
		if (dir == -1)
		{
			skindex -= 1;
			other_arrow.GetComponent<ChangeSkin>().skindex -= 1;
		}
		else
		{
			skindex += 1;
			other_arrow.GetComponent<ChangeSkin>().skindex += 1;
		}
		
		if (skindex % 7 == 0 || (skindex < 0 && 7-Mathf.Abs(skindex % 7) == 0))
		{
			player_mat.SetTexture("_MainTex", green);
			player_hud_mat.SetTexture("_EmissionMap", green);
			player_hud_mat.SetTexture("_MainTex", green);
			PlayerPrefs.SetInt("CurrSkin", 0);
		}
		else if (skindex % 7 == 1 || (skindex < 0 && 7-Mathf.Abs(skindex % 7) == 1))
		{
			player_mat.SetTexture("_MainTex", blue);
			player_hud_mat.SetTexture("_EmissionMap", blue);
			player_hud_mat.SetTexture("_MainTex", blue);
			PlayerPrefs.SetInt("CurrSkin", 1);
		}
		else if (skindex % 7 == 2 || (skindex < 0 && 7-Mathf.Abs(skindex % 7) == 2))
		{
			player_mat.SetTexture("_MainTex", red);
			player_hud_mat.SetTexture("_EmissionMap", red);
			player_hud_mat.SetTexture("_MainTex", red);
			PlayerPrefs.SetInt("CurrSkin", 2);
		}
		else if (skindex % 7 == 3 || (skindex < 0 && 7-Mathf.Abs(skindex % 7) == 3))
		{
			player_mat.SetTexture("_MainTex", yellow);
			player_hud_mat.SetTexture("_EmissionMap", yellow);
			player_hud_mat.SetTexture("_MainTex", yellow);
			PlayerPrefs.SetInt("CurrSkin", 3);
		}
		else if (skindex % 7 == 4 || (skindex < 0 && 7-Mathf.Abs(skindex % 7) == 4))
		{
			player_mat.SetTexture("_MainTex", white);
			player_hud_mat.SetTexture("_EmissionMap", white);
			player_hud_mat.SetTexture("_MainTex", white);
			PlayerPrefs.SetInt("CurrSkin", 4);
		}
		else if (skindex % 7 == 5 || (skindex < 0 && 7-Mathf.Abs(skindex % 7) == 5))
		{
			player_mat.SetTexture("_MainTex", brown);
			player_hud_mat.SetTexture("_EmissionMap", brown);
			player_hud_mat.SetTexture("_MainTex", brown);
			PlayerPrefs.SetInt("CurrSkin", 5);
		}
		else if (skindex % 7 == 6 || (skindex < 0 && 7-Mathf.Abs(skindex % 7) == 6))
		{
			player_mat.SetTexture("_MainTex", purple);
			player_hud_mat.SetTexture("_EmissionMap", purple);
			player_hud_mat.SetTexture("_MainTex", purple);
			PlayerPrefs.SetInt("CurrSkin", 6);
		}
	}
}
