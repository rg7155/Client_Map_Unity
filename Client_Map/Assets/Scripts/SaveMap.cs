using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveMap : MonoBehaviour
{
    //private StreamWriter TransStreamWriter = null;
    private StreamWriter TransStreamWriter = null;
    private BinaryWriter binaryWriter = null;

    void WriteVector(Vector3 v)
    {
        TransStreamWriter.Write(v.x + " " + v.y + " " + v.z + " ");
    }

    //�ٷ����� �� 1���� �ε��ϱ� ����
    void Start()
    {
        //StreamWriter NameStreamWriter = new StreamWriter("Assets/Data/MapObjName.txt");
        TransStreamWriter = new StreamWriter("Assets/Data/MapTransform.txt");

        Transform[] allChildren = GetComponentsInChildren<Transform>();

        TransStreamWriter.Write(allChildren.Length);
        TransStreamWriter.WriteLine(" ");

        foreach (Transform child in allChildren)
        {
            // �ڱ� �ڽ��� ��쿣 ���� 
            // (���ӿ�����Ʈ���� �� �ٸ��ٰ� �������� �� ���ϴ� �ڵ�)
            if (child.name != transform.name)
            {
                //Debug.Log(child.name);
                Debug.Log(string.Format(child.name + ": {0}, {1}, {2}", child.localEulerAngles.x, child.localEulerAngles.y, child.localEulerAngles.z));

                //NameStreamWriter.WriteLine(child.name);

                //ũ �� ��
                TransStreamWriter.Write(child.name + " ");
                WriteVector(child.localScale);
                WriteVector(child.localEulerAngles); // WriteVector(current.localRotation);
                WriteVector(child.position);
                TransStreamWriter.WriteLine(" ");

            }

        }

        TransStreamWriter.Flush();
        TransStreamWriter.Close();

       //NameStreamWriter.Flush();
        //NameStreamWriter.Close();

        print("Model Text Write Completed");
    }


    void Update()
    {
        
    }
}
