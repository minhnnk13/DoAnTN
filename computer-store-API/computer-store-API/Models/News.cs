using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for News
/// </summary>
public class News
{
    public int NewsId { get; set; }
    public string NewsTitle { get; set; }
    public string NewsDescription { get; set; }
    public string NewsContent { get; set; }
    public string NewsImage { get; set; }
    public bool NewsHighlight { get; set; }
    public DateTime CreatedDate { get; set; }

}

