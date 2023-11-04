#nullable disable

using CRUDOperations.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CRUDOperations.Models.CrudModels
{
    [Table(Constants.Db_Product_Table, Schema = Constants.Db_Product_Schema)]
    public class Product
    {
        /// <summary>
        /// The unique identifier of the product.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName(Constants.JsonKey_Connecti_Id), Column(Constants.Db_Connecti_Id)]
        public int Id { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        [JsonPropertyName(Constants.JsonKey_Connecti_Name), Column(Constants.Db_Connecti_Name)]
        public string ProductName { get; set; }

        /// <summary>
        /// The price of the product.
        /// </summary>
        [JsonPropertyName(Constants.JsonKey_Connecti_Price), Column(Constants.Db_Connecti_Price)]
        public int Price { get; set; }

        /// <summary>
        /// Additional details about the product.
        /// </summary>
        [JsonPropertyName(Constants.JsonKey_Connecti_ProductDetails), Column(Constants.Db_Connecti_ProductDetails)]
        public string ProductDetails { get; set; }
    }
}
