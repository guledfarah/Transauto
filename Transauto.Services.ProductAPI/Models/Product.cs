using System;
using System.ComponentModel.DataAnnotations;

namespace Transauto.Services.ProductAPI.Models
{
    public class Product
    {
        #region Public Properties

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 1000)]
        public double Price { get; set; }

        [Key]
        public int ProductId { get; set; }

        #endregion Public Properties
    }
}