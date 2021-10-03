namespace Transauto.Web
{
    public static class SD
    {
        #region Public Enums

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        #endregion Public Enums

        #region Public Properties

        public static string ProductAPIBase { get; set; }

        #endregion Public Properties
    }
}