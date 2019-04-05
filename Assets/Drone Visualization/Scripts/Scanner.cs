using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

/**
 * Periodically attempts to "scan" the environment. Scanning consists of:
 *     1. Raycasting outward and checking if a collider is hit
 *     2. If so, creating a particle at the voxelized position
 */
public class Scanner : MonoBehaviour
{
    public float scanTime;
    public float scanRange;
    public float voxelSize;
    public VisualEffect scanLineVFX;

    private float queuedTime;

    private void Start() {
        scanLineVFX.gameObject.SetActive(true);
    }

    private void Update() {
        queuedTime += Time.deltaTime;
        while (queuedTime > 0) {
            Scan();
            queuedTime -= scanTime;
        }
    }

    private void Scan() {
        Ray ray = new Ray(transform.position, SampleDirection());
        if (Physics.Raycast(ray, out RaycastHit hit, scanRange)) {
            Vector3 voxel = Voxelize(hit.point);
            CreateScanVFX(Voxelize(hit.point));
        }
    }

    private Vector3 Voxelize(Vector3 position) {
        position.x = position.x - position.x % voxelSize;
        position.y = position.y - position.y % voxelSize;
        position.z = position.z - position.z % voxelSize;
        return position;
    }

    private void CreateScanVFX(Vector3 targetPosition) {
        /* The event payload is a little weird. You can only set the value of
         * a couple built-in attributes (position and targetPosition are defaults). */
        VFXEventAttribute payload = scanLineVFX.CreateVFXEventAttribute();
        payload.SetVector3("position", transform.position);
        payload.SetVector3("targetPosition", targetPosition);
        scanLineVFX.SendEvent("SpawnScanLine", payload);
    }

    private Vector3 SampleDirection() {
        Vector3 dir = Random.insideUnitSphere.normalized;
        // Samples directly behind the drone are redirected forward
        if (dir.z < -0.5f) {
            dir.z *= -1;
        }
        return transform.TransformDirection(dir);
    }
}
