using System;
using System.ComponentModel.DataAnnotations;

namespace GtaVMod.Data.Entities
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public long Cash { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }
    }
}
