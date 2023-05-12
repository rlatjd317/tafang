using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class cundangdudang : MonoBehaviour
{
    public bingzhong_chuangjian putongbing;
    public bingzhong_chuangjian jianshi;
    public bingzhong_chuangjian gongjianshou;
    public bingzhong_chuangjian fashi;
    bingzhong_chuangjian bingzhong;
    public bool duqubingzhong;

    public tongguan_shuxing tongguan;
    public bool duqutongguan;

    public chengjiu chengjiu;
    public bool duquchengjiu;
    private void Start()
    {
        if (duqubingzhong)
        {
            bingzhongDudang(putongbing.name);
            bingzhongDudang(jianshi.name);
            bingzhongDudang(gongjianshou.name);
            bingzhongDudang(fashi.name);
        }
        
        if (duqutongguan)
        {
            tongguanDudang();
        }

        if (duquchengjiu)
        {
            chengjiuDudang();
        }
    }
    public void bingzhongCundang(string bingzhongname)
    {
        switch (bingzhongname)
        {
            case "putongbing":
                bingzhong = putongbing;
                break;
            case "jianshi":
                bingzhong = jianshi;
                break;
            case "gongjianshou":
                bingzhong = gongjianshou;
                break;
            case "fashi":
                bingzhong = fashi;
                break;
        }
        if (!Directory.Exists(Application.persistentDataPath + "/bingzhong"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/bingzhong");
        }
        BinaryFormatter bf = new BinaryFormatter();//转二进制
        FileStream wenjian = File.Create(Application.persistentDataPath + "/bingzhong/" + bingzhongname + ".jytd");
        var json = JsonUtility.ToJson(bingzhong);
        bf.Serialize(wenjian, json);
        wenjian.Close();
    }
    public void bingzhongDudang(string bingzhongname)
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/bingzhong/" + bingzhongname + ".jytd"))
        {
            FileStream wenjian = File.Open(
                Application.persistentDataPath + "/bingzhong/" + bingzhongname + ".jytd", FileMode.Open);

            switch (bingzhongname)
            {
                case "putongbing":
                    bingzhong = putongbing;
                    break;
                case "jianshi":
                    bingzhong = jianshi;
                    break;
                case "gongjianshou":
                    bingzhong = gongjianshou;
                    break;
                case "fashi":
                    bingzhong = fashi;
                    break;
            }
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(wenjian), bingzhong);
            wenjian.Close();
        }
    }
    public void tongguanCundang()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/tongguan"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/tongguan");
        }
        BinaryFormatter bf = new BinaryFormatter();//转二进制
        FileStream wenjian = File.Create(Application.persistentDataPath + "/tongguan/tongguan.jytd");
        var json = JsonUtility.ToJson(tongguan);
        bf.Serialize(wenjian, json);
        wenjian.Close();
    }
    public void tongguanDudang()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/tongguan/tongguan.jytd"))
        {
            FileStream wenjian = File.Open(
                Application.persistentDataPath + "/tongguan/tongguan.jytd", FileMode.Open);

            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(wenjian), tongguan);
            wenjian.Close();
        }
    }
    public void chengjiuCundang()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/chengjiu"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/chengjiu");
        }
        BinaryFormatter bf = new BinaryFormatter();//转二进制
        FileStream wenjian = File.Create(Application.persistentDataPath + "/chengjiu/chengjiu.jytd");
        var json = JsonUtility.ToJson(chengjiu);
        bf.Serialize(wenjian, json);
        wenjian.Close();
    }
    public void chengjiuDudang()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/chengjiu/chengjiu.jytd"))
        {
            FileStream wenjian = File.Open(
                Application.persistentDataPath + "/chengjiu/chengjiu.jytd", FileMode.Open);

            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(wenjian), chengjiu);
            wenjian.Close();
        }
    }
}

