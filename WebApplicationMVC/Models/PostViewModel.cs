using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMVC.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UrlPhoto { get; set; }
        public List<string> Comentarios { get; set; } = new List<string>();
    }
}
