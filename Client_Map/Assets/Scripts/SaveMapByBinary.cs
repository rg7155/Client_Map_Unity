using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveMapByBinary : MonoBehaviour
{
    private BinaryWriter binaryWriter = null;
    public string strFileName;
    void WriteVector(Vector3 v)
    {
        binaryWriter.Write(v.x);
        binaryWriter.Write(v.y);
        binaryWriter.Write(v.z);
    }

    //�ٷ����� �� 1���� �ε��ϱ� ����
    void Start()
    {
        binaryWriter = new BinaryWriter(File.Open("Assets/Data/" + strFileName + ".bin", FileMode.Create));

        Transform[] allChildren = GetComponentsInChildren<Transform>();

        binaryWriter.Write(allChildren.Length-1);//�ڱ��ڽ� ����

        foreach (Transform child in allChildren)
        {
            // �ڱ� �ڽ��� ��쿣 ���� 
            // (���ӿ�����Ʈ���� �� �ٸ��ٰ� �������� �� ���ϴ� �ڵ�)
            if (child.name != transform.name)
            {
                //Debug.Log(string.Format(child.name + ": {0}, {1}, {2}", child.localEulerAngles.x, child.localEulerAngles.y, child.localEulerAngles.z));

                //if(child.childCount >= 1)
                //    WriteChildInfo(child);
                //else
                    WriteInfo(child);
            }
        }

        binaryWriter.Flush();
        binaryWriter.Close();

        //NameStreamWriter.Flush();
        //NameStreamWriter.Close();

        print("Model Text Write Completed");
    }


    void Update()
    {

    }

    void WriteInfo(Transform trans)
    {
        //ũ �� ��
        binaryWriter.Write(trans.name);
        WriteVector(trans.localScale);
        WriteVector(trans.localEulerAngles); // WriteVector(current.localRotation);
        WriteVector(trans.position);
    }

    void WriteChildInfo(Transform trans)
    {
        foreach (Transform child in trans)
        {
            WriteInfo(child);
        }
    }
}
