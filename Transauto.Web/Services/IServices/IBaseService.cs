using System;
using System.Threading.Tasks;
using Transauto.Web.Models;

namespace Transauto.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        #region Public Properties

        ResponseDto responseModel { get; set; }

        #endregion Public Properties

        #region Public Methods

        Task<T> SendAsync<T>(ApiRequest apiRequest);

        #endregion Public Methods
    }
}