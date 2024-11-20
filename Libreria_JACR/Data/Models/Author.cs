using System;
using System.Collections.Generic;

namespace Libreria_JACR.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }


        // Propiedades de navegación

        public List<Book_Author> Book_Author { get; set; }
    }
}
