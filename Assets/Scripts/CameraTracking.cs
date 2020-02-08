using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour {

	public GameObject player;
	//private bool shiftView;
	private Vector3 newCamPos;
	//private float camOvershoot;
	public GameObject hp_chunk;
	public Canvas canvas;
	private GameObject hp_bar;
	public GameObject fade_img;
	public UnityEngine.UI.Text score_display;
	
	// Use this for initialization
	void Start () {
		hp_bar = Instantiate(hp_chunk, new Vector3(64f, 250f, 0), Quaternion.identity);
		hp_bar.transform.SetParent(canvas.transform, false);
		fade_img.transform.SetAsLastSibling();
		RectTransform hp_rect = hp_bar.GetComponent<UnityEngine.UI.Image>().rectTransform;
		hp_rect.sizeDelta = new Vector2((80.0f/5.0f)*player.GetComponent<LivingEntity>().hurtbox.hp, hp_rect.sizeDelta.y);
		/*for (int i = 0; i < player.GetComponent<LivingEntity>().hurtbox.hp / 5; i++)
		{
			GameObject chunk = Instantiate(hp_chunk, new Vector3( -(player.GetComponent<LivingEntity>().hurtbox.hp*2f) +(i*20f), 250f, 0), Quaternion.identity);
			chunk.transform.SetParent(canvas.transform, false);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		score_display.text = PlayerPrefs.GetInt("Score").ToString() + " Pts";
		//if (Mathf.Abs(player.transform.position.x-transform.position.x) > 5.0f)
		//{
		//	if (player.transform.position.x-transform.position.x > 0)
		//	{
		//		camOvershoot = 5.0f;
		//	}
		//	else
		//	{
		//		camOvershoot = -5.0f;
		//	}
		//	newCamPos = transform.position + new Vector3((player.transform.position.x-transform.position.x), 0, 0);
		//	shiftView = true;
		//}
		newCamPos = transform.position + new Vector3((player.transform.position.x-transform.position.x), 0, 0);
		//shiftView = true;
		//if (shiftView)
		//{
		transform.position += (newCamPos-transform.position)*Time.deltaTime*1.5f;
		//}
		//if (transform.position == newCamPos)
		//{
		//	shiftView = false;
		//}
		RectTransform hp_rect = hp_bar.GetComponent<UnityEngine.UI.Image>().rectTransform;
		hp_rect.sizeDelta = new Vector2((80.0f/5.0f)*player.GetComponent<LivingEntity>().hurtbox.hp, hp_rect.sizeDelta.y);
	}
}
