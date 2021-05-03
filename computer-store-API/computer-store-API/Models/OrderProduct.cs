using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderProduct
/// </summary>
public class OrderProduct
{
    public int OrderProductId { get; set; }
    public string ProductName { get; set; }
    public int OrderId { get; set; }
    public int Amount { get; set; }
}