using System.Collections;
using UnityEngine;

public class FadeOutUI : MonoBehaviour
{
	CanvasGroup cg;
	[Header("Delay before fade starts")]
	[SerializeField]
	float fadeDelay = 3f;

	[Header("Delay before fade starts")]
	[SerializeField]
	float fadeDuration = 5f;

	void Start()
	{
		cg = GetComponent<CanvasGroup>();
		StartCoroutine(DelayFade());
	}

	IEnumerator DelayFade()
	{
		yield return new WaitForSecondsRealtime(fadeDelay);
		StartCoroutine(fadeOut());
	}

	IEnumerator fadeOut()
	{
		cg.alpha = 1f;
		float now = Time.time;
		while ((Time.time - now) < fadeDuration)
		{
			cg.alpha = Mathf.Lerp(1, 0, (Time.time - now) / fadeDuration);
			yield return null;
		}
		cg.alpha = 0f;
	}
}


