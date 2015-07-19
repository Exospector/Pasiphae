using UnityEngine;
using System.Collections;

public class SwitchingEclipse : MonoBehaviour
{
	private SpriteRenderer PrimaryMask;
	private SpriteRenderer SecondaryMask;
	private Sprite[] listmask;
	private bool fading;

	void Awake()
	{
		PrimaryMask = GameObject.FindGameObjectWithTag("PrimaryMask").GetComponent<SpriteRenderer>();
		SecondaryMask = GameObject.FindGameObjectWithTag("SecondaryMask").GetComponent<SpriteRenderer>();

		PrimaryMask.material.color = new Color(1f, 1f, 1f, 0.0f);
		SecondaryMask.material.color = new Color(1f, 1f, 1f, 0.0f);
	}

	void Start()
	{
		listmask = new Sprite[2];

		for(int i = 0; i < listmask.Length; i++)
		{
			listmask[i] = Resources.Load<Sprite>("Texture/Eclipse" + i.ToString());
		}

		PrimaryMask.sprite = listmask[Random.Range(0, listmask.Length)];

		StartCoroutine("FadeIn");
	}

	void Update()
	{

	}

	IEnumerator FadeIn()
	{
		Debug.Log("FadeIn");
		while(PrimaryMask.material.color.a < 0.99f)
		{
			PrimaryMask.material.color = new Color(1f, 1f, 1f, Mathf.Lerp(PrimaryMask.material.color.a, 1, Time.deltaTime));
			yield return new WaitForSeconds(0.05f);
		}

		PrimaryMask.material.color = new Color(1f, 1f, 1f, 1f);

		//if(Random.Range(1, 101) < 51)
		//{
			StartCoroutine("FadeOut");
		//}
		//else
		//{
			//StartCoroutine("FadeExchange");
		//}
		yield break;
	}

	IEnumerator FadeExchange()
	{
		Debug.Log("FadeExchange");
		SecondaryMask = PrimaryMask;
		SecondaryMask.sprite = PrimaryMask.sprite;
		//SecondaryMask.material.color = new Color(1f, 1f, 1f, 1f);

		while(PrimaryMask.sprite.name == SecondaryMask.sprite.name)
		{
			PrimaryMask.sprite = listmask[Random.Range(0, listmask.Length)];
		}
		PrimaryMask.material.color = new Color(1f, 1f, 1f, 0.0f);

		while(SecondaryMask.material.color.a > 0.01f && PrimaryMask.material.color.a < 0.99f)
		{
			PrimaryMask.material.color = new Color(1f, 1f, 1f, Mathf.Lerp(PrimaryMask.material.color.a, 1, Time.deltaTime));
			SecondaryMask.material.color = new Color(1f, 1f, 1f, Mathf.Lerp(SecondaryMask.material.color.a, 0, Time.deltaTime));
			yield return new WaitForSeconds(0.05f);
		}
		
		//if(Random.Range(1, 101) < 51)
		//{
			//StartCoroutine("FadeOut");
		//}
		//else
		//{
			//StartCoroutine("FadeExchange");
		//}
		yield break;
	}

	IEnumerator FadeOut()
	{
		Debug.Log("FadeOut");
		float timer = Random.Range(1.0f, 3.0f);
		yield return new WaitForSeconds(timer);

		while(PrimaryMask.material.color.a > 0.01f)
		{
			PrimaryMask.material.color = new Color(1f, 1f, 1f, Mathf.Lerp(PrimaryMask.material.color.a, 0, Time.deltaTime));
			yield return new WaitForSeconds(0.05f);
		}

		PrimaryMask.material.color = new Color(1f, 1f, 1f, 0f);
		fading = false;

		timer = Random.Range(5.0f, 15.0f);
		yield return new WaitForSeconds(timer);

		StartCoroutine("FadeIn");
		yield break;
	}
}
