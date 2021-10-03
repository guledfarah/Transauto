using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Transauto.Web.Models
{
    public class ProductDto
    {
        #region Public Properties

        [Required]
        [DisplayName("Product Category Name")]
        public string CategoryName { get; set; }

        [DisplayName("Product Description")]
        public string Description { get; set; }

        [DisplayName("Product Image")]
        public string ImageUrl { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Range(1, 1000)]
        public double Price { get; set; }

        public int ProductId { get; set; }

        #endregion Public Properties
    }
}