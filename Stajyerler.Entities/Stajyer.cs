using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stajyerler.Entities
{
    public class Stajyer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string University { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Major { get; set; }
        [StringLength(50)]
        public string Department { get; set; }
    }
}
