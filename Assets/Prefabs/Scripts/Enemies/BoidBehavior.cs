using System.Collections.Generic;
using UnityEngine;

public class BoidBehavior : MonoBehaviour
{
    private GameObject ground;

    public float separationRadius = 1.0f;
    public float alignmentRadius = 2.0f;
    public float cohesionRadius = 2.0f;
    public float maxSpeed = 2.0f;
    public float randomForceMagnitude = 0.1f;
    public float rotationDamping = 0.3f;
    public float orientationAlteration = 5.0f;

    private void Awake()
    {
        ground = GameObject.FindWithTag("Ground");
    }

    private void Update()
	{
		Vector3 separation = CalculateSeparation();
		Vector3 alignment = CalculateAlignment();
		Vector3 cohesion = CalculateCohesion();

		Vector3 combinedForce = separation + alignment + cohesion;

		// Add a slight random force
		Vector3 randomForce = Random.insideUnitCircle.normalized * randomForceMagnitude;
		combinedForce += randomForce;

		Vector3 clampedForce = Vector3.ClampMagnitude(combinedForce, maxSpeed);

		// Apply rotation damping
		Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, clampedForce.normalized);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationDamping);

		// Slightly alter orientation in the direction of total force
		Quaternion forceRotation = Quaternion.Euler(0, 0, Random.Range(-orientationAlteration, orientationAlteration));
		transform.rotation *= forceRotation;

		transform.position += clampedForce * Time.deltaTime;

        PreventPlayerGoingOffScreen();

    }

    private void LateUpdate()
    {
        PreventPlayerGoingOffScreen();
    }

    private Vector3 CalculateSeparation()
    {
        Vector3 separationForce = Vector3.zero;
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, separationRadius);

        foreach (Collider2D collider in nearbyColliders)
        {
            if (collider.gameObject != gameObject)
            {
                Vector3 separationDirection = transform.position - collider.transform.position;
                float distance = separationDirection.magnitude;

                // Inverse square distance weighting
                float strength = separationRadius / distance;
                separationForce += separationDirection.normalized * strength;
            }
        }

        return separationForce.normalized;
    }

    private Vector3 CalculateAlignment()
    {
        Vector3 alignmentForce = Vector3.zero;
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, alignmentRadius);
        int neighborCount = 0;

        foreach (Collider2D collider in nearbyColliders)
        {
            if (collider.gameObject != gameObject)
            {
                BoidBehavior boid = collider.gameObject.GetComponent<BoidBehavior>();
                if (boid != null)
                {
                    alignmentForce += boid.transform.up;
                    neighborCount++;
                }
            }
        }

        if (neighborCount > 0)
            alignmentForce /= neighborCount;

        return alignmentForce.normalized;
    }

    private Vector3 CalculateCohesion()
    {
        Vector3 cohesionForce = Vector3.zero;
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, cohesionRadius);
        int neighborCount = 0;

        foreach (Collider2D collider in nearbyColliders)
        {
            if (collider.gameObject != gameObject)
            {
                cohesionForce += collider.transform.position;
                neighborCount++;
            }
        }

        if (neighborCount > 0)
        {
            Vector3 targetPosition = cohesionForce / neighborCount;
            cohesionForce = targetPosition - transform.position;
        }

        return cohesionForce.normalized;
    }

    private void PreventPlayerGoingOffScreen()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -25, 25),
                                         Mathf.Clamp(transform.position.y, -15, 15),
                                         transform.position.z);
    }
}
