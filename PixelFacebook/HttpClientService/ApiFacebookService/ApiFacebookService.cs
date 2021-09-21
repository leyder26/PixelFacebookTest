using PixelFacebook.HttpClientService.DtoObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixelFacebook.HttpClientService.ApiFacebookService
{
    public class ApiFacebookService
    {
        private readonly HttpClientService _httpClient;
        private readonly string pixelId = "387608306145949";
        private readonly string accessToken = "EAAFXZAl0f0v8BAMkACIZAC94fUghcYOKt8tDLrvJ0nyBRgti9jWgtNKQTG7e3Qni3MrMACa91PPr4We4Hp423hmSqxPV82I3cWq75mCb6FvAQyUxUPudvq9NOwiVUFiqujyScRgsTnSuvJLsiFyKVwVhgQ6kamF76aBoICdtcMsQHgSFMPZAe36v9YAvCsZD";
        private readonly string urlApi = "https://graph.facebook.com/v11.0/";

        public ApiFacebookService()
        {
            _httpClient = new HttpClientService();
        }

        /// <summary>
        /// Petición POST para pixel de facebook
        /// <example>
        /// ejemplo:
        /// <code>                
        ///     string result = await _apiFB.PostPixelFB("11", "15000000", ApiFacebookService.EventName.Paso_8);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="idCredito"></param>
        /// <param name="monto"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public async Task<string> PostPixelFB(string idCredito, string monto, EventName eventName)
        {
            try
            {
                string data = GetDataJson(idCredito, monto, eventName);
                string url = $"{urlApi + pixelId}/events?access_token={accessToken}&data={data}&test_event_code=TEST86491"; //&data={data}&test_event_code=TEST86491

                return await _httpClient.PostAsync(url, "");

            }
            catch (Exception)
            {
                throw;
            }
        }

        #region methods
        public string GetDataJson(string idCredito, string monto, EventName eventName)
        {
            try
            {
                var model = new ApiFacebookDto();
                var data = new Datum();
                var custom = new Custom_Data();
                custom.idCredito = idCredito;
                custom.monto = monto;
                custom.currency = "usd";
                data.action_source = "website";
                data.event_source_url = "https://localhost:44304/Home/Paso8";
                data.event_name = eventName.ToString();
                data.event_id = eventName.ToString().Replace("_", "");

                data.event_time = DateTimeOffset.Now.ToUnixTimeSeconds();
                data.user_data = new User_Data();
                data.custom_data = custom;
                var list = new List<Datum>();
                list.Add(data);
                model.data = list;

                return _httpClient.SerializeObjet(model.data);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region enums
        public enum EventName
        {
            Paso_1 = 1,
            Paso_5 = 5,
            Paso_8 = 8,
            Solicitud_Enviada = 9

        }
        #endregion
    }
}
