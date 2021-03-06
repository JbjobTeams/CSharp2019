﻿using HttpClientCallJWTAPI.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientCallJWTAPI.Services
{
    public class LoginManager : BaseWebAPI<LoginResponseDTO>
    {
        public LoginManager()
            : base()
        {
            this.restURL = "/LoginShort";
            this.host = Constants.HostAPI;
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default(CancellationToken))
        {

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            // ---------------------------- 另外兩種建立 QueryString的方式
            //dic.Add(Global.getName(() => memberSignIn_QS.app), memberSignIn_QS.app);
            //dic.AddItem<string>(() => 查詢資料QueryString.strHospCode);
            //dic.Add("Price", SetMemberSignUpVM.Price.ToString());
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(loginRequestDTO));
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Post, cancellationToken);

            return mr;
        }
    }
}
