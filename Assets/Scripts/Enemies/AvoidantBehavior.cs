using UnityEngine;

public class AvoidantBehavior : MonoBehaviour
{
    public float avoidDistance = 10.0f; // Distance at which ants start avoiding
    public float maxSpeed = 2.0f;

    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 directionToPlayer = transform.position - player.transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer < avoidDistance)
            {
                Vector3 avoidForce = directionToPlayer.normalized * maxSpeed;
                transform.position += avoidForce * Time.deltaTime;
            }
        }

        PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -25, 25),
                                         Mathf.Clamp(transform.position.y, -15, 15),
                                         transform.position.z);
    }
}
