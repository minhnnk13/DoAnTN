using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace computer_store_API.Api
{
    public class NewssController:EntityController<News>
    {
        public IActionResult InsertFee(News news)
        {
            return Insert(news);
        }

        public IActionResult UpdateFee(News news, int id)
        {
            return Update(news, id);
        }
    }
}
