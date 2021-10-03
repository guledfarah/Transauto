using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Transauto.Web.Models;
using Transauto.Web.Services.IServices;

namespace Transauto.Web.Services
{
    public class BaseService : IBaseService
    {
        #region Private Fields

        private readonly string MediaType = "application/json";

        #endregion Private Fields

        #region Public Properties

        public IHttpClientFactory _httpClient { get; set; }

        public ResponseDto responseModel { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            responseModel = new ResponseDto();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("TransautoAPI");

                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", MediaType);
                message.RequestUri = new Uri(apiRequest.Url);

                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data is not null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(apiRequest.Data)
                        , Encoding.UTF8
                        , MediaType);
                }

                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;

                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = await client.SendAsync(message);
                var apiResponseContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiResponseContent);
                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var ErrorResponse = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false
                };
                var result = JsonConvert.SerializeObject(ErrorResponse);
                var apiErrorResponseDto = JsonConvert.DeserializeObject<T>(result);
                return apiErrorResponseDto;
            }
        }

        #endregion Public Methods
    }
}