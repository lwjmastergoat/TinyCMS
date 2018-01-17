using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace TinyRepo.Models
{
    public class Articles
    {
        public int ID { get; set; }
        public string Headline { get; set; }
        [AllowHtml]
        public string Main { get; set; }
        public string Image { get; set; }
        public DateTime? Date { get; set; }
        public int? UserID { get; set; }

    }
}
