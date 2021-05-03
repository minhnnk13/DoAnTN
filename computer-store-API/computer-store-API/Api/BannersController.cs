using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace computer_store_API.Api
{
    public class BannersController : EntityController<Banner>
    {
        public IActionResult InsertBanner(Banner banner)
        {
            return Insert(banner);
        }

        public IActionResult UpdateBanner(Banner banner, int id)
        {
            return Update(banner, id);
        }
    }
}
