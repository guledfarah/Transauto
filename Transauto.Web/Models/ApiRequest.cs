using static Transauto.Web.SD;

namespace Transauto.Web.Models
{
    public class ApiRequest
    {
        #region Public Properties

        public string AccessToken { get; set; }

        public ApiType ApiType { get; set; } = ApiType.GET;

        public object Data { get; set; }

        public string Url { get; set; }

        #endregion Public Properties
    }
}