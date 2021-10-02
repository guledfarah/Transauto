using System.Collections.Generic;

namespace Transauto.Services.ProductAPI.Models.Dtos
{
    public class ResponseDto
    {
        #region Public Properties

        public string DisplayMessage { get; set; } = "";

        public List<string> ErrorMessages { get; set; }

        public bool IsSuccess { get; set; } = true;

        public object Result { get; set; }

        #endregion Public Properties
    }
}