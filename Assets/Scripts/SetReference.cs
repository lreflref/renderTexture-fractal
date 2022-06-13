using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Unity.Mathematics.math;
using quaternion = Unity.Mathematics.quaternion;

public class SetReference : MonoBehaviour
{
 
    public GameObject refGroup;

    [HideInInspector]
    public Vector3[] referencePosis;

    [HideInInspector]
    public Vector3[] referenceScales;

    [HideInInspector]
    public quaternion[] referenceRotations;


    public int num;

    public RenderTexture rendTex;

    public float cubeScale;

    // Start is called before the first frame update
    public virtual void SetRef()
    {
        GetNum();
        SetNum();

        GetPosition();
        SetPosition();
        GetRotation();
        SetRotation();
        GetScale();
        SetScale();


        DestroyRef();



    }

    public virtual void GetNum()
    {
        num = refGroup.gameObject.transform.childCount;
    }

    public virtual void SetNum()
    {

        GetComponent<Instancer>().instances = num;
    }

    public virtual void GetPosition()
    {
        referencePosis = new Vector3[num];

        for (int i = 0; i < num; i++)
        {
            referencePosis[i] = refGroup.gameObject.transform.GetChild(i).transform.position;
        }
    }

    public virtual void SetPosition()
    {
        GetComponent<Instancer>().positions = referencePosis;
    }


    public virtual void GetRotation()
    {
        referenceRotations = new quaternion[num];

        for (int i = 0; i < num; i++)
        {
            referenceRotations[i] = refGroup.gameObject.transform.GetChild(i).transform.rotation;
        }
    }

    public virtual void SetRotation()
    {
        GetComponent<Instancer>().rotations = referenceRotations;
    }

    public virtual void GetScale()
    {
        referenceScales = new Vector3[num];

        for (int i = 0; i < num; i++)
        {
            referenceScales[i] = refGroup.gameObject.transform.GetChild(i).transform.localScale * cubeScale;
        }
    }


    public virtual void SetScale()
    {
        GetComponent<Instancer>().scales = referenceScales;
    }


    public virtual void DestroyRef()
    {
        Destroy(refGroup);
    }

}
