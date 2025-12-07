using UnityEngine;
using System.Collections;

public class DiceController : MonoBehaviour
{
    public DiceData diceData;
    public Rigidbody rb;

    public DiceSide[] sides;

    public int FinalValue { get; private set; }
    public bool HasStopped { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Throw(float force, float torque)
    {
        HasStopped = false;
        FinalValue = 0;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.rotation = Random.rotation;

        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * torque, ForceMode.Impulse);

        StartCoroutine(CheckStopped());
    }

    private IEnumerator CheckStopped()
    {
        yield return new WaitUntil(() => rb.IsSleeping());
        yield return new WaitForSeconds(0.1f);

        FinalValue = DetectTopFace();
        HasStopped = true;

        Debug.Log($"?? Resultado del {diceData.diceName}: {FinalValue}");
    }

    private int DetectTopFace()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 1.0f, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f))
        {
            DiceSide side = hit.collider.GetComponent<DiceSide>();

            if (side != null)
            {
                int result = diceData.faceValues[side.sideIndex];
                return result;
            }
        }

        Debug.LogWarning("? No se detecto ninguna cara superior.");
        return -1;
    }
}
