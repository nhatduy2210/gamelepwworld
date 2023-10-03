using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;
public class HTTPRequestHelper : MonoBehaviour
{
    private string baseUrl = "https://fpoly-hcm.herokuapp.com/api/";

    //get
    public async Task<ListPostModel> GetAPI(string url)
    {
        try
        {

            url = baseUrl + url;

            //sewtup header authorization bearer token

            using var www = UnityWebRequest.Get(url);
            www.SetRequestHeader("Content-Type", "application/json");
           // www.SetRequestHeader("Authorization", "application/json");
            var operation = www.SendWebRequest();
            while (!operation.isDone) await Task.Yield();
            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);
            var result = www.downloadHandler.text;
            var model = ListPostModel.CreateResponseFromJSON(result);
            return model;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return default;
        }
    }



    //post
    public async Task<bool> PostAPI(string url, WWWForm form)
    {
        try
        {

            url = baseUrl + url;


            using var www = UnityWebRequest.Post(url, form);
            var operation = www.SendWebRequest();
            while (!operation.isDone) await Task.Yield();
            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);
            var result = www.downloadHandler.text;
            var model = ReponseModel.CreateFromJSON(result);
            return model.error;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return default;
        }
    }



//update position to api
    public async Task<bool> PutPositionToAPI(string id, MockUserModel mockUserModel)
{
    try
    {
        string json = JsonUtility.ToJson(mockUserModel);
        string url = "https://64d3c1a467b2662bf3dcae30.mockapi.io/users/" + id;
        using var www = UnityWebRequest.Put(url, json);
        var operation = www.SendWebRequest();
        while (!operation.isDone) await Task.Yield();
        if (www.result != UnityWebRequest.Result.Success)
            Debug.Log(www.error);
        var result = www.downloadHandler.text;

        var model = ReponseModel.CreateFromJSON(result);
        return model.error;
    }
    catch (Exception e)
    {
        Debug.Log(e.Message);
        return default;
    }
}

    public async Task<MockUserModel> GetPositionFromAPI(string email)
{
    try
    {
        string url = "https://64d3c1a467b2662bf3dcae30.mockapi.io/users/";

        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");
        var operation = www.SendWebRequest();
        while (!operation.isDone) await Task.Yield();
        if (www.result != UnityWebRequest.Result.Success)
            Debug.Log(www.error);
        var result = www.downloadHandler.text;
        Debug.Log("result+++++++++++++++" + result);
        var list = JsonUtility.FromJson<ListMockUserModel>
            ("{\"result\":" + result.ToString() + "}");
        var model = new MockUserModel();
        for (var i = 0; i < list.result.Length; i++)
        {
            var each = list.result[i];
            if (each.email.Equals(email))
            {
                model = each;
                break;
            }
        }

        return model;
    }
    catch (Exception e)
    {
        Debug.Log(e.Message);
        return default;
    }
}

}


        [System.Serializable]
public class ListMockUserModel
{
    public MockUserModel[] result;
}

[System.Serializable]
public class MockUserModel
{
    public int id;
    public string email;
    public int positionX, positionY, positionZ;


}



[System.Serializable]
public class ListPostModel : ReponseModel
{
    public List<PostModel> data;

   
    public static ListPostModel CreateResponseFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ListPostModel>(jsonString);
    }
}

[System.Serializable]
//posts reponse
public class PostModel
{
    public string id;
    public string title;
    public string content;
}

[System.Serializable]


//model respon
public class ReponseModel
{
    public bool error;
    public int statusCode;


    //chuyển string thanh object
    public static ReponseModel CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ReponseModel>(jsonString);
    }

}
