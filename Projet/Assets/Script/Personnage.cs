using UnityEngine;
using System.Collections;
namespace AssemblyCSharp
{
	public class Personnage : MonoBehaviour
	{
		public static bool pnjcollide = false;
		private Animator anim;
		private int vie;
		private int SM;

		void Start ()
		{
			anim = GetComponent<Animator> ();
			vie = 100;
			SM = 100;
		}

		void LateUpdate ()
		{
			Deplacement ();
		}

		void Deplacement()
		{
			float vitesse = 0;
			int direction = 0;
			float fatigue = anim.GetFloat ("Fatigue");
			int tempdir = anim.GetInteger ("Direction");
			fatigue += 1;

			if(!anim.GetCurrentAnimatorStateInfo (0).IsName("Fatigue"))
			{
				if (Input.GetKey (KeyCode.Q))
				{
					if (Input.GetKey (KeyCode.LeftShift))
					{
						anim.SetBool("Course", true);
						fatigue -= 2;
						if (anim.GetFloat ("Fatigue") > 0)
						{
							vitesse -= 0.1f;
						}
					}
					else
					{
						anim.SetBool ("Course", false);
					}
					vitesse = anim.GetFloat ("Vitesse") - 0.01f;
					direction = 1;
					this.transform.localEulerAngles = new Vector3 (0, 180, 0);
				}
				else if(Input.GetKey (KeyCode.D))
				{
					if(Input.GetKey (KeyCode.LeftShift))
					{
						anim.SetBool ("Course", true);
						fatigue -= 2;

						if(anim.GetFloat ("Fatigue") > 0)
						{
							vitesse += 0.1f;
						}
					}
					else
					{
						anim.SetBool ("Course", false);
					}
					this.transform.localEulerAngles = new Vector3 (0, 0, 0);
					direction = 2;
					vitesse = anim.GetFloat ("Vitesse") + 0.01f;
				}
				anim.SetInteger ("Direction", direction);

				if(!anim.GetBool ("Course"))
				{
					if(vitesse > 0.3f)
					{
						vitesse = 0.3f;
					}
					else if(vitesse < -0.3f)
					{
						vitesse = -0.3f;
					}
				}
				else
				{
					if(vitesse > 0.4f)
					{
						vitesse = 0.4f;
					}
					else if(vitesse < -0.4f)
					{
						vitesse = -0.4f;
					}
				}
				if(Input.GetKey (KeyCode.C))
				{
					anim.SetBool ("Silencieux", true);
					if(vitesse > 0.2f)
					{
						vitesse = 0.2f;
					}
					else if(vitesse < -0.2f) 
					{
						vitesse = -0.2f;
					}
				}
				else
				{
					anim.SetBool ("Silencieux", false);
				}
				anim.SetFloat ("Vitesse", vitesse);

				this.transform.position = new Vector2 (transform.position.x + vitesse, transform.position.y);
				if(!anim.GetBool ("Saut") && !anim.GetBool ("Chute"))
				{
					if(Input.GetKey (KeyCode.Space))
					{
						StartCoroutine ("saut");
						fatigue -= 20;
					}
				}
				if(fatigue > 100)
				{
					fatigue = 100;
				}

				if(Input.GetMouseButton(0))
				{
					anim.SetBool("Charge", true);

					if(vitesse < 2.0f && vitesse > 0)
						vitesse = vitesse + 0.1f;
					else if(vitesse > -2.0f && vitesse < 0)
						vitesse = vitesse - 0.1f;

					fatigue -= 4;

					anim.SetFloat ("Vitesse", vitesse);
				}
				else
				{
					anim.SetBool("Charge", false);
				}
			}

			anim.SetFloat ("Fatigue", fatigue);

			if (Input.GetKey (KeyCode.E) && pnjcollide)
			{
				anim.SetBool ("Dialogue", true);

			}

			if(!pnjcollide)
			{
				anim.SetBool("Dialogue",false);
				if(GameObject.Find("Dialog(Clone)")!=null)
				{
					GameObject.Destroy(GameObject.Find("Dialog(Clone)"));
				}
			}

		}
		IEnumerator saut()
		{
			float fatActuelle = anim.GetFloat ("Fatigue");
			anim.SetBool ("Saut", true);
			anim.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 50), ForceMode2D.Impulse);
			yield return new WaitForSeconds (1.0f);
			anim.SetFloat ("Fatigue", fatActuelle);
			anim.SetBool("Chute",true);
			anim.SetBool("Saut",false);
		}
		void OnTriggerEnter2D(Collider2D coll)
		{
			if (coll.gameObject.tag =="Pnj")
			{
				pnjcollide=true;
			}

			anim.SetBool ("Saut", false);
			anim.SetBool ("Chute", false);
		}

		void OnTriggerExit2D(Collider2D coll)
		{
			if (coll.gameObject.tag == "Pnj")
			{
				pnjcollide=false;
				OpenDialogue.enter=false;
			}
			if (!anim.GetBool ("Saut"))
			{
				anim.SetBool("Chute",true);
			}
		}
	}
}
