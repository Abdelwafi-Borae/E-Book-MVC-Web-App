using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Book_Model;

	public class Product
	{
		public int Id { get; set; }
    [Required]
    public string Tital { get; set; }
    [Required]
    
    public string Description { get; set; }
    [Required]
    public string ISBN { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    [Range(1,10000)]
    public Double ListPrice { get; set; }
    [Required]
    [Range(1, 10000)]
    public Double  Price { get; set; }
    [Required]
    [Range(1, 10000)]
    public Double Price50 { get; set; }
    [Required]
    [Range(1, 10000)]
    public Double  Price1000 { get; set; }
    [Required]
    [ValidateNever]
    public string ImageUrl { get; set; }
    [Required]
    public int CatogeryId { get; set; }
    [ForeignKey("CatogeryId")]
    [ValidateNever]
    public Catogery Catogery { get; set; }
    [Required]
    public int Cover_TypeId { get; set; }
    [ForeignKey("Cover_TypeId")]
    [ValidateNever]
    public Cover_type Cover_Type { get; set; }
}