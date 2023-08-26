using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    private GameObject player;
    private float time;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        
        Destroy(this.gameObject, 5.0f);

    }

    private void Update()
    {
        MoveProjectile();

        time += Time.deltaTime;

        if (time > 4)
        {
            StartCoroutine(scaleOverTime(this.transform, new Vector3(0, 0, 90), 1f));
        }
    }

    private void MoveProjectile()
    {

        if (SceneManager.GetActiveScene().name == "Level_3")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.05f);
        }
        else
        {
            transform.position += -transform.right * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    bool isScaling = false;

    IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }

        isScaling = false;
    }
}
