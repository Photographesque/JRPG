using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool start = false;
    public float duration;
    public float Puissance;
    public Camera CameraToShake;

    void Update()
    {
        if (start)
        {
            start = false;
            // StopAllCoroutine();
            StartCoroutine(Shaking(duration, Puissance));
        }
    }

    public IEnumerator Shaking(float TimeToShake, float Puissance)
    {

        Vector3 startPosition = CameraToShake.transform.position; // Ca creer un nv vecteur avec les vecteur de la camera
        float elapsedTime = 0f;

        while (elapsedTime < TimeToShake)
        {
            elapsedTime += Time.deltaTime;

            float randomX = Random.Range(-Puissance, Puissance);
            float randomY = Random.Range(-Puissance, Puissance);

            // Vecteur de la camera = au vecteur creer(qui a les meme CO que la camera) + les parametres.
            CameraToShake.transform.position = startPosition + new Vector3(randomX, randomY, 0);

            yield return null;
        }

        // A la fin de la duration
        CameraToShake.transform.position = startPosition;
    }
}