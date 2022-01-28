using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveMapByBinary : MonoBehaviour
{
    private BinaryWriter binaryWriter = null;

    void WriteVector(Vector3 v)
    {
        binaryWriter.Write(v.x);
        binaryWriter.Write(v.y);
        binaryWriter.Write(v.z);
    }

    //�ٷ����� �� 1���� �ε��ϱ� ����
    void Start()
    {
        //StreamWriter NameStreamWriter = new StreamWriter("Assets/Data/MapObjName.txt");
        binaryWriter = new BinaryWriter(File.Open("Assets/Data/MapTransform.bin", FileMode.Create));

        Transform[] allChildren = GetComponentsInChildren<Transform>();

        binaryWriter.Write(allChildren.Length-1);//�ڱ��ڽ� ����

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
                binaryWriter.Write(child.name);
                WriteVector(child.localScale);
                WriteVector(child.localEulerAngles); // WriteVector(current.localRotation);
                WriteVector(child.position);
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
}
