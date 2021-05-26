using System;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithASPNETUdemy.Model.Base;

namespace RestWithASPNETUdemy.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }
        
        [Column("launch_date")]
        public DateTime LaunchDate {get;set;} 
        
        [Column("price")]
        public decimal Price {get;set;} 
        
        [Column("title")]
        public string Title {get;set;}      
    }
}