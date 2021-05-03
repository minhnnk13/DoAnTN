using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
    public int OrderId { get; set; }
    public int AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName{ get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
    public string PostOfficeCode { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool OrderStatus { get; set; }
    public string Note { get; set; }
    public string OrderProducts { get; set; }
    public DateTime CreatedDate { get; set; }

}