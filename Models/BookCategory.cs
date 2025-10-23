using Pop_Dan_Ioan_LAB2.Models;
using System;

public class BookCategory
{
    public int ID { get; set; }
    public int BookID { get; set; }
    public Book Book { get; set; }
    public int CategoryID { get; set; }
    public Category Category { get; set; }
}