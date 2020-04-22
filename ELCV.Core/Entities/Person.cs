using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PicturePath { get; set; }
        public ICollection<Resume> Resumes { get; set; }
    }
}
