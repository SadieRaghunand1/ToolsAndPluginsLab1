using UnityEngine;

[ExecuteInEditMode]
public class GizmosExample : MonoBehaviour
{

    public int num = 0;
    public int num2 = 0;
    public bool done = false;
    void OnDrawGizmos()
    {

        num2 = 0;
        // Gizmos.color = new Color(1.0f, 1.0f, 1.0f);

        // Convert the local coordinate values into world
        // coordinates for the matrix transformation.
        //Gizmos.matrix = transform.localToWorldMatrix;
        //Gizmos.DrawCube(Vector3.zero, Vector3.one);
        for (int i = 0; i < 64; i++)
        {

            if (num > 8)
            {
                num2++;
                num = 0;
            }


            if (i % 2 == 0)
            {
                Gizmos.color = new Color(1.0f, 1.0f, 1.0f);
            }
            else
            {
                Gizmos.color = new Color(0.0f, 0.0f, 0.0f);
            }

            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(new Vector3(num, num2, 0), Vector3.one);
            num += 1;
            if (i == 63)
                {
                    num = 0;
                    num2 = 0;
                }
            }
        
    }
}