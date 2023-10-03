using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gọi api lấy tt và lưu vào bộ nhớ
        Getsetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public async void Getsetting()
    {
        var email = "articles";
        HTTPRequestHelper helper = new HTTPRequestHelper();
        MockUserModel model = await helper.GetPositionFromAPI(email);
        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>" + model.positionX);
    }    
}
