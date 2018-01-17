using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyRepo.Models;
using DDMF;

namespace TinyRepo.Factories
{
    public class FactoryArticle : AutoFac<Articles>
    {
        public List<ArticleUser> GetAllJoin()
        {
            string SQL = "SELECT Articles.ID, Headline, Main, Image, Date, Username FROM Articles LEFT OUTER JOIN Users ON Users.ID = UserID ORDER BY Date DESC";

            return ExecuteSQL<ArticleUser>(SQL);
        }

        public ArticleUser GetJoin(int ID)
        {
            string SQL = "SELECT Articles.ID, Headline, Main, Image, Date, Username FROM Articles LEFT OUTER JOIN Users ON Users.ID = UserID WHERE Articles.ID =" + ID;

            return ExecuteSQL<ArticleUser>(SQL)[0];
        }


    }
}
