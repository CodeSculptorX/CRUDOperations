namespace CRUDOperations.Common
{
    /// <summary>
    /// For Hiding details of string and if here you change it will change everywhere.
    /// </summary>
    public class Constants
    {
        #region Database Connectionstring Key
        public const string Db_Connection_String = "DefaultConnection";
        #endregion

        #region Database Key
        public const string Db_Product_Table = "Product";
        public const string Db_Product_Schema = "witcher";
        public const string Db_Connecti_Id = "id";
        public const string Db_Connecti_Name = "productname";
        public const string Db_Connecti_Price = "price";
        public const string Db_Connecti_ProductDetails = "productdetails";
        #endregion

        #region JsonKey
        public const string JsonKey_Connecti_Id = "id";
        public const string JsonKey_Connecti_Name = "productname";
        public const string JsonKey_Connecti_Price = "price";
        public const string JsonKey_Connecti_ProductDetails = "productdetails";
        #endregion

        #region Exception Message
        public const string Exception_Message_ProductNotFound = "Product is not exists.";
        #endregion

    }
}
