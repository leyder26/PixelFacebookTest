﻿using System.Collections.Generic;

namespace PixelFacebook.HttpClientService.DtoObjets
{
    public class ApiFacebookDto
    {
        public List<Datum> data { get; set; }
    }

    public class Datum
    {
        public string event_name { get; set; }
        public string event_id { get; set; }
        public long event_time { get; set; }
        public User_Data user_data { get; set; }
        public Custom_Data custom_data { get; set; }
        public string event_source_url { get; set; }
        public string action_source { get; set; }
    }

    public class User_Data
    {
        //public string[] em = { "7b17fb0bd173f625b58636fb796407c22b3d16fc78302d79f0fd30c2fc2fc068" };
        //public string[] ph = { "15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225" };
        public string[] em = { "309a0a5c3e211326ae75ca18196d301a9bdbd1a882a4d2569511033da23f0abd" };
        public string[] ph = { "254aa248acb47dd654ca3ea53f48c2c26d641d23d7e2e93a1ec56258df7674c4", "6f4fcb9deaeadc8f9746ae76d97ce1239e98b404efe5da3ee0b7149740f89ad6" };
        public string client_ip_address = "123.123.123.123";
        public string client_user_agent = "$CLIENT_USER_AGENT";
        public string fbc = "fb.1.1554763741205.AbCdEfGhIjKlMnOpQrStUvWxYz1234567890";
        public string fbp = "fb.1.1558571054389.1098115397";
    }

    public class Custom_Data
    {
        public string monto { get; set; }
        public string idCredito { get; set; }
        public string currency { get; set; }
    }
}
