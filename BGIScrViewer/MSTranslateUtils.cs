using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Web;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Threading;
using BGIScrViewer.TranslatorService;

namespace MSTranslateUtils
{
    public class Translator
    {
        AdmAccessToken admToken;
        string headerValue, Id, Secret;
        DateTime tokenReceived;
        AdmAuthentication admAuth;
        public struct LangCodes
        {
            public const string
            Arabic = "ar",
            Bosnian_Latin = "bs-Latn",
            Bulgarian = "bg",
            Catalan = "ca",
            ChineseSimplified = "zh-CHS",
            ChineseTraditional = "zh-CHT",
            Croatian = "hr",
            Czech = "cs",
            Danish = "da",
            Dutch = "nl",
            English = "en",
            Estonian = "et",
            Finnish = "fi",
            French = "fr",
            German = "de",
            Greek = "el",
            Haitian_Creole = "ht",
            Hebrew = "he",
            Hindi = "hi",
            Hmong_Daw = "mww",
            Hungarian = "hu",
            Indonesian = "id",
            Italian = "it",
            Japanese = "ja",
            Kiswahili = "sw",
            Klingon = "tlh",
            Klingon_pIqaD = "tlh-Qaak",
            Korean = "ko",
            Latvian = "lv",
            Lithuanian = "lt",
            Malay = "ms",
            Maltese = "mt",
            Norwegian = "no",
            Persian = "fa",
            Polish = "pl",
            Portuguese = "pt",
            QueretaroOtomi = "otq",
            Romanian = "ro",
            Russian = "ru",
            Serbian_Cyrillic = "sr-Cyrl",
            Serbian_Latin = "sr-Latn",
            Slovak = "sk",
            Slovenian = "sl",
            Spanish = "es",
            Swedish = "sv",
            Thai = "th",
            Turkish = "tr",
            Ukrainian = "uk",
            Urdu = "ur",
            Vietnamese = "vi",
            Welsh = "cy",
            YucatecMaya = "yua";
        }


        public Translator(string clientId, string clientSecret)
        {
            //Get Client Id and Client Secret from https://datamarket.azure.com/developer/applications/
            //Refer obtaining AccessToken (http://msdn.microsoft.com/en-us/library/hh454950.aspx) 
            this.Id = clientId;
            this.Secret = clientSecret;
            admAuth = new AdmAuthentication(clientId, clientSecret);
            try
            {
                admToken = admAuth.GetAccessToken();
                tokenReceived = DateTime.Now;
                // Create a header with the access_token property of the returned token
                headerValue = "Bearer " + admToken.access_token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RenewToken()
        {
            admAuth.RenewAccessToken();
            admToken = admAuth.GetAccessToken();
            tokenReceived = DateTime.Now;
            headerValue = "Bearer " + admToken.access_token;
        }

        public static bool ChkLangCode(string LangCode)
        {
            string[] SupportedLangCode =
            {
                "ar","bs-Latn","bg","ca","zh-CHS","zh-CHT","hr","cs","da","nl","en","et","fi","fr",
                "de","el","ht","he","hi","mww","hu","id","it","ja","sw","tlh","tlh-Qaak","ko","lv",
                "lt","ms","mt","no","fa","pl","pt","otq","ro","ru","sr-Cyrl","sr-Latn","sk","sl",
                "es","sv","th","tr","uk","ur","vi","cy","yua"
            };
            if (SupportedLangCode.Contains(LangCode))
                return true;
            else
                return false;
        }

        public string[] TranslateArray(string[] ArrayToTranslate, string SrcLang, string DstLang, bool ForceRenewToken)
        {
            if (ForceRenewToken)
                RenewToken();
            else
            {
                admToken = admAuth.GetAccessToken();
                tokenReceived = DateTime.Now;
                headerValue = "Bearer " + admToken.access_token;
            }
            string authToken = this.headerValue;
            string[] TranslatedArray;
            // Add TranslatorService as a service reference, Address:http://api.microsofttranslator.com/V2/Soap.svc
            LanguageServiceClient client = new LanguageServiceClient();
            //Set Authorization header before sending the request
            HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
            httpRequestProperty.Method = "POST";
            httpRequestProperty.Headers.Add("Authorization", authToken);

            // Creates a block within which an OperationContext object is in scope.
            using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                TranslateOptions translateArrayOptions = new TranslateOptions(); // Use the default options
                //Keep appId parameter blank as we are sending access token in authorization header.
                TranslateArrayResponse[] translatedTexts = client.TranslateArray("", ArrayToTranslate, SrcLang, DstLang, translateArrayOptions);
                TranslatedArray = new string[translatedTexts.Length];
                for (int i = 0; i < translatedTexts.Length; i++)
                {
                    TranslatedArray[i] = translatedTexts[i].TranslatedText;
                }
            }
            return TranslatedArray;
        }

        public string Translate(string StrToTranslate, string SrcLang, string DstLang, bool ForceRenewToken)
        {
            if (ForceRenewToken)
                RenewToken();
            else
            {
                admToken = admAuth.GetAccessToken();
                tokenReceived = DateTime.Now;
                headerValue = "Bearer " + admToken.access_token;
            }
            string authToken = this.headerValue;
            string TranslatedStr;
            // Add TranslatorService as a service reference, Address:http://api.microsofttranslator.com/V2/Soap.svc
            LanguageServiceClient client = new LanguageServiceClient();
            //Set Authorization header before sending the request
            HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
            httpRequestProperty.Method = "POST";
            httpRequestProperty.Headers.Add("Authorization", authToken);

            // Creates a block within which an OperationContext object is in scope.
            using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                TranslatedStr = client.Translate("", StrToTranslate, SrcLang, DstLang, "text/plain", "general", "");
            }
            return TranslatedStr;
        }
    }
    [DataContract]
    public class AdmAccessToken
    {
        [DataMember]
        public string access_token { get; set; }
        [DataMember]
        public string token_type { get; set; }
        [DataMember]
        public string expires_in { get; set; }
        [DataMember]
        public string scope { get; set; }
    }
    public class AdmAuthentication
    {
        public static readonly string DatamarketAccessUri = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
        private string clientId;
        private string clientSecret;
        private string request;
        private AdmAccessToken token;
        private Timer accessTokenRenewer;
        //Access token expires every 10 minutes. Renew it every 9 minutes only.
        private const int RefreshTokenDuration = 9;
        public AdmAuthentication(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            //If clientid or client secret has special characters, encode before sending request
            this.request = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", HttpUtility.UrlEncode(clientId), HttpUtility.UrlEncode(clientSecret));
            this.token = HttpPost(DatamarketAccessUri, this.request);
            //renew the token every specfied minutes
            accessTokenRenewer = new Timer(new TimerCallback(OnTokenExpiredCallback), this, TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
        }
        public AdmAccessToken GetAccessToken()
        {
            return this.token;
        }
        public void RenewAccessToken()
        {
            AdmAccessToken newAccessToken = HttpPost(DatamarketAccessUri, this.request);
            //swap the new token with old one
            //Note: the swap is thread unsafe
            this.token = newAccessToken;
            System.Diagnostics.Debug.WriteLine(string.Format("Renewed token for user: {0} is: {1}", this.clientId, this.token.access_token));
        }
        private void OnTokenExpiredCallback(object stateInfo)
        {
            try
            {
                RenewAccessToken();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    accessTokenRenewer.Change(TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private AdmAccessToken HttpPost(string DatamarketAccessUri, string requestDetails)
        {
            //Prepare OAuth request 
            WebRequest webRequest = WebRequest.Create(DatamarketAccessUri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(requestDetails);
            webRequest.ContentLength = bytes.Length;
            using (Stream outputStream = webRequest.GetRequestStream())
            {
                outputStream.Write(bytes, 0, bytes.Length);
            }
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));
                //Get deserialized object from JSON stream
                AdmAccessToken token = (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());
                return token;
            }
        }
    }

}
