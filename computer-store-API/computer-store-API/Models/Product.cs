using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public float ProductOldPrice { get; set; }
    public float ProductPrice { get; set; }
    public float ProductDiscount { get; set; }
    public string ProductDescription { get; set; }
    public string ProductGuarantee { get; set; }
    public string ProductPromotion { get; set; }
    public string ProductFeature { get; set; }
    public DateTime? CreatedDate { get; set; }
    public bool ProductStatus { get; set; }
    public int ProductCategoryId { get; set; }

}